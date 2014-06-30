using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using VB = Microsoft.VisualBasic;

// test

namespace Model_Downsizer
{
    /// <summary>
    /// Important message*****************************************************************************************
    /// If you want to make packages for distribution to users:
    /// after building the solution:
    /// Make a folder.
    /// in this folder include:
    /// - Model Downsizer.exe (found in ...Model Downsizer\Model Downsizer\bin\release\)
    /// - settings folder (found in ...Model Downsizer\bin\release\)
    /// - resources folder (found in ...Model Downsizer\bin\release\)
    /// - Console Model Downsizer.exe (found in ...Model Downsizer\Console Model Downsizer\bin\release\)
    /// - CMD Console Model Downsizer.exe (found in ...Model Downsizer\CMD Model Downsizer\bin\release\)
    /// </summary>
    
    public partial class mainForm : Form
    {
        // set public stuff
        public static string settingsLocation = Application.StartupPath + "\\settings\\";     // set currentSettings files location
        public static string TasksTableLocation = mainForm.settingsLocation + "TasksTable.xml";// set location for Tasks Table
        public static string sett = TasksTableLocation.ToString();


        public string modelFolderName;                                       // source model folder name
        public string destinationFolderName;                                 // destination parent folder name
        public string newFolderName;                                         // new model folder name

        public static string applicationName = "Model Downsizer";            // set application name for labels in dialog boxes
        public DataTable tableForListBox = new DataTable();                  // dataTable for binding with listBox. In this way listBox refreshes automatically.
        public string originForTasks;
        public string destinationForTasks;
        public string settingsForTasks;


        public mainForm()
        {
            InitializeComponent();
            this.Icon = new Icon("Resources/ModelDownsizerIcon.ico");
            textBoxOrigin.Text = Properties.Settings.Default.defaultModelFolder.ToString();             // reads settings for textBoxes
            textBoxDestination.Text = Properties.Settings.Default.defaultDestinationFolder.ToString();
            modelFolderName = Path.GetFileName(textBoxOrigin.Text);
            newFolderName = getName(modelFolderName);
            this.textBoxSaveName.Text = newFolderName;

            if (Properties.Settings.Default.preset1ModelFolder.ToString().Length != 0)                                 // fill in preset buttons
                ExecutePreset1.Text = Path.GetFileName(Properties.Settings.Default.preset1ModelFolder.ToString()) + "\n" + Properties.Settings.Default.preset1Settings.ToString();     //
            if (Properties.Settings.Default.preset2ModelFolder.ToString().Length != 0)                                 //
                ExecutePreset2.Text =  Path.GetFileName(Properties.Settings.Default.preset2ModelFolder.ToString()) + "\n" + Properties.Settings.Default.preset2Settings.ToString();     //
            if (Properties.Settings.Default.preset3ModelFolder.ToString().Length != 0)                                 //
                ExecutePreset3.Text = Path.GetFileName(Properties.Settings.Default.preset3ModelFolder.ToString()) + "\n" + Properties.Settings.Default.preset3Settings.ToString();     //
            if (Properties.Settings.Default.preset4ModelFolder.ToString().Length != 0)                                 //
                ExecutePreset4.Text = Path.GetFileName(Properties.Settings.Default.preset4ModelFolder.ToString()) + "\n" + Properties.Settings.Default.preset4Settings.ToString();     //
            if (Properties.Settings.Default.preset5ModelFolder.ToString().Length != 0)                                 //
                ExecutePreset5.Text = Path.GetFileName(Properties.Settings.Default.preset5ModelFolder.ToString()) + "\n" + Properties.Settings.Default.preset5Settings.ToString();     //


            // settings ListBox creation
            tableForListBox.Columns.Add("settingsFileName", typeof(string));                                 // adds a column to an empty table
            try
            {
                foreach (string file in Directory.EnumerateFiles(settingsLocation, "*.txt"))                     // reads settings files folder line by line
                    tableForListBox.Rows.Add(Path.GetFileNameWithoutExtension(file));                             
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                MessageBox.Show("Settings directory path does not point to anywhere.", mainForm.applicationName);
                return;
            } 
            listBoxSettings.DataSource = tableForListBox;                                                    // composes currentSettings listBox 
            listBoxSettings.DisplayMember = "settingsFileName";
        }


        // "browse for model folder" button
        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserOrigin.SelectedPath = Properties.Settings.Default.defaultModelFolder.ToString();    // sets browser to open in saved directory
            if (folderBrowserOrigin.ShowDialog() == DialogResult.OK)                                         // show dialog, if OK -> store selected path        
            {
                Properties.Settings.Default["defaultModelFolder"] = folderBrowserOrigin.SelectedPath;        // save 
                Properties.Settings.Default.Save();                                                          // Saves settings in application configuration file
                this.textBoxOrigin.Text = folderBrowserOrigin.SelectedPath;
            }
            modelFolderName = Path.GetFileName(textBoxOrigin.Text);                                          
            newFolderName = getName(modelFolderName);                                                   
            this.textBoxSaveName.Text = newFolderName;                           
        }

