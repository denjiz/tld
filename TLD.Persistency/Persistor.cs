using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLD.Model;
using Emgu.CV.Structure;
using System.Runtime.Serialization;
using TLD.Model.Integration;

namespace TLD.Persistency
{
    public class Persistor
    {
        private static SoapFormatter _serializer;

        static Persistor()
        {
            _serializer = new SoapFormatter();
            SurrogateSelector ss = new SurrogateSelector();
            ss.AddSurrogate
                (
                typeof(MCvTermCriteria),
                new StreamingContext(StreamingContextStates.All),
                new MCvTermCriteriaSerializationSurrogate()
                );
            _serializer.SurrogateSelector = ss;
        }

        public static ITld LoadTld(string path)
        {
            using (FileStream stream = File.OpenRead(path))
            {
                ITld tld = (ITld)_serializer.Deserialize(stream);
                tld.PostInstantiation();
                return tld;
            }
        }

        public static void SaveTld(string path, ITld tld)
        {
            using (FileStream stream = File.Create(path))
            {
                _serializer.Serialize(stream, tld);
            }
        }

        public static void SaveTld_DataContract(string path, ITld tld)
        {
            DataContractSerializer serializer = new DataContractSerializer
            (
            typeof(ITld)
            );
            using (FileStream stream = File.Create(path))
            {
                serializer.WriteObject(stream, tld);
            }
        }
    }
}
