namespace AmericanCheckersLogic
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class Game
    {
        public Board Board { get; }

        public Player Player1 { get; }

        public Player Player2 { get; }

        public Player PlayerInTurn { get; private set; }

        public Player PlayerOpponent { get; private set; }

        public Game(int i_BoardSize, string i_Player1Name, string i_Player2Name, bool i_IsAComputer)
        {
            this.Board = new Board(i_BoardSize);
            this.Player1 = new Player(Pawn.eSign.XPawn, i_Player1Name, this.Board, false);
            this.Player2 = new Player(Pawn.eSign.OPawn, i_Player2Name, this.Board, i_IsAComputer);
        }

        public void StartGame()
        {
            this.Board.EmptyBoard();
            this.Board.FillBoard();
            this.PlayerInTurn = this.Player1;
            this.PlayerOpponent = this.Player2;
            this.Player1.PlayersPawns = this.Board.GetPawnListBySign(this.Player1.Sign);
            this.Player2.PlayersPawns = this.Board.GetPawnListBySign(this.Player2.Sign);
        }

        public bool TakeTurn(int[] i_PlayerInTurnInputStart, int[] i_PlayerInTurnInputEnd, out bool o_CanContinueCaptureSequence)
        {
            int[] capturedPawnPosition = null;
            Pawn currentPawn = null, capturedPawn = null;
            bool turnTaken = false;

            o_CanContinueCaptureSequence = false;
            currentPawn = this.PlayerInTurn.FindPawnByPosition(i_PlayerInTurnInputStart);
            if (this.PlayerInTurn.CanCaptureInTurn())
            {
                if (currentPawn != null && this.Board.IsAValidCapturingMove(currentPawn, i_PlayerInTurnInputEnd, out capturedPawnPosition))
                {
                    this.PlayerInTurn.MovePawn(currentPawn, i_PlayerInTurnInputEnd);
                    capturedPawn = this.PlayerOpponent.FindPawnByPosition(capturedPawnPosition);
                    this.PlayerOpponent.LosePawn(capturedPawn);
                    o_CanContinueCaptureSequence = this.PlayerInTurn.PawnCanCaptureInTurn(currentPawn);
                    turnTaken = true;
                }
            }
            else if (currentPawn != null && this.Board.IsAValidNormalMove(currentPawn, i_PlayerInTurnInputEnd))
            {
                this.PlayerInTurn.MovePawn(currentPawn, i_PlayerInTurnInputEnd);
                turnTaken = true;
            }

            if (turnTaken && !o_CanContinueCaptureSequence)
            {
                this.switchPlayerInTurn();
            }

            return turnTaken;
        }

        public bool CurrentPlayerCanMakeAMove()
        {
            return this.PlayerInTurn.CanMoveInTurn();
        }

        public void TakeTurnAI(out bool o_ComputerCanMakeAMove)
        {
            Random pawnMovementRandom = new Random();
            int indexOfRandomMovment = 0;
            Pawn capturedPawn = null, pawnInPlay = null;
            int[] capturedPawnPosition = null;
            List<Tuple<Pawn, int[], int[]>> listOfPossibleCaptures = this.PlayerInTurn.CaptureInTurnPossibilities();
            List<Tuple<Pawn, int[]>> listOfPossibleNormalMoves;

            if (o_ComputerCanMakeAMove = this.PlayerInTurn.CanMoveInTurn())
            {
                Thread.Sleep(1000);
                if (listOfPossibleCaptures.Count != 0)
                {
                    indexOfRandomMovment = pawnMovementRandom.Next(listOfPossibleCaptures.Count);
                    pawnInPlay = listOfPossibleCaptures[indexOfRandomMovment].Item1;
                    this.PlayerInTurn.MovePawn(pawnInPlay, listOfPossibleCaptures[indexOfRandomMovment].Item2);
                    capturedPawn = this.PlayerOpponent.FindPawnByPosition(listOfPossibleCaptures[indexOfRandomMovment].Item3);
                    this.PlayerOpponent.LosePawn(capturedPawn);
                    while (this.PlayerInTurn.PawnCanCaptureInTurn(pawnInPlay))
                    {
                        indexOfRandomMovment = pawnMovementRandom.Next(pawnInPlay.CapturingMovementPossibilities().Count);
                        while (!this.Board.IsAValidCapturingMove(pawnInPlay, pawnInPlay.CapturingMovementPossibilities()[indexOfRandomMovment], out capturedPawnPosition))
                        {
                            indexOfRandomMovment = pawnMovementRandom.Next(pawnInPlay.CapturingMovementPossibilities().Count);
                        }

                        this.PlayerInTurn.MovePawn(pawnInPlay, pawnInPlay.CapturingMovementPossibilities()[indexOfRandomMovment]);
                        capturedPawn = this.PlayerOpponent.FindPawnByPosition(capturedPawnPosition);
                        this.PlayerOpponent.LosePawn(capturedPawn);
                    }
                }
                else
                {
                    listOfPossibleNormalMoves = this.PlayerInTurn.NormalMoveInTurnPossibilities();
                    indexOfRandomMovment = pawnMovementRandom.Next(listOfPossibleNormalMoves.Count);
                    pawnInPlay = listOfPossibleNormalMoves[indexOfRandomMovment].Item1;
                    this.PlayerInTurn.MovePawn(pawnInPlay, listOfPossibleNormalMoves[indexOfRandomMovment].Item2);
                }

                this.switchPlayerInTurn();
            }
        }

        public void QuitGame()
        {
            this.PlayerOpponent.Score += 5 + this.Board.CalculateScore();
        }

        public void EndGame()
        {
            this.PlayerOpponent.Score += this.Board.CalculateScore();
        }
        
        private void switchPlayerInTurn()
        {
            Player NextPlayerInTurn = this.PlayerOpponent;
            this.PlayerOpponent = this.PlayerInTurn;
            this.PlayerInTurn = NextPlayerInTurn;
        }
    }
}
