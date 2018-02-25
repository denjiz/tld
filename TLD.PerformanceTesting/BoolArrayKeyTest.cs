using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TLD.Model.Detection;

namespace TLD.PerformanceTesting
{
    class BoolArrayKeyTest
    {
        private static Random _random;

        static BoolArrayKeyTest()
        {
            _random = new Random();
        }

        internal static List<string> Run()
        {
            List<string> result = new List<string>();

            result.AddRange(Instantiate(10000, 13, 100));

            return result;
        }

        private static List<string> Instantiate(int count, int dataLenght, int repeat)
        {
            List<string> results = new List<string>();

            // create data for constructor
            List<bool[]> constructorData = CreateContructorData(count, dataLenght);

            results.Add("[INFO] Instantiating " + count + " objects of type 'BoolArrayKey' with data lenght " + dataLenght);
            results.Add("[REPEAT] " + repeat);

            Stopwatch s = new Stopwatch();
            s.Start();

            for (int k = 0; k < repeat; k++)
            {
                for (int i = 0; i < count; i++)
                {
                    // instantiate object
                    BoolArrayKey obj = new BoolArrayKey(constructorData[i]);
                }
            }

            s.Stop();
            results.Add("[AVG TIME] " + s.ElapsedMilliseconds / repeat + " ms");

            return results;
        }

        private static List<bool[]> CreateContructorData(int count, int dataLenght)
        {
            List<bool[]> constructorData = new List<bool[]>();
            for (int i = 0; i < count; i++)
            {
                bool[] data = new bool[dataLenght];
                for (int j = 0; j < dataLenght; j++)
                {
                    data[j] = _random.Next(2) == 1 ? true : false;
                }
                constructorData.Add(data);
            }

            return constructorData;
        }
    }
}
