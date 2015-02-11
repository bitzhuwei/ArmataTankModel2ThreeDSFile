using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmadaTank.DTMParser.Result
{
    public class TFace
    {
        public int Order { get; set; }
        public int[] VertexIndexes { get; set; }
        public TFace()
        {
            VertexIndexes = new int[3];
        }

        public override string ToString()
        {
            return string.Format("{0}:{1},{2},{3}", Order, VertexIndexes[0], VertexIndexes[1], VertexIndexes[2]);
            //return base.ToString();
        }
    }
}
