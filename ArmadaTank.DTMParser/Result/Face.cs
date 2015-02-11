using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmadaTank.DTMParser.Result
{
    public class Face
    {
        public int Order { get; set; }
        public int[] verticesIndex { get; set; }
        public Face()
        {
            verticesIndex = new int[3];
        }

        public int MatID { get; set; }

        public override string ToString()
        {
            return string.Format("{0}:{1},{2},{3};Mat:{4}", Order, verticesIndex[0], verticesIndex[1], verticesIndex[2], MatID);
            //return base.ToString();
        }
    }
}
