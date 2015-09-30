using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAEngine
{
    public class CMAGetUserPath : MAControl, IMAControl
    {
        public virtual string[] GetPath() { return new string[] { }; }
        public string[] FilePaths { get; set; }
        public string FilePath { get; set; }

        ListBox lstbox = new ListBox() { Width = 80, Height = 100, Dock = DockStyle.Top };
        private Panel panel1;
        Button btn = new Button() { Text = "浏览" ,Height=22,Width=50,Dock = DockStyle.Top };
        public CMAGetUserPath()
        {
            InitializeComponent();
            this.panel1.Controls.Add(lstbox);
            this.panel1.Controls.Add(btn);
            btn.Click += btn_Click;
        }

        void btn_Click(object sender, EventArgs e)
        {
            string[] strs = GetPath();
            if (strs == null || strs.Length==0)
                return;
            if (strs.Length ==1)
            {
                FilePath = strs[0];
            }
            else
            {
                FilePaths = strs;
            }
            init(strs);
        }
        public bool init(string[] paths)
        {
            lstbox.Items.Clear();
            FilePaths = paths;
            lstbox.Items.AddRange(paths);
            return true;
        }
        public bool init(string path)
        {
            lstbox.Items.Clear();
            FilePath = path;
            lstbox.Items.Add(path);
            return true;
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 150);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += panel1_Paint; 
            // 
            // CMAGetUserPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.panel1);
            this.Name = "CMAGetUserPath";
            this.Size = new System.Drawing.Size(435, 150);
            this.ResumeLayout(false);

        }

        void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                this.panel1.ClientRectangle,
                Color.Red,//7f9db9
                1,
                ButtonBorderStyle.Solid,
                Color.Red,
                1,
                ButtonBorderStyle.Solid,
                Color.Red,
                1,
                ButtonBorderStyle.Solid,
                Color.Red,
                1,
                ButtonBorderStyle.Solid);
                }
    }
    public class CMAGetUserFilePath : CMAGetUserPath
    {
        public CMAGetUserFilePath() : base() { }
        public string Filter { get; set; }
        public override string[] GetPath()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            Filter = string.IsNullOrEmpty(Filter) ? "*.*|*.*" : Filter;
            dlg.Filter = this.Filter;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.FileNames;
            }
            else
                return base.GetPath();
        }

    }
    public class CMAGetUserDirPath : CMAGetUserPath
    {
        public CMAGetUserDirPath() : base() { }
        public override string[] GetPath()
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return new string[] { dlg.SelectedPath };
            }
            else
                return base.GetPath();
        }
    }
}
