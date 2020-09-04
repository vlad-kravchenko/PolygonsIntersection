namespace PolyIntersectSample
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.line1X = new System.Windows.Forms.TrackBar();
            this.line1Y = new System.Windows.Forms.TrackBar();
            this.line2X = new System.Windows.Forms.TrackBar();
            this.line2Y = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.line1X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.line1Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.line2X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.line2Y)).BeginInit();
            this.SuspendLayout();
            // 
            // line1X
            // 
            this.line1X.Location = new System.Drawing.Point(618, 12);
            this.line1X.Maximum = 500;
            this.line1X.Minimum = 1;
            this.line1X.Name = "line1X";
            this.line1X.Size = new System.Drawing.Size(556, 45);
            this.line1X.TabIndex = 0;
            this.line1X.Value = 100;
            this.line1X.Scroll += new System.EventHandler(this.line2Y_Scroll);
            // 
            // line1Y
            // 
            this.line1Y.Location = new System.Drawing.Point(618, 63);
            this.line1Y.Maximum = 500;
            this.line1Y.Minimum = 1;
            this.line1Y.Name = "line1Y";
            this.line1Y.Size = new System.Drawing.Size(556, 45);
            this.line1Y.TabIndex = 1;
            this.line1Y.Value = 100;
            this.line1Y.Scroll += new System.EventHandler(this.line2Y_Scroll);
            // 
            // line2X
            // 
            this.line2X.Location = new System.Drawing.Point(618, 114);
            this.line2X.Maximum = 500;
            this.line2X.Minimum = 1;
            this.line2X.Name = "line2X";
            this.line2X.Size = new System.Drawing.Size(556, 45);
            this.line2X.TabIndex = 2;
            this.line2X.Value = 100;
            this.line2X.Scroll += new System.EventHandler(this.line2Y_Scroll);
            // 
            // line2Y
            // 
            this.line2Y.Location = new System.Drawing.Point(618, 165);
            this.line2Y.Maximum = 500;
            this.line2Y.Minimum = 1;
            this.line2Y.Name = "line2Y";
            this.line2Y.Size = new System.Drawing.Size(556, 45);
            this.line2Y.TabIndex = 3;
            this.line2Y.Value = 100;
            this.line2Y.Scroll += new System.EventHandler(this.line2Y_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(618, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Пересекаются";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.line2Y);
            this.Controls.Add(this.line2X);
            this.Controls.Add(this.line1Y);
            this.Controls.Add(this.line1X);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.line1X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.line1Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.line2X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.line2Y)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar line1X;
        private System.Windows.Forms.TrackBar line1Y;
        private System.Windows.Forms.TrackBar line2X;
        private System.Windows.Forms.TrackBar line2Y;
        private System.Windows.Forms.Label label1;
    }
}

