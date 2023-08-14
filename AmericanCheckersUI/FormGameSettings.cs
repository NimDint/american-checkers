namespace AmericanCheckersUI
{
    using System;
    using System.Windows.Forms;

    public partial class FormGameSettings : Form
    {
        internal int BoardSize { get; private set; }

        internal string Player1Name { get; private set; }

        internal string Player2Name { get; private set; }

        internal bool Player2IsAComputer { get; private set; } = true;

        internal bool InitiateGame { get; private set; } = false;

        public FormGameSettings()
        {
            InitializeComponent();
        }
   
        private void radioButton_CheckChanged(object sender, EventArgs e)
        {
            if (sender == this.radioButtonSize6)
            {
                this.BoardSize = 6;
            }
            else if (sender == this.radioButtonSize8)
            {
                this.BoardSize = 8;
            }
            else if (sender == this.radioButtonSize10)
            {
                this.BoardSize = 10;
            }
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            bool checkBoxIsChecked = (sender as CheckBox).Checked;

            this.textBoxPlayer2Name.Enabled = checkBoxIsChecked;
            this.Player2IsAComputer = !checkBoxIsChecked;
            if (checkBoxIsChecked)
            {
                this.textBoxPlayer2Name.Text = null;
            }
            else
            {
                this.textBoxPlayer2Name.Text = "[Computer]";
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            this.Player1Name = this.textBoxPlayer1Name.Text;
            this.Player2Name = this.textBoxPlayer2Name.Text;
            this.InitiateGame = true;
            this.Close();
        }
    }
}
