using System.Windows.Forms;

namespace Plotter
{
    partial class MyTrackBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.minimumLabel = new System.Windows.Forms.Label();
            this.maximumLabel = new System.Windows.Forms.Label();
            this.valueLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar
            // 
            this.trackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar.Location = new System.Drawing.Point(3, 3);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(449, 45);
            this.trackBar.TabIndex = 0;
            // 
            // minimumLabel
            // 
            this.minimumLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.minimumLabel.AutoSize = true;
            this.minimumLabel.Location = new System.Drawing.Point(3, 49);
            this.minimumLabel.Name = "minimumLabel";
            this.minimumLabel.Size = new System.Drawing.Size(35, 13);
            this.minimumLabel.TabIndex = 1;
            this.minimumLabel.Text = "label1";
            // 
            // maximumLabel
            // 
            this.maximumLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.maximumLabel.AutoSize = true;
            this.maximumLabel.Location = new System.Drawing.Point(417, 49);
            this.maximumLabel.Name = "maximumLabel";
            this.maximumLabel.Size = new System.Drawing.Size(35, 13);
            this.maximumLabel.TabIndex = 2;
            this.maximumLabel.Text = "label2";
            this.maximumLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // valueLabel
            // 
            this.valueLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.valueLabel.AutoSize = true;
            this.valueLabel.Location = new System.Drawing.Point(210, 49);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(35, 13);
            this.valueLabel.TabIndex = 3;
            this.valueLabel.Text = "label3";
            // 
            // MyTrackBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.maximumLabel);
            this.Controls.Add(this.minimumLabel);
            this.Controls.Add(this.trackBar);
            this.Name = "MyTrackBar";
            this.Size = new System.Drawing.Size(455, 62);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label minimumLabel;
        private System.Windows.Forms.Label maximumLabel;
        private System.Windows.Forms.Label valueLabel;
        private TrackBar trackBar;
    }
}
