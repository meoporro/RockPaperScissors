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
            IPlayer createdPlayer = WorkerTestPlayerFactory(SupportedPlayer.HumanPlayer);
            Assert.IsInstanceOfType(createdPlayer, typeof(HumanPlayer));
        }

        [TestMethod]
        public void TestPlayerFactoryComputerPlayer()
        {
            IPlayer createdPlayer = WorkerTestPlayerFactory(SupportedPlayer.ComputerPlayer);
            Assert.IsInstanceOfType(createdPlayer, typeof(ComputerPlayer));
        }

        [TestMethod]
        public void TestPlayerFactoryStrategicComputerPlayer()
        {
            IPlayer createdPlayer = WorkerTestPlayerFactory(SupportedPlayer.StrategicComputerPlayer);
            Assert.IsInstanceOfType(createdPlayer, typeof(StrategicComputerPlayer));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestPlayerFactoryNullArgument()
        {
            IPlayer createdPlayer = WorkerTestPlayerFactory(SupportedPlayer.Null);
            Assert.IsInstanceOfType(createdPlayer, typeof(StrategicComputerPlayer));
        }
        
        [TestMethod]
        public void TestHumanPlayerChooseMoveValue0()
        {
            int[] consoleInputMove = { 0 };
            int selectedMove = WorkerHumanPlayerSelectMove(consoleInputMove);
            Assert.AreEqual(consoleInputMove.Last(), selectedMove);
        }

        [TestMethod]
        public void TestHumanPlayerChooseMoveValue1()
        {
            int[] consoleInputMove = { 1 };
            int selectedMove = WorkerHumanPlayerSelectMove(consoleInputMove);
            Assert.AreEqual(consoleInputMove.Last(), selectedMove);
        }

        [TestMethod]
        public void TestHumanPlayerChooseMoveValue2()
        {
            int[] consoleInputMove = { 2 };
            int selectedMove = WorkerHumanPlayerSelectMove(consoleInputMove);
            Assert.AreEqual(consoleInputMove.Last(), selectedMove);
        }

        [TestMethod]
        public void TestHumanPlayerChooseMoveInvalidValue()
        {
            int[] consoleInputMove = { 4, 2 };
            int selectedMove = WorkerHumanPlayerSelectMove(consoleInputMove);
            Assert.AreEqual(consoleInputMove.Last(), selectedMove);
        }

        [TestMethod]
        public void TestComputerPlayerChooseMoveValue0()
        {
            int deterministicMove = 0;
            int selectedMove = WorkerComputerPlayerSelectMove(deterministicMove);
            Assert.AreEqual(deterministicMove, selectedMove);
        }

        [TestMethod]
        public void TestComputerPlayerChooseMoveValue1()
        {
            int deterministicMove = 1;
            int selectedMove = WorkerComputerPlayerSelectMove(deterministicMove);
            Assert.AreEqual(deterministicMove, selectedMove);
        }

        [TestMethod]
        public void TestComputerPlayerChooseMoveValue2()
        {
            int deterministicMove = 2;
            int selectedMove = WorkerComputerPlayerSelectMove(deterministicMove);
            Assert.AreEqual(deterministicMove, selectedMove);
        }

        [TestMethod]
        public void TestComputerStrategicPlayerChooseMoveValue0()
        {
            int previousMove = 0;
            int selectedMove = WorkerStrategicComputerPlayerSelectMove(previousMove);
            Assert.AreEqual(1, selectedMove);
        }

        [TestMethod]
        public void TestComputerStrategicPlayerChooseMoveValue1()
        {
            int previousMove = 1;
            int selectedMove = WorkerStrategicComputerPlayerSelectMove(previousMove);
            Assert.AreEqual(2, selectedMove);
        }

        [TestMethod]
        public void TestComputerStrategicPlayerChooseMoveValue2()
        {
            int previousMove = 2;
            int selectedMove = WorkerStrategicComputerPlayerSelectMove(previousMove);
            Assert.AreEqual(0, selectedMove);
        }
        
        private IPlayer WorkerTestPlayerFactory(SupportedPlayer selectedPlayerType)
        {
            return Player.CreatePlayer(selectedPlayerType, "TestPlayer");
        }

        private int WorkerHumanPlayerSelectMove(int[] consoleInputMove)
        {
            string consoleInputString = consoleInputMove[0].ToString();
            for (int index = 1; index < consoleInputMove.Length; index++)
            {
                consoleInputString = consoleInputString + "\n" + consoleInputMove[index];
            }
            var consoleInput = new StringReader(consoleInputString);
            Console.SetIn(consoleInput);
            var humanPlayer = Player.CreatePlayer(SupportedPlayer.HumanPlayer, "TestHumanPlayer");
            var rockPaperScissorsGame = Game.CreateGame(SupportedGame.RockPaperScissors, 3);

            var supportedMoves = rockPaperScissorsGame.SupportedMoves;
            return humanPlayer.SelectMove(supportedMoves, -1);
        }
        
        private int WorkerComputerPlayerSelectMove(int deterministicMove)
        {
            var computerPlayer = Player.CreatePlayer(SupportedPlayer.ComputerPlayer, deterministicMove);
            var rockPaperScissorsGame = Game.CreateGame(SupportedGame.RockPaperScissors, 3);

            var supportedMoves = rockPaperScissorsGame.SupportedMoves;
            return computerPlayer.SelectMove(supportedMoves, -1);
        }

        private int WorkerStrategicComputerPlayerSelectMove(int previousMove)
        {
            var strategicComputerPlayer = Player.CreatePlayer(SupportedPlayer.StrategicComputerPlayer, previousMove);
            var rockPaperScissorsGame = Game.CreateGame(SupportedGame.RockPaperScissors, 3);
            var supportedMoves = rockPaperScissorsGame.SupportedMoves;

            return strategicComputerPlayer.SelectMove(supportedMoves, -1);
        }
    }
}
