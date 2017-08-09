using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RevordFuture.Constract;

namespace RevordFuture
{
    public partial class FormMain : Form
    {
        private FormInput _fi;
        private Dictionary<DateTime, List<ExpendProject>> _database = new Dictionary<DateTime, List<ExpendProject>>();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            TimeLabel.Text = DateTime.Now.ToLongDateString();
            RefreshData();
        }

        private void RefreshData()
        {
            dataGridView.Rows.Clear();
            foreach (var data in _database)
            {
                foreach (var expendProject in data.Value)
                {
                    dataGridView.Rows.Add(data.Key.Date.ToLongDateString(),
                        expendProject.Name + "//" + expendProject.Money + "元");
                }
            }
        }

        private void InputMenuItem_Click(object sender, EventArgs e)
        {
            _fi = new FormInput();
            _fi.ShowDialog();
            var gets = _fi.Days;

            //将获取的信息加入数据库
            foreach (var dayExpend in gets)
            {
                if (_database.ContainsKey(dayExpend.Day.Date))
                {
                    foreach (var project in dayExpend.Projects)
                    {
                        _database[dayExpend.Day.Date].Add(project);
                    }
                }
                else
                {
                    _database.Add(dayExpend.Day.Date,dayExpend.Projects);
                }
            }

            RefreshData();
        }

        private void SumMenuItem_Click(object sender, EventArgs e)
        {
            var f = new FormSum(_database);
            f.ShowDialog();
        }

        private void ExcelInMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();

            var fileStream = openFileDialog.OpenFile();
            var data = new Dictionary<string, string>();
            FileRead(fileStream,data);


        }

        private static void FileRead(Stream fileStream,IDictionary<string, string> data)
        {
            var reader = new StreamReader(fileStream);

            while (true)
            {
                var str = reader.ReadLine();
                var x = new string[2];
                x = str.Split(',');
                data.Add(x[0], x[1]);
                
            }


        }

        private void ExcelOutMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
