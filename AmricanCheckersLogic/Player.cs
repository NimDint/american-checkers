namespace AmericanCheckersLogic
{
    using System;
    using System.Collections.Generic;

    public class Player
    {
        public Pawn.eSign Sign { get; }
        
        public string Name { get; }

        public int Score { get; set; }
        
        public bool IsAComputer { get; }
        
        public Board GameBoard { get; set; }
        
        public List<Pawn> PlayersPawns { get; set; }

        public Player(Pawn.eSign i_PlayerSign, string i_PlayerName, Board i_GameBoard, bool i_IsAComputer)
        {
            this.Sign = i_PlayerSign;
            this.Name = i_PlayerName;
            this.Score = 0;
            this.IsAComputer = i_IsAComputer;
            this.GameBoard = i_GameBoard;
            this.PlayersPawns = new List<Pawn>();
        }

        public bool CanNormalMoveInTurn()
        {
            bool canNormalMove = false;

            foreach (Pawn pawn in this.PlayersPawns)
            {
                foreach (int[] normalMove in pawn.NormalMovementPossibilities())
                {
                    if (this.GameBoard.IsAValidNormalMove(pawn, normalMove))
                    {
                        canNormalMove = true;
                        break;
                    }
                }

                if (canNormalMove)
                {
                    break;
                }
            }

            return canNormalMove;
        }

        public void LosePawn(Pawn i_CapturedPawn)
        {
            int[] oldPawnPosition = i_CapturedPawn.PositionOnBoard;

            this.GameBoard.CheckersBoard[oldPawnPosition[0], oldPawnPosition[1]] = null;
            this.PlayersPawns.Remove(i_CapturedPawn);
        }

        public void MovePawn(Pawn i_CurrentPawn, int[] i_NewPawnPosition)
        {
            int[] oldPawnPosition = i_CurrentPawn.PositionOnBoard;

            i_CurrentPawn.PositionOnBoard = i_NewPawnPosition;
            this.GameBoard.CheckersBoard[i_NewPawnPosition[0], i_NewPawnPosition[1]] = i_CurrentPawn;
            this.GameBoard.CheckersBoard[oldPawnPosition[0], oldPawnPosition[1]] = null;
            if (i_CurrentPawn.PawnSign.Equals(Pawn.eSign.XPawn) && i_NewPawnPosition[0] == 0)
            {
                i_CurrentPawn.SetPawnToKing();
            }
            else if (i_CurrentPawn.PawnSign.Equals(Pawn.eSign.OPawn) && i_NewPawnPosition[0] == this.GameBoard.BoardSize - 1)
            {
                i_CurrentPawn.SetPawnToKing();
            }
        }

        public bool CanCaptureInTurn()
        {
            bool canCapture = false;

            foreach (Pawn pawn in this.PlayersPawns)
            {
                foreach (int[] capturingMove in pawn.CapturingMovementPossibilities())
                {
                    if (this.GameBoard.IsAValidCapturingMove(pawn, capturingMove, out int[] notImportant))
                    {
                        notImportant = null;
                        canCapture = true;
                        break;
                    }
                }

                if (canCapture)
                {
                    break;
                }
            }

            return canCapture;
        }

        public List<Tuple<Pawn, int[], int[]>> CaptureInTurnPossibilities()
        {
            List<Tuple<Pawn, int[], int[]>> listOfPossibleCaptures = new List<Tuple<Pawn, int[], int[]>>();

            foreach (Pawn pawn in this.PlayersPawns)
            {
                foreach (int[] capturingMove in pawn.CapturingMovementPossibilities())
                {
                    if (this.GameBoard.IsAValidCapturingMove(pawn, capturingMove, out int[] capturedPawnPosition))
                    {
                        listOfPossibleCaptures.Add(new Tuple<Pawn, int[], int[]>(pawn, capturingMove, capturedPawnPosition));
                    }
                }
            }

            return listOfPossibleCaptures;
        }

        public List<Tuple<Pawn, int[]>> NormalMoveInTurnPossibilities()
        {
            List<Tuple<Pawn, int[]>> listOfPossibleNormalMoves = new List<Tuple<Pawn, int[]>>();

            foreach (Pawn pawn in this.PlayersPawns)
            {
                foreach (int[] normalMove in pawn.NormalMovementPossibilities())
                {
                    if (this.GameBoard.IsAValidNormalMove(pawn, normalMove))
                    {
                        listOfPossibleNormalMoves.Add(new Tuple<Pawn, int[]>(pawn, normalMove));
                    }
                }
            }

            return listOfPossibleNormalMoves;
        }

        public bool PawnCanCaptureInTurn(Pawn i_Pawn)
        {
            bool canCapture = false;

            foreach (int[] capturingMove in i_Pawn.CapturingMovementPossibilities())
            {
                if (this.GameBoard.IsAValidCapturingMove(i_Pawn, capturingMove, out int[] notImportant))
                {
                    notImportant = null;
                    canCapture = true;
                    break;
                }
            }

            return canCapture;
        }

        public bool CanMoveInTurn()
        {
            return this.CanCaptureInTurn() || this.CanNormalMoveInTurn();
        }

        public Pawn FindPawnByPosition(int[] i_PawnPosition)
        {
            Pawn pawnToReturn = null;

            foreach (Pawn pawn in this.PlayersPawns)
            {
                if (pawn.PositionOnBoard[0] == i_PawnPosition[0] && pawn.PositionOnBoard[1] == i_PawnPosition[1])
                {
                    pawnToReturn = pawn;
                    break;
                }
            }

            return pawnToReturn;
        }
    }
}