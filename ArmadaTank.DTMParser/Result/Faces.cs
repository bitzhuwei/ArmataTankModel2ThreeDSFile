using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmadaTank.DTMParser.Result
{
    class Faces : Block
    {
        public FaceList faceListObj { get; set; }

        public override string ToString()
        {
            return string.Format("FaceList:{0}", faceListObj);
            //return base.ToString();
        }
    }
}
