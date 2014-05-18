namespace Model_Downsizer
{
    partial class Scheduled_tasks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.deleteRowButton = new System.Windows.Forms.Button();
            this.CloseTasksButton = new System.Windows.Forms.Button();
            this.AddRowButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(585, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // deleteRowButton
            // 
            this.deleteRowButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteRowButton.Location = new System.Drawing.Point(604, 42);
            this.deleteRowButton.Name = "deleteRowButton";
            this.deleteRowButton.Size = new System.Drawing.Size(91, 23);
            this.deleteRowButton.TabIndex = 2;
            this.deleteRowButton.Text = "Delete row ...";
            this.deleteRowButton.UseVisualStyleBackColor = true;
            this.deleteRowButton.Click += new System.EventHandler(this.deleteRowButton_Click);
            // 
            // CloseTasksButton
            // 
            this.CloseTasksButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CloseTasksButton.Location = new System.Drawing.Point(603, 139);
            this.CloseTasksButton.Name = "CloseTasksButton";
            this.CloseTasksButton.Size = new System.Drawing.Size(91, 23);
            this.CloseTasksButton.TabIndex = 4;
            this.CloseTasksButton.Text = "Close tasks";
            this.CloseTasksButton.UseVisualStyleBackColor = true;
            this.CloseTasksButton.Click += new System.EventHandler(this.CloseTasksButton_Click);
            // 
            // AddRowButton
            // 
            this.AddRowButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddRowButton.Location = new System.Drawing.Point(604, 13);
            this.AddRowButton.Name = "AddRowButton";
            this.AddRowButton.Size = new System.Drawing.Size(90, 23);
            this.AddRowButton.TabIndex = 5;
            this.AddRowButton.Text = "Add row";
            this.AddRowButton.UseVisualStyleBackColor = true;
            this.AddRowButton.Click += new System.EventHandler(this.AddRowButton_Click);
            // 
            // Scheduled_tasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 176);
            this.Controls.Add(this.AddRowButton);
            this.Controls.Add(this.CloseTasksButton);
            this.Controls.Add(this.deleteRowButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Scheduled_tasks";
            this.Text = "Scheduled_tasks";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button deleteRowButton;
        private System.Windows.Forms.Button CloseTasksButton;
        private System.Windows.Forms.Button AddRowButton;

    }
}