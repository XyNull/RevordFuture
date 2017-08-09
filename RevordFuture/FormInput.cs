using RevordFuture.Constract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevordFuture
{
    public partial class FormInput : Form
    {
        public List<DayExpend> Days = new List<DayExpend>();

        public FormInput()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            var dayexpend = new DayExpend {Day = dateTimePicker.Value.Date};
            var item = new ExpendProject
            {
                Money = int.Parse(textBoxNum.Text),
                Name = textBoxName.Text
            };
            dayexpend.Projects.Add(item);
            Days.Add(dayexpend);

            operatingLabel.Text = textBoxName.Text + textBoxNum.Text + "已经加入成功";

            textBoxName.Clear();
            textBoxNum.Clear();
        }
    }
}
