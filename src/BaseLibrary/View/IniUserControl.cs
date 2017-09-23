using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseLibrary.IniEdit;
using BaseLibrary.Object;
using IniParser;
using IniParser.Parser;

namespace BaseLibrary.View
{
    public partial class IniUserControl : UserControl
    {
        public IniObject IniObject;

        public IniUserControl()
        {
            InitializeComponent();
        }

        private void IniUserControl_Load(object sender, EventArgs e)
        {
            //richTextBoxIni.Text = IniObject?.Data?.ToString();

        }
        private void buttonLoadIni_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog()
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Ini File(*.ini)|",
                Multiselect = false,
            };


            if (ofd.ShowDialog() == DialogResult.OK)
            {
                IniObject = new IniObject(ofd.FileName);
                IniObject.Load();

                //richTextBoxIni.Text = IniObject.Data?.ToString();
            }
        }
        private void buttonSaveIni_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog()
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Ini File(*.ini)|",
            };


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (IniObject == null)
                {
                    IniObject = new IniObject();
                }

                //IniObject.Data = new IniDataParser().Parse(richTextBoxIni.Text);
                //IniObject.Save();
            }
        }

    }
}
