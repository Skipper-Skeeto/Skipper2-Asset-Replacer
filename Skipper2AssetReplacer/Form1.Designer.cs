﻿namespace Skipper2AssetReplacer
{
	partial class Form1
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
			this.Open = new System.Windows.Forms.Button();
			this.btnLeft = new System.Windows.Forms.Button();
			this.btnRight = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.numIndex = new System.Windows.Forms.NumericUpDown();
			this.Goto = new System.Windows.Forms.Button();
			this.imgPanel = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.numIndex)).BeginInit();
			this.SuspendLayout();
			// 
			// Open
			// 
			this.Open.Location = new System.Drawing.Point(12, 12);
			this.Open.Name = "Open";
			this.Open.Size = new System.Drawing.Size(91, 23);
			this.Open.TabIndex = 0;
			this.Open.Text = "Open mm2.dat";
			this.Open.UseVisualStyleBackColor = true;
			this.Open.Click += new System.EventHandler(this.Open_Click);
			// 
			// btnLeft
			// 
			this.btnLeft.Location = new System.Drawing.Point(109, 12);
			this.btnLeft.Name = "btnLeft";
			this.btnLeft.Size = new System.Drawing.Size(22, 23);
			this.btnLeft.TabIndex = 2;
			this.btnLeft.Text = "<";
			this.btnLeft.UseVisualStyleBackColor = true;
			this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
			// 
			// btnRight
			// 
			this.btnRight.Location = new System.Drawing.Point(137, 12);
			this.btnRight.Name = "btnRight";
			this.btnRight.Size = new System.Drawing.Size(22, 23);
			this.btnRight.TabIndex = 3;
			this.btnRight.Text = ">";
			this.btnRight.UseVisualStyleBackColor = true;
			this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(165, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Replace";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// numIndex
			// 
			this.numIndex.Location = new System.Drawing.Point(532, 12);
			this.numIndex.Maximum = new decimal(new int[] {
            638,
            0,
            0,
            0});
			this.numIndex.Name = "numIndex";
			this.numIndex.Size = new System.Drawing.Size(120, 20);
			this.numIndex.TabIndex = 5;
			// 
			// Goto
			// 
			this.Goto.Location = new System.Drawing.Point(451, 10);
			this.Goto.Name = "Goto";
			this.Goto.Size = new System.Drawing.Size(75, 23);
			this.Goto.TabIndex = 6;
			this.Goto.Text = "Goto";
			this.Goto.UseVisualStyleBackColor = true;
			this.Goto.Click += new System.EventHandler(this.Goto_Click);
			// 
			// imgPanel
			// 
			this.imgPanel.Location = new System.Drawing.Point(12, 41);
			this.imgPanel.Name = "imgPanel";
			this.imgPanel.Size = new System.Drawing.Size(640, 420);
			this.imgPanel.TabIndex = 7;
			this.imgPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.imgPanel_Paint);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(664, 472);
			this.Controls.Add(this.imgPanel);
			this.Controls.Add(this.Goto);
			this.Controls.Add(this.numIndex);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnRight);
			this.Controls.Add(this.btnLeft);
			this.Controls.Add(this.Open);
			this.DoubleBuffered = true;
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.numIndex)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button Open;
		private System.Windows.Forms.Button btnLeft;
		private System.Windows.Forms.Button btnRight;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.NumericUpDown numIndex;
		private System.Windows.Forms.Button Goto;
		private System.Windows.Forms.Panel imgPanel;
	}
}

