using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Drawing;
using DevExpress.XtraGrid.Views.Base;
using System.Configuration;
using System.Net.Configuration;
using System.Net;
using System.Net.Sockets;
using System.IO;
using servermonitoring;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.NetworkInformation;

namespace servermonitoring
{
    public static class Functions
    {

        /*
         * ***************
         * test 종류 
         * 1. mail test
         * 2. mysql test
         * 3. mssql test
         * 4. ping test
         * ***************
         */

        // 1. mail test
        public static bool mailTest(string serverIp)
        {
            try
            {
                if (pingTest2(serverIp))
                {
                    bool rtn = false;

                    if (TestConnection(serverIp, 25))
                    {
                        rtn = true;

                    }
                    else
                    {
                        rtn = false;
                    }

                    return rtn;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        // 2. mysql test
        public static bool mysqlTest(string serverIp, string sqlPort, string sqlDbNm, string sqlId, string sqlPw)
        {
            string connStr = "Data Source=" + serverIp + ";Port=" + sqlPort + ";Database=" + sqlDbNm + ";User Id=" + sqlId + ";Password=" + sqlPw + "";
            MySqlConnection conn = new MySqlConnection(connStr);
            bool rtn = false;

            try
            {
                conn.Open();
                if (conn.Ping() == true)
                {
                    rtn = true;
                    pingTest2(serverIp);
                }
                else
                {
                    rtn = false;
                }
                conn.Close();

                return rtn;
            }
            catch (Exception ee)
            {
                conn.Close();
                return false;
            }
        }

        // 3. mssql test
        public static bool mssqlTest(string serverIp, string sqlId, string sqlPw)
        {
            SqlConnection conn=null;
            try
            {
                if (pingTest2(serverIp))
                {
                    bool rtn = false;
                    conn = new SqlConnection();
                    conn.ConnectionString = "Server=" + serverIp + ";uid=" + sqlId + ";pwd=" + sqlPw + ";";

                    conn.Open();

                    if (conn.State == ConnectionState.Open)
                    {
                        rtn = true;

                    }
                    else if (conn.State == ConnectionState.Closed)
                    {
                        rtn = false;
                    }

                    conn.Close();
                    conn.Dispose();

                    return rtn;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ee)
            {
                conn.Close();
                conn.Dispose();
                return false;
            }
        }

        // 4. ping test
        public static string replyMessage = "";
        public static bool pingTest2(string serverIp)
        {
            Ping ping = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;

            string data = "aa";
            byte[] buffer = ASCIIEncoding.ASCII.GetBytes(data);
            int timeout = 6000;
            bool rtn = false;

            PingReply reply = ping.Send(serverIp, timeout, buffer, options);

            if (reply.Status == IPStatus.Success)
            {
                replyMessage = "왕복시간 = " + reply.RoundtripTime;
                replyMessage += " TTL = " + reply.Options.Ttl;
                rtn = true;
            }
            else
            {
                replyMessage = "";
            }
            return rtn;
        }

        // test 종류 메소드 끝

        public static void saveLog(string message)
        {
            string FilePath = string.Format("C:\\MonitoringLog" + "\\" + DateTime.Now.ToString("yyyy-MM") + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + "_log.txt");

            FileInfo fi = new FileInfo(FilePath);

            DirectoryInfo dir = new DirectoryInfo("C:\\MonitoringLog" + "\\" + DateTime.Now.ToString("yyyy-MM"));

            if (dir.Exists == false)
            {
                dir.Create();
            }

            try
            {
                if (!fi.Exists)
                {
                    using (StreamWriter sw = new StreamWriter(FilePath))
                    {
                        sw.WriteLine(message);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(FilePath))
                    {
                        sw.WriteLine(message);
                        sw.Close();
                    }
                }
            }
            catch (Exception ee)
            {
                // MessageBox.Show("로그저장실패");
                // MessageBox.Show(ee.Message);
            }
        }

        // 테스트 결과를 플래그로 저장
        public static void changeFlag(string flag, string serverCd)
        {
            string sql = string.Format("UPDATE CO011T SET CHRREF7 = '{0}' WHERE MAINCD='CO410' AND SUBCD='{1}'", flag, serverCd);

            Database db = new Database("10.10.10.8", "DSRERP");
            db.DBOpen();
            try
            {
                db.NonQueryTxt(sql);
                db.DBClose();
            }catch
            {
                if (db.IsOpen)
                    db.DBClose();
            }
        }

        // 테스트 결과 통신이 되지 않을 경우 사내통신 발송
        public static void sendMessage(bool status, string serverNm, string serverIp, string location)
        {
            string title = status ? "서버상태알림(" + serverNm + " 연결복구됨)" : "서버상태알림(" + serverNm + " 연결안됨)";
            string stat = status ? "해당 서버와 통신이 연결되었습니다." : "해당 서버와 통신이 되지 않습니다.";
            string text =
                "<br/><br/><br/>=====================================================<br/>" +
                "=====================서 버 상 태 알 림=====================<br/><br/><br/>" +
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "<br/>" + stat + "<br/><br/>서버이름 : "
                + serverNm + "<br/>서버IP : " + serverIp + "<br/>사업장 : " + location
                + "<br/><br/><br/>=====================================================<br/>"
                + "=====================================================<br/><br/><br/>";

            // PobSend("199999", "210360", title, text);

            PobSendTeam("199999", "013", title, text);
        }


        /// <summary>
        /// test the smtp connection by sending a HELO command
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static bool TestConnection(Configuration config)
        {
            MailSettingsSectionGroup mailSettings = config.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;
            if (mailSettings == null)
            {
                throw new ConfigurationErrorsException("The system.net/mailSettings configuration section group could not be read.");
            }
            return TestConnection(mailSettings.Smtp.Network.Host, mailSettings.Smtp.Network.Port);
        }

        /// <summary>
        /// test the smtp connection by sending a HELO command
        /// </summary>
        /// <param name="smtpServerAddress"></param>
        /// <param name="port"></param>
        public static bool TestConnection(string ipAddress, int port)
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
                using (Socket tcpSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
                {
                    //try to connect and test the rsponse for code 220 = success
                    tcpSocket.Connect(endPoint);
                    if (!CheckResponse(tcpSocket, 220))
                    {
                        return false;
                    }

                    // send HELO and test the response for code 250 = proper response
                    SendData(tcpSocket, string.Format("HELO {0}\r\n", Dns.GetHostName()));
                    if (!CheckResponse(tcpSocket, 250))
                    {
                        return false;
                    }

                    // if we got here it's that we can connect to the smtp server
                    return true;
                }
            }
            catch (Exception ee)
            {
                // MessageBox.Show(ee.Message);
                return false;
            }

        }

        private static void SendData(Socket socket, string data)
        {
            byte[] dataArray = Encoding.ASCII.GetBytes(data);
            socket.Send(dataArray, 0, dataArray.Length, SocketFlags.None);
        }

        private static bool CheckResponse(Socket socket, int expectedCode)
        {
            while (socket.Available == 0)
            {
                System.Threading.Thread.Sleep(100);
            }
            byte[] responseArray = new byte[1024];
            socket.Receive(responseArray, 0, socket.Available, SocketFlags.None);
            string responseData = Encoding.ASCII.GetString(responseArray);
            int responseCode = Convert.ToInt32(responseData.Substring(0, 3));
            if (responseCode == expectedCode)
            {
                return true;
            }
            return false;
        }

        //저장프로시져 콜
        /// <summary>
        /// 이름을 받아서 만듦
        /// </summary>
        /// <param name="_SenderID"></param>
        /// <param name="_ReceiverName"></param>
        /// <param name="_Title"></param>
        /// <param name="_Text"></param>
        /// <returns></returns>
        public static string PrvPobSend(string _SenderID, string _ReceiverNames, string _Title, string _Text, string _GB)
        {
            return PrvPobSend(_SenderID, _ReceiverNames, _Title, _Text, @"N", _GB);
        }


        //저장프로시져 콜
        /// <summary>
        /// 이름을 받아서 만듦
        /// </summary>
        /// <param name="_SenderID"></param>
        /// <param name="_ReceiverName"></param>
        /// <param name="_Title"></param>
        /// <param name="_Text"></param>
        /// <returns></returns>
        public static string PrvPobSend(string _SenderID, string _ReceiverNames, string _Title, string _Text, string size_req, string _GB)
        {
            //_GB : T => 팀, P =>개인
            string url = "10.10.10.6";
            string kmsdb = "DSRKMS";
            //if (GlobalVal.INOUT == "OUT")
            //    url = "210.110.114.6";


            string testconnectstring = String.Format("Data Source={0};database={1};user id={2};password={3}", url, kmsdb, "sa", "dsr");
            ////SqlConnection Cnn = new SqlConnection(GlobalVal.DBConnectString);
            SqlConnection cnn = new SqlConnection(testconnectstring);
            cnn.Open();
            try
            {

                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = cnn;
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandText = "up_pob_send";

                string receivers = _ReceiverNames;

                //마지막 콤마 떼기..
                if (receivers.Trim().Substring(receivers.Length - 1, 1) == ",")
                    receivers = receivers.Substring(0, receivers.Length - 1);


                cmd1.Parameters.Add("@user_id", SqlDbType.VarChar, 20).Value = _SenderID;
                cmd1.Parameters.Add("@datnum", SqlDbType.VarChar, 13).Value = "";
                cmd1.Parameters.Add("@receivers", SqlDbType.NVarChar, 200).Value = receivers;
                cmd1.Parameters.Add("@sec_refer", SqlDbType.NVarChar, 200).Value = "";
                cmd1.Parameters.Add("@title", SqlDbType.NVarChar, 200).Value = _Title;
                cmd1.Parameters.Add("@mmtext", SqlDbType.NText).Value = _Text;
                cmd1.Parameters.Add("@reply_datnum", SqlDbType.VarChar, 13).Value = "";
                cmd1.Parameters.Add("@file_cnt", SqlDbType.Int).Value = 0;
                cmd1.Parameters.Add("@image_seq", SqlDbType.Int).Value = 0;
                cmd1.Parameters.Add("@mobile_send", SqlDbType.VarChar, 1).Value = "N";
                cmd1.Parameters.Add("@booking_dt", SqlDbType.VarChar, 20).Value = "";
                cmd1.Parameters.Add("@size_req", SqlDbType.VarChar, 1).Value = size_req;
                ;

                SqlParameter parm1 = new SqlParameter("@datnum_out", SqlDbType.VarChar, 13);
                parm1.Direction = ParameterDirection.Output;
                cmd1.Parameters.Add(parm1);
                cmd1.ExecuteNonQuery();
                cnn.Close();


            }
            catch (Exception ee)
            {
                if (cnn.State == ConnectionState.Open) cnn.Close();
                return ee.ToString();
            }

            return "";
        }

        //저장프로시져 콜
        /// <summary>
        /// 사번을 받아서 만듦
        /// </summary>
        /// <param name="_SenderID"></param>
        /// <param name="_ReceiverName"></param>
        /// <param name="_Title"></param>
        /// <param name="_Text"></param>
        /// <returns></returns>
        private static string PrvPobSend(string _SenderID, string[] _ReceiverIDs, string _Title, string _Text, string _GB)
        {
            //_GB : T => 팀, P =>개인
            string url = "10.10.10.6";
            string kmsdb = "DSRKMS";
            //if (GlobalVal.INOUT == "OUT")
            //    url = "210.110.114.6";


            string testconnectstring = String.Format("Data Source={0};database={1};user id={2};password={3}", url, kmsdb, "sa", "dsr");
            ////SqlConnection Cnn = new SqlConnection(GlobalVal.DBConnectString);
            SqlConnection cnn = new SqlConnection(testconnectstring);
            cnn.Open();
            try
            {
                //팀명이나 이름으로 변환하기..
                string[] arrReceiversNm = new string[_ReceiverIDs.Length];

                int i = 0;

                foreach (string item in _ReceiverIDs)
                {

                    string sQry;
                    if (_GB.Equals("P"))
                    {
                        sQry = string.Format("select user_name1 from user_master where user_id = '{0}'", item);
                    }
                    else
                    {
                        sQry = string.Format("select ogz_name from ogz_mng where ogz_id = '{0}'", item);
                    }

                    object obj = GetScalarTxtQuery(sQry, cnn);
                    if (obj == null || obj == DBNull.Value) return item + "Error";
                    arrReceiversNm[i] = obj.ToString();
                    i += 1;
                }


                string receivers = "";
                foreach (string item in arrReceiversNm)
                {
                    receivers += item + ",";
                }
                //마지막 콤마 떼기..
                receivers = receivers.Substring(0, receivers.Length - 1);

                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = cnn;
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandText = "up_pob_send";

                cmd1.Parameters.Add("@user_id", SqlDbType.VarChar, 20).Value = _SenderID;
                cmd1.Parameters.Add("@datnum", SqlDbType.VarChar, 13).Value = "";
                cmd1.Parameters.Add("@receivers", SqlDbType.NVarChar, 200).Value = receivers;
                cmd1.Parameters.Add("@sec_refer", SqlDbType.NVarChar, 200).Value = "";
                cmd1.Parameters.Add("@title", SqlDbType.NVarChar, 200).Value = _Title;
                cmd1.Parameters.Add("@mmtext", SqlDbType.NText).Value = _Text;
                cmd1.Parameters.Add("@reply_datnum", SqlDbType.VarChar, 13).Value = "";
                cmd1.Parameters.Add("@file_cnt", SqlDbType.Int).Value = 0;
                cmd1.Parameters.Add("@image_seq", SqlDbType.Int).Value = 0;
                cmd1.Parameters.Add("@mobile_send", SqlDbType.VarChar, 1).Value = "N";
                cmd1.Parameters.Add("@booking_dt", SqlDbType.VarChar, 20).Value = "";
                cmd1.Parameters.Add("@size_req", SqlDbType.VarChar, 1).Value = 'N';
                ;

                SqlParameter parm1 = new SqlParameter("@datnum_out", SqlDbType.VarChar, 13);
                parm1.Direction = ParameterDirection.Output;
                cmd1.Parameters.Add(parm1);
                cmd1.ExecuteNonQuery();
                cnn.Close();

            }
            catch (Exception ee)
            {
                if (cnn.State == ConnectionState.Open) cnn.Close();
                return ee.ToString();
            }

            return "";
        }

        /// <summary>
        /// 사번 배열을 받아, 사내통신 발송
        /// </summary>
        /// <param name="_SenderID"></param>
        /// <param name="_UserID"></param>
        /// <param name="_Title"></param>
        /// <param name="_Text"></param>
        /// <returns></returns>
        public static string PobSend(string _SenderID, string[] _UserID, string _Title, string _Text)
        {

            return PrvPobSend(_SenderID, _UserID, _Title, _Text, "P");
        }

        /// <summary>
        /// 1명에게 사내통신 보냄
        /// </summary>
        /// <param name="_SenderID"></param>
        /// <param name="_UserID"></param>
        /// <param name="_Title"></param>
        /// <param name="_Text"></param>
        /// <returns></returns>
        public static string PobSend(string _SenderID, string _UserID, string _Title, string _Text)
        {

            return PrvPobSend(_SenderID, new string[1] { _UserID }, _Title, _Text, "P");
        }

        /// <summary>
        /// 여러팀 보낼때, array사용
        /// </summary>
        /// <param name="_SenderID"></param>
        /// <param name="_DeptID"></param>
        /// <param name="_Title"></param>
        /// <param name="_Text"></param>
        /// <returns></returns>
        public static string PobSendTeam(string _SenderID, string[] _DeptID, string _Title, string _Text)
        {
            return PrvPobSend(_SenderID, _DeptID, _Title, _Text, "T");
        }

        /// <summary>
        /// 팀 하나만 보낼때, array안쓰고 string으로만 할때
        /// </summary>
        /// <param name="_SenderID"></param>
        /// <param name="_DeptID"></param>
        /// <param name="_Title"></param>
        /// <param name="_Text"></param>
        /// <returns></returns>

        public static string PobSendTeam(string _SenderID, string _DeptID, string _Title, string _Text)
        {

            return PrvPobSend(_SenderID, new string[1] { _DeptID }, _Title, _Text, "T");
        }

        private static object GetScalarTxtQuery(string strCmm, SqlConnection _Cnn)
        {
            object id;
            using (SqlCommand cmd = new SqlCommand(strCmm, _Cnn))
            {
                //id = Convert.ToInt32(cmd.ExecuteScalar());
                id = cmd.ExecuteScalar();
            }

            return id;
        }

    }
}
