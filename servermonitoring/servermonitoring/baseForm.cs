using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using System.IO;
using System.Diagnostics;
using System.Threading;


namespace servermonitoring
{
    public partial class baseForm : XtraForm
    {
        public baseForm()
        {
            InitializeComponent();

            //this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Visible = false;
            this.tray.Visible = true;

            setData();
            tabMoveThread();

            xtraTabControl2.SelectedTabPageIndex = 0;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string filePath = "C:\\MonitoringLog";

            DirectoryInfo dir = new DirectoryInfo(filePath);

            if (dir.Exists == false)
            {
                dir.Create();
            }

            Process.Start(filePath);
        }

        int locationX = 0;
        int locationY = 0;
        string beforeLocation = "";
        bool threadStop = true;

        protected void SetPosition(XtraUserControl sc, int cnt, string locationcd)
        {
            // git commit 테스트   
            try
            {
                Panel pan;

                if (locationcd == "A")
                {
                    // 부산
                    pan = panelA;
                    pan.Controls.Add(sc);
                }
                else if (locationcd == "B")
                {
                    // 순천
                    pan = panelB;
                    pan.Controls.Add(sc);
                }
                else if (locationcd == "D")
                {
                    // 스텐
                    pan = panelD;
                    pan.Controls.Add(sc);
                }
                else if (locationcd == "E")
                {
                    // 서울
                    pan = panelE;
                    pan.Controls.Add(sc);
                }
                else if (locationcd == "F" || locationcd == "G" || locationcd == "I")
                {
                    // 해외지사 F :: 뉴욕, G :: 유럽, I :: 일본
                    pan = panelF;
                    pan.Controls.Add(sc);
                }
                else if (locationcd == "H")
                {
                    // 2공장
                    pan = panelH;
                    pan.Controls.Add(sc);
                }
                else if (locationcd == "J")
                {
                    // 청도
                    pan = panelJ;
                    pan.Controls.Add(sc);
                }
                else if (locationcd == "L")
                {
                    // 율촌
                    pan = panelL;
                    pan.Controls.Add(sc);
                }
                else if (locationcd == "O")
                {
                    // 베트남
                    pan = panelO;
                    pan.Controls.Add(sc);
                }
                else
                {
                    pan = new Panel();
                }

                int fullsizeX = pan.Size.Width;
                int fullsizeY = pan.Size.Height;

                if (beforeLocation != "" && beforeLocation != locationcd)
                {
                    locationX = 0;
                    locationY = 0;
                }

                sc.Location = new System.Drawing.Point(locationX, locationY);

                if (fullsizeX <= locationX + sc.Size.Width)
                {
                    locationX = 0;
                    locationY += sc.Size.Height;
                }
                else
                {
                    locationX += sc.Size.Width;
                }

                beforeLocation = locationcd;
                //locationX =  ? locationX + sc.Size.Width : 0;
                //locationY = fullsizeX > locationX + sc.Size.Width ? 0 : locationY + sc.Size.Height;

                sc.Name = "uSubMenu" + cnt;
                sc.Size = new System.Drawing.Size(sc.Size.Width, sc.Size.Height);
                sc.TabIndex = cnt;
            }
            catch (Exception ex)
            {
                Common.LogWrite("E", "SetPosition : " + ex.Message + "\n"); 
                
                
            }
        }
        int TotallocationX = 0;
        int TotallocationY = 0;
        protected void SetToTalPosition(XtraUserControl sc, int cnt, string locationcd)
        {
            
            try
            {
                Panel pan = panelTotal;
                pan.Controls.Add(sc);
                
                int fullsizeX = pan.Size.Width;
                int fullsizeY = pan.Size.Height;

                if (cnt==0)
                {
                    TotallocationX = 0;
                    TotallocationY = 0;
                }

                sc.Location = new System.Drawing.Point(TotallocationX, TotallocationY);

                if (fullsizeX <= TotallocationX + sc.Size.Width)
                {
                    TotallocationX = 0;
                    TotallocationY += sc.Size.Height;
                }
                else
                {
                    TotallocationX += sc.Size.Width;
                }

                //beforeLocation = locationcd;
                //locationX =  ? locationX + sc.Size.Width : 0;
                //locationY = fullsizeX > locationX + sc.Size.Width ? 0 : locationY + sc.Size.Height;

                sc.Name = "uSubMenuTotal" + cnt;
                sc.Size = new System.Drawing.Size(sc.Size.Width, sc.Size.Height);
                sc.TabIndex = cnt;
            }
            catch (Exception ex)
            {
                Common.LogWrite("E", "SetPosition : " + ex.Message + "\n");
            }
        }

