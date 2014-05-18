using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMD_Model_Downsizer
{
    public class Program
    {
        /// <summary>
        /// This console application is written specifically for the purpose of automatically invoking a "Do you want to run this application with administrator rights..."
        /// This is needed for windows task scheduler.
        /// This is done with a change in app.manifest.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            if (args[0] == "create")
            {
                string startPath = Application.StartupPath;
                // cmd schtasks syntax:
                // /C ... read this in cmd
                // /F ... overrides "Warning this task allready exists. Replace? YES/NO"
                // /DELAY ... delay task after logon event trigger. 
                string strCmdText = @"/C schtasks /Create /TN ModelDownsizer /TR " + @"""\""" + startPath + @"\Console Model Downsizer.exe\"""" /SC ONLOGON /F /DELAY 0002:00";
                System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            }
            if (args[0] == "delete")
            {
                string strCmdText = @"/C schtasks /delete /TN ModelDownsizer /F";
                System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            }
        }
    }
}
