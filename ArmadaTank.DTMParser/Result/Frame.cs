using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmadaTank.DTMParser.Result
{
    class Frame:Block
    {
        public int Order { get; set; }

        public FrameContentItemList frameContentItemListObj { get; set; }

        public override string ToString()
        {
            return string.Format("order:{0}", Order);
            //return base.ToString();
        }
    }
}
