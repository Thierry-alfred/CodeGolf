namespace GolfCode
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtChaine = new TextBox();
            label1 = new Label();
            label2 = new Label();
            lblresult = new Label();
            lblEvaluer = new Label();
            SuspendLayout();
            // 
            // txtChaine
            // 
            txtChaine.Location = new Point(47, 104);
            txtChaine.Name = "txtChaine";
            txtChaine.Size = new Size(725, 27);
            txtChaine.TabIndex = 0;
            txtChaine.KeyDown += txtChaine_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(315, 31);
            label1.Name = "label1";
            label1.Size = new Size(151, 35);
            label1.TabIndex = 1;
            label1.Text = "CODE GOLF";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 81);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 2;
            label2.Text = "Chaîne:";
            // 
            // lblresult
            // 
            lblresult.AutoSize = true;
            lblresult.Location = new Point(47, 197);
            lblresult.Name = "lblresult";
            lblresult.Size = new Size(0, 20);
            lblresult.TabIndex = 3;
            // 
            // lblEvaluer
            // 
            lblEvaluer.AutoSize = true;
            lblEvaluer.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblEvaluer.Location = new Point(51, 268);
            lblEvaluer.Name = "lblEvaluer";
            lblEvaluer.Size = new Size(0, 35);
            lblEvaluer.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(829, 397);
            Controls.Add(lblEvaluer);
            Controls.Add(lblresult);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtChaine);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CODE GOLF";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtChaine;
        private Label label1;
        private Label label2;
        private Label lblresult;
        private Label lblEvaluer;
    }
}
