using System;
using System.Drawing;
using System.Windows.Forms;
using BaseLibrary.Object;

namespace BaseLibrary.View
{
    public partial class ResultUserControl : UserControl
    {
        public string Fail = "FAIL";
        public string Pass = "PASS";

        public string WaitString = "Waiting";
        public string ProcessString = "Testing";

        public ResultUserControl()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            labelResult.Text = WaitString;
            labelResult.BackColor = Color.Gold;
        }

        public void UpdateStart(TestResultObject result)
        {
            labelResult.Text = ProcessString;
            labelResult.BackColor = Color.Gold;
        }

        public void UpdateStatus(object obj)
        {
            labelResult.Text = obj.ToString();
            labelResult.BackColor = Color.Gold;
        }

        public void UpdateResult(TestResultObject result)
        {
            if (result == null)
            {
                labelResult.Text = "ERROR";
                labelResult.BackColor = Color.LightGray;
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
        }

    }
}