using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using TLD.Model;
using TLD.Persistency;
using TLD.View.Properties;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using TLD.Model.Detection;
using TLD.View.Learning;
using TLD.Model.Learning;
using TLD.Model.Integration;
using System.Threading;
using TLD.View.App;

namespace TLD.View
{
    public partial class frmMain : Form
    {
        private Settings _preferences;
        private bool _tldLocked;

        private int _frameWidth;
        private int _frameHeight;
        private Capture _capture;
        private bool _captureInProgress;
        private Image _currentImage;
        private Image _previousImage;

        private Stopwatch _fpsStopwatch;
        private Stopwatch _frameToFrameStopwatch;
        private bool _mouseDown;
        private bool _drawRectangle;
        private Rectangle _tldRectangle;
        public bool tldRunning;
        private Rectangle _rectangle;
        private Pen _pen;
        private Image<Gray, byte> _currentFrame;
        private Image<Bgr, byte> _currentBgrFrame;
        private MedianFlowTracker _tracker;
        public ITld tld;
        private bool _tldInitialized;
        private string _configurationFolder;
        private string _tldPath;
        private string _tldPathDataContract;
        private Stopwatch _tldStopwatch;
        private IBoundingBox _currentBb;
        private Brush _reliablePointColor = Brushes.LawnGreen;
        private Brush _validPointColor = Brushes.Black;
        private IDetector _detector;
        private IFrmSpecificDetector _frmDetectorSpecific;
        private IFrmSpecificLearner _frmLearnerSpecific;
        private long _tldTimeSum = 0;
        private int _tldAverageTimeCount = 20;
        private int _tldTimeCount = 0;
        private EventHandler _processFrameEventHandler;
        private string _videosFolder;
        private VideoFile _videoFile;
        private bool _tldSessionReplayRunning;
        private Camera _camera;
        private int _currentCamera;
        private OpenFileDialog OVF;
        private frmObjectModel _frmObjectModel;
        private frmFrameToFrame _frmFrameToFrame;
        private bool _frmFrameToFrame_IsOpen;
        private bool _frameChanged;

        public frmMain()
        {
            InitializeComponent();
            KeyPreview = true;
            WindowState = FormWindowState.Maximized;

            _preferences = Properties.Settings.Default;
            _fpsStopwatch = new Stopwatch();
            _frameToFrameStopwatch = new Stopwatch();

            // get rid of flickering
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, _pnlVideo, new object[] { true });

            _mouseDown = false;
            _drawRectangle = false;
            _pen = new Pen(Color.Yellow, 4);
            tldRunning = false;

            _configurationFolder = @"..\..\Configuration";
            _tldPath = Path.Combine(_configurationFolder, "tld.xml");
            _tldPathDataContract = Path.Combine(_configurationFolder, "tld_dataContract.xml");
            _tldStopwatch = new Stopwatch();

            InstantiateTLD();
            SetReferences();

            LoadDetectorPanel(new frmDetector(tld.Detector as Detector, this));
            LoadLearnerPanel(new frmLearner(tld.Learner as Learner, this));
            _frmObjectModel = (_frmLearnerSpecific as frmLearner).FrmObjectModel;

            _tldLocked = true;
            DisableOnValueChangedEvents();
            FillFormWithTldConfiguration();
            FillFormWithUserPreferences();
            EnableOnValueChangedEvents();
            _tldLocked = false;

            TldDrawingInfo.TrackerGroupBox = _gbxTracking;
            TldDrawingInfo.DetectorGroupBox = _gbxDetection;

            _processFrameEventHandler = new EventHandler(ProcessFrame);
            _camera = new Camera();
            _camera.OpenAll();
            _currentCamera = 0;
            _videosFolder = @"..\..\Videos";
            OVF = new OpenFileDialog();
            OVF.InitialDirectory = Path.GetFullPath(_videosFolder);
            try
            {
                OpenVideoFile(Path.Combine(OVF.InitialDirectory, _preferences.VideoFileName));
            }
            catch (Exception ex)
            {
                ShowExceptionRecursive(ex);
            }
            _tldSessionReplayRunning = false;
            VideoMode.Current = _preferences.VideoMode;

            _frmFrameToFrame = new frmFrameToFrame(this);
            _frmFrameToFrame.FormClosing += _frmFrameToFrame_FormClosing;
            FillFormWithGeneralVideoInfo();
        }

        private void OpenFrameToFrameView()
        {
            _frmFrameToFrame.WindowState = FormWindowState.Maximized;
            _frmFrameToFrame.Show();
        }

