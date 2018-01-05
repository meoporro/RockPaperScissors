using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Games;
using Players;

namespace Tests
{
    [TestClass]
    public class Tests
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

        [TestMethod]
        public void TestPlayerFactoryHumanPlayer()
        {
            WorkerTestPlayerFactory(SupportedPlayers.HumanPlayer, typeof(HumanPlayer));
        }

        [TestMethod]
        public void TestPlayerFactoryComputerPlayer()
        {
            WorkerTestPlayerFactory(SupportedPlayers.ComputerPlayer, typeof(ComputerPlayer));
        }

        [TestMethod]
        public void TestPlayerFactoryStrategicComputerPlayer()
        {
            WorkerTestPlayerFactory(SupportedPlayers.StrategicComputerPlayer, typeof(StrategicComputerPlayer));
        }

        private void WorkerTestGameFactory(SupportedGames selectedGameType, Type expectedGameType)
        {
            var NumberOfTurns = 3;
            var CreatedGame = Game.CreateGame(selectedGameType, NumberOfTurns);
            Assert.IsInstanceOfType(CreatedGame, expectedGameType);
        }

        private void WorkerTestPlayerFactory(SupportedPlayers selectedPlayerType, Type playerType)
        {
            var CreatedPlayer = Player.CreatePlayer(selectedPlayerType);
            Assert.IsInstanceOfType(CreatedPlayer, playerType);
        }


    }
}
