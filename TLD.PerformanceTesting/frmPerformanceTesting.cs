using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TLD.PerformanceTesting
{
    public partial class frmPerformanceTesting : Form
    {
        public frmPerformanceTesting()
        {
            InitializeComponent();
        }

        private void DisplayResults(List<string> list)
        {
            _rtbxTestResults.Text = string.Join("\n", list.ToArray());
        }

        private void btnRunBoolArrayKeyTest_Click(object sender, EventArgs e)
        {
            DisplayResults(BoolArrayKeyTest.Run());
        }
    }
}
