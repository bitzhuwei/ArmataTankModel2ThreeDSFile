using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmadaTank.DTMParser.Result
{
    class MapChannel:Block
    {
        public int Order { get; set; }

        public TextureList textureListObj { get; set; }

        public override string ToString()
        {
            return string.Format("Order:{0}", Order);
            //return base.ToString();
        }
    }
}
