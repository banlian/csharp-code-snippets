using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseLibrary.Object;

namespace BaseLibrary.View
{
    public partial class ResultStatusUserControl : UserControl
    {
        public string WaitString = "Waiting";
        public string ProcessString = "Testing";

        public string Pass = "PASS";
        public string Fail = "FAIL";

        public ResultStatusUserControl()
        {
            InitializeComponent();
        }

        public void SetSplitter(float ratio)
        {
            if (ratio >= 0 & ratio <= 1)
            {
                splitContainerMain.SplitterDistance = (int)(ratio * splitContainerMain.Height);
            }
        }

        public void Clear()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(Clear));
            }
            else
            {
                labelResult.Text = WaitString;
                labelResult.BackColor = Color.Gold;
                richTextBoxResult.Clear();
            }
        }

        public void UpdateStart(TestResultObject result)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<TestResultObject>(UpdateStart), result);
            }
            else
            {
                if (result == null)
                {
                    labelResult.Text = "ERROR";
                    richTextBoxResult.Text = "ERROR";
                    return;
                }

                labelResult.Text = ProcessString;
                labelResult.BackColor = Color.Gold;

                richTextBoxResult.Clear();
                richTextBoxResult.Text = result.ToString();
            }
        }

        public void UpdateStatus(object status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object>(UpdateStatus), status);
            }
            else
            {
                richTextBoxResult.Text = status.ToString();
            }
        }

        public void UpdateResult(TestResultObject result)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<TestResultObject>(UpdateStart), result);
            }
            else
            {
                if (result == null)
                {
                    labelResult.Text = "ERROR";
                    richTextBoxResult.Text = "ERROR";
                    return;
                }

                if (result.Status == TestResultStatus.Pass)
                {
                    labelResult.Text = Pass;
                    labelResult.BackColor = Color.Lime;
                }
                else
                {
                    labelResult.Text = Fail;
                    labelResult.BackColor = Color.Red;
                }

                richTextBoxResult.Text = result.ToString();
            }

        }


    }
}