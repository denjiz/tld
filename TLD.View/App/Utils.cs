using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TLD.View
{
    /// <summary>
    /// Common methods when working with forms.
    /// </summary>
    static class Utils
    {
        #region numeric up-down value getters

        public static int NudGetValueInt(NumericUpDown nud)
        {
            return (int)nud.Value;
        }

        public static float NudGetValueFloat(NumericUpDown nud)
        {
            return (float)nud.Value;
        }

        public static double NudGetValueDouble(NumericUpDown nud)
        {
            return (double)nud.Value;
        }

        #endregion

        #region numeric up-down value setters

        public static void NudSetValueInt(NumericUpDown nud, int value)
        {
            nud.Value = value;
        }

        public static void NudSetValueFloat(NumericUpDown nud, float value)
        {
            nud.Value = (decimal)value;
        }

        public static void NudSetValueDouble(NumericUpDown nud, double value)
        {
            nud.Value = (decimal)value;
        }

        #endregion

        public static void ClearFolder(string folderName)
        {
            DirectoryInfo dir = new DirectoryInfo(folderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                ClearFolder(di.FullName);
                di.Delete();
            }
        }
    }
}
