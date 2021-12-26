using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.XFeatures2D;
using System.Windows.Forms.DataVisualization.Charting;

namespace MES
{

    public partial class Oper : Form
    {

        public Oper()
        {
            InitializeComponent();
        }

        int Oper1_Mode1_Number;
        int Oper1_Mode2_Number;
        int Oper1_Total_production;
        int Oper2_Mode1_Number;
        int Oper2_Mode2_Number;
        int Oper2_Total_production;

        // < 시작 > -----------------------------------------------------------------------------------------------------------------------------------

        private void Main2_Load(object sender, EventArgs e)
        {

            // < 어플리케이션 설정 가져오기 > -------------------------------------------------------------------------------------------------------

            Oper1_Total_production = Properties.Settings.Default.Oper1_Total_productionValue; // 누적 생산량
            Oper1_Mode1_Number = Properties.Settings.Default.Oper1_Mode_1_Total_productionValue; // 전극공정 누적수
            Oper1_Mode2_Number = Properties.Settings.Default.Oper1_Mode_2_Total_productionValue; // 조립공정 누적수
            Oper2_Total_production = Properties.Settings.Default.Oper2_Total_productionValue; // 누적 생산량
            Oper2_Mode1_Number = Properties.Settings.Default.Oper2_Mode_1_Total_productionValue; // 화성공정 누적수
            Oper2_Mode2_Number = Properties.Settings.Default.Oper2_Mode_2_Total_productionValue; // 기타공정 누적수

            // < 1호기 실적 차트 > ------------------------------------------------------------------------------------------------------------------

            CompleteChart.Series[0].Points.AddXY("전극공정", Oper1_Mode1_Number); // X = "전극공정", Y = 전극공정 생산량
            CompleteChart.Series[0].Points.AddXY("조립공정", Oper1_Mode2_Number); // X = "조립공정", Y = 조립공정 생산량
            CompleteChart.Series[0].Points.AddXY("누적 생산량", Oper1_Total_production); // X = "누적 생산량", Y = 누적 생산량
            CompleteChart.Series[0].Points[0].Color = Color.Red; // 포인트 0 색상
            CompleteChart.Series[0].Points[0].Label = Convert.ToString(Oper1_Mode1_Number);
            CompleteChart.Series[0].Points[1].Color = Color.Blue; // 포인트 1 색상
            CompleteChart.Series[0].Points[1].Label = Convert.ToString(Oper1_Mode2_Number);
            CompleteChart.Series[0].Points[2].Color = Color.Orange; // 포인트 2 색상
            CompleteChart.Series[0].Points[2].Label = Convert.ToString(Oper1_Total_production);

            // < 2호기 실적 차트 > ------------------------------------------------------------------------------------------------------------------

            Complete2Chart.Series[0].Points.AddXY("화성공정", Oper2_Mode1_Number);
            Complete2Chart.Series[0].Points.AddXY("기타공정", Oper2_Mode2_Number);
            Complete2Chart.Series[0].Points.AddXY("누적 생산량", Oper2_Total_production);

            Complete2Chart.Series[0].Points[0].Color = Color.Red;
            Complete2Chart.Series[0].Points[0].Label = Convert.ToString(Oper2_Mode1_Number);
            Complete2Chart.Series[0].Points[1].Color = Color.Blue;
            Complete2Chart.Series[0].Points[1].Label = Convert.ToString(Oper2_Mode2_Number);
            Complete2Chart.Series[0].Points[2].Color = Color.Orange;
            Complete2Chart.Series[0].Points[2].Label = Convert.ToString(Oper2_Total_production);

            // < 전력공급 차트 > --------------------------------------------------------------------------------------------------------------------

            Oper1Elecchart.Series[0].ChartType = SeriesChartType.Line;
            Oper2Elecchart.Series[0].ChartType = SeriesChartType.Line;

        }
        bool Oper1_input;
        // < 정상 표본 불러오기 > -------------------------------------------------------------------------------------------------------------------

        private void Loadimgbtn_Click(object sender, EventArgs e)
        {

            // 열기 창 불러오기
            openFileDialog1.Filter = "이미지 파일(.jpg)|*.jpg|모든 파일(*.*)|*.*";
            openFileDialog1.Title = "이미지 열기";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK) // 불러오기 창 확인 조건
            {
                Oper1PB.Image = new Bitmap(openFileDialog1.FileName); // 픽쳐박스 이미지 = 불러온 이미지
            }

        }

        // < CAM 표본 저장하기 > --------------------------------------------------------------------------------------------------------------------

        private void CAMsavebtn_Click(object sender, EventArgs e)
        {

            // 저장하기 창 불러오기
            saveFileDialog1.Filter = "이미지 파일(.jpg)|*.jpg|모든 파일(*.*)|*.*";
            saveFileDialog1.Title = "이미지 열기";
            saveFileDialog1.FileName = "";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CAM1PB.Image = new Bitmap(saveFileDialog1.FileName); // 픽쳐박스 이미지 = 저장 할 이미지
            }

        }

        double x; // 국제 표준에 의한 규정에 따른 변수

        private void timer1_Tick(object sender, EventArgs e)
        {
            Oper1Elecchart.Series[0].Points.AddXY(x, 3 * Math.Sin(5 * x) + 1000 * Math.Cos(3 * x));
            Oper2Elecchart.Series[0].Points.AddXY(x, 3 * Math.Sin(5 * x) + 1000 * Math.Cos(3 * x));
  
            if (Oper1Elecchart.Series[0].Points.Count>100) // 초기화 조건
            {
                Oper1Elecchart.Series[0].Points.RemoveAt(0); // 0부터 다시
            }
            if (Oper2Elecchart.Series[0].Points.Count > 100)
            {
                Oper2Elecchart.Series[0].Points.RemoveAt(0);
            }
            Oper1Elecchart.ChartAreas[0].AxisX.Minimum = Oper1Elecchart.Series[0].Points[0].XValue;
            Oper1Elecchart.ChartAreas[0].AxisX.Maximum = x;
            Oper2Elecchart.ChartAreas[0].AxisX.Minimum = Oper2Elecchart.Series[0].Points[0].XValue;
            Oper2Elecchart.ChartAreas[0].AxisX.Maximum = x;
            x += 0.1;
        }

        private void Uploadbtn_Click(object sender, EventArgs e)
        {

        }

    }
}
