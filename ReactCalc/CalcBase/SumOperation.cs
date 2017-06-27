﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc.Models
{
    public class SumOperation : Operation
    {
        public override long Code
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string Name
        {
            get
            {
                return "sum";
            }
        }

        public override double Execute(double[] args)
        {
            return args.Sum();
        }
    }
}