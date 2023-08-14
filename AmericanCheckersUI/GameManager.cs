namespace AmericanCheckersUI
{
    using System.Windows.Forms;
    using AmericanCheckersLogic;

    public class GameManager
    {
        private readonly FormGameSettings r_FormGameSettings;
        private FormGameBoard m_FormGameBoard;
        private Game m_Game;

        public GameManager()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            this.r_FormGameSettings = new FormGameSettings();
            Application.Run(r_FormGameSettings);
            if(this.r_FormGameSettings.InitiateGame)
            {
                this.initialaizeGame();
            }
        }

        private void initialaizeGame()
        {
            this.m_FormGameBoard = new FormGameBoard(this.r_FormGameSettings.BoardSize);
            this.m_FormGameBoard.InitializeNameLabels(this.r_FormGameSettings.Player1Name, this.r_FormGameSettings.Player2Name);
            this.m_Game = new Game(this.r_FormGameSettings.BoardSize, this.r_FormGameSettings.Player1Name, this.r_FormGameSettings.Player2Name, this.r_FormGameSettings.Player2IsAComputer);
            this.startNewGame();
            this.m_FormGameBoard.SendCoordinates += this.gameRound;
            this.m_FormGameBoard.CheckCapturingPawn += this.checkCapturingPawn;
            this.m_FormGameBoard.QuitGame += playerQuitGame;
            this.m_FormGameBoard.OnClose += this.gameOverFinalMessage;
            this.m_FormGameBoard.GameCannotContinue += this.currentPlayerCanMoveInTurn;
            Application.Run(this.m_FormGameBoard);
        }

        private void checkCapturingPawn(int[] i_PawnPosition)
        {
            if (this.m_FormGameBoard.SamePosition(this.m_FormGameBoard.CapturingPawnCell, i_PawnPosition))
            {
                this.m_FormGameBoard.MarkCapturingPawn(i_PawnPosition);
            }
            else
            {
                this.notCapturingPawnMessageBox();
            }
        }

        private void notCapturingPawnMessageBox()
        {
            MessageBox.Show(
                        "This is not the pawn you used before, please try again.",
                        "Invalid Move!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
        }

        private void gameRound(int[] i_OriginCell, int[] i_DestinationCell)
        {
            bool canContinueCapturing, computerCanMoveInTurn;

            if (this.m_Game.TakeTurn(i_OriginCell, i_DestinationCell, out canContinueCapturing))
            {
                this.m_FormGameBoard.UpdateBoard(this.m_Game.Board.CheckersBoard);
                if (canContinueCapturing)
                {
                    this.captureSequenceInitiated();
                }
                else
                {
                    this.m_FormGameBoard.UpdateCaptureSequenceStatus(false);
                    if (this.m_Game.Player2.IsAComputer)
                    {
                        this.m_FormGameBoard.SwitchCurrentPlayerIndicator();
                        this.m_Game.TakeTurnAI(out computerCanMoveInTurn);
                        if(computerCanMoveInTurn)
                        {
                            this.m_FormGameBoard.UpdateBoard(this.m_Game.Board.CheckersBoard);
                            this.m_FormGameBoard.SwitchCurrentPlayerIndicatorWhileGameIsNotOver();
                        }
                        else
                        {
                            this.gameEnded();
                        }
                    }
                    else
                    {
                        this.m_FormGameBoard.SwitchCurrentPlayerIndicatorWhileGameIsNotOver();
                    }
                }
            }
            else
            {
                this.invalidMoveMessageBox();
            }
        }

        private void currentPlayerCanMoveInTurn()
        {
            if(!this.m_Game.CurrentPlayerCanMakeAMove())
            {
                this.gameEnded();
            }
        }

        private void invalidMoveMessageBox()
        {
            MessageBox.Show(
            "Move is invalid, please try again.",
            "Invalid Move!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        }

        private void captureSequenceInitiated()
        {
            this.m_FormGameBoard.UpdateCaptureSequenceStatus(true);
            this.m_FormGameBoard.UpdateCapturingPawnCell();
            MessageBox.Show(
            "You can make another capture! please continue with the same pawn.",
            "Capturing Sequence!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation);
        }

        private void playerQuitGame()
        {
            string quitMessage;

            this.m_Game.QuitGame();
            this.m_FormGameBoard.UpdateScore(this.m_Game.Player1.Score, this.m_Game.Player2.Score);
            quitMessage = string.Format(
                @"{0} has quit the game, {1} won! (and got extra 5 points)
Current Scores:
{0}: {2}
{1}: {3}
Do you wish to play another game?",
                this.m_Game.PlayerInTurn.Name,
                this.m_Game.PlayerOpponent.Name,
                this.m_Game.PlayerInTurn.Score,
                this.m_Game.PlayerOpponent.Score);
            this.endGameMessageBox(quitMessage);
        }

        private void gameEnded()
        {
            string endMessage;

            this.m_Game.EndGame();
            this.m_FormGameBoard.UpdateScore(this.m_Game.Player1.Score, this.m_Game.Player2.Score);
            if (this.m_Game.Board.CalculateScore() == 0)
            {
                endMessage = string.Format(
                    @"The game resulted in a draw!
Current Scores:
{0}: {2}
{1}: {3}
Do you wish to play another game?",
                    this.m_Game.PlayerOpponent.Name,
                    this.m_Game.PlayerInTurn.Name,
                    this.m_Game.PlayerOpponent.Score,
                    this.m_Game.PlayerInTurn.Score);
            }
            else
            {
                endMessage = string.Format(
                    @"{0} has won!
Current Scores:
{0}: {2}
{1}: {3}
Do you wish to play another game?",
                    this.m_Game.PlayerOpponent.Name,
                    this.m_Game.PlayerInTurn.Name,
                    this.m_Game.PlayerOpponent.Score,
                    this.m_Game.PlayerInTurn.Score);
            }

            this.endGameMessageBox(endMessage);
        }

        private void endGameMessageBox(string i_MessageToShow)
        {
            if (MessageBox.Show(i_MessageToShow, "Game Stopped", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.startNewGame();
            }
            else
            {
                this.m_FormGameBoard.Close();
            }
        }

        private void startNewGame()
        {
            this.m_Game.StartGame();
            this.m_FormGameBoard.UpdateBoard(this.m_Game.Board.CheckersBoard);
            this.m_FormGameBoard.ResetLabelPlayersFonts();
        }

        private void gameOverFinalMessage()
        {
            string winnerName, finalMessage;

            if (this.m_Game.Player1.Score > this.m_Game.Player2.Score)
            {
                winnerName = this.m_Game.Player1.Name;
            }
            else if (this.m_Game.Player1.Score < this.m_Game.Player2.Score)
            {
                winnerName = this.m_Game.Player2.Name;
            }
            else
            {
                winnerName = "IT'S A DRAW";
            }

            finalMessage = string.Format(
                @"The final winner is: {0}!
Total Scorline:
{1}: {2}
{3}: {4}",
                winnerName,
                this.m_Game.Player1.Name,
                this.m_Game.Player1.Score,
                this.m_Game.Player2.Name,
                this.m_Game.Player2.Score);
            MessageBox.Show(finalMessage, "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
