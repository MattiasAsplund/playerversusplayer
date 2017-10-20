using PlayerVersusPlayerLib;
using System;
using Xunit;
using Xunit.Abstractions;

namespace PlayerVersusPlayer.Tests
{
    public class PlayerVersusPlayerTests
    {
        private readonly ITestOutputHelper output;

        public PlayerVersusPlayerTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void Winner_Depletes_Enemy()
        {
            var player1 = new Player("Player One", 100, 30, 50);
            var player2 = new Player("Player Two", 100, 20, 70);
            var sut = new PlayerVersusPlayerGame(player1, player2);
            sut.AttackReport += (attacker, defender) =>
            {
                output.WriteLine($"{attacker.name} attacked {defender.name}, resulting in HP:{defender.hp} Def:{defender.defense}");
            };
            while (!sut.GameOver)
            {
                var player = sut.NextPlayer();
                sut.Attack(player, (player.name == player1.name) ? player2 : player1);
            }
            output.WriteLine($"And the winner is: " + sut.Winner.name);
        }
    }
}
