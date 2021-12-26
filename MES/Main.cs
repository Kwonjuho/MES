using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MES
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }

        // < 사용할 메뉴 폼 인스턴스화(객체 생성) > -------------------------------------------------------------------------------------------------

        Home Home = new Home();
        Produc Produc = new Produc();
        Oper Oper = new Oper();
        Order Order = new Order();

        // < 시작 > ---------------------------------------------------------------------------------------------------------------------------------

        private void Form1_Load(object sender, EventArgs e)
        {
            Home.Show(); // 실행 시 홈 폼 보이기

            // 현재 시간 타이머
            timer.Enabled = true;

            // 홈 버튼 판넬 출력
            Home.TopLevel = false; // 자식 폼 최상위 해제 (메인 폼 하나만 최상위)
            Home.Parent = this.panel; // 자식 폼 판넬에 상속
            Home.ControlBox = false; // 폼 상단 창 없애기

            // 생산관리 버튼 판넬 출력
            Produc.TopLevel = false;
            Produc.Parent = this.panel;
            Produc.ControlBox = false;

            // 가동실적 버튼 판넬 출력
            Oper.TopLevel = false;
            Oper.Parent = this.panel;
            Oper.ControlBox = false;

            // 주문 / 재고 관리 버튼 판넬 출력
            Order.TopLevel = false;
            Order.Parent = this.panel;
            Order.ControlBox = false;
        }

        string DateTimeStr = "현재 시간 : ";

        // < 현재 시간 표시 > -----------------------------------------------------------------------------------------------------------------------

        private void timer_Tick(object sender, EventArgs e)
        {
            this.DateTimelbl.Text = DateTimeStr + DateTime.Now.ToLongTimeString();
        }

        // < 메뉴 버튼 클릭시 폼 띄우기 > -----------------------------------------------------------------------------------------------------------

        private void TSMIhome_Click(object sender, EventArgs e) // 홈
        {
            Order.Hide();
            Produc.Hide();
            Oper.Hide();
            Home.Show();
        }

        private void TSMIproduc_Click(object sender, EventArgs e) // 생산관리
        {
            Home.Hide();
            Order.Hide();
            Oper.Hide();
            Produc.Show();
        }

        private void TSMIoper_Click(object sender, EventArgs e) // 가동율 모니터링
        {
            Home.Hide();
            Order.Hide();
            Produc.Hide();
            Oper.Show();
        }

        private void TSMIinventory_Click(object sender, EventArgs e) // 제품창고 재고관리
        {
            Home.Hide();
            Produc.Hide();
            Oper.Hide();
            Order.Hide();
        }

        private void TSMIorder_Click(object sender, EventArgs e) // 재료 주문관리
        {
            Home.Hide();
            Produc.Hide();
            Oper.Hide();
            Order.Show();
        }

        private void TSMIhelp_Click(object sender, EventArgs e) // 도움말
        {
            Help Help = new Help();
            Help.ShowDialog();
        }

        private void TSMIUpdate_Click(object sender, EventArgs e) // 재시작
        {
            Application.Restart();
        }

        private void exitbtn_Click(object sender, EventArgs e) // 종료
        {
            this.Close();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
