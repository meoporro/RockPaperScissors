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
            WorkerTestGameFactory(SupportedGames.RockPaperScissors, typeof(RockPaperScissorsGame));
        }

        [TestMethod]
        public void TestGameFactoryRockPaperScissorsLizardSpockGame()
        {
            WorkerTestGameFactory(SupportedGames.RockPaperScissorsLizardSpock, typeof(RockPaperScissorsLizardSpockGame));
        }

        // Add a test that catches the exception

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCaseRockRock()
        {
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 1);

            int Player1Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Rock");
            int Player2Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Rock");

            int TurnResult = RockPaperScissorsGame.DetermineTurnResult(Player1Move, Player2Move);

            Assert.AreEqual(TurnResult, 0);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCaseRockPaper()
        {
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 1);

            int Player1Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Rock");
            int Player2Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Paper");

            int TurnResult = RockPaperScissorsGame.DetermineTurnResult(Player1Move, Player2Move);

            Assert.AreEqual(TurnResult, 2);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameRockScissors()
        {
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 1);

            int Player1Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Rock");
            int Player2Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Scissors");
            
            int TurnResult = RockPaperScissorsGame.DetermineTurnResult(Player1Move, Player2Move);

            Assert.AreEqual(TurnResult, 1);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCasePaperRock()
        {
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 1);

            int Player1Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Paper");
            int Player2Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Rock");

            int TurnResult = RockPaperScissorsGame.DetermineTurnResult(Player1Move, Player2Move);

            Assert.AreEqual(TurnResult, 1);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCasePaperPaper()
        {
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 1);

            int Player1Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Paper");
            int Player2Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Paper");

            int TurnResult = RockPaperScissorsGame.DetermineTurnResult(Player1Move, Player2Move);

            Assert.AreEqual(TurnResult, 0);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCasePaperScissors()
        {
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 1);

            int Player1Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Paper");
            int Player2Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Scissors");

            int TurnResult = RockPaperScissorsGame.DetermineTurnResult(Player1Move, Player2Move);

            Assert.AreEqual(TurnResult, 2);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCaseScissorsRock()
        {
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 1);

            int Player1Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Scissors");
            int Player2Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Rock");

            int TurnResult = RockPaperScissorsGame.DetermineTurnResult(Player1Move, Player2Move);

            Assert.AreEqual(TurnResult, 2);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCaseScissorsPaper()
        {
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 1);

            int Player1Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Scissors");
            int Player2Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Paper");

            int TurnResult = RockPaperScissorsGame.DetermineTurnResult(Player1Move, Player2Move);

            Assert.AreEqual(TurnResult, 1);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCaseScissorsScissors()
        {
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 1);

            int Player1Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Scissors");
            int Player2Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Scissors");

            int TurnResult = RockPaperScissorsGame.DetermineTurnResult(Player1Move, Player2Move);

            Assert.AreEqual(TurnResult, 0);
        }

        [TestMethod]
        public void TestPlayRockPaperScissorsGame()
        {
            int NumberOfTurns = 3;
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, NumberOfTurns);

            int IndexRockMove = RockPaperScissorsGame.SupportedMoves.IndexOf("Rock");
            int IndexPaperMove = RockPaperScissorsGame.SupportedMoves.IndexOf("Paper");

            string ConsoleInputString = "TestPlayer1\n" + "TestPlayer2\n";
            for (int Turn = 0; Turn < NumberOfTurns; Turn++)
            {
                ConsoleInputString += ConsoleInputString + IndexRockMove.ToString() + "\n" + IndexPaperMove.ToString() + "\n";
            }

            var ConsoleInput = new StringReader(ConsoleInputString);
            Console.SetIn(ConsoleInput);

            IGame GameToPlay = Game.CreateGame(SupportedGames.RockPaperScissors, NumberOfTurns);

            IPlayer Player1 = Player.CreatePlayer(SupportedPlayers.HumanPlayer);
            IPlayer Player2 = Player.CreatePlayer(SupportedPlayers.HumanPlayer);

            int GameResult = GameToPlay.Play(Player1, Player2);

            Assert.AreEqual(GameResult, 2);
        }

        private void WorkerTestGameFactory(SupportedGames selectedGameType, Type expectedGameType)
        {
            var NumberOfTurns = 3;
            var CreatedGame = Game.CreateGame(selectedGameType, NumberOfTurns);
            Assert.IsInstanceOfType(CreatedGame, expectedGameType);
        }
        
    }
}
