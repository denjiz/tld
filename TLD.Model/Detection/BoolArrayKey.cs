using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLD.Model.Detection
{
    public class BoolArrayKey
    {
        private int _hash;
        private bool[] _data;

        /// <summary>
        /// Use this constructor only when sure that data will not change anymore.
        /// </summary>
        /// <param name="data">The data that should not change anymore.</param>
        public BoolArrayKey(bool[] data)
        {
            // copy data
            int length = data.Length;
            _data = new bool[length];
            Array.Copy(data, _data, length);

            // calculate hash
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = _data[i] == true ? '1' : '0';
            }
            string str = new string(chars);
            _hash = str.GetHashCode();
        }

        #region overrides of Equals(object obj) and GetHashCode()

        public override bool Equals(object obj)
        {
            BoolArrayKey other = obj as BoolArrayKey;
            if (obj == null)
            {
                return false;
            }

            bool[] otherData = other.Data;
            if (otherData.Length != _data.Length)
            {
                return false;
            }
            for (int i = 0; i < _data.Length; i++)
            {
                if (otherData[i] != _data[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return _hash;
        }

        #endregion

        public bool[] Data
        {
            get { return _data; }
        }

        public BoolArrayKey DeepCopy()
        {
            return new BoolArrayKey(_data);
        }
    }
}