        public void setData()
        {
            Database db=null;
            try
            {
                string sql = @"SELECT (SELECT SUBNM_KR AS SUBNM FROM CO011T WHERE MAINCD='CO411' AND T1.CHRREF2=SUBCD) TESTNM, SUBSTRING(T1.SUBCD,1,1) LOCATIONCD,
                               (SELECT SUBNM_KR AS SUBNM FROM CO011T WHERE MAINCD='CO002' AND SUBSTRING(T1.SUBCD,1,1)=SUBCD) LOCATION, 
						       SUBNM_KR AS SUBNM,	SUBCD, CHRREF1, CHRREF2, CHRREF3, CHRREF4, CHRREF5, CHRREF6, CHRREF7, CHRREF8,
						       NUMREF1, NUMREF2, NUMREF3, NUMREF4	   					   
                               FROM CO011T T1 WHERE MAINCD='CO410' AND T1.USEYN='Y'
                               ORDER BY SUBCD";

                db = new Database("10.10.10.8", "DSRERP");
                db.DBOpen();
            
                DataTable dt = db.GetDataTableTxtQuery(sql);
                db.DBClose();
                int cnt = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["CHRREF3"].ToString() == "L")
                    {
                        SetPosition(new subControl2(dr["SUBCD"].ToString(), dr["SUBNM"].ToString(), dr["CHRREF1"].ToString(), dr["CHRREF2"].ToString(), dr["TESTNM"].ToString(),
                        "pingtest", "ping13579", dr["CHRREF5"].ToString(), dr["CHRREF6"].ToString(), dr["LOCATION"].ToString(), Convert.ToInt32(dr["NUMREF2"])),
                        cnt, dr["LOCATIONCD"].ToString());

                        SetToTalPosition(new TotalsubControl2(dr["SUBCD"].ToString(), dr["SUBNM"].ToString(), dr["CHRREF1"].ToString(), dr["CHRREF2"].ToString(), dr["TESTNM"].ToString(),
                        "pingtest", "ping13579", dr["CHRREF5"].ToString(), dr["CHRREF6"].ToString(), dr["LOCATION"].ToString(), Convert.ToInt32(dr["NUMREF2"])),
                        cnt, dr["LOCATIONCD"].ToString());
                    }
                    else
                    {
                        SetPosition(new subControl(dr["SUBCD"].ToString(), dr["SUBNM"].ToString(), dr["CHRREF1"].ToString(), dr["CHRREF2"].ToString(), dr["TESTNM"].ToString(),
                        "pingtest", "ping13579", dr["CHRREF5"].ToString(), dr["CHRREF6"].ToString(), dr["LOCATION"].ToString(), Convert.ToInt32(dr["NUMREF2"])),
                        cnt, dr["LOCATIONCD"].ToString());

                        SetToTalPosition(new TotalsubControl(dr["SUBCD"].ToString(), dr["SUBNM"].ToString(), dr["CHRREF1"].ToString(), dr["CHRREF2"].ToString(), dr["TESTNM"].ToString(),
                        "pingtest", "ping13579", dr["CHRREF5"].ToString(), dr["CHRREF6"].ToString(), dr["LOCATION"].ToString(), Convert.ToInt32(dr["NUMREF2"])),
                        cnt, dr["LOCATIONCD"].ToString());
                    }
                    cnt++;
                }
            }
            catch (Exception ex)
            {
                if (db.IsOpen)
                    db.DBClose();

                Common.LogWrite("E", "setData : " + ex.Message + "\n"); 
            }
        }

        public void tabMoveThread()
        {
            Thread tabMoveThread = new Thread(new ThreadStart(tabMove));
            tabMoveThread.Start();
        }

        public void tabMove()
        {

            while (true)
            {
                if (!threadStop)
                {
                    tabMoveAct();
                }
                
                Thread.Sleep(1000 * 20);
            }
        }
        
        int tabCnt = 0;

        delegate void tabMoveActStart();
        public void tabMoveAct()
        {
            if (this.InvokeRequired)
            {
                tabMoveActStart d = new tabMoveActStart(tabMoveAct);
                this.Invoke(d, new object[] { });
            }
            else
            {
                Database db = new Database("10.10.10.8", "DSRERP");
                db.DBOpen();
                try
                {

                    string sql = @"SELECT NUMREF1 FROM CO011T WHERE MAINCD='CO410' AND CHRREF7='N' AND USEYN='Y' GROUP BY NUMREF1";

                
                    DataTable dt = db.GetDataTableTxtQuery(sql);
                    db.DBClose();

                    if (dt != null)
                    {
                        int totCnt = 0;
                        int[] idx = new int[dt.Rows.Count];

                        foreach (DataRow dr in dt.Rows)
                        {
                            idx[totCnt] = Convert.ToInt32(dr["NUMREF1"]);
                            totCnt++;
                        }

                        if (tabCnt >= totCnt)
                        {
                            tabCnt = 0;
                        }

                        xtraTabControl2.SelectedTabPageIndex = idx[tabCnt++];
                        
                    }
                    else
                    {
                        int tabcnt = xtraTabControl2.TabPages.Count - 1;
                        int selectedIdx = xtraTabControl2.SelectedTabPageIndex;

                        if (xtraTabControl2.TabPages.Count == 0)
                        {
                            return;
                        }

                        if (tabcnt == selectedIdx)
                            xtraTabControl2.SelectedTabPageIndex = 0;
                        else
                            xtraTabControl2.SelectedTabPageIndex++;
                    }
                }
                catch (Exception ex)
                {
                    if (db.IsOpen)
                        db.DBClose();
                    Common.LogWrite("E", "tabMoveAct : " + ex.Message + "\n");
                    // MessageBox.Show(ee.Message);
                }
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barButtonItem3.Caption == "Stop")
            {
                barButtonItem3.Caption = "Move";
                threadStop = true;
            }
            else
            {
                barButtonItem3.Caption = "Stop";
                threadStop = false;
            }
        }

        private void baseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) //유저가 종료 하려 할때
            {
                e.Cancel = true;//종료를 취소하고 
                this.Visible = false;//어플리케이션을 숨긴다. 
                this.tray.Visible = true;
            }
            else 
            {
                this.tray.Visible = true;   //NotifyIcon을 숨기고 종료
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process[] _proceses = null;

            _proceses = Process.GetProcessesByName("servermonitoring");
            foreach (Process proces in _proceses)
            {
                proces.Kill();
                System.Threading.Thread.Sleep(1000);
            }
            this.tray.Visible = false;
            Application.Exit();
        }

        private void tray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = true;
            this.Visible = true;
            this.tray.Visible = false;
        }

        private void baseForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

    }
}