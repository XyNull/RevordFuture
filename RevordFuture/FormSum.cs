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
    public partial class FormSum : Form
    {
        private Dictionary<DateTime, List<ExpendProject>> _database = new Dictionary<DateTime, List<ExpendProject>>();
        public FormSum(Dictionary<DateTime, List<ExpendProject>> database)
        {
            InitializeComponent();
            _database = database;
        }

        private void FormSum_Load(object sender, EventArgs e)
        {
            InitTree(_database);
        }

        private void InitTree(Dictionary<DateTime, List<ExpendProject>> database)
        {
            foreach (var data in database)
            {
                var node = new TreeNode {Text = data.Key.Date.ToLongDateString()};
                foreach (var expendProject in data.Value)
                {
                    node.Nodes.Add(new TreeNode {Text = expendProject.Name + expendProject.Money});
                }
                treeView.Nodes.Add(node);
            }
            treeView.ExpandAll();
        }

        private void button_Click(object sender, EventArgs e)
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
    }
}
