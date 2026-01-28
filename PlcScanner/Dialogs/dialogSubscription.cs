using Krypton.Toolkit.Suite.Extended.TreeGridView;
using PlcScanner.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlcScanner.Dialogs
{
    public partial class dialogSubscription : Form
    {
        private OpcTag _inputMapping;
        public Dictionary<string, bool> Mapping { get; private set; }
        public dialogSubscription(OpcTag rootNode)
        {
            InitializeComponent();
            _inputMapping = rootNode;
            Mapping = new Dictionary<string, bool>();
            foreach (OpcTag element in rootNode.Childrens)
            {
                treeView1.Nodes.Add(CreateNode(element));
            }
        }
        public TreeNode CreateNode(OpcTag tag)
        {
            TreeNode n = new TreeNode(tag.NodeId);
            if (tag.SubscriptionID != string.Empty)
                n.Checked = true;
            Mapping.Add(tag.NodeId, tag.SubscriptionID != string.Empty);
            foreach (OpcTag element in tag.Childrens)
                n.Nodes.Add(CreateNode(element));
            return n;
        }

        private void dialogSubscription_Load(object sender, EventArgs e)
        {

        }

        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void CheckNodesRecursively(TreeNode node, bool status)
        {
            if(node.Checked != status)
            {
                node.Checked = status;
            }
            foreach(TreeNode n in node.Nodes)
            {
                CheckNodesRecursively(n, status);
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            Mapping[e.Node.Text] = e.Node.Checked;
            if(e.Node.Nodes.Count > 0)
               CheckNodesRecursively(e.Node, e.Node.Checked);
        }
    }
}
