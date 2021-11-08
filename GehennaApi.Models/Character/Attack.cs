using System;
using System.Collections.Generic;
using System.Text;

namespace GehennaApi.Models.Character
{
    public class Attack
    {
        public string Name { get; set; }
        public string AttackTest { get; set; }
        public int Damage { get; set; }
        public int Critical { get; set; }
        public string Type { get; set; }
        public int Reach { get; set; }
    }
}
