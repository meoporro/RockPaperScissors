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
            var CreatedGame = WorkerTestGameFactory(SupportedGames.RockPaperScissors);
            Assert.IsInstanceOfType(CreatedGame, typeof(RockPaperScissorsGame));
        }

        [TestMethod]
        public void TestGameFactoryRockPaperScissorsLizardSpockGame()
        {
            var CreatedGame = WorkerTestGameFactory(SupportedGames.RockPaperScissorsLizardSpock);
            Assert.IsInstanceOfType(CreatedGame, typeof(RockPaperScissorsLizardSpockGame));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGameFactoryNullArgument()
        {
            var CreatedGame = WorkerTestGameFactory(SupportedGames.Null);
        }

        #region Test the combination of two moves

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCaseRockRock()
        {
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 1);

            int Player1Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Rock");
            int Player2Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Rock");

            int TurnResult = RockPaperScissorsGame.DetermineTurnResult(Player1Move, Player2Move);

            Assert.AreEqual(0, TurnResult);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCaseRockPaper()
        {
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 1);

            int Player1Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Rock");
            int Player2Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Paper");

            int TurnResult = RockPaperScissorsGame.DetermineTurnResult(Player1Move, Player2Move);

            Assert.AreEqual(2, TurnResult);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameRockScissors()
        {
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 1);

            int Player1Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Rock");
            int Player2Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Scissors");
            
            int TurnResult = RockPaperScissorsGame.DetermineTurnResult(Player1Move, Player2Move);

            Assert.AreEqual(1, TurnResult);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCasePaperRock()
        {
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 1);

            int Player1Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Paper");
            int Player2Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Rock");

            int TurnResult = RockPaperScissorsGame.DetermineTurnResult(Player1Move, Player2Move);

            Assert.AreEqual(1, TurnResult);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCasePaperPaper()
        {
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 1);

            int Player1Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Paper");
            int Player2Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Paper");

            int TurnResult = RockPaperScissorsGame.DetermineTurnResult(Player1Move, Player2Move);

            Assert.AreEqual(0, TurnResult);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCasePaperScissors()
        {
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 1);

            int Player1Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Paper");
            int Player2Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Scissors");

            int TurnResult = RockPaperScissorsGame.DetermineTurnResult(Player1Move, Player2Move);

            Assert.AreEqual(2, TurnResult);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCaseScissorsRock()
        {
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 1);

            int Player1Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Scissors");
            int Player2Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Rock");

            int TurnResult = RockPaperScissorsGame.DetermineTurnResult(Player1Move, Player2Move);

            Assert.AreEqual(2, TurnResult);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCaseScissorsPaper()
        {
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 1);

            int Player1Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Scissors");
            int Player2Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Paper");

            int TurnResult = RockPaperScissorsGame.DetermineTurnResult(Player1Move, Player2Move);

            Assert.AreEqual(1, TurnResult);
        }

        [TestMethod]
        public void TestDetermineTurnResultRockPaperScissorsGameCaseScissorsScissors()
        {
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, 1);

            int Player1Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Scissors");
            int Player2Move = RockPaperScissorsGame.SupportedMoves.IndexOf("Scissors");

            int TurnResult = RockPaperScissorsGame.DetermineTurnResult(Player1Move, Player2Move);

            Assert.AreEqual(0, TurnResult);
        }

        #endregion Test the combination of two moves

        [TestMethod]
        public void TestPlayRockPaperScissorsGameCase0()
        {
            int NumberOfTurns = 3;
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, NumberOfTurns);

            int IndexRockMove = RockPaperScissorsGame.SupportedMoves.IndexOf("Rock");
            int IndexPaperMove = RockPaperScissorsGame.SupportedMoves.IndexOf("Paper");

            string ConsoleInputString = "";
            for (int Turn = 0; Turn < NumberOfTurns; Turn++)
            {
                ConsoleInputString = ConsoleInputString + IndexRockMove.ToString() + "\n" + IndexPaperMove.ToString() + "\n";
            }

            var ConsoleInput = new StringReader(ConsoleInputString);
            Console.SetIn(ConsoleInput);

            IGame GameToPlay = Game.CreateGame(SupportedGames.RockPaperScissors, NumberOfTurns);

            IPlayer Player1 = Player.CreatePlayer(SupportedPlayers.HumanPlayer, "TestPlayer1");
            IPlayer Player2 = Player.CreatePlayer(SupportedPlayers.HumanPlayer, "TestPlayer2");

            int GameResult = GameToPlay.Play(Player1, Player2);

            Assert.AreEqual(2, GameResult);
        }

        [TestMethod]
        public void TestPlayRockPaperScissorsGameCase0EarlyEnd()
        {
            int NumberOfTurns = 3;
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, NumberOfTurns);

            int IndexRockMove = RockPaperScissorsGame.SupportedMoves.IndexOf("Rock");
            int IndexPaperMove = RockPaperScissorsGame.SupportedMoves.IndexOf("Paper");

            string ConsoleInputString = "";
            for (int Turn = 0; Turn < NumberOfTurns - 1; Turn++)
            {
                ConsoleInputString = ConsoleInputString + IndexRockMove.ToString() + "\n" + IndexPaperMove.ToString() + "\n";
            }

            var ConsoleInput = new StringReader(ConsoleInputString);
            Console.SetIn(ConsoleInput);

            IGame GameToPlay = Game.CreateGame(SupportedGames.RockPaperScissors, NumberOfTurns);

            IPlayer Player1 = Player.CreatePlayer(SupportedPlayers.HumanPlayer, "TestPlayer1");
            IPlayer Player2 = Player.CreatePlayer(SupportedPlayers.HumanPlayer, "TestPlayer2");

            int GameResult = GameToPlay.Play(Player1, Player2);

            Assert.AreEqual(2, GameResult);
        }


        [TestMethod]
        public void TestPlayRockPaperScissorsGameCase1()
        {
            int NumberOfTurns = 3;
            var RockPaperScissorsGame = Game.CreateGame(SupportedGames.RockPaperScissors, NumberOfTurns);

            int IndexRockMove = RockPaperScissorsGame.SupportedMoves.IndexOf("Rock");
            int IndexPaperMove = RockPaperScissorsGame.SupportedMoves.IndexOf("Paper");
            int IndexScissorsMove = RockPaperScissorsGame.SupportedMoves.IndexOf("Scissors");

            string ConsoleInputString = IndexRockMove.ToString() + "\n" + IndexRockMove.ToString() + "\n"
                + IndexPaperMove.ToString() + "\n" + IndexPaperMove.ToString() + "\n"
                + IndexScissorsMove.ToString() + "\n" + IndexScissorsMove.ToString() + "\n";
            
            var ConsoleInput = new StringReader(ConsoleInputString);
            Console.SetIn(ConsoleInput);

            IGame GameToPlay = Game.CreateGame(SupportedGames.RockPaperScissors, NumberOfTurns);

            IPlayer Player1 = Player.CreatePlayer(SupportedPlayers.HumanPlayer, "TestPlayer1");
            IPlayer Player2 = Player.CreatePlayer(SupportedPlayers.HumanPlayer, "TestPlayer2");

            int GameResult = GameToPlay.Play(Player1, Player2);

            Assert.AreEqual(0, GameResult);
        }

        private IGame WorkerTestGameFactory(SupportedGames selectedGameType)
        {
            var NumberOfTurns = 3;
            return Game.CreateGame(selectedGameType, NumberOfTurns);
        }
    }
}
