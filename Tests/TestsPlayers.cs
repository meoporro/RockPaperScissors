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
            IPlayer CreatedPlayer = WorkerTestPlayerFactory(SupportedPlayers.HumanPlayer);
            Assert.IsInstanceOfType(CreatedPlayer, typeof(HumanPlayer));
        }

        [TestMethod]
        public void TestPlayerFactoryComputerPlayer()
        {
            IPlayer CreatedPlayer = WorkerTestPlayerFactory(SupportedPlayers.ComputerPlayer);
            Assert.IsInstanceOfType(CreatedPlayer, typeof(ComputerPlayer));
        }

        [TestMethod]
        public void TestPlayerFactoryStrategicComputerPlayer()
        {
            IPlayer CreatedPlayer = WorkerTestPlayerFactory(SupportedPlayers.StrategicComputerPlayer);
            Assert.IsInstanceOfType(CreatedPlayer, typeof(StrategicComputerPlayer));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestPlayerFactoryNullArgument()
        {
            IPlayer CreatedPlayer = WorkerTestPlayerFactory(SupportedPlayers.Null);
            Assert.IsInstanceOfType(CreatedPlayer, typeof(StrategicComputerPlayer));
        }
        
        [TestMethod]
        public void TestHumanPlayerChooseMoveValue0()
        {
            int[] ConsoleInputMove = { 0 };
            int SelectedMove = WorkerHumanPlayerSelectMove(ConsoleInputMove);
            Assert.AreEqual(ConsoleInputMove.Last(), SelectedMove);
        }

        [TestMethod]
        public void TestHumanPlayerChooseMoveValue1()
        {
            int[] ConsoleInputMove = { 1 };
            int SelectedMove = WorkerHumanPlayerSelectMove(ConsoleInputMove);
            Assert.AreEqual(ConsoleInputMove.Last(), SelectedMove);
        }

        [TestMethod]
        public void TestHumanPlayerChooseMoveValue2()
        {
            int[] ConsoleInputMove = { 2 };
            int SelectedMove = WorkerHumanPlayerSelectMove(ConsoleInputMove);
            Assert.AreEqual(ConsoleInputMove.Last(), SelectedMove);
        }

        [TestMethod]
        public void TestHumanPlayerChooseMoveInvalidValue()
        {
            int[] ConsoleInputMove = { 4, 2 };
            int SelectedMove = WorkerHumanPlayerSelectMove(ConsoleInputMove);
            Assert.AreEqual(ConsoleInputMove.Last(), SelectedMove);
        }

        private IPlayer WorkerTestPlayerFactory(SupportedPlayers selectedPlayerType)
        {
            return Player.CreatePlayer(selectedPlayerType, "TestPlayer");
        }

        [TestMethod]
        public void TestComputerPlayerChooseMoveValue0()
        {
            int DeterministicMove = 0;
            int SelectedMove = WorkerComputerPlayerSelectMove(DeterministicMove);
            Assert.AreEqual(DeterministicMove, SelectedMove);
        }

        [TestMethod]
        public void TestComputerPlayerChooseMoveValue1()
        {
            int DeterministicMove = 1;
            int SelectedMove = WorkerComputerPlayerSelectMove(DeterministicMove);
            Assert.AreEqual(DeterministicMove, SelectedMove);
        }

        [TestMethod]
        public void TestComputerPlayerChooseMoveValue2()
        {
            int DeterministicMove = 2;
            int SelectedMove = WorkerComputerPlayerSelectMove(DeterministicMove);
            Assert.AreEqual(DeterministicMove, SelectedMove);
        }

        [TestMethod]
        public void TestComputerStrategicPlayerChooseMoveValue0()
        {
            int PreviousMove = 0;

            int SelectedMove = WorkerStrategicComputerPlayerSelectMove(PreviousMove);

            Assert.AreEqual(1, SelectedMove);
        }

        [TestMethod]
        public void TestComputerStrategicPlayerChooseMoveValue1()
        {
            int PreviousMove = 1;

            int SelectedMove = WorkerStrategicComputerPlayerSelectMove(PreviousMove);

            Assert.AreEqual(2, SelectedMove);
        }

        [TestMethod]
        public void TestComputerStrategicPlayerChooseMoveValue2()
        {
            int PreviousMove = 2;

            int SelectedMove = WorkerStrategicComputerPlayerSelectMove(PreviousMove);

            Assert.AreEqual(0, SelectedMove);
        }
        
        private int WorkerHumanPlayerSelectMove(int[] consoleInputMove)
        {
            string ConsoleInputString = consoleInputMove[0].ToString();
            for (int Index = 1; Index < consoleInputMove.Length; Index++)
            {
                ConsoleInputString = ConsoleInputString + "\n" + consoleInputMove[Index];
            }
            var ConsoleInput = new StringReader(ConsoleInputString);
            Console.SetIn(ConsoleInput);
            var HumanPlayer = Player.CreatePlayer(SupportedPlayers.HumanPlayer, "TestHumanPlayer");
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 3);

            var SupportedMoves = RockPaperScissorsGame.SupportedMoves;
            return HumanPlayer.SelectMove(SupportedMoves, -1);
        }

        private int WorkerComputerPlayerSelectMove(int deterministicMove)
        {
            var ComputerPlayer = Player.CreatePlayer(SupportedPlayers.ComputerPlayer, deterministicMove);
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 3);

            var SupportedMoves = RockPaperScissorsGame.SupportedMoves;
            return ComputerPlayer.SelectMove(SupportedMoves, -1);
        }

        private int WorkerStrategicComputerPlayerSelectMove(int previousMove)
        {
            var StrategicComputerPlayer = Player.CreatePlayer(SupportedPlayers.StrategicComputerPlayer, previousMove);
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 3);
            var SupportedMoves = RockPaperScissorsGame.SupportedMoves;

            return StrategicComputerPlayer.SelectMove(SupportedMoves, -1);
        }
    }
}
