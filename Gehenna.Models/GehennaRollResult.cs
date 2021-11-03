﻿using System.Collections.Generic;

namespace Gehenna.Models
{
    public class GehennaRollResult
    {
        public int ResultType { get; set; }
        public double Value { get; set; }
        public List<GehennaDieResult> Values { get; set; }
        public int NumRolls { get; set; }
        public string Expression { get; set; }
    }

}