        void _frmFrameToFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            _frmFrameToFrame.Hide();
            e.Cancel = true;
        }

        private void OpenVideoFile(string path)
        {
            if (_videoFile != null)
            {
                _videoFile.Close();
            }
            _videoFile = new VideoFile(path, new Size(640, 480));
            _tbxVideoFilePath.Text = path;

            TldSessionPersistor.TryLoad(_videoFile);
            GroundTruthPersistor.TryLoad(_videoFile);
            GroundTruthMode.Active = false;
            GroundTruthMode.DrawRectangle = false;
            GroundTruthMode.Rectangle = Rectangle.Empty;
        }

        private void OpenAndShowVideoFile(string path)
        {
            OpenVideoFile(path);
            _cbxVideoMode.SelectedItem = VideoMode.File;
            UpdateVideoFileCapture();
        }

        private void FillFormWithGeneralVideoInfo()
        {
            _frameWidth = _preferences.FrameWidth;
            _frameHeight = _preferences.FrameHeight;
            
            Utils.NudSetValueInt(_nudFrameWidth, _frameWidth);
            Utils.NudSetValueInt(_nudFrameHeight, _frameHeight);

            _cbxVideoMode.Items.Add(VideoMode.Camera);
            _cbxVideoMode.Items.Add(VideoMode.File);
            _cbxVideoMode.SelectedItem = VideoMode.Current;
        }

        private void DisableOnValueChangedEvents()
        {
            // video
            _nudFrameWidth.ValueChanged -= _nudFrameWidth_ValueChanged;
            _nudFrameHeight.ValueChanged -= _nudFrameHeight_ValueChanged;

            // tracker
            _cbxUseTracker.CheckedChanged -= _cbxUseTracker_CheckedChanged;
            _cbxEnableTrackerFailure.CheckedChanged -= _cbxEnableTrackerFailure_CheckedChanged;

            // learner
            _cbxUseLearner.CheckedChanged -= _cbxUseLearner_CheckedChanged;

            //detector
            _cbxUseDetector.CheckedChanged -= _cbxUseDetector_CheckedChanged;
        }

        private void EnableOnValueChangedEvents()
        {
            // video
            _nudFrameWidth.ValueChanged += _nudFrameWidth_ValueChanged;
            _nudFrameHeight.ValueChanged += _nudFrameHeight_ValueChanged;

            // tracker
            _cbxUseTracker.CheckedChanged += _cbxUseTracker_CheckedChanged;
            _cbxEnableTrackerFailure.CheckedChanged += _cbxEnableTrackerFailure_CheckedChanged;

            // learner
            _cbxUseLearner.CheckedChanged += _cbxUseLearner_CheckedChanged;

            //detector
            _cbxUseDetector.CheckedChanged += _cbxUseDetector_CheckedChanged;
        }

        /// <summary>
        /// Fills this form's detection container with detector-specific controls.
        /// </summary>
        private void LoadDetectorPanel(IFrmSpecificDetector detectorForm)
        {
            _frmDetectorSpecific = detectorForm;
            _gbxDetectionSpecific.Controls.Clear();
            _gbxDetectionSpecific.Controls.Add(_frmDetectorSpecific.Panel);
        }

        /// <summary>
        /// Fills this form's learner container with learner-specific controls.
        /// </summary>
        private void LoadLearnerPanel(IFrmSpecificLearner learnerForm)
        {
            _frmLearnerSpecific = learnerForm;
            _gbxLearningSpecific.Controls.Clear();
            _gbxLearningSpecific.Controls.Add(_frmLearnerSpecific.Panel);
        }

        private void SetReferences()
        {
            _tracker = tld.Tracker as MedianFlowTracker;
            _detector = tld.Detector;
        }

        /// <summary>
        /// Fills form controls with tld configuration data.
        /// Value changed event handlers are called on every control that has them.
        /// </summary>
        private void FillFormWithTldConfiguration()
        {
            // tracker

            //      tracker 'enable failure' property
            _cbxEnableTrackerFailure.Checked = tld.Tracker.FailureEnabled;

            //      tracker bb
            MedianFlowTrackerBoundingBox bb = GetTrackerBb();

            //          tracker bb grid size
            Utils.NudSetValueInt(_nudGridWidth, bb.GridSize.Width);
            Utils.NudSetValueInt(_nudGridHeight, bb.GridSize.Height);

            //          tracker bb grid padding
            Utils.NudSetValueFloat(_nudGridPaddingWidth, bb.GridPadding.Width);
            Utils.NudSetValueFloat(_nudGridPaddingHeight, bb.GridPadding.Height);

            //      Lucas-Kanade tracker
            LucasKanadeTracker lk = GetLkTracker();

            //          Lucas-Kanade tracker window size
            Utils.NudSetValueInt(_nudLkWindowWidth, lk.WindowSize.Width);
            Utils.NudSetValueInt(_nudLkWindowHeight, lk.WindowSize.Height);

            //          Lucas-Kanade tracker levels
            Utils.NudSetValueInt(_nudLkLevels, lk.Levels);

            //          Lucas-Kanade tracker termination criteria
            Utils.NudSetValueDouble(_nudLkEpsilon, lk.Epsilon);
            Utils.NudSetValueInt(_nudLkMaxIterations, lk.MaxIterations);

            // tracker NCC patch size
            Utils.NudSetValueInt(_nudNccPatchWidth, _tracker.NccPatchSize.Width);
            Utils.NudSetValueInt(_nudNccPatchHeight, _tracker.NccPatchSize.Height);

            // tracker MAD treshold
            Utils.NudSetValueFloat(_nudMadTreshold, _tracker.MadTreshold);
        }

        /// <summary>
        /// Fills form controls according to user preferences.
        /// Typical controls are the ones that enable/disable
        /// the drawing of certain elements.
        /// </summary>
        private void FillFormWithUserPreferences()
        {
            // tracking
            _cbxUseTracker.Checked = _preferences.UseTracker;
            (tld as Tld).UseTracker = _cbxUseTracker.Checked;
            _cbxShowTrackerObject.Checked = _preferences.ShowTrackerObject;
            _cbxShowGrid.Checked = _preferences.ShowMedianFlowTrackerGrid;
            _cbxShowValidTrackingPoints.Checked = _preferences.ShowMedianFlowTrackerValidPoints;
            _cbxShowReliableTrackingPoints.Checked = _preferences.ShowMedianFlowTrackerReliablePoints;

            // learning
            _cbxUseLearner.Checked = _preferences.UseLearner;
            (tld as Tld).UseLearner = _cbxUseLearner.Checked;

            // detection
            _cbxUseDetector.Checked = _preferences.UseDetector;
            (tld as Tld).UseDetector = _cbxUseDetector.Checked;
            _cbxShowDetectorObjects.Checked = _preferences.ShowDetectorObjects;
        }

        private MedianFlowTrackerBoundingBox GetTrackerBb()
        {
            return _tracker.BoundingBox as MedianFlowTrackerBoundingBox;
        }

        private void SaveUserPreferences()
        {
            // video
            _preferences.FrameWidth = _frameWidth;
            _preferences.FrameHeight = _frameHeight;
            _preferences.VideoMode = VideoMode.Current;
            _preferences.VideoFileName = Path.GetFileName(_videoFile.Path);

            // tracking
            _preferences.UseTracker = _cbxUseTracker.Checked;
            _preferences.ShowTrackerObject = _cbxShowTrackerObject.Checked;
            _preferences.ShowMedianFlowTrackerGrid = _cbxShowGrid.Checked;
            _preferences.ShowMedianFlowTrackerValidPoints = _cbxShowValidTrackingPoints.Checked;
            _preferences.ShowMedianFlowTrackerReliablePoints = _cbxShowReliableTrackingPoints.Checked;

            // learning
            _preferences.UseLearner = _cbxUseLearner.Checked;

            // detection
            _preferences.UseDetector = _cbxUseDetector.Checked;
            _preferences.ShowDetectorObjects = _cbxShowDetectorObjects.Checked;

            _preferences.Save();
        }

        private void _nudFrameWidth_ValueChanged(object sender, EventArgs e)
        {
            tldRunning = false;
            _frameWidth = Utils.NudGetValueInt(_nudFrameWidth);
        }

        private void _nudFrameHeight_ValueChanged(object sender, EventArgs e)
        {
            tldRunning = false;
            _frameHeight = Utils.NudGetValueInt(_nudFrameHeight);
        }

        private delegate void DisplayImageDelegate(Bitmap image);
        private void DisplayImage(Bitmap image)
        {
            /*
            if (_pnlVideo.InvokeRequired)
            {
                try
                {
                    DisplayImageDelegate did = new DisplayImageDelegate(DisplayImage);
                    this.BeginInvoke(did, new object[] { image });
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
            else
            */
            {
                _previousImage = _currentImage;
                _currentImage = image;
                _currentFrame = _currentBgrFrame.Convert<Gray, byte>();

                OnFrameChanged();
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            if (VideoMode.Current == VideoMode.File)
            {
                _currentBgrFrame = _capture.QueryFrame();
                if (_currentBgrFrame == null)
                {
                    StopTld();
                    StopTldSessionReplay();
                    StopCapture();
                    return;
                }
            }
            else if (VideoMode.Current == VideoMode.Camera)
            {
                _currentBgrFrame = _capture.QueryFrame();
            }
            
            _currentBgrFrame = _currentBgrFrame.Resize(_frameWidth, _frameHeight, INTER.CV_INTER_LINEAR);

            DisplayImage(_currentBgrFrame.ToBitmap());
        }

        private void StopTldSessionReplay()
        {
            _tldSessionReplayRunning = false;
        }

        private void _btnStartPause_Click(object sender, EventArgs e)
        {
            ToggleVideo();
        }

        private void _btnStopVideo_Click(object sender, EventArgs e)
        {
            StopCapture();
        }

        private void _btnPrevFrame_Click(object sender, EventArgs e)
        {
            if (VideoMode.Current == VideoMode.File)
            {
                PauseCapture();
                if (_videoFile.CurrentFrame >= 1)
                {
                    _videoFile.NextFrame = _videoFile.CurrentFrame - 1;
                    ProcessFrame(null, null);
                }
            }
        }

        private void _btnNextFrame_Click(object sender, EventArgs e)
        {
            PauseCapture();
            ProcessFrame(null, null);
        }

        private void ShowVideoFrame(int frame)
        {
            _videoFile.CurrentFrame = frame;
            ProcessFrame(null, null);
        }

        private void ToggleVideo()
        {
            if (!_captureInProgress)
            {
                StartCapture();
            }
            else
            {
                PauseCapture();
            }
        }

        private void StartCapture()
        {
            try
            {
                if (VideoMode.Current == VideoMode.Camera)
                {
                    _capture = _camera.Captures[_currentCamera];
                }
                else if (VideoMode.Current == VideoMode.File)
                {
                    _capture = _videoFile.Capture;
                }
            }
            catch (Exception ex)
            {
                ShowExceptionRecursive(ex);
                return;
            }

            if (!_captureInProgress)
            {
                Application.Idle += _processFrameEventHandler;
                _captureInProgress = true;
                _btnStartPauseVideo.Text = "Pause";
            }
        }

        private void StopCapture()
        {
            StopTld();

            if (_captureInProgress)
            {
                Application.Idle -= _processFrameEventHandler;
                _captureInProgress = false;
                _btnStartPauseVideo.Text = "Start";
            }
            
            if (VideoMode.Current == VideoMode.File)
            {
                ShowFirstVideoFrame();
                if (_videoFile.SessionComplete)
                {
                    InitializeSessionObjectModel();
                }
            }
        }

        private void PauseCapture()
        {
            if (_captureInProgress)
            {
                Application.Idle -= _processFrameEventHandler;
                _captureInProgress = false;
                _btnStartPauseVideo.Text = "Start";
            }
        }

        private void ShowExceptionRecursive(Exception ex)
        {
            while (ex != null)
            {
                string info = "";
                info += "**Data**\n" + ex.Data;
                info += "\n\n";
                info += "**Help Link**\n" + ex.HelpLink;
                info += "\n\n";
                info += "**Inner Exception**\n" + ex.InnerException;
                info += "\n\n";
                info += "**Message**\n" + ex.Message;
                info += "\n\n";
                info += "**Source**\n" + ex.Source;
                info += "\n\n";
                info += "**Stack Trace**\n" + ex.StackTrace;
                info += "\n\n";
                info += "**Target Site**\n" + ex.TargetSite;
                MessageBox.Show(info);
                ex = ex.InnerException;
            }
        }

        private void ShowFirstVideoFrame()
        {
            _videoFile.RewindToBeginning();
            ProcessFrame(null, null);
        }

        private void pbxCapture_Paint(object sender, PaintEventArgs e)
        {
            // disable too fast video playback
            if (VideoMode.Current == VideoMode.File && _frameChanged)
            {
                _frameChanged = false;
                if (_cbxVideoRealTime.Checked)
                {
                    _frameToFrameStopwatch.Stop();
                    int sleepTime = (int)Math.Round(_videoFile.FrameDelay - _frameToFrameStopwatch.ElapsedMilliseconds);
                    if (sleepTime > 0)
                    {
                        Thread.Sleep(sleepTime);
                    }
                }

                _frameToFrameStopwatch.Stop();
                _frameToFrameStopwatch.Reset();
                _frameToFrameStopwatch.Start();
            }

            if (_currentImage != null)
            {
                _fpsStopwatch.Stop();
                if (_fpsStopwatch.ElapsedMilliseconds != 0)
                {
                    int fps = (int)(1000.0 / _fpsStopwatch.ElapsedMilliseconds);
                    _lblVideoFps.Text = fps.ToString();
                }
                _fpsStopwatch.Reset();
                _fpsStopwatch.Start();

                e.Graphics.DrawImage(_currentImage, new Point(0, 0));

                if (VideoMode.Current == VideoMode.File)
                {
                    if (_videoFile.CurrentFrame == 0 && _videoFile.GroundTruth.ContainsKey(0))
                    {
                        IBoundingBox bb = _videoFile.GroundTruth[0];
                        if (bb != null)
                        {
                            DrawingService.DrawBoundingBox(e, bb, _pen);
                        }
                    }

                    if (_cbxDrawGroundTruth.Checked)
                    {
                        if (GroundTruthMode.DrawRectangle && !_captureInProgress)
                        {
                            e.Graphics.DrawRectangle(TldDrawingInfo.GroundTruthSessionPen, GroundTruthMode.Rectangle);
                        }

                        int frame = _videoFile.CurrentFrame;
                        Dictionary<int, IBoundingBox> GT = _videoFile.GroundTruth;
                        if (GT.ContainsKey(frame))
                        {
                            if (GT[frame] != null)
                            {
                                DrawingService.DrawBoundingBox(e, GT[frame], TldDrawingInfo.GroundTruthPen);

                            }

                        }
                    }
                }

                if (tldRunning)
                {
                    _frmDetectorSpecific.Draw(e);

                    if ((tld as Tld).UseTracker && !tld.Tracker.Failed)
                    {
                        if (_cbxShowTrackerObject.Checked)
                        {
                            DrawBoundingBox(e, GetTrackerBb(), TldDrawingInfo.TrackerOutputPen);
                        }
                        if (_cbxShowGrid.Checked)
                        {
                            DrawingService.DrawPoints(e, GetTrackerBb().GetGridPoints(), TldDrawingInfo.TrackerGridBrush, TldDrawingInfo.TrackerGridPointSize);
                        }
                        if (_cbxShowValidTrackingPoints.Checked)
                        {
                            if (_tracker.ValidShifts != null)
                            {
                                PointF[] points = new PointF[_tracker.ValidShifts.Length];
                                for (int i = 0; i < points.Length; i++)
                                {
                                    points[i] = _tracker.ValidShifts[i].Forward;
                                }
                                DrawingService.DrawPoints(e, points, TldDrawingInfo.TrackerValidPointBrush, TldDrawingInfo.TrackerValidPointSize);
                            }
                        }
                        if (_cbxShowReliableTrackingPoints.Checked)
                        {
                            if (_tracker.ReliableShifts != null)
                            {
                                PointF[] points = new PointF[_tracker.ReliableShifts.Length];
                                for (int i = 0; i < points.Length; i++)
                                {
                                    points[i] = _tracker.ReliableShifts[i].Forward;
                                }
                                DrawingService.DrawPoints(e, points, TldDrawingInfo.TrackerReliablePointBrush, TldDrawingInfo.TrackerReliablePointSize);
                            }
                        }
                    }

                    if ((tld as Tld).UseDetector)
                    {
                        if (_cbxShowDetectorObjects.Checked)
                        {
                            foreach (IBoundingBox bb in tld.Detector.Detections)
                            {
                                DrawBoundingBox(e, bb, TldDrawingInfo.DetectorOutputPen);
                            }
                        }
                    }

                    if (_currentBb != null && _cbxShowTldOutput.Checked)
                    {
                        DrawBoundingBox(e, _currentBb, _pen);
                    }
                }
                else if (_tldSessionReplayRunning)
                {
                    if (_currentBb != null)
                    {
                        DrawBoundingBox(e, _currentBb, _pen);
                    }
                }

                if (_drawRectangle)
                {
                    e.Graphics.DrawRectangle(_pen, _rectangle);
                }
            }
        }

        private List<IBoundingBox> GetDetectorBbs()
        {
            return tld.Detector.Detections;
        }

        private void DrawBoundingBox(PaintEventArgs e, IBoundingBox bb, Pen pen)
        {
            Rectangle rect = Rectangle.Round(bb.GetRectangle());
            e.Graphics.DrawRectangle(pen, rect);
        }

        private void DrawValidTrackingPoints(PaintEventArgs e)
        {
            foreach (Shift shift in _tracker.ValidShifts)
            {
                PointF point = shift.Forward;
                e.Graphics.FillEllipse(_validPointColor, point.X - 2, point.Y - 2, 4, 4);
            }
        }

        private void DrawReliableTrackingPoints(PaintEventArgs e)
        {
            foreach (Shift shift in _tracker.ReliableShifts)
            {
                PointF point = shift.Forward;
                e.Graphics.FillEllipse(_reliablePointColor, point.X - 2, point.Y - 2, 4, 4);
            }
        }

        private void UpdateTldTime(long milliseconds)
        {
            _lblTldTime.Text = milliseconds.ToString() + " ms";

            UpdateTldAverageTime(milliseconds);
        }

        private void UpdateTldAverageTime(long milliseconds)
        {
            _tldTimeSum += milliseconds;
            _tldTimeCount++;
            if (_tldTimeCount == _tldAverageTimeCount)
            {
                _lblTldAverageTime.Text = (_tldTimeSum / _tldAverageTimeCount).ToString() + " ms";

                _tldTimeSum = 0;
                _tldTimeCount = 0;
            }
        }

        private void pbxCapture_MouseDown(object sender, MouseEventArgs e)
        {
            if (GroundTruthMode.Active)
            {
                if (GroundTruthMode.CursorInsideGroundTruth(e.Location))
                {
                    GroundTruthMode.StartDragging(e.Location);
                }
                else
                {
                    GroundTruthMode.Rectangle = new Rectangle(e.Location, new Size(0, 0));
                    GroundTruthMode.DrawRectangle = true;
                    GroundTruthMode.StopDragging();
                }
            }
            else
            {
                _rectangle = new Rectangle(e.Location, new Size(0, 0));
                _drawRectangle = true;
            }
            
            _mouseDown = true;
            pbxCapture_MouseMove(sender, e);
        }

        private void pbxCapture_MouseMove(object sender, MouseEventArgs e)
        {
            if (GroundTruthMode.Active)
            {
                if (GroundTruthMode.CursorInsideGroundTruth(e.Location) && !_mouseDown)
                {
                    Cursor.Current = Cursors.SizeAll;
                }
            }
            if (_mouseDown)
            {
                if (GroundTruthMode.Active)
                {
                    if (GroundTruthMode.Dragging)
                    {
                        GroundTruthMode.DragRectangle(e.Location);
                    }
                    else
                    {
                        GroundTruthMode.Rectangle = new Rectangle(
                            GroundTruthMode.Rectangle.Location,
                            new Size(
                                e.X - GroundTruthMode.Rectangle.X,
                                e.Y - GroundTruthMode.Rectangle.Y
                            )
                        );
                    }
                    
                }
                else
                {
                    _rectangle.Size = new Size
                        (
                            e.X - _rectangle.X,
                            e.Y - _rectangle.Y
                        );
                }

                RefreshVideoFrame();
            }
        }

        private void pbxCapture_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
            if (GroundTruthMode.Active)
            {
                
            }
            else
            {
                float rectangleArea = _rectangle.Width * _rectangle.Height;
                if (rectangleArea > 0)
                {
                    _drawRectangle = false;
                    _tldRectangle = _rectangle;
                    IBoundingBox initBb = BbFromRect(_tldRectangle);
                    _frmObjectModel.ObjectModel = tld.Learner.ObjectModel;
                    InitializeTLD(_currentFrame, initBb);
                    UseTLD();
                    StartCapture();
                    if (VideoMode.Current == VideoMode.File)
                    {
                        List<Image<Gray, byte>> positivePatches = new List<Image<Gray, byte>>(tld.Learner.ObjectModel.PositivePatches);
                        List<Image<Gray, byte>> negativePatches = new List<Image<Gray, byte>>(tld.Learner.ObjectModel.NegativePatches);
                        _videoFile.StartNewTldSession(initBb, positivePatches, negativePatches);
                    }
                    _rectangle = Rectangle.Empty;
                }
            }
        }

        private IBoundingBox BbFromRect(Rectangle rectangle)
        {
            PointF bbCenter = new PointF(rectangle.X + rectangle.Width / 2.0f, rectangle.Y + rectangle.Height / 2.0f);
            SizeF bbSize = new SizeF(rectangle.Width, rectangle.Height);

            return new BoundingBox(bbCenter, bbSize);
        }       

        private void OnFrameChanged()
        {
            _frameChanged = true;

            if (tldRunning)
            {
                _tldStopwatch.Reset();
                _tldStopwatch.Start();
                _currentBb = tld.FindObject(_currentFrame);
                _tldStopwatch.Stop();
                UpdateTldTime(_tldStopwatch.ElapsedMilliseconds);
                UpdateFbErrorMedian(_tracker.FbErrorMedian);
                UpdateNccMedian(_tracker.NccMedian);

                // notify components
                if (_cbxUseDetector.Checked)
                {
                    _frmDetectorSpecific.OnTldFindObjectCalled();
                }
                _frmLearnerSpecific.OnTldFindObjectCalled();

                // if TLD is running on a video, remember tld output and model update
                if (VideoMode.Current == VideoMode.File)
                {
                    // output bb
                    IBoundingBox bb;
                    if (_currentBb != null)
                    {
                        bb = new BoundingBox(_currentBb.Center, _currentBb.Size);
                    }
                    else
                    {
                        bb = null;
                    }

                    // model update
                    List<Image<Gray, byte>> positivePatches, negativePatches;
                    if (_frmObjectModel.NewPositivePatches.Count != 0)
                    {
                        positivePatches = new List<Image<Gray, byte>>(_frmObjectModel.NewPositivePatches);
                    }
                    else
                    {
                        positivePatches = null;
                    }
                    if (_frmObjectModel.NewNegativePatches.Count != 0)
                    {
                        negativePatches = new List<Image<Gray, byte>>(_frmObjectModel.NewNegativePatches);
                    }
                    else
                    {
                        negativePatches = null;
                    }

                    _videoFile.AddNewSessionInput(_videoFile.CurrentFrame, bb, positivePatches, negativePatches);
                }
            }
            else if (GroundTruthMode.Active)
            {
                int frame = _videoFile.CurrentFrame;
                Dictionary<int, IBoundingBox> GT = _videoFile.GroundTruth; 
                if (GT.ContainsKey(frame))
                {
                    IBoundingBox bb = GT[frame];
                    if (bb != null)
                    {
                        Rectangle rect = Rectangle.Round(GT[frame].GetRectangle());
                        if (rect != Rectangle.Empty)
                        {
                            GroundTruthMode.Rectangle = rect;
                            GroundTruthMode.DrawRectangle = true;
                        }
                    }
                }
            }
            else if (_tldSessionReplayRunning)
            {
                // current output
                _currentBb = _videoFile.GetTldOutput(_videoFile.CurrentFrame);

                // model update
                List<Image<Gray, byte>> positivePatches = _videoFile.PositiveModelUpdates[_videoFile.CurrentFrame];
                List<Image<Gray, byte>> negativePatches = _videoFile.NegativeModelUpdates[_videoFile.CurrentFrame];
                if (positivePatches != null)
                    positivePatches.ForEach(p => _frmObjectModel.ObjectModel.AddPositivePatch(p));
                if (negativePatches != null)
                    negativePatches.ForEach(p => _frmObjectModel.ObjectModel.AddNegativePatch(p));

                _frmObjectModel.OnTldFindObjectCalled();
            }

            if (VideoMode.Current == VideoMode.File)
            {
                _lblVideoFrame.Text = _videoFile.CurrentFrame.ToString() + "/" + _videoFile.FrameCount.ToString();
            }

            RefreshVideoFrame();

            if (_frmFrameToFrame.Visible)
            {
                _frmFrameToFrame.ShowFrames(_previousImage, _currentImage);
            }
        }        

        private void UpdateFbErrorMedian(float median)
        {
            _lblFbErrorMedian.Text = median.ToString("0.00");
        }

        private void UpdateNccMedian(float median)
        {
            _lblNccMedian.Text = median.ToString("0.00");
        }

        public void RefreshVideoFrame()
        {
            _pnlVideo.Invalidate();
        }

        private void InstantiateTLD()
        {
            if (!_tldLocked)
            {
                try
                {
                    tld = Persistor.LoadTld(_tldPath);
                }
                catch (Exception)
                {
                    tld = TldHardcoded.Instantiate();
                }
            }
        }

        private void InitializeTLD(Image<Gray, byte> frame, IBoundingBox bb)
        {
            if (!_tldLocked && tld != null)
            {
                if (frame != null)
                {
                    tld.Initialize(frame, bb);
                    _frmDetectorSpecific.TldInitialized();
                    _frmLearnerSpecific.OnTldInitialized();

                    _tldInitialized = true;
                }
            }
        } 

        private void UseTLD()
        {
            if (!_tldLocked && _tldInitialized)
            {
                tldRunning = true;
            }
        }

        private void _cbxUseTracker_CheckedChanged(object sender, EventArgs e)
        {
            (tld as Tld).UseTracker = _cbxUseTracker.Checked;
        }

        private void _cbxUseLearner_CheckedChanged(object sender, EventArgs e)
        {
            (tld as Tld).UseLearner = _cbxUseLearner.Checked;
        }

        private void _cbxUseDetector_CheckedChanged(object sender, EventArgs e)
        {
            (tld as Tld).UseDetector = _cbxUseDetector.Checked;
        }

        private void _cbxEnableTrackerFailure_CheckedChanged(object sender, EventArgs e)
        {
            tld.Tracker.FailureEnabled = _cbxEnableTrackerFailure.Checked;
        }

        private void _nudGridWidth_ValueChanged(object sender, EventArgs e)
        {
            MedianFlowTrackerBoundingBox bb = GetTrackerBb();
            bb.GridSize = new Size(Utils.NudGetValueInt(_nudGridWidth), bb.GridSize.Height);
            RefreshVideoFrame();
        }

        private void _nudGridHeight_ValueChanged(object sender, EventArgs e)
        {
            MedianFlowTrackerBoundingBox bb = GetTrackerBb();
            bb.GridSize = new Size(bb.GridSize.Width, Utils.NudGetValueInt(_nudGridHeight));
            RefreshVideoFrame();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveUserPreferences();
            Persistor.SaveTld(_tldPath, tld);
        }

        private void _cbxShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            RefreshVideoFrame();
        }

        private void _nudGridPaddingWidth_ValueChanged(object sender, EventArgs e)
        {
            MedianFlowTrackerBoundingBox bb = GetTrackerBb();
            bb.GridPadding = new SizeF(Utils.NudGetValueFloat(_nudGridPaddingWidth), bb.GridPadding.Height);
            RefreshVideoFrame();
        }

        private void _nudGridPaddingHeight_ValueChanged(object sender, EventArgs e)
        {
            MedianFlowTrackerBoundingBox bb = GetTrackerBb();
            bb.GridPadding = new SizeF(bb.GridPadding.Width, Utils.NudGetValueFloat(_nudGridPaddingHeight));
            RefreshVideoFrame();
        }

        private void _nudLkWindowWidth_ValueChanged(object sender, EventArgs e)
        {
            LucasKanadeTracker lk = GetLkTracker();
            lk.WindowSize = new Size(Utils.NudGetValueInt(_nudLkWindowWidth), lk.WindowSize.Height);
        }

        private void _nudLkWindowHeight_ValueChanged(object sender, EventArgs e)
        {
            LucasKanadeTracker lk = GetLkTracker();
            lk.WindowSize = new Size(lk.WindowSize.Width, Utils.NudGetValueInt(_nudLkWindowHeight));
        }

        private LucasKanadeTracker GetLkTracker()
        {
            return _tracker.LucasKanadeTracker as LucasKanadeTracker;
        }

        private void _nudLkLevels_ValueChanged(object sender, EventArgs e)
        {
            LucasKanadeTracker lk = GetLkTracker();
            lk.Levels = Utils.NudGetValueInt(_nudLkLevels);
        }
        

        private void _nudLkEpsilon_ValueChanged(object sender, EventArgs e)
        {
            LucasKanadeTracker lk = GetLkTracker();
            lk.Epsilon = Utils.NudGetValueDouble(_nudLkEpsilon);
        }

        private void _nudLkMaxIterations_ValueChanged(object sender, EventArgs e)
        {
            LucasKanadeTracker lk = GetLkTracker();
            lk.MaxIterations = Utils.NudGetValueInt(_nudLkMaxIterations);
        }

        private void _nudNccPatchWidth_ValueChanged(object sender, EventArgs e)
        {
            _tracker.NccPatchSize = new Size(Utils.NudGetValueInt(_nudNccPatchWidth), _tracker.NccPatchSize.Height);
        }

        private void _nudNccPatchHeight_ValueChanged(object sender, EventArgs e)
        {
            _tracker.NccPatchSize = new Size(_tracker.NccPatchSize.Width, Utils.NudGetValueInt(_nudNccPatchHeight));
        }

        private void _nudMadTreshold_ValueChanged(object sender, EventArgs e)
        {
            _tracker.MadTreshold = Utils.NudGetValueFloat(_nudMadTreshold);
        }

        private void _cbxShowValidTrackingPoints_CheckedChanged(object sender, EventArgs e)
        {
            RefreshVideoFrame();
        }

        private void _cbxShowReliableTrackingPoints_CheckedChanged(object sender, EventArgs e)
        {
            RefreshVideoFrame();
        }

        private void _cbxShowTrackerObject_CheckedChanged(object sender, EventArgs e)
        {
            RefreshVideoFrame();
        }

        private void _cbxShowDetectorObjects_CheckedChanged(object sender, EventArgs e)
        {
            RefreshVideoFrame();
        }

        private void _cmbxChooseSpecificDetector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cmbxChooseSpecificDetector.SelectedIndex == 0)
            {
                frmCreateDetector frm = new frmCreateDetector(DetectorCreated);
                frm.ShowDialog();
            }
        }

        private void DetectorCreated(IFrmSpecificDetector detectorForm, string name, Type type)
        {
            _cmbxChooseSpecificDetector.Items.Add(name + " (" + type + ")");
            _cmbxChooseSpecificDetector.SelectedIndex = _cmbxChooseSpecificDetector.Items.Count - 1;
            LoadDetectorPanel(detectorForm);
            tld.Detector = detectorForm.Detector;
            if (tldRunning)
            {
                tld.Detector.Initialize(_currentFrame, _currentBb);
            }
        }

        private void _cbxVideoMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoMode.Current = (string)_cbxVideoMode.SelectedItem;
            OnVideoModeChanged();
        }

        void OnVideoModeChanged()
        {
            StopTld();
            if (VideoMode.Current == VideoMode.Camera)
            {
                Utils.NudSetValueInt(_nudFrameWidth, 640);
                Utils.NudSetValueInt(_nudFrameHeight, 480);
                StartCapture();
            }
            else if (VideoMode.Current == VideoMode.File)
            {
                UpdateVideoFileCapture();
            }
        }

        private void UpdateVideoFileCapture()
        {
            if (_videoFile != null)
            {
                _capture = _videoFile.Capture;
                Utils.NudSetValueInt(_nudFrameWidth, _videoFile.NormalizedSize.Width);
                Utils.NudSetValueInt(_nudFrameHeight, _videoFile.NormalizedSize.Height);
                StopCapture();
                if (_videoFile.SessionComplete)
                {
                    InitializeSessionObjectModel();
                }

                // ground truth
                GroundTruthMode.VerticalTransStep = 1;
                GroundTruthMode.HorizontalTransStep = 1;
            }
            else
            {
                MessageBox.Show("Video file not loaded!");
            }
        }

        private void InitializeSessionObjectModel()
        {
            _frmObjectModel.ObjectModel = new ObjectModel(tld.Learner.ObjectModel.PatchSize);
            _videoFile.PositiveModelUpdates[0].ForEach(p => _frmObjectModel.ObjectModel.AddPositivePatch(p));
            _videoFile.NegativeModelUpdates[0].ForEach(p => _frmObjectModel.ObjectModel.AddNegativePatch(p));
            _frmObjectModel.OnTldInitialized();
        }

        private void StopTld()
        {
            tldRunning = false;
            _tldSessionReplayRunning = false;
        }

        private void _btnReplayTldSession_Click(object sender, EventArgs e)
        {
            GroundTruthMode.Active = false;
            if (VideoMode.Current == VideoMode.File && _videoFile.CurrentFrame == 0 && _videoFile.SessionComplete)
            {
                _tldSessionReplayRunning = true;
                StartCapture();
            }
        }

        private void _btnOpenVideoFile_Click(object sender, EventArgs e)
        {
            if (OVF.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OpenAndShowVideoFile(OVF.FileName);
                }
                catch (Exception ex)
                {
                    ShowExceptionRecursive(ex);
                }
            }
        }

        private void _btnStartNewTldSessionUsingGTInit_Click(object sender, EventArgs e)
        {
            if (VideoMode.Current == VideoMode.File)
            {
                GroundTruthMode.Active = false;
                try
                {
                    IBoundingBox initBb = _videoFile.GroundTruth[0];
                    _rectangle = Rectangle.Round(initBb.GetRectangle());
                    GroundTruthMode.Active = false;
                    pbxCapture_MouseUp(null, null);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void _btnSaveTldSession_Click(object sender, EventArgs e)
        {
            if (_videoFile.SessionComplete)
            {
                TldSessionPersistor.Save(_videoFile);
            }
        }

        private void _btnLoadTldSession_Click(object sender, EventArgs e)
        {
            TldSessionPersistor.TryLoad(_videoFile);
            StopCapture();
            InitializeSessionObjectModel();
        }

        private void _cbxShowTldOutput_CheckedChanged(object sender, EventArgs e)
        {
            RefreshVideoFrame();
        }

        private void frametoframeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFrameToFrameView();
        }

        private void nCCCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmNccCalculator();
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }

        private void _cbxVideoRealTime_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (VideoMode.Current == VideoMode.File)
            {
                if (GroundTruthMode.Active)
                {
                    if (e.KeyCode == Keys.E)
                    {
                        // remember ground truth
                        int currentFrame = _videoFile.CurrentFrame;
                        if (GroundTruthMode.Rectangle != Rectangle.Empty)
                        {
                            _videoFile.GroundTruth[currentFrame] = BbFromRect(GroundTruthMode.Rectangle);
                        }
                        else
                        {
                            _videoFile.GroundTruth[currentFrame] = null;
                        }

                        // go to next frame
                        ProcessFrame(null, null);

                        if (_videoFile.CurrentFrame == 0)
                        {
                            GroundTruthMode.Active = false;
                        }
                    }
                    else if (e.KeyCode == Keys.Q)
                    {
                        // remember ground truth
                        int currentFrame = _videoFile.CurrentFrame;
                        _videoFile.GroundTruth[currentFrame] = BbFromRect(GroundTruthMode.Rectangle);

                        // go to previous frame
                        currentFrame = _videoFile.CurrentFrame;
                        if (currentFrame >= 1)
                        {
                            _videoFile.CurrentFrame = currentFrame - 2;
                        }
                        ProcessFrame(null, null);
                    }
                    else if (e.KeyCode == Keys.D)
                    {
                        // go to next frame
                        ProcessFrame(null, null);
                    }
                    else if (e.KeyCode == Keys.A)
                    {
                        // go to previous frame
                        int currentFrame = _videoFile.CurrentFrame;
                        if (currentFrame >= 1)
                        {
                            _videoFile.CurrentFrame = currentFrame - 2;
                        }
                        ProcessFrame(null, null);
                    }
                    else if (e.KeyCode == Keys.Delete)
                    {
                        GroundTruthMode.Rectangle = Rectangle.Empty;
                        RefreshVideoFrame();
                    }
                    // move GT session rectangle to the left
                    else if (e.KeyCode == Keys.J)
                    {
                        Rectangle r = GroundTruthMode.Rectangle;
                        GroundTruthMode.Rectangle = new Rectangle(
                            new Point(r.X - GroundTruthMode.HorizontalTransStep, r.Y),
                            r.Size
                        );
                        RefreshVideoFrame();
                    }
                    // move GT session rectangle to the right
                    else if (e.KeyCode == Keys.L)
                    {
                        Rectangle r = GroundTruthMode.Rectangle;
                        GroundTruthMode.Rectangle = new Rectangle(
                            new Point(r.X + GroundTruthMode.HorizontalTransStep, r.Y),
                            r.Size
                        );
                        RefreshVideoFrame();
                    }
                    // move GT session rectangle to the top
                    else if (e.KeyCode == Keys.I)
                    {
                        Rectangle r = GroundTruthMode.Rectangle;
                        GroundTruthMode.Rectangle = new Rectangle(
                            new Point(r.X, r.Y - GroundTruthMode.VerticalTransStep),
                            r.Size
                        );
                        RefreshVideoFrame();
                    }
                    // move GT session rectangle to the bottom
                    else if (e.KeyCode == Keys.K)
                    {
                        Rectangle r = GroundTruthMode.Rectangle;
                        GroundTruthMode.Rectangle = new Rectangle(
                            new Point(r.X, r.Y + GroundTruthMode.VerticalTransStep),
                            r.Size
                        );
                        RefreshVideoFrame();
                    }
                    // make GT session rectangle smaller
                    else if (e.KeyCode == Keys.O)
                    {
                        Rectangle r = GroundTruthMode.Rectangle;
                        GroundTruthMode.Rectangle = new Rectangle(
                            new Point(r.X + 1, r.Y + 1),
                            new Size(r.Size.Width - 2, r.Size.Height - 2)
                        );
                        RefreshVideoFrame();
                    }
                    // make GT session rectangle bigger
                    else if (e.KeyCode == Keys.U)
                    {
                        Rectangle r = GroundTruthMode.Rectangle;
                        GroundTruthMode.Rectangle = new Rectangle(
                            new Point(r.X - 1, r.Y - 1),
                            new Size(r.Size.Width + 2, r.Size.Height + 2)
                        );
                        RefreshVideoFrame();
                    }
                    // make vertical translation faster
                    else if (e.KeyCode == Keys.Z)
                    {
                        GroundTruthMode.VerticalTransStep++;
                    }
                    // make vertical translation slower
                    else if (e.KeyCode == Keys.H)
                    {
                        if (GroundTruthMode.VerticalTransStep >= 2)
                        {
                            GroundTruthMode.VerticalTransStep--;
                        }
                    }
                    // make horizontal translation faster
                    else if (e.KeyCode == Keys.T)
                    {
                        GroundTruthMode.HorizontalTransStep++;
                    }
                    // make vertical translation slower
                    else if (e.KeyCode == Keys.G)
                    {
                        if (GroundTruthMode.HorizontalTransStep >= 2)
                        {
                            GroundTruthMode.HorizontalTransStep--;
                        }
                    }
                }
            }
        }

        private void _btnEnterGroundTruthMode_Click(object sender, EventArgs e)
        {
            GroundTruthMode.Active = true;
            _cbxDrawGroundTruth.Checked = true;
            if (_videoFile.GroundTruth.ContainsKey(_videoFile.CurrentFrame))
            {
                IBoundingBox bb = _videoFile.GroundTruth[_videoFile.CurrentFrame];
                if (bb != null)
                {
                    GroundTruthMode.Rectangle = Rectangle.Round(bb.GetRectangle());
                    RefreshVideoFrame();
                }
            }
        }

        private void _btnExitGroundTruthMode_Click(object sender, EventArgs e)
        {
            GroundTruthMode.Active = false;
            _cbxDrawGroundTruth.Checked = false;
            StopCapture();
        }

        private void _btnSaveGroundTruth_Click(object sender, EventArgs e)
        {
            GroundTruthPersistor.Save(_videoFile);
        }

        private void _btnLoadGroundTruth_Click(object sender, EventArgs e)
        {
            GroundTruthPersistor.TryLoad(_videoFile);
        }

        private void _cbxDrawGroundTruth_CheckedChanged(object sender, EventArgs e)
        {
            RefreshVideoFrame();
        }

        private void _btnEvaluateTldSession_Click(object sender, EventArgs e)
        {
            if (!(_videoFile.GroundTruth.Count == _videoFile.FrameCount))
            {
                List<int> missingFrames = new List<int>();
                for (int i = 0; i < _videoFile.FrameCount; i++)
                {
                    if (!(_videoFile.GroundTruth.ContainsKey(i)))
                    {
                        missingFrames.Add(i);
                    }
                }
                string frames = "";
                foreach (int frame in missingFrames)
                {
                    frames += frame.ToString() + " ";
                }
                MessageBox.Show("Unable to evaluate video session!\nMissing ground truth for frames:\n" + frames);
            }
            else if (!(_videoFile.TldOutputs.Count == _videoFile.FrameCount))
            {
                MessageBox.Show("Unable to evaluate video session!\nTLD session is not complete.");
            }
            else
            {
                frmEvaluation frm = new frmEvaluation(_videoFile);
                frm.ShowDialog();
            }
        }

        private void _btnClearGroundTruthSession_Click(object sender, EventArgs e)
        {
            _videoFile.GroundTruth.Clear();
            RefreshVideoFrame();
        }
    }
}
