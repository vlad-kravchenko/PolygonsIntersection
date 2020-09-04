namespace PolyIntersectSample
{
    partial class Form2
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
            this.line2Y = new System.Windows.Forms.TrackBar();
            this.line2X = new System.Windows.Forms.TrackBar();
            this.line1Y = new System.Windows.Forms.TrackBar();
            this.line1X = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.line2Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.line2X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.line1Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.line1X)).BeginInit();
            this.SuspendLayout();
            // 
            // line2Y
            // 
            this.line2Y.Location = new System.Drawing.Point(721, 165);
            this.line2Y.Maximum = 500;
            this.line2Y.Minimum = 1;
            this.line2Y.Name = "line2Y";
            this.line2Y.Size = new System.Drawing.Size(556, 45);
            this.line2Y.TabIndex = 7;
            this.line2Y.Value = 500;
            this.line2Y.Scroll += new System.EventHandler(this.line2Y_Scroll);
            // 
            // line2X
            // 
            this.line2X.Location = new System.Drawing.Point(721, 114);
            this.line2X.Maximum = 500;
            this.line2X.Minimum = 1;
            this.line2X.Name = "line2X";
            this.line2X.Size = new System.Drawing.Size(556, 45);
            this.line2X.TabIndex = 6;
            this.line2X.Value = 500;
            this.line2X.Scroll += new System.EventHandler(this.line2Y_Scroll);
            // 
            // line1Y
            // 
            this.line1Y.Location = new System.Drawing.Point(721, 63);
            this.line1Y.Maximum = 500;
            this.line1Y.Minimum = 1;
            this.line1Y.Name = "line1Y";
            this.line1Y.Size = new System.Drawing.Size(556, 45);
            this.line1Y.TabIndex = 5;
            this.line1Y.Value = 100;
            this.line1Y.Scroll += new System.EventHandler(this.line2Y_Scroll);
            // 
            // line1X
            // 
            this.line1X.Location = new System.Drawing.Point(721, 12);
            this.line1X.Maximum = 500;
            this.line1X.Minimum = 1;
            this.line1X.Name = "line1X";
            this.line1X.Size = new System.Drawing.Size(556, 45);
            this.line1X.TabIndex = 4;
            this.line1X.Value = 100;
            this.line1X.Scroll += new System.EventHandler(this.line2Y_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(731, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Пересекаются";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 749);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.line2Y);
            this.Controls.Add(this.line2X);
            this.Controls.Add(this.line1Y);
            this.Controls.Add(this.line1X);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.line2Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.line2X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.line1Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.line1X)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar line2Y;
        private System.Windows.Forms.TrackBar line2X;
        private System.Windows.Forms.TrackBar line1Y;
        private System.Windows.Forms.TrackBar line1X;
        private System.Windows.Forms.Label label1;
    }
}