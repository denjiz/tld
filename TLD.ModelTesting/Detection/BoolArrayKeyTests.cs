using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TLD.Model.Detection;

namespace TLD.ModelTesting.Detection
{
    [TestClass]
    public class BoolArrayKeyTests
    {
        [TestMethod]
        public void AddToHashSet_CheckIfAddedByReference()
        {
            // arrange - add 1 item to hashset
            bool[] data = {true, true, false, false};
            BoolArrayKey item = new BoolArrayKey(data);
            HashSet<BoolArrayKey> set = new HashSet<BoolArrayKey>();
            set.Add(item);

            // assert - check if hashet contains item
            Assert.IsTrue(set.Contains(item));
        }

        [TestMethod]
        public void AddToHashSet_CheckIfAddedByData()
        {
            // arrange - add 1 item to hashset
            bool[] data = { true, true, false, false };
            BoolArrayKey item = new BoolArrayKey(data);
            HashSet<BoolArrayKey> set = new HashSet<BoolArrayKey>();
            set.Add(item);

            // arrange create another item with the same data
            bool[] data2 = { true, true, false, false };
            BoolArrayKey item2 = new BoolArrayKey(data2);

            // assert - check if hashet contains the second item
            Assert.IsTrue(set.Contains(item2));
        }

        [TestMethod]
        public void AddToHashSet_5DifferentItems_AllUnique()
        {
            // arrange - add 5 different items to a hashset
            List<BoolArrayKey> list = new List<BoolArrayKey>()
            {
                new BoolArrayKey(new bool[]{false, false, false}),
                new BoolArrayKey(new bool[]{false, false, true}),
                new BoolArrayKey(new bool[]{false, true, false}),
                new BoolArrayKey(new bool[]{false, true, true}),
                new BoolArrayKey(new bool[]{true, false, false}),
            };
            HashSet<BoolArrayKey> set = new HashSet<BoolArrayKey>();
            foreach (BoolArrayKey item in list)
            {
                set.Add(item);
            }

            // assert - check if hashet contains all items
            Assert.IsTrue(set.Count == 5);
            foreach (BoolArrayKey item in list)
            {
                Assert.IsTrue(set.Contains(item));
            }
        }

        [TestMethod]
        public void AddToHashSet_5DifferentItems_3Unique()
        {
            // arrange - add 5 items to a hashset, 3 of which are the same
            List<BoolArrayKey> list = new List<BoolArrayKey>()
            {
                new BoolArrayKey(new bool[]{false, false, false}),
                new BoolArrayKey(new bool[]{false, false, false}),
                new BoolArrayKey(new bool[]{true, true, true}),
                new BoolArrayKey(new bool[]{true, true, true}),
                new BoolArrayKey(new bool[]{false, true, false}),
            };
            HashSet<BoolArrayKey> set = new HashSet<BoolArrayKey>();
            foreach (BoolArrayKey item in list)
            {
                set.Add(item);
            }

            // assert - check if hashet contains only the unique items
            Assert.IsTrue(set.Count == 3);
            Assert.IsTrue(set.Contains(list[0]));
            Assert.IsTrue(set.Contains(list[2]));
            Assert.IsTrue(set.Contains(list[4]));
        }

        [TestMethod]
        public void Create5EqualItems_AllHaveEqualHashes()
        {
            // arrange - create 5 equal items
            List<BoolArrayKey> list = new List<BoolArrayKey>()
            {
                new BoolArrayKey(new bool[]{false, false, false}),
                new BoolArrayKey(new bool[]{false, false, false}),
                new BoolArrayKey(new bool[]{false, false, false}),
                new BoolArrayKey(new bool[]{false, false, false}),
                new BoolArrayKey(new bool[]{false, false, false}),
            };

            // arrange - create a list of their hashes
            List<int> hashes = new List<int>();
            foreach (BoolArrayKey item in list)
            {
                hashes.Add(item.GetHashCode());
            }

            // assert - there are 5 hash codes and they are all the same
            Assert.AreEqual(5, hashes.Count);
            int firstHash = hashes[0];
            foreach (int hash in hashes)
            {
                Assert.AreEqual(firstHash, hash);
            }
        }

        [TestMethod]
        public void Create5DifferentItems_AllHaveDifferentHashes()
        {
            // arrange - create 5 items
            List<BoolArrayKey> list = new List<BoolArrayKey>()
            {
                new BoolArrayKey(new bool[]{false, false, false}),
                new BoolArrayKey(new bool[]{false, false, true}),
                new BoolArrayKey(new bool[]{false, true, false}),
                new BoolArrayKey(new bool[]{false, true, true}),
                new BoolArrayKey(new bool[]{true, false, false}),
            };
            
            // arrange - create a list of their hashes
            List<int> hashes = new List<int>();
            foreach (BoolArrayKey item in list)
            {
                hashes.Add(item.GetHashCode());
            }

            // assert - there are 5 hash codes and they are all unique
            Assert.AreEqual(5, hashes.Count);
            CollectionAssert.AllItemsAreUnique(hashes);
        }

        [TestMethod]
        public void AddToDictionary_AllUnique()
        {
            // arrange - create 5 keys
            List<BoolArrayKey> keys = new List<BoolArrayKey>()
            {
                new BoolArrayKey(new bool[]{false, false, false}),
                new BoolArrayKey(new bool[]{false, false, true}),
                new BoolArrayKey(new bool[]{false, true, false}),
                new BoolArrayKey(new bool[]{false, true, true}),
                new BoolArrayKey(new bool[]{true, false, false}),
            };

            // arrange - create 5 values
            List<double> values = new List<double>()
            {
                1, 2, 3, 4, 5
            };

            // arrange - add key-value pair to a dictionary
            Dictionary<BoolArrayKey, double> dict = new Dictionary<BoolArrayKey, double>();
            for (int i = 0; i < keys.Count; i++)
            {
                dict.Add(keys[i], values[i]);
            }

            // assert - dictionary contains all key-value pairs
            Assert.AreEqual(keys.Count, dict.Count);
            for (int i = 0; i < keys.Count; i++)
            {
                Assert.IsTrue(dict[keys[i]] == values[i]);
            }
        }

        [TestMethod]
        public void AddToDictionary_NotAllUnique()
        {
            // arrange - create 5 keys
            List<BoolArrayKey> keys = new List<BoolArrayKey>()
            {
                new BoolArrayKey(new bool[]{false, false, false}),
                new BoolArrayKey(new bool[]{false, false, true}),
                new BoolArrayKey(new bool[]{false, true, false}),
                new BoolArrayKey(new bool[]{false, true, true}),
                new BoolArrayKey(new bool[]{false, true, true}),
            };

            // arrange - create 5 values
            List<double> values = new List<double>()
            {
                1, 2, 3, 4, 5
            };

            // arrange - add key-value pair to a dictionary
            Dictionary<BoolArrayKey, double> dict = new Dictionary<BoolArrayKey, double>();
            for (int i = 0; i < keys.Count; i++)
            {
                dict[keys[i]] = values[i];
            }

            // assert - dictionary contains only 4 key values pairs
            Assert.AreEqual(keys.Count - 1, dict.Count);
            Assert.IsTrue(dict[keys[0]] == 1);
            Assert.IsTrue(dict[keys[1]] == 2);
            Assert.IsTrue(dict[keys[2]] == 3);
            Assert.IsTrue(dict[keys[3]] == 5);
        }
    }
}
