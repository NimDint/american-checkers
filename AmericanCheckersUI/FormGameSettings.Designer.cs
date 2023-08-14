namespace AmericanCheckersUI
{
    public partial class FormGameSettings
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
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.radioButtonSize6 = new System.Windows.Forms.RadioButton();
            this.radioButtonSize8 = new System.Windows.Forms.RadioButton();
            this.radioButtonSize10 = new System.Windows.Forms.RadioButton();
            this.labelPlayers = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.textBoxPlayer1Name = new System.Windows.Forms.TextBox();
            this.textBoxPlayer2Name = new System.Windows.Forms.TextBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelBoardSize.Location = new System.Drawing.Point(10, 13);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(102, 20);
            this.labelBoardSize.TabIndex = 0;
            this.labelBoardSize.Text = "Board Size:";
            // 
            // radioButtonSize6
            // 
            this.radioButtonSize6.AutoSize = true;
            this.radioButtonSize6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonSize6.Location = new System.Drawing.Point(37, 47);
            this.radioButtonSize6.Name = "radioButtonSize6";
            this.radioButtonSize6.Size = new System.Drawing.Size(64, 24);
            this.radioButtonSize6.TabIndex = 1;
            this.radioButtonSize6.TabStop = true;
            this.radioButtonSize6.Text = "6 X 6";
            this.radioButtonSize6.UseVisualStyleBackColor = true;
            this.radioButtonSize6.CheckedChanged += new System.EventHandler(this.radioButton_CheckChanged);
            // 
            // radioButtonSize8
            // 
            this.radioButtonSize8.AutoSize = true;
            this.radioButtonSize8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonSize8.Location = new System.Drawing.Point(141, 47);
            this.radioButtonSize8.Name = "radioButtonSize8";
            this.radioButtonSize8.Size = new System.Drawing.Size(64, 24);
            this.radioButtonSize8.TabIndex = 2;
            this.radioButtonSize8.TabStop = true;
            this.radioButtonSize8.Text = "8 X 8";
            this.radioButtonSize8.UseVisualStyleBackColor = true;
            this.radioButtonSize8.CheckedChanged += new System.EventHandler(this.radioButton_CheckChanged);
            // 
            // radioButtonSize10
            // 
            this.radioButtonSize10.AutoSize = true;
            this.radioButtonSize10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonSize10.Location = new System.Drawing.Point(239, 47);
            this.radioButtonSize10.Name = "radioButtonSize10";
            this.radioButtonSize10.Size = new System.Drawing.Size(82, 24);
            this.radioButtonSize10.TabIndex = 3;
            this.radioButtonSize10.TabStop = true;
            this.radioButtonSize10.Text = "10 X 10";
            this.radioButtonSize10.UseVisualStyleBackColor = true;
            this.radioButtonSize10.CheckedChanged += new System.EventHandler(this.radioButton_CheckChanged);
            // 
            // labelPlayers
            // 
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPlayers.Location = new System.Drawing.Point(10, 92);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(72, 20);
            this.labelPlayers.TabIndex = 4;
            this.labelPlayers.Text = "Players:";
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPlayer1.Location = new System.Drawing.Point(33, 130);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(69, 20);
            this.labelPlayer1.TabIndex = 5;
            this.labelPlayer1.Text = "Player 1:";
            // 
            // checkBoxPlayer2
            // 
            this.checkBoxPlayer2.AutoSize = true;
            this.checkBoxPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBoxPlayer2.Location = new System.Drawing.Point(17, 160);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Size = new System.Drawing.Size(88, 24);
            this.checkBoxPlayer2.TabIndex = 7;
            this.checkBoxPlayer2.Text = "Player 2:";
            this.checkBoxPlayer2.UseVisualStyleBackColor = true;
            this.checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer2_CheckedChanged);
            // 
            // textBoxPlayer1Name
            // 
            this.textBoxPlayer1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxPlayer1Name.Location = new System.Drawing.Point(108, 127);
            this.textBoxPlayer1Name.Name = "textBoxPlayer1Name";
            this.textBoxPlayer1Name.Size = new System.Drawing.Size(213, 26);
            this.textBoxPlayer1Name.TabIndex = 6;
            this.textBoxPlayer1Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPlayer2Name
            // 
            this.textBoxPlayer2Name.Enabled = false;
            this.textBoxPlayer2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxPlayer2Name.Location = new System.Drawing.Point(108, 158);
            this.textBoxPlayer2Name.Name = "textBoxPlayer2Name";
            this.textBoxPlayer2Name.Size = new System.Drawing.Size(213, 26);
            this.textBoxPlayer2Name.TabIndex = 8;
            this.textBoxPlayer2Name.Text = "[Computer]";
            this.textBoxPlayer2Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonDone
            // 
            this.buttonDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonDone.Location = new System.Drawing.Point(255, 206);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(90, 33);
            this.buttonDone.TabIndex = 9;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // FormGameSettings
            // 
            this.AcceptButton = this.buttonDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 251);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.textBoxPlayer2Name);
            this.Controls.Add(this.textBoxPlayer1Name);
            this.Controls.Add(this.checkBoxPlayer2);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.labelPlayers);
            this.Controls.Add(this.radioButtonSize10);
            this.Controls.Add(this.radioButtonSize8);
            this.Controls.Add(this.radioButtonSize6);
            this.Controls.Add(this.labelBoardSize);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBoardSize;
        private System.Windows.Forms.RadioButton radioButtonSize6;
        private System.Windows.Forms.RadioButton radioButtonSize8;
        private System.Windows.Forms.RadioButton radioButtonSize10;
        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.CheckBox checkBoxPlayer2;
        private System.Windows.Forms.TextBox textBoxPlayer1Name;
        private System.Windows.Forms.TextBox textBoxPlayer2Name;
        private System.Windows.Forms.Button buttonDone;
    }
}