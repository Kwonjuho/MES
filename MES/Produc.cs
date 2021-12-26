using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic;

namespace MES
{
    public partial class Produc : Form
    {
        public Produc()
        {
            InitializeComponent();
        }

        // < 시작 > ---------------------------------------------------------------------------------------------------------------------------------

        private void Produc_Load(object sender, EventArgs e)
        {

            // 정지 램프 이미지
            this.Oper1LampPB.Image = (Image)this.Lamp_imglist.Images[1];
            this.Oper2LampPB.Image = (Image)this.Lamp_imglist.Images[1];

            // 업로드 타이머 ON
            this.Upload_Timer.Enabled = true;

            // 현태 가동 상태 텍스트
            this.ControlMode_txt.Text = "정지";
            this.ControlMode2_txt.Text = "정지";

            // < 콤보박스 설정 > --------------------------------------------------------------------------------------------------------------------

            for (int i = 0; i < SList.Length; i++)
            {
                this.Mode_CB.Items.Add(SList[i]);
            }

            for (int i = 0; i < SList2.Length; i++)
            {
                this.Mode2_CB.Items.Add(SList2[i]);
            }
            Mode_CB.SelectedIndex = 0;
            Mode2_CB.SelectedIndex = 0;

            // < 불량품 랜덤 객체생성 > -------------------------------------------------------------------------------------------------------------

            Random Faled = new Random();

            // < 어플리케이션 설정 가져오기 > -------------------------------------------------------------------------------------------------------

            // 1호기 저장 값 Oper1Number 불러오기
            Oper1_Total_production = Properties.Settings.Default.Oper1_Total_productionValue; // 누적 생산량
            Oper1_Mode1_Number = Properties.Settings.Default.Oper1_Mode_1_Total_productionValue; // 공정1 누적수
            Oper1_Mode2_Number = Properties.Settings.Default.Oper1_Mode_2_Total_productionValue; // 공정2 누적수

            // 2호기 저장 값 Oper2Number 불러오기
            Oper2_Total_production = Properties.Settings.Default.Oper2_Total_productionValue;
            Oper2_Mode1_Number = Properties.Settings.Default.Oper2_Mode_1_Total_productionValue;
            Oper2_Mode2_Number = Properties.Settings.Default.Oper2_Mode_2_Total_productionValue;

        }

        // 1호기 ====================================================================================================================================

        // < 1호기 문자열 저장 > --------------------------------------------------------------------------------------------------------------------

        string Str_Oper1time = "가동시간 : ";
        string Str_Oper1Complete = "공정 진행율 : ";
        string Str_Completer = "오늘 생산량 : ";
        string Str_Completerresult = "누적 생산량 : ";
        string Str_Mode1_Today = "오늘 전극공정 : ";
        string Str_Mode2_Today = "오늘 조립공정 : ";
        string Str_Mode1_Num = "누적 전극공정 : ";
        string Str_Mode2_Num = "누적 조립공정 : ";

        // 콤보박스 공정 선택 문자열
        string[] SList = new string[] { "전극공정", "조립공정" };

        // 전체 가동 타이머 정수
        int Oper1Timerint;

        // 완성 타이머 시간 정수
        int Oper1CompleteTimerint;

        bool Oper1_input; // 전극공정
        bool Oper1_input2; // 조립공정

        // < 연속 가동 버튼 하나로 제어 > -----------------------------------------------------------------------------------------------------------

