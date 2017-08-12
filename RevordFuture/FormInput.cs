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
        private FormMain _formMain;

        public FormInput(FormMain fm)
        {
            InitializeComponent();
            _formMain = fm;
        }

        private void button_Click(object sender, EventArgs e)
        {
            var dayexpend = new DayExpend {Day = dateTimePicker.Value.Date};
            try
            {
                var item = new ExpendProject
                {
                    Money = int.Parse(textBoxNum.Text) * (checkBox.Checked ? -1 : 1),
                    Name = textBoxName.Text
                };
                dayexpend.Projects.Add(item);
                _formMain.AddNode(dayexpend);

                operatingLabel.ForeColor = Color.Green;
                operatingLabel.Text = textBoxName.Text + textBoxNum.Text + "已经加入成功";
            }
            catch (Exception exception)
            {
                operatingLabel.ForeColor = Color.Red;
                operatingLabel.Text = exception.Message;
            }

            textBoxName.Clear();
            textBoxNum.Clear();
        }
    }
}
