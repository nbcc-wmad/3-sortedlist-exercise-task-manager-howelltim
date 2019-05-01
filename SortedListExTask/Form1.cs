using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortedListExTask
{
    public partial class Form1 : Form
    {
        private Dictionary<DateTime, string> taskList = new Dictionary<DateTime, string>();

        public Form1()
        {
            InitializeComponent();
        }
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (txtTask.Text != null || txtTask.Text != string.Empty)
            {
				if (!taskList.ContainsKey(dtpTaskDate.Value))
				{
					taskList.Add(dtpTaskDate.Value, txtTask.Text);
					lstTasks.Items.Add(dtpTaskDate.Value);
									
					txtTask.Clear();
					dtpTaskDate.Value = DateTime.Now;
				}
				else
					MessageBox.Show("Only one task per date is allowed.");
            }
            else
                MessageBox.Show("You must enter a task.");
        }
        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex != -1)
                lblTaskDetails.Text = taskList[(DateTime)lstTasks.SelectedItem].ToString();
            else
                lblTaskDetails.Text = string.Empty;
        }
        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex != -1)
            {
                lstTasks.Items.Remove(lstTasks.SelectedItem);
                taskList.Remove(Convert.ToDateTime(lstTasks.SelectedItem));
            }
            else
                MessageBox.Show("Please select an item to remove.");
        }
        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            if (taskList.Count == 0)
                MessageBox.Show("There are no tasks");
            else
            {
                string display = string.Empty;

                foreach (KeyValuePair<DateTime, string> kvp in taskList)
                    display += $"{kvp.Key.ToShortDateString()} {kvp.Value.ToString()} \n";

                MessageBox.Show(display);
            }
        }
    }
}
