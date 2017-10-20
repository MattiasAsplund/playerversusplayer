using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerVersusPlayerLib
{
    public class Player
    {
        public string name;
        public int hp;
        public int damage;
        public int defense;

        public Player(string name, int hp, int damage, int defense)
        {
            this.name = name;
            this.hp = hp;
            this.damage = damage;
            this.defense = defense;
        }

        internal bool IsDead()
        {
            return (hp <= 0);
        }
    }
}
