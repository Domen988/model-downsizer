using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Model_Downsizer
{
    public partial class Scheduled_tasks : Form
    {
        /// <summary>
        /// Scheduled tasks table. Shows a new form with tasks table.
        /// </summary>
        public Scheduled_tasks()
        {
            InitializeComponent();
            refreshTable();
        }

        // Add row button. It just closes table form and lets user pick a new task.
        private void AddRowButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Delete row button
        /// First ask for conformation. If table is empty, it shows a message and returns.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteRowButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete selected row?", mainForm.applicationName, MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.No || result == DialogResult.Cancel)
                return;

            tasksClass deleteRow = new tasksClass();
            if (dataGridView1.RowCount > 1)                                                        // only execute when table is not empty
            {
                DataRowView currentDataRowView = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                DataRow row = currentDataRowView.Row;
                int index = dataGridView1.CurrentCell.RowIndex;                                   // find index of picked row
                deleteRow.deleteFromTasks(index);                                                 // call deleteFromTasks fuction of taskClass
                refreshTable();

            }
            else
            {
                MessageBox.Show("Tasks table is empty.", mainForm.applicationName);
            }
        }

        /// <summary>
        /// does a fresh read of tasks table
        /// </summary>
        void refreshTable()
        {
            DataSet defaultTasksSet = new DataSet();
            DataTable defaultTasksTable = new DataTable();

            defaultTasksSet.ReadXml(@mainForm.TasksTableLocation);
            defaultTasksTable = defaultTasksSet.Tables[0];

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.DataSource = defaultTasksTable;
        }

        private void CloseTasksButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }
    }
}
