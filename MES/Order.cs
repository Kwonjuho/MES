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
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // < 콤보박스 설정 > --------------------------------------------------------------------------------------------------------------------

            for (int i = 0; i < comList.Length; i++)
            {
                this.AnodeCB.Items.Add(comList[i]);
            }
            AnodeCB.SelectedIndex = 0;

            Oper1_Mode1_Number = Properties.Settings.Default.Oper1_Mode_1_Total_productionValue; // 공정1 누적수
            Oper1_Mode2_Number = Properties.Settings.Default.Oper1_Mode_2_Total_productionValue; // 공정2 누적수
            Oper2_Mode1_Number = Properties.Settings.Default.Oper2_Mode_1_Total_productionValue;
            Oper2_Mode2_Number = Properties.Settings.Default.Oper2_Mode_2_Total_productionValue;

            Anode_Result_txt.Text = Convert.ToString(Oper1_Mode1_Number);
            Cathode_Result_txt.Text = Convert.ToString(Oper1_Mode2_Number);
            SM_Result_txt.Text = Convert.ToString(Oper2_Mode1_Number);
            ES_Result_txt.Text = Convert.ToString(Oper2_Mode2_Number);
        }

        // 콤보박스 문자열
        string[] comList = new string[] { "포스코케미칼", "에코프로비엠", "엘앤에프", "SK이노베이션", "LG화학", "삼성SDI" };

        // 리스트 뷰 문자열
        string Str_Num, Str_Day, Str_Name, Str_Num2, Str_Num3, Str_Num4, Str_Num5, Str_Addr, Str_AB;

        int Oper1_Mode1_Number;
        int Oper1_Mode2_Number;
        int Oper2_Mode1_Number;
        int Oper2_Mode2_Number;

        // < 예약 버튼 > ----------------------------------------------------------------------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi2 in lvi2Order.SelectedItems) // 입고 시 주문 리스트 삭제
            {
                lvi2Order.Items.Remove(lvi2);
            }
        }

        // < 입고 버튼 > ----------------------------------------------------------------------------------------------------------------------------
        int a;

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lviOrder.SelectedItems) // 주문 리스트 값 입고 리스트 값에 추가
            {
                lvi2Order.Items.Add((ListViewItem)lvi.Clone());
                lviOrder.Items.Remove(lvi);
            }

            decimal sum = 0; // int 로 하면 value 문제 뜸 decimal(고정소수점)
            foreach (ListViewItem lvi2 in lvi2Order.Items)
            {
                sum += decimal.Parse(lvi2.SubItems[3].Text); // a += b는 a = a + b와 같음
            }
            Anode_txt.Text = Convert.ToString(sum);
            Cathode_txt.Text = Convert.ToString(sum);
            SM_txt.Text = Convert.ToString(sum);
            ES_txt.Text = Convert.ToString(sum);
        }

        // < 주문 버튼 > ----------------------------------------------------------------------------------------------------------------------------

        int i;

        private void Orderbtn_Click(object sender, EventArgs e)
        {

            i++;
            Str_Num = Convert.ToString(i);
            Str_Day = Order_DTP.Text;
            Str_Name = AnodeCB.SelectedItem.ToString();
            Str_Num2 = Anodetxt.Text;
            Str_Num3 = Cathodetxt.Text;
            Str_Num4 = SMtxt.Text;
            Str_Num5 = EStxt.Text;
            Str_AB = abtxt.Text;
            Str_Addr = Addrtxt.Text;

            ListViewItem lvi = new ListViewItem(new string[] { Str_Num, Str_Day, Str_Name, Str_Num2, Str_Num3, Str_Num4, Str_Num5, Str_Addr, Str_AB});
            this.lviOrder.Items.Add(lvi);

        }

        // < 주문 취소 버튼 > -----------------------------------------------------------------------------------------------------------------------
        private void OrderCancelbtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lviOrder.SelectedItems)
            {
                lviOrder.Items.Remove(lvi);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {


            if (TextCheck() == true)
            {

            }
            else return;
        }
        private bool TextCheck()
        {
            if (this.Anode_Result_txt.Text != "")
            {
                return true;
            }
            else

                return false;
        }
    }
}
