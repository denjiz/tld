using System;
using System.Windows.Forms;
using TLD.Model;
using TLD.Model.Detection;
namespace TLD.View
{
    internal interface IFrmSpecificDetector
    {
        TableLayoutPanel Panel { get; }
        IDetector Detector { get; }
        void Draw(PaintEventArgs e);

        void TldInitialized();
        void OnTldFindObjectCalled();
    }
}
