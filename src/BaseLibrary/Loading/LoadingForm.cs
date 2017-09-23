using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseLibrary.Loading
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {

            label1.Text = LoadingAppName;
        }

        public string LoadingAppName = "程序启动中";


        public void UpdateStatus(string name)
        {
            LoadingAppName = name;
            label1.Text = LoadingAppName;
        }

        public List<LoadingItem> ProcessList = new List<LoadingItem>();

        public void AddProgress(string process, int percent)
        {
            if (ProcessList.Count > 0 && ProcessList[ProcessList.Count - 1].Name == process)
            {
                ProcessList[ProcessList.Count - 1] = new LoadingItem()
                {
                    Name = process,
                    Percent = percent / 100f,
                };
            }
            else
            {
                ProcessList.Add(new LoadingItem()
                {
                    Name = process,
                    Percent = percent / 100f,
                });
            }

            listBoxLoading.Items.Clear();
            foreach (var loadingItem in ProcessList)
            {
                listBoxLoading.Items.Add(loadingItem);
            }
            Application.DoEvents();
            listBoxLoading.SelectedIndex = listBoxLoading.Items.Count - 1;

            Thread.Sleep(300);
        }
    }


    public struct LoadingItem
    {
        public string Name;
        public float Percent;

        public bool Status;

        public override string ToString()
        {
            return $"{Name}:{Percent:P}";
        }
    }
}
