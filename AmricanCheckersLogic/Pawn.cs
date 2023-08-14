namespace AmericanCheckersLogic
{
    using System.Collections.Generic;

    public class Pawn
    {
        public enum eSign
        {
            OPawn = 'O',
            XPawn = 'X',
            OKing = 'Q',
            XKing = 'Z'
        }

        public enum eValue
        {
            Pawn = 1,
            King = 4,
        }

        public int PlayerID { get; }

        public int[] PositionOnBoard { get; set; }
        
        public eSign PawnSign { get; private set; }
        
        public eValue PawnValue { get; private set; }
        
        public bool IsAKing { get; private set; }

        public Pawn(int i_PlayerID, int i_BoardRowPosition, int i_BoardColPosition, eSign i_PawnSign)
        {
            this.PlayerID = i_PlayerID;
            this.PositionOnBoard = new int[2] { i_BoardRowPosition, i_BoardColPosition };
            this.PawnSign = i_PawnSign;
            this.PawnValue = eValue.Pawn;
            this.IsAKing = false;
        }

        public int BoardRowPosition
        {
            get { return this.PositionOnBoard[0]; }
            set { this.PositionOnBoard[0] = value; }
        }

        public int BoardColPosition
        {
            get { return this.PositionOnBoard[1]; }
            set { this.PositionOnBoard[1] = value; }
        }

        public void SetPawnToKing()
        {
            if (this.PawnSign.Equals(eSign.XPawn))
            {
                this.PawnSign = eSign.XKing;
            }
            else if (this.PawnSign.Equals(eSign.OPawn))
            {
                this.PawnSign = eSign.OKing;
            }

            this.PawnValue = eValue.King;
            this.IsAKing = true;
        }

        public List<int[]> NormalMovementPossibilities()
        {
            return this.movementPossibilities(false);
        }

        public List<int[]> CapturingMovementPossibilities()
        {
            return this.movementPossibilities(true);
        }

        private List<int[]> movementPossibilities(bool i_IsACapturingMove = false)
        {
            List<int[]> movementPossibilities = new List<int[]>();
            int sizeOfStep = 1;

            if (i_IsACapturingMove)
            {
                sizeOfStep = 2;
            }

            if (this.IsAKing)
            {
                movementPossibilities.Add(new int[2] { this.BoardRowPosition - sizeOfStep, this.BoardColPosition - sizeOfStep });
                movementPossibilities.Add(new int[2] { this.BoardRowPosition - sizeOfStep, this.BoardColPosition + sizeOfStep });
                movementPossibilities.Add(new int[2] { this.BoardRowPosition + sizeOfStep, this.BoardColPosition - sizeOfStep });
                movementPossibilities.Add(new int[2] { this.BoardRowPosition + sizeOfStep, this.BoardColPosition + sizeOfStep });
            }

            if (this.PawnSign.Equals(eSign.OPawn))
            {
                movementPossibilities.Add(new int[2] { this.BoardRowPosition + sizeOfStep, this.BoardColPosition - sizeOfStep });
                movementPossibilities.Add(new int[2] { this.BoardRowPosition + sizeOfStep, this.BoardColPosition + sizeOfStep });
            }
            else
            {
                movementPossibilities.Add(new int[2] { this.BoardRowPosition - sizeOfStep, this.BoardColPosition - sizeOfStep });
                movementPossibilities.Add(new int[2] { this.BoardRowPosition - sizeOfStep, this.BoardColPosition + sizeOfStep });
            }

            return movementPossibilities;
        }
    }
}
