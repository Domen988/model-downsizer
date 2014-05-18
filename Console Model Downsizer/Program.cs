using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Console_Model_Downsizer
{
    /// <summary>
    /// Console application. It gets executed on every logon, if task has been added with CMD Model Downsizer app. 
    /// App goes throught task table and executes each row.
    /// </summary>
    class Program
    {
        static Model_Downsizer.settingsFileClass currentSettings = new Model_Downsizer.settingsFileClass();
        static Model_Downsizer.copyClass copyFolderInstance = new Model_Downsizer.copyClass();                                         
        
        static DataTable influenceTable;                                                                                    // settings reader output declaration
        static Dictionary<String, List<String>> directoriesDict;
        static Dictionary<String, List<String>> filesDict;

        public static void Main(string[] args)
        {
            DataSet defaultTasksSet = new DataSet();
            DataTable defaultTasksTable = new DataTable();

            string settingsLocation = Application.StartupPath + @"\settings\";                                            // set folder location for settings to be the same as applications startup folder
            string TasksTableLocation = settingsLocation + "TasksTable.xml";                                               //-> not the most elegant solution, because it needs a new reference: System.Windows.Forms.
                                                                                                                           //who cares..
            if (File.Exists(TasksTableLocation))                                                                          // check fo table existance
                defaultTasksSet.ReadXml(TasksTableLocation);
            else
                return;
            defaultTasksTable = defaultTasksSet.Tables[0];

            string counterLocation = settingsLocation + "LastTaskTime";                                                    // Preparatio for last task time file creation. Needed for counter. App starts at startup, checks last task time. If there
            string dateTimeFormat = "yyyy-MM-ddTHH:mm:sszzzzzz";                                                           // is more than one day between the dates, copy.
            DateTime dtThisTaskTime = DateTime.Now;

            if (File.Exists(counterLocation))
            {
                try
                {
                    string strPreviousTaskTime = File.ReadAllText(counterLocation); ;
                    DateTime dtPreviousTaskTime = XmlConvert.ToDateTime(strPreviousTaskTime, dateTimeFormat);

                    TimeSpan difference = dtThisTaskTime - dtPreviousTaskTime;                                              // compare last task time and current task time.
                    if (difference.TotalMinutes < (12*60))
                        return;
                }
                catch
                {
                    File.Delete(counterLocation);                                                                           // if LastTaskTime file is not readable, delete.
                }
            }

            string strThisTaskTime = dtThisTaskTime.ToString(dateTimeFormat);
            File.WriteAllText(counterLocation, strThisTaskTime);

            foreach (DataRow row in defaultTasksTable.Rows)
            {
                string sourceFolder;
                string destinationFolder;
                string settings;
                string modelFolderName;
                string newFolderName;
                string destFolder;

                sourceFolder = row[0].ToString();
                destinationFolder = row[1].ToString();
                settings = settingsLocation + row[2].ToString() + ".txt";

                bool existsSource = Directory.Exists(sourceFolder);                               // check if both folders and settings exist. If not, continue with next row.
                bool existsDestination = Directory.Exists(destinationFolder);
                bool existsSetting = File.Exists(settings);
                if (!existsSource || !existsDestination || !existsSetting)
                {
                    warningMessage(sourceFolder, destinationFolder, settings);
                    Console.WriteLine("Check if source file or settins exist.");
                    Console.WriteLine("Press any key to continue.");
                    Console.Read();
                }

                try
                {
                    currentSettings.settingsReader(settings,                                      // reads settings    
                                                   sourceFolder,
                                                   out  influenceTable,
                                                   out  directoriesDict,
                                                   out  filesDict);
                }
                catch (Exception exc)                                                                   // stop copying event if exception in prevoius step
                {
                    warningMessage(sourceFolder, destinationFolder, settings);
                    Console.WriteLine("Something went wrong when reading settings. Copying aborted.");
                    Console.WriteLine("Press any key to continue.");
                    Console.Read();
                    return;                                                                           //good idea to throw unexpected exceptions anyway
                }

                modelFolderName = Path.GetFileName(sourceFolder);                                        // gets source folder name
                newFolderName = getName(modelFolderName, 0);                                             // creates a name and path for copying
                destFolder = Path.Combine(destinationFolder, newFolderName, modelFolderName);

                if (Directory.Exists(destFolder))                                                        // if directory allready exists (when you make multiple copies of the same model in the same second)
                {                                                                                         //-> use 1 instead of 0 for getName funciton. This adds hundreds of a second to the name.
                    newFolderName = getName(modelFolderName, 1);
                    destFolder = Path.Combine(destinationFolder, newFolderName, modelFolderName);
                }
                try
                {
                    copyFolderInstance.copyFolder(sourceFolder,                                           // copy 
                                                  destFolder,
                                                  influenceTable,
                                                  directoriesDict,
                                                  filesDict);
                }
                catch
                {
                    warningMessage(sourceFolder, destinationFolder, settings);
                    Console.WriteLine("Copying aborted.");
                    Console.WriteLine("Press any key to continue.");
                    Console.Read();
                    return;
                }
            }
        }

        static string getName(string modelFolderName, int precision)                                   // get name. Name is sum of source name and time.
        {
            DateTime time = DateTime.Now;
            string timeFormat = "";
            if (precision == 0)
                timeFormat = "_yyyy-MM-dd_HH-mm-ss";
            if (precision == 1)
                timeFormat = "_yyyy-MM-dd_HH-mm-ss-ff";                                                // ...-ff -> hundreds of a second
            string timeString = time.ToString(timeFormat);
            string newFolderName = modelFolderName + timeString;
            return newFolderName;
        }

        static void warningMessage(string sourceFolder, string destinationFolder, string settings)      // Warning message body.
        {
            Console.WriteLine("Model Downsizer message:");
            Console.WriteLine("Problem In next row:");
            Console.WriteLine();
            Console.WriteLine("Source folder: ");
            Console.WriteLine( sourceFolder );
            Console.WriteLine();
            Console.WriteLine("Destination folder: ");
            Console.WriteLine( destinationFolder);
            Console.WriteLine();
            Console.WriteLine("Settings file: ");
            Console.WriteLine( settings );
            Console.WriteLine();
        }
    }
}
