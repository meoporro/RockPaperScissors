using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Games;
using System.IO;
using Players;

namespace Tests
{
    [TestClass]
    public class TestsGames
    {
        [TestMethod]
        public void TestGameFactoryRockPaperScissorsGame()
        {
            var createdGame = WorkerTestGameFactory(SupportedGame.RockPaperScissors);
            Assert.IsInstanceOfType(createdGame, typeof(RockPaperScissorsGame));
        }

        [TestMethod]
        public void TestGameFactoryRockPaperScissorsLizardSpockGame()
        {
            var createdGame = WorkerTestGameFactory(SupportedGame.RockPaperScissorsLizardSpock);
            Assert.IsInstanceOfType(createdGame, typeof(RockPaperScissorsLizardSpockGame));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGameFactoryNullArgument()
        {
            var createdGame = WorkerTestGameFactory(SupportedGame.Null);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCaseRockRock()
        {
            int turnResult = WorkerTestDetermineTurnResultGame(SupportedGame.RockPaperScissors, "Rock", "Rock");
            Assert.AreEqual(0, turnResult);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCaseRockPaper()
        {
            int turnResult = WorkerTestDetermineTurnResultGame(SupportedGame.RockPaperScissors, "Rock", "Paper");
            Assert.AreEqual(2, turnResult);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameRockScissors()
        {
            int turnResult = WorkerTestDetermineTurnResultGame(SupportedGame.RockPaperScissors, "Rock", "Scissors");
            Assert.AreEqual(1, turnResult);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCasePaperRock()
        {
            int turnResult = WorkerTestDetermineTurnResultGame(SupportedGame.RockPaperScissors, "Paper", "Rock");
            Assert.AreEqual(1, turnResult);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCasePaperPaper()
        {
            int turnResult = WorkerTestDetermineTurnResultGame(SupportedGame.RockPaperScissors, "Paper", "Paper");
            Assert.AreEqual(0, turnResult);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCasePaperScissors()
        {
            int turnResult = WorkerTestDetermineTurnResultGame(SupportedGame.RockPaperScissors, "Paper", "Scissors");
            Assert.AreEqual(2, turnResult);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCaseScissorsRock()
        {
            int turnResult = WorkerTestDetermineTurnResultGame(SupportedGame.RockPaperScissors, "Scissors", "Rock");
            Assert.AreEqual(2, turnResult);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCaseScissorsPaper()
        {
            int turnResult = WorkerTestDetermineTurnResultGame(SupportedGame.RockPaperScissors, "Scissors", "Paper");
            Assert.AreEqual(1, turnResult);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCaseScissorsScissors()
        {
            int turnResult = WorkerTestDetermineTurnResultGame(SupportedGame.RockPaperScissors, "Scissors", "Scissors");
            Assert.AreEqual(0, turnResult);
        }

        [TestMethod]
        public void TestPlayRockPaperScissorsGameCase0()
        {
            int numberOfTurns = 3;
            string[] player1Strategy = { "Rock", "Rock", "Rock" };
            string[] player2Strategy = { "Paper", "Paper", "Paper" };

            int gameResult = WorkerTestPlayGame(SupportedGame.RockPaperScissors, numberOfTurns, player1Strategy, player2Strategy);

            Assert.AreEqual(2, gameResult);
        }

        [TestMethod]
        public void TestPlayRockPaperScissorsGameCase0EarlyEnd()
        {
            int numberOfTurns = 3;
            string[] player1Strategy = { "Rock", "Rock", "" };
            string[] player2Strategy = { "Paper", "Paper", "" };

            int gameResult = WorkerTestPlayGame(SupportedGame.RockPaperScissors, numberOfTurns, player1Strategy, player2Strategy);

            Assert.AreEqual(2, gameResult);
        }

        [TestMethod]
        public void TestPlayRockPaperScissorsGameCase1()
        {
            int numberOfTurns = 3;
            string[] player1Strategy = { "Rock", "Paper", "Scissors" };
            string[] player2Strategy = { "Rock", "Paper", "Scissors" };

            int gameResult = WorkerTestPlayGame(SupportedGame.RockPaperScissors, numberOfTurns, player1Strategy, player2Strategy);

            Assert.AreEqual(0, gameResult);
        }

        private IGame WorkerTestGameFactory(SupportedGame selectedGameType)
        {
            var NumberOfTurns = 3;
            return Game.CreateGame(selectedGameType, NumberOfTurns);
        }

        private int WorkerTestDetermineTurnResultGame(SupportedGame selectedGame, string player1Move, string player2Move)
        {
            var game = Game.CreateGame(selectedGame, 1);

            int Player1Move = game.SupportedMoves.IndexOf(player1Move);
            int Player2Move = game.SupportedMoves.IndexOf(player2Move);

            return game.DetermineTurnResult(Player1Move, Player2Move);
        }

        private int WorkerTestPlayGame(SupportedGame selectedGame, int numberOfTurns, string[] player1Strategy, string[] player2Strategy)
        {
            var game = Game.CreateGame(selectedGame, numberOfTurns);
            var supportedMoves = game.SupportedMoves;

            string consoleInputString = "";
            for (int turn = 0; turn < numberOfTurns; turn++)
            {
                consoleInputString = consoleInputString + supportedMoves.IndexOf(player1Strategy[turn]) + "\n" + supportedMoves.IndexOf(player2Strategy[turn]) + "\n";
            }
            var consoleInput = new StringReader(consoleInputString);
            Console.SetIn(consoleInput);

            IPlayer player1 = Player.CreatePlayer(SupportedPlayer.HumanPlayer, "TestPlayer1");
            IPlayer player2 = Player.CreatePlayer(SupportedPlayer.HumanPlayer, "TestPlayer2");

            return game.Play(player1, player2);
        }
    }
}
