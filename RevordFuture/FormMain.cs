using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void FormSum_Load(object sender, EventArgs e)
        {
            InitTree(_database);
        }

        private void InitTree(Dictionary<DateTime, List<ExpendProject>> database)
        {
            foreach (var data in database)
            {
                var node = new TreeNode {Text = ConvertTime(data.Key)};
                foreach (var expendProject in data.Value)
                {
                    node.Nodes.Add(new TreeNode
                    {
                        Text = expendProject.Name + expendProject.Money
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
            var sum = choosedData.SelectMany(data => data.Value).Sum(num => num.Money);
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
                _database[dayExpend.Day].AddRange(dayExpend.Projects);
            }
            else
            {
                _database.Add(dayExpend.Day, dayExpend.Projects);
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
        /// 向treeview添加节点，同时将数据同步到数据仓库。
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
    }
}
