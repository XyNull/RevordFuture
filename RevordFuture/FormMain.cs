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
        private Dictionary<DateTime, DayExpend> _database = new Dictionary<DateTime, DayExpend>();
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitTree(_database);
        }

        private void InitTree(Dictionary<DateTime,DayExpend> database)
        {
            foreach (var data in database)
            {
                var node = new TreeNode {Text = ConvertTime(data.Key)};
                foreach (var expendProject in data.Value.Projects)
                {
                    node.Nodes.Add(new TreeNode
                    {
                        Text = $"“{expendProject.Name}”预计{(expendProject.Money > 0 ? "收入" : "开销")}{Math.Abs(expendProject.Money)}元"
                    });
                }
                treeView.Nodes.Add(node);
            }
            treeView.ExpandAll();
        }

        private void buttonSum_Click(object sender, EventArgs e)
        {
            treeView.Nodes.Clear();
            var time = dateTimePicker.Value.Date;
            var choosedData =
                _database.Where(data => DateTime.Compare(time, data.Key) >= 0)
                    .ToDictionary(data => data.Key, data => data.Value);
            var sum = choosedData.SelectMany(data => data.Value.Projects).Sum(num => num.Money);
            treeView.Nodes.Add(new TreeNode {Text = sum.ToString()});
            InitTree(choosedData);
        }

        private void InputMenuItem_Click(object sender, EventArgs e)
        {
            _fi = new FormInput(this);
            _fi.ShowDialog();
        }

        private void AddData(DayExpend dayExpend)
        {
            if (_database.ContainsKey(dayExpend.Day))
            {
                _database[dayExpend.Day].Projects.AddRange(dayExpend.Projects);
            }
            else
            {
                _database.Add(dayExpend.Day, dayExpend);
            }
        }

        private string ConvertTime(DateTime date)
        {
            var str = date.Date.ToShortDateString();
            var strs = str.Split('/');
            return $"{strs[0]}.{strs[1]}.{strs[2]}";
        }

        private TreeNode FindNode(TreeNodeCollection nodeCollection, string key)
        {
            var nodes = nodeCollection.Cast<TreeNode>().ToList();
            return nodes.FirstOrDefault(node => node.Text.Equals(key));
        }

        /// <summary>
        /// 向treeview添加节点，同时将这条数据同步到数据仓库。
        /// </summary>
        /// <param name="dayExpend"></param>
        public void AddNode(DayExpend dayExpend)
        {
            AddData(dayExpend);

            var time = ConvertTime(dayExpend.Day);
            var node = FindNode(treeView.Nodes, time);
            if (node != null)
            {
                foreach (var expendProject in dayExpend.Projects)
                {
                    node.Nodes.Add(new TreeNode
                    {
                        Text = $"“{expendProject.Name}”预计{(expendProject.Money > 0 ? "收入" : "开销")}{Math.Abs(expendProject.Money)}元"
                    });
                }
            }
            else
            {
                node = new TreeNode
                {
                    Text = time
                };
                foreach (var expendProject in dayExpend.Projects)
                {
                    node.Nodes.Add(new TreeNode()
                    {
                        Text =
                            $"“{expendProject.Name}”预计{(expendProject.Money > 0 ? "收入" : "开销")}{Math.Abs(expendProject.Money)}元"
                    });
                }
                treeView.Nodes.Add(node);
            }

            treeView.ExpandAll();
        }

        private void ExcelInMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "data";
            openFileDialog.Filter = "Excel逗号分隔符文件(*.csv)|*.csv";
            saveFileDialog.AddExtension = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                    var streamReader = new StreamReader(fileStream);
                    var list = new List<string>();
                    while (!streamReader.EndOfStream)
                    {
                        list.AddRange(streamReader.ReadLine().Split(','));
                    }
                    list.RemoveAll(str => str.Equals(""));
                    var dayExpends = DayExpend.Deserialization(list);
                    foreach (var dayExpend in dayExpends)
                    {
                        _database.Add(dayExpend.Day, dayExpend);
                    }
                    fileStream?.Close();
                    FormMain_Load(null, null);
                }
                catch (Exception exception)
                {
                    statusLabel.ForeColor = Color.Red;
                    statusLabel.Text = exception.Message;
                }
            }
        }

        private void ExcelOutMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "data";
            saveFileDialog.Filter = "Excel逗号分隔符文件(*.csv)|*.csv";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
                    var streamWriter = new StreamWriter(fileStream);
                    var list = DayExpend.Serialization(_database.Values.ToList());
                    foreach (var str in list)
                    {
                        streamWriter.Write(str+",");
                    }
                    streamWriter?.Flush();
                    streamWriter?.Close();
                    fileStream?.Close();
                }
                catch (Exception exception)
                {
                    statusLabel.ForeColor = Color.Red;
                    statusLabel.Text = exception.Message;
                }
            }
        }

        private void FreshMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                treeView.Nodes.Clear();
                InitTree(_database);
                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "已刷新";
            }
            catch (Exception exception)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = exception.Message;
            }
        }

        private void clearMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _database.Clear();
                treeView.Nodes.Clear();
            }
            catch (Exception exception)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = exception.Message;
            }
        }
    }
}
