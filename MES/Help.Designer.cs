
namespace MES
{
    partial class Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Mail2lbl = new System.Windows.Forms.Label();
            this.Maillbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LogoPB = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPB)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.Interval = 10;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Mail2lbl);
            this.groupBox1.Controls.Add(this.Maillbl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "만든이";
            // 
            // Mail2lbl
            // 
            this.Mail2lbl.AutoSize = true;
            this.Mail2lbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Mail2lbl.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Mail2lbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Mail2lbl.Location = new System.Drawing.Point(79, 58);
            this.Mail2lbl.Name = "Mail2lbl";
            this.Mail2lbl.Size = new System.Drawing.Size(122, 12);
            this.Mail2lbl.TabIndex = 3;
            this.Mail2lbl.Text = "boy1521@naver.com";
            this.Mail2lbl.Click += new System.EventHandler(this.Maillbl_Click);
            // 
            // Maillbl
            // 
            this.Maillbl.AutoSize = true;
            this.Maillbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Maillbl.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Maillbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Maillbl.Location = new System.Drawing.Point(79, 26);
            this.Maillbl.Name = "Maillbl";
            this.Maillbl.Size = new System.Drawing.Size(121, 12);
            this.Maillbl.TabIndex = 3;
            this.Maillbl.Text = "ffpp1215@naver.com";
            this.Maillbl.Click += new System.EventHandler(this.Maillbl_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "백주호 : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "권주호 : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "2021.12.02";
            // 
            // LogoPB
            // 
            this.LogoPB.Image = ((System.Drawing.Image)(resources.GetObject("LogoPB.Image")));
            this.LogoPB.Location = new System.Drawing.Point(12, 12);
            this.LogoPB.Name = "LogoPB";
            this.LogoPB.Size = new System.Drawing.Size(223, 73);
            this.LogoPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoPB.TabIndex = 2;
            this.LogoPB.TabStop = false;
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(247, 232);
            this.Controls.Add(this.LogoPB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Help";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "도움말";
            this.Load += new System.EventHandler(this.Help_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Maillbl;
        private System.Windows.Forms.Label Mail2lbl;
        private System.Windows.Forms.PictureBox LogoPB;
    }
}