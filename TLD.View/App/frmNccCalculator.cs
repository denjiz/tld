using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TLD.View.Properties;
using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;
using System.Reflection;
using TLD.Model;

namespace TLD.View
{
    public partial class frmNccCalculator : Form
    {
        private Settings _preferences;

        private Image _image;

        private Image<Gray, byte> _cvImage;
        private Image<Gray, byte> _cvPatch1;
        private Image<Gray, byte> _cvPatch2;

        private Rectangle _patch1Rectangle;
        private Rectangle _patch2Rectangle;

        private OpenFileDialog OF;

        public frmNccCalculator()
        {
            InitializeComponent();
            _preferences = Settings.Default;

            OF = new OpenFileDialog();
            OF.InitialDirectory = Path.GetFullPath(@"..\..\Images");
            LoadImage(_preferences.NccImagePath);

            // get rid of flickering
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, _pnlImage, new object[] { true });
        }

        private void LoadImage(string path)
        {
            try
            {
                _cvImage = new Image<Gray, byte>(path);
                _image = _cvImage.ToBitmap();
                _tbxImagePath.Text = path;
                RefreshVideoFrame();
            }
            catch (Exception)
            {
                MessageBox.Show("Image '" + path + "' could not be loaded");
            }
        }

        private void RefreshVideoFrame()
        {
            _pnlImage.Invalidate();
        }

        private void _pnlImage_Paint(object sender, PaintEventArgs e)
        {
            if (_image != null)
            {
                e.Graphics.DrawImage(_image, new Point(0, 0));
            }

            if (_patch1Rectangle != Rectangle.Empty)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Blue, 1), _patch1Rectangle);
            }

            if (_patch2Rectangle != Rectangle.Empty)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Red, 1), _patch2Rectangle);
            }
        }

        private void frmNccCalculator_FormClosing(object sender, FormClosingEventArgs e)
        {
            _preferences.NccImagePath = _tbxImagePath.Text;
            _preferences.Save();
        }

        private void _btnOpenImage_Click(object sender, EventArgs e)
        {
            if (OF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadImage(OF.FileName);
            }
        }

        private void _pnlImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                _patch1Rectangle = new Rectangle(e.Location, new Size(0, 0));
            }

            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _patch2Rectangle = new Rectangle(e.Location, new Size(0, 0));
            }
        }

        private void _pnlImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (_patch1Rectangle != Rectangle.Empty)
                {
                    _patch1Rectangle = new Rectangle(
                        _patch1Rectangle.Location,
                        new Size(e.Location.X - _patch1Rectangle.Location.X, e.Location.Y - _patch1Rectangle.Location.Y)
                    );

                    RefreshVideoFrame();
                }
            }

            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (_patch2Rectangle != Rectangle.Empty)
                {
                    _patch2Rectangle = new Rectangle(
                        _patch2Rectangle.Location,
                        new Size(e.Location.X - _patch2Rectangle.Location.X, e.Location.Y - _patch2Rectangle.Location.Y)
                    );

                    RefreshVideoFrame();
                }
            }
        }

        private void _pnlImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                RefreshPatch1();
            }

            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                RefreshPatch2();
            }
        }

        private void UpdateNcc()
        {
            if (_cvPatch1 != null && _cvPatch2 != null)
            {
                if (_cvPatch1.Size == _cvPatch2.Size)
                {
                    _lblNcc.Text = Service.NCC(_cvPatch1, _cvPatch2).ToString();
                }
            }
        }

        private void RefreshPatch1()
        {
            _pnlPatch1.Invalidate();
        }

        private void RefreshPatch2()
        {
            _pnlPatch2.Invalidate();
        }

        private void _pnlPatch1_Paint(object sender, PaintEventArgs e)
        {
            _cvPatch1 = TryDrawPatch(_patch1Rectangle, _cvImage, _pnlPatch1, e);
            UpdateNcc();
        }

        private void _pnlPatch2_Paint(object sender, PaintEventArgs e)
        {
            _cvPatch2 = TryDrawPatch(_patch2Rectangle, _cvImage, _pnlPatch2, e);
            UpdateNcc();
        }

        private Image<Gray, byte> TryDrawPatch(Rectangle rect, Image<Gray, byte> image, Panel panel, PaintEventArgs e)
        {
            if (rect != Rectangle.Empty && rect.Size.Width > 0 && rect.Size.Height > 0)
            {
                PointF patchCenter = new PointF(
                    (rect.Location.X + rect.Size.Width / 2.0f),
                    (rect.Location.Y + rect.Size.Height / 2.0f)
                );
                Image<Gray, byte> cvPatch = image
                    .GetPatch(patchCenter, rect.Size)
                    .Resize(Utils.NudGetValueInt(_nudNormalizedWidth), Utils.NudGetValueInt(_nudNormalizedHeight), Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
                Image patch = cvPatch.ToBitmap();
                e.Graphics.DrawImage(patch, new Point(0, 0));

                return cvPatch;
            }

            return null;
        }
    }
}
