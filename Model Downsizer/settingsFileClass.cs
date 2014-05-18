using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace Model_Downsizer
{
    public class settingsFileClass
    {
        // template for new file.
        public void settingsTemplate(string fileName)
        {
            int pad = 80;                                                                                         // length of header line, used by PadRight method
            using (StreamWriter sw = File.CreateText(fileName))
            {
                sw.WriteLine(("/*") + new String('*', pad-2).PadRight(pad-2) + "*/");                                                     //
                sw.WriteLine(("/* Model Downsizer settings file").PadRight(pad) + "*/");                                                  // title
                sw.WriteLine(("/*") + new String('*', pad-2).PadRight(pad-2) + "*/");                                                     //
                
                sw.WriteLine(("/* This settings file is used for creating filters for copying. By default (i.e.").PadRight(pad) + "*/");  //
                sw.WriteLine(("/* when using empty settings file) Model Downsizer copies entire model folder.").PadRight(pad) + "*/");    //
                sw.WriteLine(("/* In case you want a different behaviour for copying specific folders, you can").PadRight(pad) + "*/");   //
                sw.WriteLine(("/* enter settings in a manner described bellow.").PadRight(pad) + "*/");                                   // intro
                sw.WriteLine(("/*") + new String('-', pad - 2).PadRight(pad - 2) + "*/");                                                 //
                sw.WriteLine(("/* Instructions:").PadRight(pad) + "*/");                                                                  //
                sw.WriteLine(("/* Settings are created in groups. Each group consists of header and list.").PadRight(pad) + "*/");        //
                sw.WriteLine(("/*") + new String('-', pad-2).PadRight(pad-2) + "*/");                                                     //
                
                sw.WriteLine(("/* Header").PadRight(pad) + "*/");
                sw.WriteLine(("/* Header of each group specifies what will it be done with the group. Header").PadRight(pad) + "*/");     //
                sw.WriteLine(("/* must consist of next three lines:").PadRight(pad) + "*/");                                              //
                sw.WriteLine(("/*").PadRight(pad) + "*/");                                                                                //
                sw.WriteLine(("/* line 1: \"#in ...\" ").PadRight(pad) + "*/");                                                           //
                sw.WriteLine(("/*         Specify folder, for which the next group of settings apply.").PadRight(pad) + "*/");            //
                sw.WriteLine(("/*         \"#in .\\\" stands for model folder.").PadRight(pad) + "*/");                                   //
                sw.WriteLine(("/*").PadRight(pad) + "*/");                                                                                //
                sw.WriteLine(("/* Line 2: \"#directories\" or \"#files\"").PadRight(pad) + "*/");                                         //
                sw.WriteLine(("/*         Specifies if the next set of rules applies to folders or files which").PadRight(pad) + "*/");   //
                sw.WriteLine(("/*         are contained inside main folder of the settings group.").PadRight(pad) + "*/");                //
                sw.WriteLine(("/*").PadRight(pad) + "*/");                                                                                // Header instructions
                sw.WriteLine(("/* Line 3: \"#only\" or \"#without\"").PadRight(pad) + "*/");                                              //
                sw.WriteLine(("/*         Specifies what should be done with files or folders in this group.").PadRight(pad) + "*/");     //
                sw.WriteLine(("/*         #only - copies only listed files or folders").PadRight(pad) + "*/");                            //
                sw.WriteLine(("/*         #without - copies all other files or folders").PadRight(pad) + "*/");                           //
                sw.WriteLine(("/*").PadRight(pad) + "*/");                                                                                //
                sw.WriteLine(("/* Line 1 can be left out in the next case:").PadRight(pad) + "*/");                                       //
                sw.WriteLine(("/*   #in .\\").PadRight(pad) + "*/");                                                                      //
                sw.WriteLine(("/*   #directories").PadRight(pad) + "*/");                                                                 //
                sw.WriteLine(("/*   #...").PadRight(pad) + "*/");                                                                         //
                sw.WriteLine(("/*   ...").PadRight(pad) + "*/");                                                                          //
                sw.WriteLine(("/*").PadRight(pad) + "*/");                                                                                //
                sw.WriteLine(("/*   #files").PadRight(pad) + "*/");                                                                       //
                sw.WriteLine(("/*   #...").PadRight(pad) + "*/");                                                                         //
                sw.WriteLine(("/*   ...").PadRight(pad) + "*/");                                                                          //
                sw.WriteLine(("/* Second group applies to the same folder as the first.").PadRight(pad) + "*/");                          //
                sw.WriteLine(("/*") + new String('-', pad - 2).PadRight(pad - 2) + "*/");                                                 //
                                                                                                                                          //
                sw.WriteLine(("/* List").PadRight(pad) + "*/");                                                                           //
                sw.WriteLine(("/* List is a collection of folders or files, which directly follows third line").PadRight(pad) + "*/");    //
                sw.WriteLine(("/* of group header. Objects in list are folder and file names or file").PadRight(pad) + "*/");             //
                sw.WriteLine(("/* extensions. When you input file extensions the correct format is <.txt>").PadRight(pad) + "*/");        //
                sw.WriteLine(("/* (without brackets).").PadRight(pad) + "*/");                                                            //
                sw.WriteLine(("/*") + new String('-', pad - 2).PadRight(pad - 2) + "*/");                                                 //
                sw.WriteLine(("/* Instructions").PadRight(pad) + "*/");                                                                   //
                sw.WriteLine(("/* - When you want to copy only files in a specific subfolder of model folder").PadRight(pad) + "*/");     //
                sw.WriteLine(("/*   use the next combination:").PadRight(pad) + "*/");                                                    //
                sw.WriteLine(("/*").PadRight(pad) + "*/");                                                                                // list instructions
                sw.WriteLine(("/*   #in .\\example").PadRight(pad) + "*/");                                                               //
                sw.WriteLine(("/*   #directories").PadRight(pad) + "*/");                                                                 //
                sw.WriteLine(("/*   #only").PadRight(pad) + "*/");                                                                        //
                sw.WriteLine(("/*   none").PadRight(pad) + "*/");                                                                         //
                sw.WriteLine(("/*").PadRight(pad) + "*/");                                                                                //
                sw.WriteLine(("/*   Explanation: everything is copied by default. So all files get").PadRight(pad) + "*/");               //
                sw.WriteLine(("/*   automatically copied. But you do not want to copy folders, so you use next").PadRight(pad) + "*/");   //
                sw.WriteLine(("/*   logic: copy only folders, with name 'none'. You can use any name, which").PadRight(pad) + "*/");      //
                sw.WriteLine(("/*   does not exist in that location.").PadRight(pad) + "*/");                                             //
                sw.WriteLine(("/*   Same applies for copying only folders.").PadRight(pad) + "*/");                                       //
                sw.WriteLine(("/* - In next case:").PadRight(pad) + "*/");                                                                //
                sw.WriteLine(("/*").PadRight(pad) + "*/");                                                                                //
                sw.WriteLine(("/*   #in .\\").PadRight(pad) + "*/");                                                                      //
                sw.WriteLine(("/*   #files").PadRight(pad) + "*/");                                                                       //
                sw.WriteLine(("/*   #without").PadRight(pad) + "*/");                                                                     //
                sw.WriteLine(("/*   old model db").PadRight(pad) + "*/");                                                                  //
                sw.WriteLine(("/*").PadRight(pad) + "*/");                                                                                //
                sw.WriteLine(("/*   Model Downsizer copies only the current instance of db files.").PadRight(pad) + "*/");      //
                sw.WriteLine(("/* - In next case:").PadRight(pad) + "*/");                                                                //
                sw.WriteLine(("/*").PadRight(pad) + "*/");                                                                                //
                sw.WriteLine(("/*   #in .\\").PadRight(pad) + "*/");                                                                      //
                sw.WriteLine(("/*   #files").PadRight(pad) + "*/");                                                                       //
                sw.WriteLine(("/*   #only").PadRight(pad) + "*/");                                                                     //
                sw.WriteLine(("/*   last model db").PadRight(pad) + "*/");                                                                  //
                sw.WriteLine(("/*").PadRight(pad) + "*/");                                                                                //
                sw.WriteLine(("/*   Model Downsizer copies only the current instance of model db.").PadRight(pad) + "*/");      //
                sw.WriteLine(("/*") + new String('*', pad - 2).PadRight(pad - 2) + "*/");                                                 //
            }
        }

        

        // method for reading settings
        // uses 'out' parameter modifier, so that it can return more than one value.
        // http://msdn.microsoft.com/en-us/library/ee332485.aspx
        public void settingsReader(string settingsLocation, 
                                   string sourceFolder,
                                   out DataTable influenceTable, 
                                   out Dictionary<String, List<String>> directoriesDict, 
                                   out Dictionary<String, List<String>> filesDict)
        {
            // creates data tableForListBox influenceTable
            //
            // tableForListBox has 3 columns: folderName, directoriesMode, filesMode
            // folderName(string): name of the folder for which the subsequent settings in settings file apply
            // directoriesMode(int): 0 - no data about mode. Copy everything.
            //                      1 - 'only' mode. Copy only listed directories.
            //                      2 - 'without' mode. Copy everything but listed directories.
            // filesMode(int): 0 - no data about mode. Copy everything.
            //                 1 - 'only' mode. Copy only listed files.
            //                 2 - 'without' mode. Copy everything but listed files.
            influenceTable = new DataTable();
            influenceTable.Columns.Add("folderName", typeof(string));
            influenceTable.Columns.Add("directoriesMode", typeof(int));
            influenceTable.Columns.Add("filesMode", typeof(int));

            directoriesDict = new Dictionary<String, List<String>>();                    // directoriesDict - contains lists of rules for directories copying
            filesDict = new Dictionary<String, List<String>>();                          // filesDict - contains lists of rules for files copying

            string[] lines = System.IO.File.ReadAllLines(settingsLocation);              // reads file
            var lineCount = lines.Count();
            int modeToggle = 1;                                                          // used for toggling between directoriesMode and filesMod
            string currentKey = "";
            try
            {
                // goes line by line over settings file.
                // when it hits '#in', it creates new row in influenceTable DataTable. Then it looks for mode selection and adjusts modeToggle.
                // Then it checks for 'only' or 'without' and adds to tableForListBox. At the end it writes to one of the dictionaries, depends on the toggle.
                for (int i = 0; i < lineCount; )
                {
                    if (lines[i].StartsWith("#in"))
                    {                                                                    // adds a new row to influenceTable
                        if (lines[i].EndsWith("\\"))                                     // exception for ".\", which stands for main model folder
                            currentKey = sourceFolder + lines[i].Remove(0, 6);
                        else
                            currentKey = sourceFolder + "\\" + lines[i].Remove(0, 6);
                        influenceTable.Rows.Add(currentKey, 0, 0);
                        modeToggle = 3;                                                  // creates exception, if folder name is followed immediately by '#only' or '#without' (there should be direcotires or files before)
                    }
                    else if (lines[i].StartsWith("#directories"))
                    {
                        directoriesDict.Add(currentKey, new List<string>());             // add new directoriesDict entry. Key: folder name (defined with '#in ... '), value: empty list.
                        modeToggle = 1;                                                  // adjust toggle
                    }
                    else if (lines[i].StartsWith("#files"))
                    {
                        filesDict.Add(currentKey, new List<string>());                   // add new filesDict entry. Key: folder name (defined with '#in ... '), value: empty list.
                        modeToggle = 2;                                                  // adjust toggle
                    }
                    else if (lines[i].StartsWith("#only"))
                        influenceTable.Rows[influenceTable.Rows.Count - 1][modeToggle] = 1; // set the third column of influenceTable DataTable
                    
                    else if (lines[i].StartsWith("#without"))
                        influenceTable.Rows[influenceTable.Rows.Count - 1][modeToggle] = 2; // set the third column of influenceTable DataTable
                    

                    // next structure adds lines to appropriate dictionaries
                    else if (!lines[i].StartsWith("/*") && lines[i].Trim() != "")        // trim in second expression protects from empty spaces inclusion in lists
                    {
                        if (modeToggle == 1)
                            directoriesDict[currentKey].Add(lines[i]);
                        
                        if (modeToggle == 2)
                            filesDict[currentKey].Add(lines[i]);
                    }
                    else                                                                 // do nothing with everything else
                    {
                    }
                    i += 1;
                }
            }
            catch (System.ArgumentException)                                                            // my first try of catch. Should have done more than one exception.
            {
                //MessageBox.Show("Something is wrong with the settings file or with reading of the settings file.", mainForm.applicationName);
                MessageBox.Show("One or more items '#files' or '#directories' duplicated", mainForm.applicationName);
                throw;
                //
                                            // TO-DO: - add a general exception. 
                                            //        - how to stop copying if exception happens?
            }

        }
    }
} 
