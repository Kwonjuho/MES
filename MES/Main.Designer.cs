
namespace MES
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel = new System.Windows.Forms.Panel();
            this.DateTimelbl = new System.Windows.Forms.Label();
            this.MainTimePicker = new System.Windows.Forms.DateTimePicker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.exitbtn = new System.Windows.Forms.Button();
            this.Uptimelbl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TSMIhome = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIproduc = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIoper = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIorder = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIhelp = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.Window;
            this.panel.Controls.Add(this.DateTimelbl);
            this.panel.Controls.Add(this.MainTimePicker);
            this.panel.Controls.Add(this.statusStrip1);
            this.panel.Controls.Add(this.exitbtn);
            this.panel.Controls.Add(this.Uptimelbl);
            this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel.Location = new System.Drawing.Point(0, 24);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1664, 882);
            this.panel.TabIndex = 4;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // DateTimelbl
            // 
            this.DateTimelbl.AutoSize = true;
            this.DateTimelbl.BackColor = System.Drawing.SystemColors.Menu;
            this.DateTimelbl.Location = new System.Drawing.Point(763, 865);
            this.DateTimelbl.Name = "DateTimelbl";
            this.DateTimelbl.Size = new System.Drawing.Size(65, 12);
            this.DateTimelbl.TabIndex = 5;
            this.DateTimelbl.Text = "현재 시간 :";
            // 
            // MainTimePicker
            // 
            this.MainTimePicker.Location = new System.Drawing.Point(1430, 861);
            this.MainTimePicker.Name = "MainTimePicker";
            this.MainTimePicker.Size = new System.Drawing.Size(207, 21);
            this.MainTimePicker.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 860);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1664, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // exitbtn
            // 
            this.exitbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitbtn.Location = new System.Drawing.Point(1593, 812);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(59, 36);
            this.exitbtn.TabIndex = 2;
            this.exitbtn.Text = "종료";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // Uptimelbl
            // 
            this.Uptimelbl.AutoSize = true;
            this.Uptimelbl.BackColor = System.Drawing.SystemColors.Window;
            this.Uptimelbl.Location = new System.Drawing.Point(12, 885);
            this.Uptimelbl.Name = "Uptimelbl";
            this.Uptimelbl.Size = new System.Drawing.Size(61, 12);
            this.Uptimelbl.TabIndex = 1;
            this.Uptimelbl.Text = "가동시간 :";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIhome,
            this.TSMIproduc,
            this.TSMIoper,
            this.TSMIorder,
            this.TSMIUpdate,
            this.TSMIhelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1664, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TSMIhome
            // 
            this.TSMIhome.Name = "TSMIhome";
            this.TSMIhome.Size = new System.Drawing.Size(31, 20);
            this.TSMIhome.Text = "홈";
            this.TSMIhome.Click += new System.EventHandler(this.TSMIhome_Click);
            // 
            // TSMIproduc
            // 
            this.TSMIproduc.Name = "TSMIproduc";
            this.TSMIproduc.Size = new System.Drawing.Size(67, 20);
            this.TSMIproduc.Text = "생산관리";
            this.TSMIproduc.Click += new System.EventHandler(this.TSMIproduc_Click);
            // 
            // TSMIoper
            // 
            this.TSMIoper.Name = "TSMIoper";
            this.TSMIoper.Size = new System.Drawing.Size(107, 20);
            this.TSMIoper.Text = "가동율 모니터링";
            this.TSMIoper.Click += new System.EventHandler(this.TSMIoper_Click);
            // 
            // TSMIorder
            // 
            this.TSMIorder.Name = "TSMIorder";
            this.TSMIorder.Size = new System.Drawing.Size(100, 20);
            this.TSMIorder.Text = "주문/재고 관리";
            this.TSMIorder.Click += new System.EventHandler(this.TSMIorder_Click);
            // 
            // TSMIUpdate
            // 
            this.TSMIUpdate.Name = "TSMIUpdate";
            this.TSMIUpdate.Size = new System.Drawing.Size(55, 20);
            this.TSMIUpdate.Text = "재실행";
            this.TSMIUpdate.Click += new System.EventHandler(this.TSMIUpdate_Click);
            // 
            // TSMIhelp
            // 
            this.TSMIhelp.Name = "TSMIhelp";
            this.TSMIhelp.Size = new System.Drawing.Size(72, 20);
            this.TSMIhelp.Text = "도움말(H)";
            this.TSMIhelp.Click += new System.EventHandler(this.TSMIhelp_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1664, 906);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MES - 생산공정관리 프로그램";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStripMenuItem TSMIhome;
        private System.Windows.Forms.ToolStripMenuItem TSMIorder;
        private System.Windows.Forms.Label Uptimelbl;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.DateTimePicker MainTimePicker;
        private System.Windows.Forms.ToolStripMenuItem TSMIhelp;
        private System.Windows.Forms.ToolStripMenuItem TSMIproduc;
        private System.Windows.Forms.ToolStripMenuItem TSMIoper;
        private System.Windows.Forms.Label DateTimelbl;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMIUpdate;
    }
}

