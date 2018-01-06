using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Players;

namespace Tests
{
    [TestClass]
    public class TestsPlayers
    {
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

        private void WorkerTestPlayerFactory(SupportedPlayers selectedPlayerType, Type playerType)
        {
            var CreatedPlayer = Player.CreatePlayer(selectedPlayerType);
            Assert.IsInstanceOfType(CreatedPlayer, playerType);
        }
    }
}
