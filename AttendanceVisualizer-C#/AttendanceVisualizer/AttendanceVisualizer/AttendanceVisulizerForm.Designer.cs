using System;

namespace AttendanceVisualizer
{
    partial class AttendanceVisulizerForm
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
            this.DrawButton = new System.Windows.Forms.Button();
            this.TimeLineDrawingPanel = new System.Windows.Forms.Panel();
            this.SheetContents_ListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // DrawButton
            // 
            this.DrawButton.Location = new System.Drawing.Point(256, 75);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(138, 41);
            this.DrawButton.TabIndex = 122;
            this.DrawButton.Text = "Draw";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // TimeLineDrawingPanel
            // 
            this.TimeLineDrawingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TimeLineDrawingPanel.Location = new System.Drawing.Point(256, 122);
            this.TimeLineDrawingPanel.Name = "TimeLineDrawingPanel";
            this.TimeLineDrawingPanel.Size = new System.Drawing.Size(800, 324);
            this.TimeLineDrawingPanel.TabIndex = 121;
            // 
            // SheetContents_ListBox
            // 
            this.SheetContents_ListBox.FormattingEnabled = true;
            this.SheetContents_ListBox.Location = new System.Drawing.Point(36, 122);
            this.SheetContents_ListBox.Name = "SheetContents_ListBox";
            this.SheetContents_ListBox.Size = new System.Drawing.Size(192, 316);
            this.SheetContents_ListBox.TabIndex = 120;
            // 
            // AttendanceVisulizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 563);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.TimeLineDrawingPanel);
            this.Controls.Add(this.SheetContents_ListBox);
            this.Name = "AttendanceVisulizerForm";
            this.Text = "AttendanceVisulizerForm";
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Button DrawButton;
        internal System.Windows.Forms.Panel TimeLineDrawingPanel;
        internal System.Windows.Forms.ListBox SheetContents_ListBox;
       
    }
}