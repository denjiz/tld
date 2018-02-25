using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLD.Model
{
    public enum MedianFlowTrackerStatus
    {
        OK,
        NOT_ENOUGH_VALID_SHIFTS,
        MAD_TOO_BIG,
        NOT_ENOUGH_RELIABLE_SHIFTS,
    }
}
