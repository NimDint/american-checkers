namespace AmericanCheckersUI
{
    public partial class FormGameBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelPlayer2Score = new System.Windows.Forms.Label();
            this.labelPlayer2Name = new System.Windows.Forms.Label();
            this.labelPlayer1Score = new System.Windows.Forms.Label();
            this.labelPlayer1Name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPlayer2Score
            // 
            this.labelPlayer2Score.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelPlayer2Score.AutoSize = true;
            this.labelPlayer2Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPlayer2Score.Location = new System.Drawing.Point(836, 28);
            this.labelPlayer2Score.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.labelPlayer2Score.Name = "labelPlayer2Score";
            this.labelPlayer2Score.Size = new System.Drawing.Size(18, 20);
            this.labelPlayer2Score.TabIndex = 7;
            this.labelPlayer2Score.Text = "0";
            // 
            // labelPlayer2Name
            // 
            this.labelPlayer2Name.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelPlayer2Name.AutoSize = true;
            this.labelPlayer2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPlayer2Name.Location = new System.Drawing.Point(586, 28);
            this.labelPlayer2Name.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.labelPlayer2Name.Name = "labelPlayer2Name";
            this.labelPlayer2Name.Size = new System.Drawing.Size(73, 20);
            this.labelPlayer2Name.TabIndex = 6;
            this.labelPlayer2Name.Text = "Player 2: ";
            // 
            // labelPlayer1Score
            // 
            this.labelPlayer1Score.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelPlayer1Score.AutoSize = true;
            this.labelPlayer1Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPlayer1Score.Location = new System.Drawing.Point(384, 28);
            this.labelPlayer1Score.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.labelPlayer1Score.Name = "labelPlayer1Score";
            this.labelPlayer1Score.Size = new System.Drawing.Size(18, 20);
            this.labelPlayer1Score.TabIndex = 5;
            this.labelPlayer1Score.Text = "0";
            // 
            // labelPlayer1Name
            // 
            this.labelPlayer1Name.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelPlayer1Name.AutoSize = true;
            this.labelPlayer1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPlayer1Name.Location = new System.Drawing.Point(133, 28);
            this.labelPlayer1Name.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.labelPlayer1Name.Name = "labelPlayer1Name";
            this.labelPlayer1Name.Size = new System.Drawing.Size(83, 20);
            this.labelPlayer1Name.TabIndex = 4;
            this.labelPlayer1Name.Text = "Player 1: ";
            // 
            // FormGameBoard
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(998, 631);
            this.Controls.Add(this.labelPlayer2Score);
            this.Controls.Add(this.labelPlayer2Name);
            this.Controls.Add(this.labelPlayer1Score);
            this.Controls.Add(this.labelPlayer1Name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormGameBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Board";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlayer2Score;
        private System.Windows.Forms.Label labelPlayer2Name;
        private System.Windows.Forms.Label labelPlayer1Score;
        private System.Windows.Forms.Label labelPlayer1Name;
    }
}