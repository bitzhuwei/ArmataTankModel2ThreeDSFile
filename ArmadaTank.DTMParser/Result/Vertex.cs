﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmadaTank.DTMParser.Result
{
    public class Vertex
    {
        public int Order { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public override string ToString()
        {
            return string.Format("{0}:{1},{2},{3}", Order, X, Y, Z);
            //return base.ToString();
        }
    }
}
