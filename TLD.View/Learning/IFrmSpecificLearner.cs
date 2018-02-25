using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TLD.View.Learning
{
    public interface IFrmSpecificLearner
    {
        void OnTldInitialized();
        void OnTldFindObjectCalled();
        TableLayoutPanel Panel { get; }
    }
}
