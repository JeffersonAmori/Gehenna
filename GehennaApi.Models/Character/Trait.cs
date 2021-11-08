using System;
using System.Collections.Generic;
using System.Text;

namespace GehennaApi.Models.Character
{
    public class Trait
    {
        public string Name { get; set; }
        public int Total { get; set; }
        public int HalfLevel { get; set; }
        public int AttributeModifier { get; set; }
        public int Train { get; set; }
        public int Other { get; set; }
    }
}
