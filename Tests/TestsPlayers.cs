using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Players;
using Games;
using System.Linq;

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

        [TestMethod]
        public void TestHumanPlayerChooseMoveValue0()
        {
            int ConsoleInputMove = 0;
            WorkerHumanPlayerSelectMove(ConsoleInputMove);
        }

        [TestMethod]
        public void TestHumanPlayerChooseMoveValue1()
        {
            int ConsoleInputMove = 1;
            WorkerHumanPlayerSelectMove(ConsoleInputMove);
        }

        [TestMethod]
        public void TestHumanPlayerChooseMoveValue2()
        {
            int ConsoleInputMove = 2;
            WorkerHumanPlayerSelectMove(ConsoleInputMove);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]        
        public void TestHumanPlayerChooseMoveInvalidValue()
        {
            int ConsoleInputMove = 4;
            WorkerHumanPlayerSelectMove(ConsoleInputMove);
        }

        private void WorkerTestPlayerFactory(SupportedPlayers selectedPlayerType, Type playerType)
        {
            var CreatedPlayer = Player.CreatePlayer(selectedPlayerType, "TestPlayer");
            Assert.IsInstanceOfType(CreatedPlayer, playerType);
        }

        [TestMethod]
        public void TestComputerPlayerChooseMoveValue0()
        {
            int DeterministicMove = 0;
            WorkerComputerPlayerSelectMove(DeterministicMove);
        }

        [TestMethod]
        public void TestComputerPlayerChooseMoveValue1()
        {
            int DeterministicMove = 1;
            WorkerComputerPlayerSelectMove(DeterministicMove);
        }

        [TestMethod]
        public void TestComputerPlayerChooseMoveValue2()
        {
            int DeterministicMove = 2;
            WorkerComputerPlayerSelectMove(DeterministicMove);
        }

        [TestMethod]
        public void TestComputerStrategicPlayerChooseMoveValue0()
        {
            int PreviousMove = 0;

            int SelectedMove = WorkerStrategicComputerPlayerSelectMove(PreviousMove);

            Assert.AreEqual(SelectedMove, 1);
        }

        [TestMethod]
        public void TestComputerStrategicPlayerChooseMoveValue1()
        {
            int PreviousMove = 1;

            int SelectedMove = WorkerStrategicComputerPlayerSelectMove(PreviousMove);

            Assert.AreEqual(SelectedMove, 2);
        }

        [TestMethod]
        public void TestComputerStrategicPlayerChooseMoveValue2()
        {
            int PreviousMove = 2;

            int SelectedMove = WorkerStrategicComputerPlayerSelectMove(PreviousMove);

            Assert.AreEqual(SelectedMove, 0);
        }
        
        private void WorkerHumanPlayerSelectMove(int consoleInputMove)
        {
            var ConsoleInput = new StringReader(consoleInputMove.ToString());
            Console.SetIn(ConsoleInput);
            var HumanPlayer = Player.CreatePlayer(SupportedPlayers.HumanPlayer, "TestHumanPlayer");
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 3);

            var SupportedMoves = RockPaperScissorsGame.SupportedMoves;
            int SelectedMove = HumanPlayer.SelectMove(SupportedMoves);

            Assert.AreEqual(consoleInputMove, SelectedMove);
        }

        private void WorkerComputerPlayerSelectMove(int deterministicMove)
        {
            var ComputerPlayer = Player.CreatePlayer(SupportedPlayers.ComputerPlayer, deterministicMove);
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 3);

            var SupportedMoves = RockPaperScissorsGame.SupportedMoves;
            int SelectedMove = ComputerPlayer.SelectMove(SupportedMoves);

            Assert.AreEqual(deterministicMove, SelectedMove);
        }

        private int WorkerStrategicComputerPlayerSelectMove(int previousMove)
        {
            var StrategicComputerPlayer = Player.CreatePlayer(SupportedPlayers.StrategicComputerPlayer, previousMove);
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 3);
            var SupportedMoves = RockPaperScissorsGame.SupportedMoves;

            return StrategicComputerPlayer.SelectMove(SupportedMoves);
        }
    }
}
