namespace TrafficSim
{
    partial class SimForm
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
            this.MenuButton = new System.Windows.Forms.Button();
            this.CycleButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CyclesBox = new System.Windows.Forms.TextBox();
            this.CycleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MenuButton
            // 
            this.MenuButton.Location = new System.Drawing.Point(723, 719);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(97, 25);
            this.MenuButton.TabIndex = 0;
            this.MenuButton.Text = "Back to Menu";
            this.MenuButton.UseVisualStyleBackColor = true;
            this.MenuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // CycleButton
            // 
            this.CycleButton.Location = new System.Drawing.Point(12, 717);
            this.CycleButton.Name = "CycleButton";
            this.CycleButton.Size = new System.Drawing.Size(97, 25);
            this.CycleButton.TabIndex = 1;
            this.CycleButton.Text = "Run Cycles";
            this.CycleButton.UseVisualStyleBackColor = true;
            this.CycleButton.Click += new System.EventHandler(this.CycleButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 644);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // CyclesBox
            // 
            this.CyclesBox.Location = new System.Drawing.Point(15, 691);
            this.CyclesBox.Name = "CyclesBox";
            this.CyclesBox.Size = new System.Drawing.Size(94, 20);
            this.CyclesBox.TabIndex = 3;
            this.CyclesBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CycleLabel
            // 
            this.CycleLabel.AutoSize = true;
            this.CycleLabel.Location = new System.Drawing.Point(18, 672);
            this.CycleLabel.Name = "CycleLabel";
            this.CycleLabel.Size = new System.Drawing.Size(93, 13);
            this.CycleLabel.TabIndex = 4;
            this.CycleLabel.Text = "Number of Cycles:";
            // 
            // SimForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 750);
            this.Controls.Add(this.CycleLabel);
            this.Controls.Add(this.CyclesBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CycleButton);
            this.Controls.Add(this.MenuButton);
            this.Name = "SimForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SimForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MenuButton;
        private System.Windows.Forms.Button CycleButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CyclesBox;
        private System.Windows.Forms.Label CycleLabel;
    }
}