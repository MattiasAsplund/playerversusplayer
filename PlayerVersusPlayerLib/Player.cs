using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerVersusPlayerLib
{
    public class Player
    {
        private string name;
        private int hp;
        private int damage;
        private int defense;

        public string Name { get => name; internal set => name = value; }
        public int Hp { get => hp; internal set => hp = value; }
        public int Damage { get => damage; internal set => damage = value; }
        public int Defense { get => defense; internal set => defense = value; }

        public Player(string name, int hp, int damage, int defense)
        {
            this.Name = name;
            this.Hp = hp;
            this.Damage = damage;
            this.Defense = defense;
        }

        internal bool IsDead()
        {
            return (Hp <= 0);
        }
    }
}