        // when textBox is manually changed
        private void textBoxOrigin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default["defaultModelFolder"] = textBoxOrigin.Text;
                Properties.Settings.Default.Save();                                                          // Saves settings in application configuration file
                modelFolderName = Path.GetFileName(textBoxOrigin.Text);
                newFolderName = getName(modelFolderName);
                this.textBoxSaveName.Text = newFolderName;                                                   
            }
            catch (Exception)
            {
            }
        }

        // "browse for destination folder" button
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.SelectedPath = Properties.Settings.Default.defaultDestinationFolder.ToString();    // reads from settings
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)                                               // if user clicks browse...
            {
                Properties.Settings.Default["defaultDestinationFolder"] = folderBrowserDialog2.SelectedPath;
                Properties.Settings.Default.Save();                                                                 // Saves new settings in application configuration file
                this.textBoxDestination.Text = folderBrowserDialog2.SelectedPath;
            }
        }


        // "new setting" button
        private void button3_Click(object sender, EventArgs e)
        {
            string newName = Microsoft.VisualBasic.Interaction.InputBox("Enter new currentSettings file name:", applicationName, "", -1, -1); // opens file name dialog and composes a file name
            if (newName == "")                                                                                      // click on "cancel" -> return, if name = "" -> return
                return;

            string newFile = settingsLocation + newName + ".txt";                                                   // compose file path
            try
            {
                if (File.Exists(newFile))                                                                           // Check if file already exists. If yes, ask for overwrite.
                {
                    string dialogText = "File with that name allready exists.";
                    var result = MessageBox.Show(dialogText, applicationName, MessageBoxButtons.OK);
                    if (result == DialogResult.OK)                                                                  // if 'no' -> again open "Enter new file name ... "
                        button3.PerformClick();
                }

                settingsFileClass newTemplate = new settingsFileClass();                                            // Create a new file. Use settingsFileClass
                newTemplate.settingsTemplate(newFile);

                tableForListBox.Rows.Add(Path.GetFileNameWithoutExtension(newFile));                                // adds new setting to tableForListBox, so that the listBoxSettings updates
                System.Diagnostics.Process.Start(newFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("something");
            }
        }


        // "edit currentSettings" button
        private void button2_Click(object sender, EventArgs e)
        {
            string curItem = settingsLocation + listBoxSettings.GetItemText(listBoxSettings.SelectedItem).ToString() + ".txt";     // creates path from currentSettings location and selected item in viewbox
            System.Diagnostics.Process.Start(curItem);                                                                             // opens .txt
        }


        // "delete currentSettings" button
        private void button6_Click(object sender, EventArgs e)
        {
            string currentSelection = listBoxSettings.GetItemText(listBoxSettings.SelectedItem);                        // creates path from selected item in viewbox
            string curItem = settingsLocation + currentSelection + ".txt";

            string dialogText = "Are you sure you want to move '" + currentSelection + "' to the Recycle Bin?";         // brings up "Are you sure ... "
            var result = MessageBox.Show(dialogText, applicationName, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                VB.FileIO.FileSystem.DeleteFile(curItem, VB.FileIO.UIOption.OnlyErrorDialogs, VB.FileIO.RecycleOption.SendToRecycleBin);    // sends file to recycle bin (using some VB method)

                string currentSelectionForTableSelect = "'" + currentSelection + "'";                                   // preparation for uptdating tableForListBox, which updates listBoxSettings
                DataRow[] currentRow = tableForListBox.Select("settingsFileName=" + currentSelectionForTableSelect);
                DataRow row = currentRow.FirstOrDefault();
                tableForListBox.Rows.Remove(row);
            }
        }


        // "Make a copy" button
        private void button5_Click(object sender, EventArgs e)
        {

            copyClass copyFolderInstance = new copyClass();                                         // creates new instance of copyClass

            string currentSelection = listBoxSettings.GetItemText(listBoxSettings.SelectedItem);    // gets settings
            string activeSettings = settingsLocation + currentSelection + ".txt";
            string sourceFolder = textBoxOrigin.Text;                                               // gets source folder and destionation location
            string destFolder = Path.Combine(textBoxDestination.Text, textBoxSaveName.Text, modelFolderName);

            if (Directory.Exists(destFolder))                                                       // ask for overwrite if dir exists
            {
                string dialogText = "Directory with that name allready exists. Overwrite?";
                var result = MessageBox.Show(dialogText, applicationName, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    Directory.Delete(destFolder, true);                                             // delete exisiting dir if 'yes'. 'true' is added to allow recursion.
                if (result == DialogResult.No)
                    return;
            }

            settingsFileClass currentSettings = new settingsFileClass();                            // declaring for the settingsReader
            DataTable influenceTable;
            Dictionary<String, List<String>> directoriesDict;
            Dictionary<String, List<String>> filesDict;
            try
            {
                currentSettings.settingsReader(activeSettings,                                      // reads settings    
                                               sourceFolder,                                            
                                               out  influenceTable,                                      
                                               out  directoriesDict,                                    
                                               out  filesDict);     
            }
            catch (Exception exc)                                                                   // stop copying event if exception in prevoius step
            {
                if (exc is System.ArgumentException)
                {
                    MessageBox.Show("Something went wrong when reading settings. Copying aborted.", applicationName, MessageBoxButtons.OK);
                    return;
                }
                else
                    throw;                                                                           //good idea to throw unexpected exceptions anyway
            }

            Cursor.Current = Cursors.WaitCursor;                                                    // shows waiting cursor symbol
            this.button5.Text = "... copying ...";                                                  // changes button text

            copyFolderInstance.copyFolder(sourceFolder,                                             // copy by rules of selected settings
                                          destFolder, 
                                          influenceTable, 
                                          directoriesDict, 
                                          filesDict); 

            this.button5.Text = "Make a copy";
            Cursor.Current = Cursors.Default;                                                        
        }

        
        // "refresh name" button
        private void button7_Click(object sender, EventArgs e)
        {
            newFolderName = getName(modelFolderName);
            this.textBoxSaveName.Text = newFolderName; 
        }


        // "add to scheduled tasks" button
        public void button8_Click(object sender, EventArgs e)
        {
            tasksClass tasksInstance = new tasksClass();
            try
            {
                tasksInstance.addToTasks(textBoxOrigin.Text,
                         textBoxDestination.Text,
                         listBoxSettings.GetItemText(listBoxSettings.SelectedItem));

                Scheduled_tasks myForm = new Scheduled_tasks();
                myForm.ShowDialog();
            }
            catch 
            { 
                MessageBox.Show("Administrator rights are needed for modifying scheduled tasks.", mainForm.applicationName);
            }
        }


        // "scheduled tasks" button (as in 'see scheduled tasks table')
        private void button9_Click(object sender, EventArgs e)
        {
            Scheduled_tasks myForm = new Scheduled_tasks();
            myForm.ShowDialog();
        }

        /// <summary>
        /// create name with added time stamp
        /// </summary>
        /// <param name="modelFolderName"></param>
        /// <returns></returns>
        public string getName(string modelFolderName)
        {
            DateTime time = DateTime.Now;
            string timeFormat = ("  yyyy-MM-dd  HH-mm-ss");
            string timeString = time.ToString(timeFormat);
            newFolderName = modelFolderName + timeString;
            return newFolderName;
        }

        private void closeModelDownsizer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Preset buttons
        private void SetPreset1_Click(object sender, EventArgs e)
        {
            SetPreset(1);
        }

        private void SetPreset2_Click(object sender, EventArgs e)
        {
            SetPreset(2);
        }

        private void SetPreset3_Click(object sender, EventArgs e)
        {
            SetPreset(3);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            SetPreset(4);
        }
        private void SetPreset5_Click(object sender, EventArgs e)
        {
            SetPreset(5);
        }

        public void SetPreset(int index)
        {
            string modelFolderSettingsName = "preset" + index + "ModelFolder";
            string settingsSettingsName = "preset" + index + "Settings";
            string destinationFolderSettingsName = "preset" + index + "DestinationFolder";

            Properties.Settings.Default[modelFolderSettingsName] = textBoxOrigin.Text.ToString();        
            Properties.Settings.Default[settingsSettingsName] = listBoxSettings.GetItemText(listBoxSettings.SelectedItem);
            Properties.Settings.Default[destinationFolderSettingsName] = textBoxDestination.Text;

            Properties.Settings.Default.Save();

            if (index == 1)
                ExecutePreset1.Text = Path.GetFileName(Properties.Settings.Default.preset1ModelFolder.ToString()) + "\n" + Properties.Settings.Default.preset1Settings.ToString();
            if (index == 2)
                ExecutePreset2.Text = Path.GetFileName(Properties.Settings.Default.preset2ModelFolder.ToString()) + "\n" + Properties.Settings.Default.preset2Settings.ToString();
            if (index == 3)
                ExecutePreset3.Text = Path.GetFileName(Properties.Settings.Default.preset3ModelFolder.ToString()) + "\n" + Properties.Settings.Default.preset3Settings.ToString();
            if (index == 4)
                ExecutePreset4.Text = Path.GetFileName(Properties.Settings.Default.preset4ModelFolder.ToString()) + "\n" + Properties.Settings.Default.preset4Settings.ToString();
            if (index == 5)
                ExecutePreset5.Text = Path.GetFileName(Properties.Settings.Default.preset5ModelFolder.ToString()) + "\n" + Properties.Settings.Default.preset5Settings.ToString();
 
        }

        private void ExecutePreset1_Click(object sender, EventArgs e)
        {
            ExecutePreset(1);
        }
        private void ExecutePreset2_Click(object sender, EventArgs e)
        {
            ExecutePreset(2);
        }
        private void ExecutePreset3_Click(object sender, EventArgs e)
        {
            ExecutePreset(3);
        }
        private void ExecutePreset4_Click(object sender, EventArgs e)
        {
            ExecutePreset(4);
        }
        private void ExecutePreset5_Click(object sender, EventArgs e)
        {
            ExecutePreset(5);
        }
        public void ExecutePreset(int index)
        {
            try
            {
                if (index == 1)
                {
                    textBoxOrigin.Text = Properties.Settings.Default.preset1ModelFolder;
                    textBoxDestination.Text = Properties.Settings.Default.preset1DestinationFolder;
                    listBoxSettings.SelectedIndex = listBoxSettings.FindString(Properties.Settings.Default.preset1Settings.ToString());
                    button5.PerformClick();
                }
                if (index == 2)
                {
                    textBoxOrigin.Text = Properties.Settings.Default.preset2ModelFolder;
                    textBoxDestination.Text = Properties.Settings.Default.preset2DestinationFolder;
                    listBoxSettings.SelectedIndex = listBoxSettings.FindString(Properties.Settings.Default.preset2Settings.ToString());
                    button5.PerformClick();
                }
                if (index == 3)
                {
                    textBoxOrigin.Text = Properties.Settings.Default.preset3ModelFolder;
                    textBoxDestination.Text = Properties.Settings.Default.preset3DestinationFolder;
                    listBoxSettings.SelectedIndex = listBoxSettings.FindString(Properties.Settings.Default.preset3Settings.ToString());
                    button5.PerformClick();
                }
                if (index == 4)
                {
                    textBoxOrigin.Text = Properties.Settings.Default.preset4ModelFolder;
                    textBoxDestination.Text = Properties.Settings.Default.preset4DestinationFolder;
                    listBoxSettings.SelectedIndex = listBoxSettings.FindString(Properties.Settings.Default.preset4Settings.ToString());
                    button5.PerformClick();
                }
                if (index == 5)
                {
                    textBoxOrigin.Text = Properties.Settings.Default.preset5ModelFolder;
                    textBoxDestination.Text = Properties.Settings.Default.preset5DestinationFolder;
                    listBoxSettings.SelectedIndex = listBoxSettings.FindString(Properties.Settings.Default.preset5Settings.ToString());
                    button5.PerformClick();
                }
            }
            catch
            {
                MessageBox.Show("Preset corrupted.");
            }
        }

        private void SeePresetInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Preset 1 \n" +
                            "Model Folder: \t" + Properties.Settings.Default.preset1ModelFolder.ToString() + "\n" +
                            "Settings: \t\t" + Properties.Settings.Default.preset1Settings.ToString() + "\n" +
                            "Destination Folder: \t" + Properties.Settings.Default.preset1DestinationFolder.ToString() + "\n\n" +
                            "Preset 2 \n" +
                            "Model Folder: \t" + Properties.Settings.Default.preset2ModelFolder.ToString() + "\n" +
                            "Settings: \t\t" + Properties.Settings.Default.preset2Settings.ToString() + "\n" +
                            "Destination Folder: \t" + Properties.Settings.Default.preset2DestinationFolder.ToString() + "\n\n" +
                            "Preset 3 \n" +
                            "Model Folder: \t" + Properties.Settings.Default.preset3ModelFolder.ToString() + "\n" +
                            "Settings: \t\t" + Properties.Settings.Default.preset3Settings.ToString() + "\n" +
                            "Destination Folder: \t" + Properties.Settings.Default.preset3DestinationFolder.ToString() + "\n\n" +
                            "Preset 4 \n" +
                            "Model Folder: \t" + Properties.Settings.Default.preset4ModelFolder.ToString() + "\n" +
                            "Settings: \t\t" + Properties.Settings.Default.preset4Settings.ToString() + "\n" +
                            "Destination Folder: \t" + Properties.Settings.Default.preset4DestinationFolder.ToString()+ "\n\n" +
                            "Preset 5 \n" +
                            "Model Folder: \t" + Properties.Settings.Default.preset5ModelFolder.ToString() + "\n" +
                            "Settings: \t\t" + Properties.Settings.Default.preset5Settings.ToString() + "\n" +
                            "Destination Folder: \t" + Properties.Settings.Default.preset5DestinationFolder.ToString(),
                            mainForm.applicationName);
        }
        #endregion 

        private void HelpButton_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }




    }
}
