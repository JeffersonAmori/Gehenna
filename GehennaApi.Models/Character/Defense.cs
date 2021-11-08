using System;
using System.Collections.Generic;
using System.Text;

namespace GehennaApi.Models.Character
{
    public class Defense
    {
        public int Value { get; set; }
        public int DexterityMod { get; set; }
        public int ArmorBonus { get; set; }
        public int ShieldBonus { get; set; }
        public int Other { get; set; }
        public Shield Shield { get; set; }
        public Armor Armor{ get; set; }

        public Defense()
        {
            Shield = new Shield();
            Armor = new Armor();
        }
    }
}
