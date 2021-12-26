using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private double o = 0.0; // 폼 투명도 값 설정

        private void Help_Load(object sender, EventArgs e)
        {
            this.Timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (o < 100.0)
            {
                o = o + 3.6;
                float c = Convert.ToSingle(o);
                float f = c / 100;
                this.Opacity = f;
            }
            else
            {
                this.Opacity = Convert.ToSingle(100 / 100);
                o = 0.0;
                this.Timer.Enabled = false;
            }
        }

        private void Maillbl_Click(object sender, EventArgs e)
        {
            // 윈도우 기본 메일 응용 프로그램을 시작
            System.Diagnostics.Process.Start("mailto:ffpp1215@naver.com");
            System.Diagnostics.Process.Start("mailto:boy1521@naver.com");
        }
    }
}
