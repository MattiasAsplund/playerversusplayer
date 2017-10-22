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
        public void Gentrit_Wins()
        {
            var gentrit = new Player("Gentrit", 100, 30, 50);
            var mattias = new Player("Mattias", 100, 20, 70);
            var sut = new PlayerVersusPlayerGame(gentrit, mattias);
            sut.AttackReport += (attacker, defender) =>
            {
                Output($"{attacker.Name} attacked {defender.Name}, resulting in HP:{defender.Hp} Def:{defender.Defense}");
            };
            while (!sut.GameOver)
            {
                var attackingPlayer = sut.NextPlayer();
                sut.AttackBy(attackingPlayer);
            }
            Output($"And the winner is: " + sut.Winner.Name);
            Assert.Equal("Gentrit", sut.Winner.Name);
        }

        private void Output(string message)
        {
            output.WriteLine(message);
            Console.WriteLine(message);
        }
    }
}
