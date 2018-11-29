using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servermonitoring
{
    class Common
    {
        public static void LogWrite(string type, string msg)
        {
            string addr = @"C:\\LOG_SERVER\\";

            //try
            //{
            //    addr += DateTime.Now.ToShortDateString() + ".LOG";
            //    msg = DateTime.Now.ToString("HH:mm:ss") + (type == string.Empty ? " : " : " : [" + type + "] ") + msg + "\r\n";
            //    System.IO.File.AppendAllText(addr, msg);
            //}
            //catch { }

            try
            {
                if (!System.IO.Directory.Exists(addr))
                {
                    System.IO.Directory.CreateDirectory(addr);
                }

                addr += DateTime.Now.ToShortDateString() + ".LOG";

                System.IO.FileMode mode = System.IO.FileMode.CreateNew;
                if (System.IO.File.Exists(addr))
                {
                    mode = System.IO.FileMode.Append;
                }
                msg = "[" + DateTime.Now.ToString("HH:mm:ss:ffff") + "] " + (type == string.Empty ? " : " : " : [" + type + "] ") + msg + "\r\n";
                System.IO.FileStream fs = new System.IO.FileStream(addr, mode);
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.Default);
                sw.WriteLine(msg);
                sw.Flush();
                sw.Close();
            }
            catch (Exception e)
            {
            }

        }
    }
}
