using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Games;


namespace Tests
{
    [TestClass]
    public class TestsGames
    {
        [TestMethod]
        public void TestGameFactoryRockPaperScissorsGame()
        {
            WorkerTestGameFactory(SupportedGames.RockPaperScissors, typeof(RockPaperScissorsGame));
        }

        [TestMethod]
        public void TestGameFactoryRockPaperScissorsLizardSpockGame()
        {
            WorkerTestGameFactory(SupportedGames.RockPaperScissorsLizardSpock, typeof(RockPaperScissorsLizardSpockGame));
        }

        // Add a test that catched the exception
        
        private void WorkerTestGameFactory(SupportedGames selectedGameType, Type expectedGameType)
        {
            var NumberOfTurns = 3;
            var CreatedGame = Game.CreateGame(selectedGameType, NumberOfTurns);
            Assert.IsInstanceOfType(CreatedGame, expectedGameType);
        }
    }
}
