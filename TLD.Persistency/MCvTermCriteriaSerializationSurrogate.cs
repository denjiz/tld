using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TLD.Persistency
{
    class MCvTermCriteriaSerializationSurrogate : ISerializationSurrogate
    {
        private static string epsilon = "Eps";
        private static string maxIter = "MaxIter";
        private static string type = "Type";

        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            MCvTermCriteria criteria = (MCvTermCriteria)obj;
            info.AddValue(maxIter, criteria.max_iter);
            info.AddValue(epsilon, criteria.epsilon);
            info.AddValue(type, criteria.type);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            MCvTermCriteria criteria = (MCvTermCriteria)obj;
            criteria.max_iter = (int)info.GetValue(maxIter, typeof(int));
            criteria.epsilon = (double)info.GetValue(epsilon, typeof(double));
            criteria.type = (TERMCRIT)info.GetValue(type, typeof(TERMCRIT));
            return criteria;
        }
    }
}
