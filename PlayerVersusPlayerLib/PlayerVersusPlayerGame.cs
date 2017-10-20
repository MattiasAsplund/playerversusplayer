using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayerVersusPlayerLib
{
    public delegate void AttackReportHandler(Player attacker, Player defender);
    public class PlayerVersusPlayerGame
    {
        private List<Player> _players = new List<Player>();
        private int playerPos = 1;
        public event AttackReportHandler AttackReport;
        public PlayerVersusPlayerGame(Player player1, Player player2)
        {
            _players.Add(player1);
            _players.Add(player2);
        }

        public bool GameOver {
            get
            {
                return _players[0].IsDead() || _players[1].IsDead();
            }
        }

        public Player Winner
        {
            get
            {
                return _players.OrderByDescending(p => p.hp).First();
            }
        }

        public void Attack(Player attacker, Player defender)
        {
            defender.defense -= attacker.damage;
            if (defender.defense < 0)
            {
                defender.hp += defender.defense;
                defender.defense = 0;
            }
            AttackReport?.Invoke(attacker, defender);
        }

        public Player NextPlayer()
        {
            playerPos = (playerPos + 1) % 2;
            return _players[playerPos];
        }
    }
}
