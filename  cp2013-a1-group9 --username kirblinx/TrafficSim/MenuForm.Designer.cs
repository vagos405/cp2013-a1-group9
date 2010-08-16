namespace TrafficSim
{
    partial class MenuForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.HLaneBox = new System.Windows.Forms.TextBox();
            this.VLaneBox = new System.Windows.Forms.TextBox();
            this.HProbBox = new System.Windows.Forms.TextBox();
            this.VProbBox = new System.Windows.Forms.TextBox();
            this.SimButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Set Number of Horizontal Lanes (H-Street)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Set Number of Vertical Lanes (V-Street)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Set Probability of a Car Entering H-Street";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Set Probabilty of a Car Entering V-Street";
            // 
            // HLaneBox
            // 
            this.HLaneBox.Location = new System.Drawing.Point(251, 25);
            this.HLaneBox.Name = "HLaneBox";
            this.HLaneBox.Size = new System.Drawing.Size(52, 20);
            this.HLaneBox.TabIndex = 4;
            this.HLaneBox.Text = "1";
            this.HLaneBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // VLaneBox
            // 
            this.VLaneBox.Location = new System.Drawing.Point(251, 51);
            this.VLaneBox.Name = "VLaneBox";
            this.VLaneBox.Size = new System.Drawing.Size(52, 20);
            this.VLaneBox.TabIndex = 5;
            this.VLaneBox.Text = "1";
            this.VLaneBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // HProbBox
            // 
            this.HProbBox.Location = new System.Drawing.Point(251, 93);
            this.HProbBox.Name = "HProbBox";
            this.HProbBox.Size = new System.Drawing.Size(52, 20);
            this.HProbBox.TabIndex = 6;
            this.HProbBox.Text = "0.5";
            this.HProbBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // VProbBox
            // 
            this.VProbBox.Location = new System.Drawing.Point(251, 119);
            this.VProbBox.Name = "VProbBox";
            this.VProbBox.Size = new System.Drawing.Size(52, 20);
            this.VProbBox.TabIndex = 7;
            this.VProbBox.Text = "0.5";
            this.VProbBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SimButton
            // 
            this.SimButton.Location = new System.Drawing.Point(30, 193);
            this.SimButton.Name = "SimButton";
            this.SimButton.Size = new System.Drawing.Size(273, 31);
            this.SimButton.TabIndex = 8;
            this.SimButton.Text = "Simulate";
            this.SimButton.UseVisualStyleBackColor = true;
            this.SimButton.Click += new System.EventHandler(this.SimButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(251, 161);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(52, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "1";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Set Number of Cycles to Simulate";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 246);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SimButton);
            this.Controls.Add(this.VProbBox);
            this.Controls.Add(this.HProbBox);
            this.Controls.Add(this.VLaneBox);
            this.Controls.Add(this.HLaneBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MenuForm";
            this.Text = "Traffic Simulation Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox HLaneBox;
        private System.Windows.Forms.TextBox VLaneBox;
        private System.Windows.Forms.TextBox HProbBox;
        private System.Windows.Forms.TextBox VProbBox;
        private System.Windows.Forms.Button SimButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
    }
}

