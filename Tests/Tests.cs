using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Games;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestGameFactoryRockPaperScissorsGame()
        {
            SupportedGames GameType = SupportedGames.RockPaperScissors;
            var NumberOfTurns = 3;
            var CreatedGame = Game.CreateGame(GameType, NumberOfTurns);
            Assert.IsInstanceOfType(CreatedGame, typeof(RockPaperScissorsGame));
        }

        [TestMethod]
        public void TestGameFactoryRockPaperScissorsLizardSpockGame()
        {
            SupportedGames GameType = SupportedGames.RockPaperScissorsLizardSpock;
            var NumberOfTurns = 3;
            var CreatedGame = Game.CreateGame(GameType, NumberOfTurns);
            Assert.IsInstanceOfType(CreatedGame, typeof(RockPaperScissorsLizardSpockGame));
        }

        // Add a test that catched the exception
    }
}
