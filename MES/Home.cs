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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        // < 링크 > --------------------------------------------------------------------------------------------------------------------------------- 
        private void YoutubePB_Click(object sender, EventArgs e)
        {
            // 시스템 기본 프로그램 열기
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=cK0pXGovQYo");
        }

        private void YoutubePB2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://youtu.be/mNNhfhGx3VE");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.kopo.ac.kr/cheongju/index.do");
        }
    }
}
