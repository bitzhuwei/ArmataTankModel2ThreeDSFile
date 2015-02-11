using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmadaTank.DTMParser.Result
{
    class MapCount : FileDescItem
    {
        public int mapCount { get; set; }

        public int tVerticesCount { get; set; }

        public override string ToString()
        {
            return string.Format("mapCount:{0}, tVerticesCount:{1}", mapCount, tVerticesCount);
            //return base.ToString();
        }
    }
}
