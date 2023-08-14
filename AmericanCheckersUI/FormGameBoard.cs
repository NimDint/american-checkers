namespace AmericanCheckersUI
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using AmericanCheckersLogic;

    public partial class FormGameBoard : Form
    {
        private readonly Button[,] m_BoardCells;
        private readonly int r_BoardSize;
        private int[] m_OriginCell;
        private int[] m_DestinationCell;
        private bool m_ClickedOnce = false;
        private bool m_InACaptureSequence = false;

        public int[] CapturingPawnCell { get; private set; }

        public event Action<int[], int[]> SendCoordinates;

        public event Action<int[]> CheckCapturingPawn;

        public event Action QuitGame;

        public event Action OnClose;

        public event Action GameCannotContinue;

        public FormGameBoard(int i_BoardSize)
        {
            InitializeComponent();
            this.m_BoardCells = new Button[i_BoardSize, i_BoardSize];
            this.r_BoardSize = i_BoardSize;
            this.createButtonsLayout();
        }

        internal void UpdateBoard(Pawn[,] i_GameBoard)
        {
            for (int row = 0; row < this.r_BoardSize; row++)
            {
                for (int col = 0; col < this.r_BoardSize; col++)
                {
                    if (i_GameBoard[row, col] != null)
                    {
                        this.m_BoardCells[row, col].BackgroundImageLayout = ImageLayout.Stretch; 
                        switch (((char)i_GameBoard[row, col].PawnSign).ToString())
                        {
                            case "X":
                                this.m_BoardCells[row, col].BackgroundImage = Properties.Resources.white_man;
                                break;
                            case "O":
                                this.m_BoardCells[row, col].BackgroundImage = Properties.Resources.black_man;
                                break;
                            case "Z":
                                this.m_BoardCells[row, col].BackgroundImage = Properties.Resources.white_cro;
                                break;
                            case "Q":
                                this.m_BoardCells[row, col].BackgroundImage = Properties.Resources.black_cro;
                                break;
                        }
                    }
                    else
                    {
                        this.m_BoardCells[row, col].BackgroundImage = null;
                    }
                }
            }

            this.Update();
        }

        internal void MarkCapturingPawn(int[] i_PawnPosition)
        {
            this.m_ClickedOnce = true;
            this.m_OriginCell = i_PawnPosition;
            this.m_BoardCells[this.m_OriginCell[0], this.m_OriginCell[1]].BackColor = Color.LightBlue;
        }

        internal void InitializeNameLabels(string i_Player1Name, string i_Player2Name)
        {
            this.labelPlayer1Name.Text = string.Format("{0}:", i_Player1Name);
            this.labelPlayer2Name.Text = string.Format("{0}:", i_Player2Name);
            this.labelPlayer1Score.Left = (this.Width / 2) - 20 - this.labelPlayer1Score.Width;
            this.labelPlayer2Name.Left = this.Width / 2;
            this.labelPlayer1Name.Left = this.labelPlayer1Score.Left - 3 - this.labelPlayer1Name.Width;
            this.labelPlayer2Score.Left = this.labelPlayer2Name.Right + 3;
        }

        internal void UpdateCapturingPawnCell()
        {
            this.CapturingPawnCell = this.m_DestinationCell;
        }

        internal void UpdateCaptureSequenceStatus(bool i_CaptureStatus)
        {
            this.m_InACaptureSequence = i_CaptureStatus;
        }

        internal void SwitchCurrentPlayerIndicatorWhileGameIsNotOver()
        {
            this.SwitchCurrentPlayerIndicator();
            if (this.GameCannotContinue != null)
            {
                this.GameCannotContinue.Invoke();
            }
        }

        internal void SwitchCurrentPlayerIndicator()
        {
            Font player1Font = this.labelPlayer1Name.Font;

            this.labelPlayer1Name.Font = this.labelPlayer2Name.Font;
            this.labelPlayer2Name.Font = player1Font;
            this.Update();
        }

        internal void UpdateScore(int i_Player1Score, int i_Player2Score)
        {
            this.labelPlayer1Score.Text = i_Player1Score.ToString();
            this.labelPlayer2Score.Text = i_Player2Score.ToString();
        }

        internal bool SamePosition(int[] i_FirstPosition, int[] i_SecondPosition)
        {
            return i_FirstPosition[0] == i_SecondPosition[0] && i_FirstPosition[1] == i_SecondPosition[1];
        }

        internal void ResetLabelPlayersFonts()
        {
            this.labelPlayer1Name.Font = new Font(this.labelPlayer1Name.Font.FontFamily, 12, FontStyle.Bold);
            this.labelPlayer2Name.Font = new Font(this.labelPlayer2Name.Font.FontFamily, 12, FontStyle.Regular);
        }

        protected override void OnClosed(EventArgs e)
        {
            if (this.OnClose != null)
            {
                this.OnClose.Invoke();
            }

            base.OnClosed(e);
        }

        private void createButtonsLayout()
        {
            Button currentButton;

            for (int row = 0; row < this.r_BoardSize; row++)
            {
                for (int col = 0; col < this.r_BoardSize; col++)
                {
                    currentButton = new Button
                    {
                        Width = 50,
                        Height = 50
                    };

                    if (col > 0)
                    {
                        currentButton.Top = this.m_BoardCells[row, col - 1].Top;
                        currentButton.Left = this.m_BoardCells[row, col - 1].Right;
                    }
                    else if (row > 0)
                    {
                        currentButton.Top = this.m_BoardCells[row - 1, col].Bottom;
                        currentButton.Left = this.m_BoardCells[row - 1, col].Left;
                    }
                    else
                    {
                        currentButton.Top = this.labelPlayer1Name.Bottom + 10;
                    }

                    if ((row % 2 == 0 && col % 2 == 0) || (row % 2 != 0 && col % 2 != 0))
                    {
                        currentButton.Enabled = false;
                        currentButton.BackColor = Color.FromArgb(128, 64, 0);
                    }
                    else
                    {
                        currentButton.BackColor = Color.FromArgb(255, 224, 192);
                    }

                    currentButton.Tag = new int[] { row, col };
                    currentButton.Click += ButtonCell_OnClick;
                    this.m_BoardCells[row, col] = currentButton;
                    this.Controls.Add(currentButton);
                }
            }

            this.createQuitButton();
        }

        private void createQuitButton()
        {
            Button buttonQuit = new Button();

            buttonQuit.Left = (this.Width - buttonQuit.Width) / 2;
            buttonQuit.Top = this.m_BoardCells[this.r_BoardSize - 1, 0].Bottom + 5;
            buttonQuit.Font = this.labelPlayer1Name.Font;
            buttonQuit.BackColor = Color.DarkRed;
            buttonQuit.Text = "Quit";
            buttonQuit.ForeColor = Color.White;
            buttonQuit.AutoSize = true;
            buttonQuit.Click += this.buttonQuit_Click;
            this.Controls.Add(buttonQuit);
        }

        private void ButtonCell_OnClick(object sender, EventArgs e)
        {
            Button buttonClicked = sender as Button;
            int[] senderPosition = buttonClicked.Tag as int[];

            if (this.m_InACaptureSequence && !this.m_ClickedOnce)
            {
                if (this.CheckCapturingPawn != null)
                {
                    this.CheckCapturingPawn.Invoke(senderPosition);
                }
            }
            else
            {
                if (!this.m_ClickedOnce)
                {
                    this.m_OriginCell = senderPosition;
                    this.m_ClickedOnce = true;
                    buttonClicked.BackColor = Color.LightBlue;
                }
                else if (this.SamePosition(senderPosition, this.m_OriginCell))
                {
                    this.m_ClickedOnce = false;
                    buttonClicked.BackColor = Color.FromArgb(255, 224, 192);
                }
                else
                {
                    this.m_DestinationCell = senderPosition;
                    this.m_ClickedOnce = false;
                    this.m_BoardCells[m_OriginCell[0], m_OriginCell[1]].BackColor = Color.FromArgb(255, 224, 192);
                    this.m_BoardCells[m_DestinationCell[0], m_DestinationCell[1]].BackColor = Color.FromArgb(255, 224, 192);
                    if (this.SendCoordinates != null)
                    {
                        this.SendCoordinates.Invoke(this.m_OriginCell, this.m_DestinationCell);
                    }
                }
            }
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            if (this.QuitGame != null)
            {
                this.QuitGame.Invoke();
            }
        }
    }
}