        private void Oper1startbtn_Click(object sender, EventArgs e)
        {
            if (Mode_CB.Text == "전극공정") // 모드 선택 조건 == 텍스트일치
            {
                if (Oper1_input2 == false) // 입력 가동이 OFF인 상태
                {
                    if (Oper1_input == false) // 연속 가동이 OFF인 상태
                    {
                        // 타이머 시작
                        Oper1_timer.Start(); // 가동 시간 타이머
                        Complete_Timer.Start(); // 완성 시간 타이머

                        Oper1_input = true; // 가동 True 상태
                        Mode_CB.Enabled = false; // 콤보박스 선택 False 상태
                        CAM_PB.Enabled = true; // CAM 가동

                        // 텍스트 변경
                        this.Oper1start_btn.Text = "정지"; // 가동 버튼 "정지" 텍스트 출력
                        this.ControlMode_txt.Text = "전극공정 실행"; // 현재상태 "전극공정 실행" 텍스트 출력

                        this.Oper1LampPB.Image = (Image)this.Lamp_imglist.Images[0]; // 램프 이미지 ON 이미지 = 0
                        CAM_PB.Image = System.Drawing.Image.FromFile("C:/Users/ffpp1/Desktop/MES/MES/source/img/Sensorimg.gif"); // CAM 이미지 경로

                    }
                    else
                    {
                        Oper1_timer.Stop();
                        Complete_Timer.Stop();

                        Oper1_input = false;
                        Mode_CB.Enabled = true;
                        CAM_PB.Enabled = false;

                        this.Oper1start_btn.Text = "가동";
                        this.ControlMode_txt.Text = "정지";

                        this.Oper1LampPB.Image = (Image)this.Lamp_imglist.Images[1];

                        // 정지 시 초기화
                        Oper1CompleteTimerint = 0; // 완성 타이머
                        CompleteTimerBar.Value = 0; // 진행바
                        Complete_txt.Text = Str_Oper1Complete; // 진행률 텍스트
                    }
                }
                else
                {
                    MessageBox.Show("입력 가동 중입니다.", "경고",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (Mode_CB.Text == "조립공정")
            {
                if (Oper1_input2 == false)
                {
                    if (Oper1_input == false)
                    {
                        // 타이머 시작
                        Oper1_timer.Start();
                        Complete_Timer.Start();

                        Oper1_input = true;
                        Mode_CB.Enabled = false;
                        CAM_PB.Enabled = true;

                        // 텍스트 변경
                        this.Oper1start_btn.Text = "정지";
                        this.ControlMode_txt.Text = "조립공정 실행";

                        this.Oper1LampPB.Image = (Image)this.Lamp_imglist.Images[0];
                        CAM_PB.Image = System.Drawing.Image.FromFile("C:/Users/ffpp1/Desktop/MESTest/MES/MES/source/img/Asemimg.gif");
                    }
                    else
                    {
                        Oper1_timer.Stop();
                        Complete_Timer.Stop();

                        Oper1_input = false;
                        Mode_CB.Enabled = true;
                        CAM_PB.Enabled = false;

                        this.Oper1start_btn.Text = "가동";
                        this.ControlMode_txt.Text = "정지";

                        this.Oper1LampPB.Image = (Image)this.Lamp_imglist.Images[1];

                        // 정지 시 초기화
                        Oper1CompleteTimerint = 0;
                        CompleteTimerBar.Value = 0;
                        Complete_txt.Text = Str_Oper1Complete;
                    }
                }
                else
                {
                    MessageBox.Show("입력 가동 중입니다.", "경고",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // < 입력 가동 버튼 > -----------------------------------------------------------------------------------------------------------------------

        private void Oper1startbtn2_Click(object sender, EventArgs e)
        {
            if (IntCheck() == true) // 텍스트 체크 == True 조건
            {
                Oper1_Start_Count = Convert.ToInt32(this.Oper1_start_txt.Text); // 텍스트박스 string -> int변환 (카운트 차감은 Tick에서)

                this.Oper1_start_txt.ReadOnly = true; // 수량 입력 텍스트박스 읽기전용

                if (Mode_CB.Text == "전극공정") // 모드 선택 조건 == 텍스트일치
                {
                    if (Oper1_input == false) // 연속 가동이 OFF인 상태
                    {
                        if (Oper1_input2 == false) // 입력 가동이 OFF인 상태
                        {
                            // 타이머 시작
                            Oper1_timer.Start();
                            Complete_Timer.Start();

                            Oper1_input2 = true; // 가동 True 상태
                            Mode_CB.Enabled = false; // 콤보박스 선택 False 상태
                            CAM_PB.Enabled = true; // CAM 가동

                            // 텍스트 변경
                            this.Oper1start_btn2.Text = "정지"; // 가동 버튼 "정지" 텍스트 출력
                            this.ControlMode_txt.Text = "전극공정 실행"; // 현재상태 "전극공정 실행" 텍스트 출력

                            // 램프 정지 이미지
                            this.Oper1LampPB.Image = (Image)this.Lamp_imglist.Images[0]; // 램프 이미지 ON 이미지 = 0
                            CAM_PB.Image = System.Drawing.Image.FromFile("C:/Users/ffpp1/Desktop/MESTest/MES/MES/source/img/Sensorimg.gif"); // CAM 이미지 경로
                        }
                        else
                        {
                            Oper1_timer.Stop();
                            Complete_Timer.Stop();

                            Oper1_input2 = false;
                            Mode_CB.Enabled = true;
                            CAM_PB.Enabled = false;
                            this.Oper1_start_txt.ReadOnly = false;

                            this.Oper1start_btn2.Text = "가동";
                            this.ControlMode_txt.Text = "정지";

                            this.Oper1LampPB.Image = (Image)this.Lamp_imglist.Images[1];

                            // 정지 시 초기화
                            Oper1CompleteTimerint = 0;
                            CompleteTimerBar.Value = 0;
                            Complete_txt.Text = Str_Oper1Complete;
                        }
                    }
                    else
                    {
                        MessageBox.Show("연속 가동 중입니다.", "경고",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (Mode_CB.Text == "조립공정")
                {
                    if (Oper1_input == false) // 입력 가동이 OFF인 상태
                    {
                        if (Oper1_input2 == false) // 연속 가동이 OFF인 상태
                        {
                            // 타이머 시작
                            Oper1_timer.Start();
                            Complete_Timer.Start();

                            Oper1_input2 = true;
                            Mode_CB.Enabled = false;
                            CAM_PB.Enabled = true;

                            // 텍스트 변경
                            this.Oper1start_btn2.Text = "정지";
                            this.ControlMode_txt.Text = "조립공정 실행";

                            this.Oper1LampPB.Image = (Image)this.Lamp_imglist.Images[0];
                            CAM_PB.Image = System.Drawing.Image.FromFile("C:/Users/ffpp1/Desktop/MESTest/MES/MES/source/img/Asemimg.gif");
                        }
                        else
                        {
                            Oper1_timer.Stop();
                            Complete_Timer.Stop();

                            Oper1_input2 = false;
                            Mode_CB.Enabled = true;
                            CAM_PB.Enabled = false;

                            this.Oper1start_btn2.Text = "가동";
                            this.ControlMode_txt.Text = "정지";

                            this.Oper1LampPB.Image = (Image)this.Lamp_imglist.Images[1];

                            // 정지 시 초기화
                            Oper1CompleteTimerint = 0;
                            CompleteTimerBar.Value = 0;
                            Complete_txt.Text = Str_Oper1Complete;
                        }
                    }
                    else
                    {
                        MessageBox.Show("연속 가동 중입니다.", "경고",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // < 긴급정지 버튼 > ------------------------------------------------------------------------------------------------------------------------

        private void Oper1stopbtn_Click(object sender, EventArgs e)
        {

            if (Oper1_input == false)
            {
                if (Oper1_input2 == false)
                {
                    MessageBox.Show("정지 상태 입니다.", "경고",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Oper1_timer.Stop();
                Complete_Timer.Stop();

                Oper1_input = false;
                Oper1_input2 = false;
                CAM_PB.Enabled = false;

                this.Oper1start_btn.Text = "가동";
                this.Oper1start_btn2.Text = "가동";
                this.ControlMode_txt.Text = "긴급정지";

                this.Oper1LampPB.Image = (Image)this.Lamp_imglist.Images[2];
            }

        }

        // 리스트 뷰 문자열
        string Str_Name, Str_Mode, Str_Num, Str_Day, Str_True, Str_Failed, Str_Edit;

        // 동적 저장 불러오기
        string Oper1_Name = Properties.Settings.Default.Oper1_NameValue;
        int Oper1_Total_production = Properties.Settings.Default.Oper1_Total_productionValue;
        int Oper1_Mode1_Number = Properties.Settings.Default.Oper1_Mode_1_Total_productionValue;
        int Oper1_Mode2_Number = Properties.Settings.Default.Oper1_Mode_2_Total_productionValue;
        string Oper1_Mode1 = Properties.Settings.Default.Oper1_Mode_1Value;
        string Oper1_Mode2 = Properties.Settings.Default.Oper1_Mode_2Value;

        // 오늘 생산량 초기화됨
        int Oper1_NumberToday = 0;
        int Oper1_Mode1_Today = 0;
        int Oper1_Mode2_Today = 0;
        int Oper1_Start_Count = 0;

        // 제품 1개 완성 타이머
        private void CompleteTimer_Tick(object sender, EventArgs e)
        {
            Oper1CompleteTimerint++;

            if (CompleteTimerBar.Value == 100)
            {
                Oper1CompleteTimerint = 0;           // 초기화
                Oper1_Total_production++;            // 사이클 한번 돌면 누적 생산량 1증가
                Oper1_NumberToday++;                 // Today 생산량 1증가(종료 시 초기화 되는 값)

                // 전극공정 컨트롤 -------------------------------------------------------------------------------------------------------------------------

                if (Mode_CB.Text == "전극공정")
                {
                    if (Oper1_input2 == true)
                    {
                        if (Oper1_Start_Count -1 < 1)
                        {
                            Complete_Timer.Enabled = false;
                            this.Oper1_start_txt.ReadOnly = false;
                            CAM_PB.Enabled = false;
                            Oper1_input2 = false;
                            Mode_CB.Enabled = true;

                            this.Oper1start_btn2.Text = "가동";Oper1start_btn2.Text = "가동";
                            this.Oper1_start_txt.Text = "";
                            MessageBox.Show("입력공정 완료", "알림",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Oper1_Start_Count--;
                            this.Oper1_start_txt.Text = Convert.ToString(Oper1_Start_Count);
                        }
                    }
                    Oper1_Mode1_Number++; // 누적 공정1 1회 증가
                    Oper1_Mode1_Today++; // 오늘 공정1 1회 증가

                    Str_Name = Oper1_Name; // 품명
                    Str_Mode = Oper1_Mode1; // 모드명
                    Str_Num = Convert.ToString(Oper1_Mode1_Number); // 누적 공정1 텍스트 값 = Str_Num

                    this.Oper1_Mode1_txt.Text = Str_Mode1_Num + Str_Num + " " + "회"; // 누적 공정 텍스트 출력
                    this.Oper1_Mode1_Today_txt.Text = Str_Mode1_Today + Convert.ToString(Oper1_Mode1_Today) + " " + "회"; // 오늘 공정1 텍스트 출력
                }

                // 조립공정 컨트롤 -------------------------------------------------------------------------------------------------------------------------

                else if (Mode_CB.Text == "조립공정")
                {
                    if (Oper1_input2 == true)
                    {
                        if (Oper1_Start_Count - 1 < 1)
                        {
                            Complete_Timer.Enabled = false;
                            this.Oper1_start_txt.ReadOnly = false;
                            CAM_PB.Enabled = false;
                            Oper1_input2 = false;
                            Mode_CB.Enabled = true;

                            this.Oper1start_btn2.Text = "가동"; Oper1start_btn2.Text = "가동";
                            this.Oper1_start_txt.Text = "";
                            MessageBox.Show("입력공정 완료", "알림",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Oper1_Start_Count--;
                            this.Oper1_start_txt.Text = Convert.ToString(Oper1_Start_Count);
                        }
                    }

                    Oper1_Mode2_Number++;
                    Oper1_Mode2_Today++;

                    Str_Name = Oper1_Name; // 품명
                    Str_Mode = Oper1_Mode2; // 모드명
                    Str_Num = Convert.ToString(Oper1_Mode2_Number);

                    this.Oper1_Mode2_txt.Text = Str_Mode2_Num + Str_Num + " " + "회";
                    this.Oper1_Mode2_Today_txt.Text = Str_Mode2_Today + Convert.ToString(Oper1_Mode2_Today) + " " + "회";
                }
                // 리스트 뷰 출력할 정보 값 -------------------------------------------------------------------------------------------------------------------

                if (TextCheck() == true)
                {
                    Str_Day = this.Oper_DTP.Text; // 날짜
                    Str_True = "O"; // 텍스트 O
                }
                else return;

                ListViewItem lvi = new ListViewItem(new string[] { Str_Name + Str_Mode + "_" + Str_Num, Str_Day, Str_True, Str_Failed, Str_Edit });
                this.Oper1listView.Items.Add(lvi);
            }
            // 정보 출력
            this.CompleteTimerBar.Value = Oper1CompleteTimerint; // 진행율 바 == 증가한 타이머
            this.Complete_txt.Text = Str_Oper1Complete + " " + Oper1CompleteTimerint + " " + "%"; // % 증가한 타이머 텍스트 출력
            this.Complete_lbl.Text = Str_Completer + " " + Oper1_NumberToday + " " + "EA"; // Oper1 오늘 생산량
            this.Completeresult_txt.Text = Str_Completerresult + " " + Oper1_Total_production + " " + "EA"; // Oper1 누적 생산량
            
        }

        // 텍스트 유무 확인
        private bool TextCheck()
        {
            if (this.Oper_DTP.Text != "")
            {
                return true;
            }
            else

                return false;
        }

        // 2호기 ====================================================================================================================================


        // < 2호기 문자열 저장 > --------------------------------------------------------------------------------------------------------------------
        string Str_Oper2time = "가동시간 : ";
        string Str_Oper2Complete = "공정 진행율 : ";
        string Str_Completer2 = "오늘 생산량 : ";
        string Str_Completerresult2 = "누적 생산량 : ";
        string Str_Mode1_Today2 = "오늘 화성공정 : ";
        string Str_Mode2_Today2 = "오늘 기타공정 : ";
        string Str_Mode1_Num2 = "누적 화성공정 : ";
        string Str_Mode2_Num2 = "누적 기타공정 : ";

        // 콤보박스 공정 선택 문자열
        string[] SList2 = new string[] { "화성공정", "기타공정" };

        // 전체 가동 타이머 정수
        int Oper2Timerint;

        // 완성 타이머 시간 정수
        int Oper2CompleteTimerint;

        bool Oper2_input; // 전극공정
        bool Oper2_input2; // 조립공정

        // < 연속 가동 버튼 하나로 제어 > -----------------------------------------------------------------------------------------------------------
        private void Oper2start_btn2_Click(object sender, EventArgs e)
        {
            if (Mode2_CB.Text == "화성공정") // 모드 선택 조건
            {
                if (Oper2_input2 == false) // 입력 가동이 OFF인 상태
                {
                    if (Oper2_input == false) // 연속 가동이 OFF인 상태
                    {
                        // 타이머 시작
                        Oper2_timer.Start();
                        Complete2_Timer.Start();

                        Oper2_input = true;
                        Mode2_CB.Enabled = false;
                        CAM2_PB.Enabled = true;

                        // 텍스트 변경
                        this.Oper2start_btn.Text = "정지";
                        this.ControlMode2_txt.Text = "화성공정 실행";

                        this.Oper2LampPB.Image = (Image)this.Lamp_imglist.Images[0];
                        CAM2_PB.Image = System.Drawing.Image.FromFile("C:/Users/ffpp1/Desktop/MES/MES/source/img/Homeimg.gif");

                    }
                    else
                    {
                        Oper2_timer.Stop();
                        Complete2_Timer.Stop();

                        Oper2_input = false;
                        Mode2_CB.Enabled = true;
                        CAM2_PB.Enabled = false;

                        this.Oper2start_btn.Text = "가동";
                        this.ControlMode2_txt.Text = "정지";

                        this.Oper2LampPB.Image = (Image)this.Lamp_imglist.Images[1];

                        // 정지 시 초기화
                        Oper2CompleteTimerint = 0;
                        Complete2TimerBar.Value = 0;
                        Complete2_txt.Text = Str_Oper1Complete;
                    }
                }
                else
                {
                    MessageBox.Show("입력 가동 중입니다.", "경고",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (Mode2_CB.Text == "기타공정")
            {
                if (Oper2_input2 == false) // 입력 가동이 OFF인 상태
                {
                    if (Oper2_input == false) // 연속 가동이 OFF인 상태
                    {
                        // 타이머 시작
                        Oper2_timer.Start();
                        Complete2_Timer.Start();

                        Oper2_input = true;
                        Mode2_CB.Enabled = false;
                        CAM2_PB.Enabled = true;

                        // 텍스트 변경
                        this.Oper2start_btn.Text = "정지";
                        this.ControlMode2_txt.Text = "기타공정 실행";

                        // 램프 정지 이미지
                        this.Oper2LampPB.Image = (Image)this.Lamp_imglist.Images[0];
                        CAM2_PB.Image = System.Drawing.Image.FromFile("C:/Users/ffpp1/DesktopMES/MES/source/img/etc.gif");
                    }
                    else
                    {
                        Oper2_timer.Stop();
                        Complete2_Timer.Stop();

                        Oper2_input = false;
                        Mode2_CB.Enabled = true;
                        CAM2_PB.Enabled = false;

                        this.Oper2start_btn.Text = "가동";
                        this.ControlMode2_txt.Text = "정지";

                        this.Oper2LampPB.Image = (Image)this.Lamp_imglist.Images[1];

                        // 정지 시 초기화
                        Oper2CompleteTimerint = 0;
                        Complete2TimerBar.Value = 0;
                        Complete2_txt.Text = Str_Oper2Complete;
                    }
                }
                else
                {
                    MessageBox.Show("입력 가동 중입니다.", "경고",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // < 긴급정지 버튼 > ------------------------------------------------------------------------------------------------------------------------
        private void Oper2stop_btn_Click(object sender, EventArgs e)
        {

            if (Oper2_input == false)
            {
                if (Oper2_input2 == false)
                {
                    MessageBox.Show("정지 상태 입니다.", "경고",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Oper2_timer.Stop();
                Complete2_Timer.Stop();

                Oper2_input = false;
                Oper2_input2 = false;
                CAM2_PB.Enabled = false;

                this.Oper2start_btn.Text = "가동";
                this.Oper2start_btn2.Text = "가동";
                this.ControlMode2_txt.Text = "긴급정지";

                this.Oper2LampPB.Image = (Image)this.Lamp_imglist.Images[2];
            }

        }

        // < 입력 가동 버튼 > -----------------------------------------------------------------------------------------------------------------------
        private void Oper2start_btn2_Click_1(object sender, EventArgs e)
        {
            if (IntCheck() == true)
            {
                Oper2_Start_Count = Convert.ToInt32(this.Oper2_start_txt.Text);
                this.Oper2_start_txt.ReadOnly = true;

                if (Mode2_CB.Text == "화성공정") // 모드 선택 조건
                {
                    if (Oper2_input == false) // 연속 가동이 OFF인 상태
                    {
                        if (Oper2_input2 == false) // 입력 가동이 OFF인 상태
                        {
                            // 타이머 시작
                            Oper2_timer.Start();
                            Complete2_Timer.Start();

                            Oper2_input2 = true;
                            Mode2_CB.Enabled = false;
                            CAM2_PB.Enabled = true;

                            // 텍스트 변경
                            this.Oper2start_btn2.Text = "정지";
                            this.ControlMode2_txt.Text = "화성공정 실행";

                            // 램프 정지 이미지
                            this.Oper2LampPB.Image = (Image)this.Lamp_imglist.Images[0];
                        }
                        else
                        {
                            Oper2_timer.Stop();
                            Complete2_Timer.Stop();

                            Oper2_input2 = false;
                            Mode2_CB.Enabled = true;
                            CAM2_PB.Enabled = false;
                            this.Oper2_start_txt.ReadOnly = false;

                            this.Oper2start_btn2.Text = "가동";
                            this.ControlMode2_txt.Text = "정지";

                            this.Oper2LampPB.Image = (Image)this.Lamp_imglist.Images[1];

                            // 정지 시 초기화
                            Oper2CompleteTimerint = 0;
                            Complete2TimerBar.Value = 0;
                            Complete2_txt.Text = Str_Oper2Complete;
                        }
                    }
                    else
                    {
                        MessageBox.Show("연속 가동 중입니다.", "경고",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (Mode2_CB.Text == "기타공정")
                {
                    if (Oper2_input == false) // 입력 가동이 OFF인 상태
                    {
                        if (Oper2_input2 == false) // 연속 가동이 OFF인 상태
                        {
                            // 타이머 시작
                            Oper2_timer.Start();
                            Complete2_Timer.Start();

                            Oper2_input2 = true;
                            Mode2_CB.Enabled = false;
                            CAM2_PB.Enabled = true;

                            // 텍스트 변경
                            this.Oper2start_btn2.Text = "정지";
                            this.ControlMode2_txt.Text = "기타공정 실행";

                            // 램프 정지 이미지
                            this.Oper2LampPB.Image = (Image)this.Lamp_imglist.Images[0];
                        }
                        else
                        {
                            Oper2_timer.Stop();
                            Complete2_Timer.Stop();

                            Oper2_input2 = false;
                            Mode2_CB.Enabled = true;
                            CAM2_PB.Enabled = false;

                            this.Oper2start_btn2.Text = "가동";
                            this.ControlMode2_txt.Text = "정지";

                            this.Oper2LampPB.Image = (Image)this.Lamp_imglist.Images[1];

                            // 정지 시 초기화
                            Oper2CompleteTimerint = 0;
                            Complete2TimerBar.Value = 0;
                            Complete2_txt.Text = Str_Oper2Complete;
                        }
                    }
                    else
                    {
                        MessageBox.Show("연속 가동 중입니다.", "경고",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // 리스트 뷰 문자열
        string Str_Name2, Str_Mode2, Str_Num2, Str_Day2, Str_True2, Str_Failed2, Str_Edit2;

        // 동적 저장 불러오기
        string Oper2_Name = Properties.Settings.Default.Oper2_NameValue;
        int Oper2_Total_production = Properties.Settings.Default.Oper2_Total_productionValue;
        int Oper2_Mode1_Number = Properties.Settings.Default.Oper2_Mode_1_Total_productionValue;
        int Oper2_Mode2_Number = Properties.Settings.Default.Oper2_Mode_2_Total_productionValue;
        string Oper2_Mode1 = Properties.Settings.Default.Oper2_Mode_1Value;
        string Oper2_Mode2 = Properties.Settings.Default.Oper2_Mode_2Value;

        // 오늘 생산량 초기화됨
        int Oper2_NumberToday = 0;
        int Oper2_Mode1_Today = 0;
        int Oper2_Mode2_Today = 0;
        int Oper2_Start_Count = 0;

        // < 제품 1개 완성 타이머 > -----------------------------------------------------------------------------------------------------------------

        private void Complete2_Timer_Tick(object sender, EventArgs e)
        {
            Oper2CompleteTimerint++;

            if (Complete2TimerBar.Value == 100)
            {
                Oper2CompleteTimerint = 0;           // 초기화
                Oper2_Total_production++;            // 사이클 한번 돌면 누적 생산량 1증가
                Oper2_NumberToday++;                 // Today 생산량 1증가(종료 시 초기화 되는 값)

                // < 화성공정 > ---------------------------------------------------------------------------------------------------------------------

                if (Mode2_CB.Text == "화성공정")
                {
                    if (Oper2_input2 == true)
                    {
                        if (Oper2_Start_Count - 1 < 1)
                        {
                            Complete2_Timer.Enabled = false;
                            this.Oper2_start_txt.ReadOnly = false;
                            CAM2_PB.Enabled = false;
                            Oper2_input2 = false;
                            Mode2_CB.Enabled = true;

                            this.Oper2start_btn2.Text = "가동"; Oper2start_btn2.Text = "가동";
                            this.Oper2_start_txt.Text = "";
                            MessageBox.Show("입력공정 완료", "알림",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Oper2_Start_Count--;
                            this.Oper2_start_txt.Text = Convert.ToString(Oper2_Start_Count);
                        }
                    }
                    Oper2_Mode1_Number++; // 누적 공정1 1회 증가
                    Oper2_Mode1_Today++; // 오늘 공정1 1회 증가

                    Str_Name2 = Oper2_Name; // 품명
                    Str_Mode2 = Oper2_Mode1; // 모드명
                    Str_Num2 = Convert.ToString(Oper2_Mode1_Number); // 누적 공정1 텍스트 값 = Str_Num

                    this.Oper2_Mode1_txt.Text = Str_Mode1_Num2 + Str_Num2 + " " + "회"; // 누적 공정 텍스트 출력
                    this.Oper2_Mode1_Today_txt.Text = Str_Mode1_Today2 + Convert.ToString(Oper2_Mode1_Today) + " " + "회"; // 오늘 공정1 텍스트 출력
                }

                // < 기타공정 > ---------------------------------------------------------------------------------------------------------------------

                else if (Mode2_CB.Text == "기타공정")
                {
                    if (Oper2_input2 == true)
                    {
                        if (Oper2_Start_Count - 1 < 1)
                        {
                            Complete2_Timer.Enabled = false;
                            this.Oper2_start_txt.ReadOnly = false;
                            CAM2_PB.Enabled = false;
                            Oper2_input2 = false;
                            Mode2_CB.Enabled = true;

                            this.Oper2start_btn2.Text = "가동"; Oper2start_btn2.Text = "가동";
                            this.Oper2_start_txt.Text = "";
                            MessageBox.Show("입력공정 완료", "알림",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Oper2_Start_Count--;
                            this.Oper2_start_txt.Text = Convert.ToString(Oper2_Start_Count);
                        }
                    }

                    Oper2_Mode2_Number++;
                    Oper2_Mode2_Today++;

                    Str_Name2 = Oper2_Name; // 품명
                    Str_Mode2 = Oper2_Mode2; // 모드명
                    Str_Num2 = Convert.ToString(Oper2_Mode2_Number);

                    this.Oper2_Mode2_txt.Text = Str_Mode2_Num2 + Str_Num2 + " " + "회"; // 누적 공정 텍스트 출력
                    this.Oper2_Mode2_Today_txt.Text = Str_Mode2_Today2 + Convert.ToString(Oper2_Mode2_Today) + " " + "회"; // 오늘 공정2 텍스트 출력

                }
                // < 리스트 뷰 출력할 정보 값 > -----------------------------------------------------------------------------------------------------

                if (TextCheck() == true)
                {
                    Str_Day2 = this.Oper_DTP.Text; // 날짜
                    Str_True2 = "O"; // 텍스트 O
                }
                else return;

                ListViewItem lvi = new ListViewItem(new string[] { Str_Name2 + Str_Mode2 + "_" + Str_Num2, Str_Day2, Str_True2, Str_Failed2, Str_Edit2 });
                this.Oper2listView.Items.Add(lvi);
            }
            // < 정보 출력 > 
            this.Complete2TimerBar.Value = Oper2CompleteTimerint;
            this.Complete2_txt.Text = Str_Oper2Complete + " " + Oper2CompleteTimerint + " " + "%";
            this.Complete2_lbl.Text = Str_Completer2 + " " + Oper2_NumberToday + " " + "EA";
            this.Completeresult2_txt.Text = Str_Completerresult2 + " " + Oper2_Total_production + " " + "EA";
        }

        // < 숫자 체크 > ----------------------------------------------------------------------------------------------------------------------------
        private bool IntCheck()
        {
            if (Information.IsNumeric(this.Oper1_start_txt.Text)) // 1호기 텍스트박스
                return true;
            if (Information.IsNumeric(this.Oper2_start_txt.Text)) // 2호기 텍스트박스
                return true;
            else
            {
                MessageBox.Show("숫자를 입력하세요.", "알림",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        // < 전체 가동 시간 표시 > ------------------------------------------------------------------------------------------------------------------

        private void Oper1timer_Tick(object sender, EventArgs e) // 1호기
        {
            Oper1Timerint++;

            this.Oper1_time_txt.Text = Str_Oper1time + " " +
                new TimeSpan(0, 0, Oper1Timerint).ToString("hh\\:mm\\:ss");
        }

        private void Oper2_timer_Tick(object sender, EventArgs e) // 2호기
        {
            Oper2Timerint++;

            this.Oper2_time_txt.Text = Str_Oper2time + " " +
                new TimeSpan(0, 0, Oper2Timerint).ToString("hh\\:mm\\:ss");
        }

        // < 입력가동 리셋버튼 > --------------------------------------------------------------------------------------------------------------------
        private void Setbtn_Click(object sender, EventArgs e) // 1호기
        {
            Oper1CompleteTimerint = 0;
            CompleteTimerBar.Value = 0;
            Complete_txt.Text = Str_Oper1Complete;
            Oper1_input2 = false;
            Mode_CB.Enabled = true;
            Complete_Timer.Enabled = false;
            CAM_PB.Enabled = false;
            this.Oper1_start_txt.ReadOnly = false;
            this.Oper1start_btn2.Text = "가동";
            this.Oper1_start_txt.Text = "";
        }

        private void Set2btn_Click(object sender, EventArgs e) // 2호기
        {
            Oper2CompleteTimerint = 0;
            Complete2TimerBar.Value = 0;
            Complete2_txt.Text = Str_Oper2Complete;
            Oper2_input2 = false;
            Mode2_CB.Enabled = true;
            Complete2_Timer.Enabled = false;
            CAM2_PB.Enabled = false;
            this.Oper2_start_txt.ReadOnly = false;
            this.Oper2start_btn2.Text = "가동";
            this.Oper2_start_txt.Text = "";
        }

        // < 추가사항 엔터 > ------------------------------------------------------------------------------------------------------------------------

        private void Oper1_Edit_txt_KeyUp(object sender, KeyEventArgs e) // 1호기
        {

            if (e.KeyCode == Keys.Enter) // 엔터 키 조건
            {
                Text = Convert.ToString(Oper1_Edit_txt.Text); // int -> string 변환

                if (Oper1listView.SelectedIndices.Count == 0) // 리스트뷰 선택 == 0
                {
                    MessageBox.Show("수정할 위치를 선택해 주세요", "경고",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Oper1listView.SelectedItems[0].SubItems[4].Text = Text.ToString(); // 리스트뷰 칼럼 5번째 값은 = Text
                Oper1_Edit_txt.Clear(); // 텍스트박스 클리어
            }

        }

        private void Oper2_Edit_txt_KeyUp(object sender, KeyEventArgs e) // 2호기
        {

            if (e.KeyCode == Keys.Enter)
            {
                Text = Convert.ToString(Oper2_Edit_txt.Text);

                if (Oper2listView.SelectedIndices.Count == 0)
                {
                    MessageBox.Show("수정할 위치를 선택해 주세요", "경고",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Oper2listView.SelectedItems[0].SubItems[4].Text = Text.ToString();
                Oper2_Edit_txt.Clear();
            }

        }

        // < 추가사항 삭제 > ------------------------------------------------------------------------------------------------------------------------

        private void button1_Click(object sender, EventArgs e) // 1호기
        {
            Oper1listView.SelectedItems[0].SubItems[4].Text = "";
        }

        private void button2_Click(object sender, EventArgs e) // 2호기
        {
            Oper2listView.SelectedItems[0].SubItems[4].Text = "";
        }

        // < 1호기 공정내역 초기화 버튼 > -----------------------------------------------------------------------------------------------------------

        private void Result_resetbtn_Click(object sender, EventArgs e) // 1호기
        {
            Del_Timer.Enabled = true;
        }

        private void Result2_resetbtn_Click(object sender, EventArgs e) // 2호기
        {
            Del_Timer.Enabled = true;
        }

        // < 1호기& 2호기 데이터 저장 / 삭제 > ------------------------------------------------------------------------------------------------------

        // 데이터 저장 타이머
        private void UploadTimer_Tick(object sender, EventArgs e)
        {
            // 1호기
            Properties.Settings.Default.Oper1_Total_productionValue = Oper1_Total_production; // 누적 생산량
            Properties.Settings.Default.Oper1_Mode_1_Total_productionValue = Oper1_Mode1_Number; // 공정1 누적수
            Properties.Settings.Default.Oper1_Mode_2_Total_productionValue = Oper1_Mode2_Number; // 공정2 누적수

            // 2호기
            Properties.Settings.Default.Oper2_Total_productionValue = Oper2_Total_production;
            Properties.Settings.Default.Oper2_Mode_1_Total_productionValue = Oper2_Mode1_Number;
            Properties.Settings.Default.Oper2_Mode_2_Total_productionValue = Oper2_Mode2_Number;

            Properties.Settings.Default.Save(); // 저장
        }

        // 누적 공정내역 초기화용 정수
        int Oper1_Total_productionValue_Reset = 0;
        int Oper1_Mode_1_Total_productionValue_Reset = 0;
        int Oper1_Mode_2_Total_productionValue_Reset = 0;
        int Oper2_Total_productionValue_Reset = 0;
        int Oper2_Mode_1_Total_productionValue_Reset = 0;
        int Oper2_Mode_2_Total_productionValue_Reset = 0;

        // 누적 데이터 삭제 타이머
        private void DelTimer_Tick(object sender, EventArgs e)
        {
            // 1호기
            Properties.Settings.Default.Oper1_Total_productionValue = Oper1_Total_productionValue_Reset;
            Properties.Settings.Default.Oper1_Mode_1_Total_productionValue = Oper1_Mode_1_Total_productionValue_Reset;
            Properties.Settings.Default.Oper1_Mode_2_Total_productionValue = Oper1_Mode_2_Total_productionValue_Reset;

            // 2호기
            Properties.Settings.Default.Oper1_Total_productionValue = Oper2_Total_productionValue_Reset;
            Properties.Settings.Default.Oper1_Mode_1_Total_productionValue = Oper2_Mode_1_Total_productionValue_Reset;
            Properties.Settings.Default.Oper1_Mode_2_Total_productionValue = Oper2_Mode_2_Total_productionValue_Reset;

            Properties.Settings.Default.Save();
        }
    }
}