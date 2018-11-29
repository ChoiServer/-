using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;

namespace servermonitoring
{
    public partial class subControl : DevExpress.XtraEditors.XtraUserControl
    {
        private bool bFlag = false;
        private string serverCd;
        private string serverNm;
        private string serverIp;
        private string testTypeCd;
        private string testTypeNm;
        private string sqlId;
        private string sqlPw;
        private string sqlPort;
        private string sqlDbNm;
        private string location;
        private int sec;
        private BackgroundWorker bg_Data_Check;

        public subControl()
        {
            InitializeComponent();
        }

        public subControl(string serverCd, string serverNm, string serverIp, string testTypeCd, string testTypeNm, string sqlId, string sqlPw, string sqlDbNm, string sqlPort, string location, int sec)
        {
            try
            {
                InitializeComponent();
                this.serverCd = serverCd;
                this.serverNm = serverNm;
                this.serverIp = serverIp;
                this.testTypeCd = testTypeCd;
                this.testTypeNm = testTypeNm;
                this.sqlId = sqlId;
                this.sqlPw = sqlPw;
                this.sqlDbNm = sqlDbNm;
                this.sqlPort = sqlPort;
                this.location = location;
                this.sec = sec;
                setText();

                //Thread setTestThread = new Thread(setTest);
                //setTestThread.Start();

                this.bg_Data_Check = new BackgroundWorker();
                this.bg_Data_Check.DoWork += new DoWorkEventHandler(setTest);
                this.bg_Data_Check.WorkerSupportsCancellation = true;
                this.bg_Data_Check.RunWorkerAsync();

                // 백그라운드 가동 플래그
                bFlag = true;

            }
            catch { }
        }

        public string getServerCd()
        {
            return this.serverCd;
        }

        private void setText()
        {
            try
            {
                label2.Text = serverNm;
                label5.Text = serverIp;

                pingIMG.Visible = false;
                mailIMG.Visible = false;
                mssqlIMG.Visible = false;
                mysqlIMG.Visible = false;

                if (this.testTypeCd == "00")
                {
                    pingIMG.Visible = true;
                }
                else if (this.testTypeCd == "01")
                {
                    mssqlIMG.Visible = true;
                }
                else if (this.testTypeCd == "02")
                {
                    mysqlIMG.Visible = true;
                }
                else if (this.testTypeCd == "03")
                {
                    mailIMG.Visible = true;
                }
                else
                {
                    pingIMG.Visible = true;
                }
            }
            catch { }
        }

        // 테스트타입별로 분기(00 :: ping, 01 :: mssql, 02 :: mysql, 03 :: mail)
        public bool switchTestType()
        {
            bool rtn = false;

            switch (testTypeCd)
            {
                case "00":
                    // ping test
                    rtn = Functions.pingTest2(this.serverIp);
                    break;
                case "01":
                    // mssql test
                    rtn = Functions.mssqlTest(this.serverIp, this.sqlId, this.sqlPw);
                    break;
                case "02":
                    // mysql test
                    rtn = Functions.mysqlTest(this.serverIp, this.sqlPort, this.sqlDbNm, this.sqlId, this.sqlPw);
                    break;
                case "03":
                    // mail test
                    rtn = Functions.mailTest(this.serverIp);
                    break;
                default:
                    rtn = false;
                    break;
            }

            return rtn;
        }

        public void setTest(object sender, DoWorkEventArgs e)
        {
            int cnt = 0;
            bool messageFlag = false;
            bool re = false;
            do
            {
                try
                {
                    Thread.Sleep(1000 * this.sec); // 180초 

                    if (bFlag)
                    {
                        bool rtn = switchTestType();

                        //Console.WriteLine(this.serverNm + "::" + this.serverIp + "TEST START");

                        if (rtn)
                        {
                            changeStatus(rtn);
                            Functions.changeFlag("Y", this.serverCd);
                            cnt = 0;

                            if (messageFlag)
                            {
                                Functions.sendMessage(true, this.serverNm, this.serverIp, this.location);
                                Functions.saveLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " :: " + this.serverNm + " :: " + this.serverIp + " :: 해당 서버와 통신 연결됨.");
                                messageFlag = false;
                            }

                            //Console.WriteLine(this.serverNm + "::" + this.serverIp + "SERVER ON");

                            Thread.Sleep(1000 * this.sec);
                        }
                        else
                        {
                            cnt++;
                            //Console.WriteLine(this.serverNm + "::" + this.serverIp + "RETEST " + cnt);

                            if (cnt < 3)
                            {
                                //Thread.Sleep(1000 * 30);
                            }
                            else if (cnt == 3)
                            {
                                //Console.WriteLine(this.serverNm + "::" + this.serverIp + "SERVER OFF");

                                changeStatus(rtn);
                                Functions.changeFlag("N", this.serverCd);
                                Functions.sendMessage(false, this.serverNm, this.serverIp, this.location);
                                Functions.saveLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " :: " + this.serverNm + " :: " + this.serverIp + " :: 해당 서버와 통신 안됨.");
                                messageFlag = true;
                                //Thread.Sleep(1000 * this.sec);
                            }
                            else
                            {
                                //Thread.Sleep(1000 * this.sec);
                            }
                        }

                        //Console.WriteLine(this.serverNm + "::" + this.serverIp + "TEST FINISH");
                    }
                }
                catch (Exception ex)
                {
                    Common.LogWrite("E", "setTest : " + ex.Message + "\n");
                }
            } while (!re);//!bgLiveUpdate.CancellationPending);
        }

        // 상태 변환 메소드 (빨강, 초록)
        delegate void SetchangeStatusStart(bool stat);
        public void changeStatus(bool stat)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    SetchangeStatusStart d = new SetchangeStatusStart(changeStatus);
                    this.Invoke(d, new object[] { stat });
                }
                else
                {
                    greenColor.Visible = false;
                    redColor.Visible = false;

                    label3.Text = Functions.replyMessage;
                    label4.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    if (stat)
                    {
                        greenColor.Visible = true;
                        panel1.BackgroundImage = DXWindowsApplication2.Properties.Resources.ppt2;
                    }
                    else
                    {
                        redColor.Visible = true;
                        panel1.BackgroundImage = DXWindowsApplication2.Properties.Resources.ppt2r;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.LogWrite("E", "changeStatus : " + ex.Message + "\n");
            }
        }

    }
}
