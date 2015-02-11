using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmadaTank.DTMParser.Result
{
    class FacesCount : FileDescItem
    {
        public int facesCount { get; set; }

        public override string ToString()
        {
            return string.Format("facesCount:{0}", facesCount);
        }
    }
}
