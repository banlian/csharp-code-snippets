using System;
using System.Drawing;
using System.Windows.Forms;
using BaseLibrary.Object;

namespace BaseLibrary.IniEdit
{
    public partial class IniEditControl : UserControl
    {
        public IniEditControl()
        {
            InitializeComponent();
        }

        private void IniEditControl_Load(object sender, EventArgs e)
        {

        }


        private IniObject iniObject;

        private Panel panel;

        public void LoadIniObject(IniObject ini, int labelWidth = 200, int textboxWidth = 300)
        {
            iniObject = ini;

            var p = IniEditLoader.LoadIniObject(ini, labelWidth, textboxWidth);
            p.Location = new Point(10, 10);
            p.Dock = DockStyle.Fill;

            var groupbox = new GroupBox();
            groupbox.Text = p.Text;
            groupbox.Dock = DockStyle.Fill;
            groupbox.Controls.Add(p);

            this.splitContainer1.Panel1.Controls.Add(groupbox);

            this.Invalidate();

            panel = p;
        }

        private void buttonSaveIni_Click(object sender, EventArgs e)
        {
            IniEditLoader.UpdateIniObject(ref iniObject, panel);
        }
    }
}
