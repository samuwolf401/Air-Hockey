﻿
namespace Air_Hockey
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.GameEnigine = new System.Windows.Forms.Timer(this.components);
            this.infoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GameEnigine
            // 
            this.GameEnigine.Interval = 20;
            this.GameEnigine.Tick += new System.EventHandler(this.GameEnigine_Tick);
            // 
            // infoLabel
            // 
            this.infoLabel.Location = new System.Drawing.Point(12, 236);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(326, 23);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "Press \"P\" to start and pause the game!";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.infoLabel.Click += new System.EventHandler(this.infoLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 600);
            this.Controls.Add(this.infoLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Air Hockey";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer GameEnigine;
        private System.Windows.Forms.Label infoLabel;
    }
}

