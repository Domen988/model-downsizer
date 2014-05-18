using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Model_Downsizer
{
    /// <summary>
    /// This class is used for functions for manipulation with tasks table
    /// </summary>
    public class tasksClass
    {
        string CMDModelDownsizerPath = Application.StartupPath + @"\CMD Model Downsizer.exe";

        /// <summary>
        /// adds a new row to tasks table. It needs input: original model folder, save destination, selected settings.
        /// </summary>
        /// <param name="orig"></param>
        /// <param name="dest"></param>
        /// <param name="settings"></param>
        public void addToTasks(string orig, string dest, string settings)
        {            
            string column1Name = "Model folder";                                   // set column names to be displayed in the table.
            string column2Name = "Destination folder";
            string column3Name = "Settings file";
            DataSet defaultTasksSet = new DataSet();
            DataTable defaultTasksTable = new DataTable();

            //            System.Diagnostics.Process.Start(@"D:\Desktop\Model Downsizer_01\Model Downsizer_01\Model Downsizer\Model Downsizer\bin\Release\CMD Model Downsizer.exe", "create");

            System.Diagnostics.Process.Start(CMDModelDownsizerPath, "create");

            if (File.Exists(mainForm.TasksTableLocation))                                                // if file exists -
                defaultTasksSet.ReadXml(@mainForm.TasksTableLocation);                                   // read from disk,
            else                                                                                         // or make a new table:
            {
                DataTable TasksTable = new DataTable();
                TasksTable.Columns.Add(column1Name, typeof(string));
                TasksTable.Columns.Add(column2Name, typeof(string));
                TasksTable.Columns.Add(column3Name, typeof(string));
                defaultTasksSet.Tables.Add(TasksTable);
            }

            defaultTasksTable = defaultTasksSet.Tables[0];                           // sets table to the first table in set
            DataRow newTasksTableRow = defaultTasksTable.NewRow();

            newTasksTableRow[column1Name] = orig;                                    // paths and settings to be saved
            newTasksTableRow[column2Name] = dest;
            newTasksTableRow[column3Name] = settings;

            defaultTasksTable.Rows.Add(newTasksTableRow);
   
            defaultTasksSet.WriteXml(@mainForm.TasksTableLocation);                                   // Save to disk
        }

        /// <summary>
        /// deletes row from tasks table.
        /// If the row deleted was the only row in table, function also deletes task from schtasks
        /// </summary>
        /// <param name="index"></param> index of the row selected for deletion
        public void deleteFromTasks(int index)
        {
            DataSet defaultTasksSet = new DataSet();
            DataTable defaultTasksTable = new DataTable();
            
            try
            {
                if (defaultTasksTable.Rows.Count == 0)                                                 // deletes task from windows scheduler, if there is no more row in table.
                {
                    System.Diagnostics.Process.Start(CMDModelDownsizerPath, "delete");
                }
            }
            catch
            {
                MessageBox.Show("Administrator rights are needed for modifying scheduled tasks.", mainForm.applicationName);
                return;
            }

            defaultTasksSet.ReadXml(@mainForm.TasksTableLocation);                                 // read
            defaultTasksTable = defaultTasksSet.Tables[0];

            DataRow row = defaultTasksTable.Rows[index];                                           // pinpoint row
            defaultTasksTable.Rows.Remove(row);                                                    // remove row

            StringWriter writer = new StringWriter();                                              // write, save
            defaultTasksTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
            using (StreamWriter sw = new StreamWriter(mainForm.TasksTableLocation))
            {
                sw.Write(writer.ToString());
            }
        }
    }
}
