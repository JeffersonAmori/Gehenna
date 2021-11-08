using System;
using System.Collections.Generic;
using System.Text;

namespace GehennaApi.Models.Character
{
    public class Character
    {
        public Header Header { get; set; }
        public Stats Stats { get; set; }
        public Resource HP { get; set; }
        public Resource Mana { get; set; }
        public IEnumerable<Attack> Attacks { get; set; }
        public Defense Defense { get; set; }
        public IEnumerable<Trait> Traits { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public IEnumerable<Equipment> Equipments { get; set; }

        public Character()
        {
            Header = new Header();
            Stats = new Stats();
            HP = new Resource();
            Mana = new Resource();
            Attacks = new List<Attack>();
            Defense = new Defense();
            Traits = new List<Trait>();
            Skills = new List<Skill>();
            Equipments = new List<Equipment>();

        }
    }
}
