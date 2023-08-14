namespace AmericanCheckersLogic
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class Board
    {
        public int BoardSize { get; }

        public Pawn[,] CheckersBoard { get; set; }

        public Board(int i_BoardSize = 8)
        {
            this.BoardSize = i_BoardSize;
            this.CheckersBoard = new Pawn[this.BoardSize, this.BoardSize];
        }

        public void FillBoard()
        {
            int middleOfBoard = (this.BoardSize / 2) - 1;

            for (int rowOfBoard = 0; rowOfBoard < this.BoardSize; rowOfBoard++)
            {
                if (rowOfBoard == middleOfBoard)
                {
                    rowOfBoard++;
                    continue;
                }

                for (int colOfBoard = 0; colOfBoard < this.BoardSize; colOfBoard++)
                {
                    if (rowOfBoard % 2 == 0 && colOfBoard % 2 != 0)
                    {
                        if (rowOfBoard < middleOfBoard)
                        {
                            this.CheckersBoard[rowOfBoard, colOfBoard] = new Pawn(2, rowOfBoard, colOfBoard, Pawn.eSign.OPawn);
                        }
                        else
                        {
                            this.CheckersBoard[rowOfBoard, colOfBoard] = new Pawn(1, rowOfBoard, colOfBoard, Pawn.eSign.XPawn);
                        }
                    }
                    else if (rowOfBoard % 2 != 0 && colOfBoard % 2 == 0)
                    {
                        if (rowOfBoard < middleOfBoard)
                        {
                            this.CheckersBoard[rowOfBoard, colOfBoard] = new Pawn(2, rowOfBoard, colOfBoard, Pawn.eSign.OPawn);
                        }
                        else
                        {
                            this.CheckersBoard[rowOfBoard, colOfBoard] = new Pawn(1, rowOfBoard, colOfBoard, Pawn.eSign.XPawn);
                        }
                    }
                }
            }
        }

        public int CalculateScore()
        {
            int totalScorePlayer1 = 0;
            int totalScorePlayer2 = 0;

            foreach (Pawn currentPawn in this.CheckersBoard)
            {
                if (currentPawn != null)
                {
                    if (currentPawn.PlayerID == 1)
                    {
                        totalScorePlayer1 += (int)currentPawn.PawnValue;
                    }
                    else if (currentPawn.PlayerID == 2)
                    {
                        totalScorePlayer2 += (int)currentPawn.PawnValue;
                    }
                }
            }

            return Math.Abs(totalScorePlayer1 - totalScorePlayer2); 
        }

        public bool IsAValidNormalMove(Pawn i_PawnInPlay, int[] i_WantedMove)
        {
            return this.isAValidMove(i_PawnInPlay, i_WantedMove, "NormalMovementPossibilities");
        }

        public bool IsAValidCapturingMove(Pawn i_PawnInPlay, int[] i_WantedMove, out int[] o_CapturedPawnPosition)
        {
            bool canCapture = true;
            int rowOfCapturedPawn = 0;
            int colOfCapturedPawn = 0;
            int capturedPawnPlayerID;
            bool isAValidMovement = this.isAValidMove(i_PawnInPlay, i_WantedMove, "CapturingMovementPossibilities");

            if (isAValidMovement)
            {
                if (i_WantedMove[0] - i_PawnInPlay.BoardRowPosition > 0)
                {
                    rowOfCapturedPawn = i_PawnInPlay.BoardRowPosition + 1;
                }
                else
                {
                    rowOfCapturedPawn = i_PawnInPlay.BoardRowPosition - 1;
                }

                if (i_WantedMove[1] - i_PawnInPlay.BoardColPosition > 0)
                {
                    colOfCapturedPawn = i_PawnInPlay.BoardColPosition + 1;
                }
                else
                {
                    colOfCapturedPawn = i_PawnInPlay.BoardColPosition - 1;
                }

                if (this.CheckersBoard[rowOfCapturedPawn, colOfCapturedPawn] == null)
                {
                    canCapture = false;
                }
                else
                {
                    capturedPawnPlayerID = this.CheckersBoard[rowOfCapturedPawn, colOfCapturedPawn].PlayerID;
                    if (capturedPawnPlayerID == i_PawnInPlay.PlayerID)
                    {
                        canCapture = false;
                    }
                }
            }

            o_CapturedPawnPosition = new int[2] { rowOfCapturedPawn, colOfCapturedPawn };

            return isAValidMovement && canCapture;
        }

        public List<Pawn> GetPawnListBySign(Pawn.eSign i_SignOfPawn)
        {
            List<Pawn> pawnListBySign = new List<Pawn>();

            foreach (Pawn pawn in this.CheckersBoard)
            {
                if (pawn != null && pawn.PawnSign.Equals(i_SignOfPawn))
                {
                    pawnListBySign.Add(pawn);
                }
            }

            return pawnListBySign;
        }

        public override string ToString()
        {
            StringBuilder boardToPrint = new StringBuilder();
            string lineBreaker = new string('=', (this.BoardSize * 4) + 1);
            string boardStrFormat;
            char pawnToAdd;

            for (int colOfBoard = 0; colOfBoard < this.BoardSize; colOfBoard++)
            {
                boardStrFormat = string.Format("   {0}", (char)('A' + colOfBoard));
                boardToPrint.Append(boardStrFormat);
            }

            boardToPrint.AppendLine();
            boardToPrint.AppendLine(" " + lineBreaker);
            for (int rowOfBoard = 0; rowOfBoard < this.BoardSize; rowOfBoard++)
            {
                boardStrFormat = string.Format("{0}|", (char)('a' + rowOfBoard));
                boardToPrint.Append(boardStrFormat);
                for (int colOfBoard = 0; colOfBoard < this.BoardSize; colOfBoard++)
                {
                    if (this.CheckersBoard[rowOfBoard, colOfBoard] == null)
                    {
                        pawnToAdd = ' ';
                    }
                    else
                    {
                        pawnToAdd = (char)this.CheckersBoard[rowOfBoard, colOfBoard].PawnSign;
                    }

                    boardStrFormat = string.Format(" {0} |", pawnToAdd);
                    boardToPrint.Append(boardStrFormat);
                }

                boardToPrint.AppendLine();
                boardToPrint.AppendLine(" " + lineBreaker);
            }

            return boardToPrint.ToString();
        }

        public void EmptyBoard()
        {
            for (int rowInBoard = 0; rowInBoard < this.BoardSize; rowInBoard++)
            {
                for (int colInBoard = 0; colInBoard < this.BoardSize; colInBoard++)
                {
                    this.CheckersBoard[rowInBoard, colInBoard] = null;
                }
            }
        }

        private bool isAValidMove(Pawn i_PawnInPlay, int[] i_WantedMove, string i_MovementPossibilitiesMethodStr)
        {
            bool validMove = false;
            bool moveIsPossible = true;
            bool moveIsInBoard = true;

            if (i_MovementPossibilitiesMethodStr.Equals("NormalMovementPossibilities"))
            {
                foreach (int[] movement in i_PawnInPlay.NormalMovementPossibilities())
                {
                    if (movement[0] == i_WantedMove[0] && movement[1] == i_WantedMove[1])
                    {
                        validMove = true;
                        break;
                    }
                }
            }

            if (i_MovementPossibilitiesMethodStr.Equals("CapturingMovementPossibilities"))
            {
                foreach (int[] movement in i_PawnInPlay.CapturingMovementPossibilities())
                {
                    if (movement[0] == i_WantedMove[0] && movement[1] == i_WantedMove[1])
                    {
                        validMove = true;
                        break;
                    }
                }
            }

            if (i_WantedMove[0] < 0 || i_WantedMove[0] >= this.BoardSize || i_WantedMove[1] < 0 || i_WantedMove[1] >= this.BoardSize)
            {
                moveIsInBoard = false;
            }
            else if (this.CheckersBoard[i_WantedMove[0], i_WantedMove[1]] != null)
            {
                moveIsPossible = false;
            }

            return validMove && moveIsPossible && moveIsInBoard;
        }
    }
}
