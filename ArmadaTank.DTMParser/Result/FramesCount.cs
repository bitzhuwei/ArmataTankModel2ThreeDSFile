using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmadaTank.DTMParser.Result
{
    class FramesCount : FileDescItem
    {
        public int framesCount { get; set; }

        public override string ToString()
        {
            return string.Format("framesCount:{0}", framesCount);
            //return base.ToString();
        }
    }
}
