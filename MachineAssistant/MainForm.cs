using MAEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineAssistant
{
    public partial class MainForm : Form
    {
        public static Dictionary<string, CCMDTag> _cmdDir = new Dictionary<string, CCMDTag>();
        public MainForm()
        {
            InitializeComponent();
            _cmdDir = Common.g_CMDDir;
        }
        TreeNode nodeSource = null;
        TreeNode nodeGeneral = null;
        TreeNode nodeRecent = null;
        private void MainForm_Load(object sender, EventArgs e)
        {
            nodeSource = new TreeNode() { Name = "nodeSource", Text = "资源库" };
            nodeGeneral = new TreeNode() { Name = "nodeGeneral", Text = "最常使用" };
            nodeRecent = new TreeNode() { Name = "nodeRecent", Text = "最近添加" };
            this.tvModel.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            nodeSource,
            nodeGeneral,
            nodeRecent});

            foreach (var item in _cmdDir)
            {
                string dllName = item.Key.Split('.')[0];
                TreeNode[] tns = nodeSource.Nodes.Find(dllName, false);
                if (tns==null || tns.Length ==0)
                {
                    nodeSource.Nodes.Add(dllName, item.Value.DllDescrip);
                }
            }
            if (nodeSource.Nodes.Count > 0)
            {
                tvModel.SelectedNode = nodeSource.Nodes[0];
            }
        }

        private void tvModel_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != nodeSource)
                return;
            tvFuntion.Nodes.Clear();
            List<string> lstFuntionName = _cmdDir.Keys.ToList().FindAll(a => a.Split('.')[0].Equals(e.Node.Name));
            lstFuntionName.ForEach(a =>
            {
                string itemName = _cmdDir[a].MACmd.Name;
                if (!string.IsNullOrEmpty(itemName))
                {
                    tvFuntion.Nodes.Add(new TreeNode(itemName) { Name = a });
                }
            });
            if (tvFuntion.Nodes.Count > 0)
            {
                tvFuntion.SelectedNode = tvFuntion.Nodes[0];
            }
        }

        private void tvFuntion_AfterSelect(object sender, TreeViewEventArgs e)
        {
            richTextBox1.Text = _cmdDir[e.Node.Name].MACmd.Description;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            //其中label1.Text显示的就是拖进文件的文件名； 
            MessageBox.Show(((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString());   
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;   
        }

        private void tvFuntion_ItemDrag(object sender, ItemDragEventArgs e)
        {
           // MessageBox.Show((e.Item as TreeNode).Name);
        }

        //拖动效果暂时用双击代替
        private void tvFuntion_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }



    }
}
