using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using BaseLibrary.Object;

namespace BaseLibrary.Statistics
{
    public partial class StatisticsUserControl : UserControl
    {
        public StatisticsUserControl()
        {
            InitializeComponent();
        }

        private void StatisticsUserControl_Load(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = (int)(0.4 * splitContainer1.Width);
            splitContainer2.SplitterDistance = (int)(0.5 * splitContainer2.Width);

            splitContainer3.SplitterDistance = (int)(0.4 * splitContainer3.Width);
            splitContainer4.SplitterDistance = (int)(0.4 * splitContainer4.Width);
            splitContainer5.SplitterDistance = (int)(0.4 * splitContainer5.Width);


            _startTime = DateTime.Now;

            groupBoxStatistics.Text = $"统计信息 {_startTime.ToString("s")}";
        }


        #region user interact
        private void labelTOTAL_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("清楚统计数据？", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                Clear();

                _startTime = DateTime.Now;

                groupBoxStatistics.Text = $"统计信息 {_startTime.ToString("s")}";
            }
        }

        private void labelStat_DoubleClick(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.Append($"起始时间: {_startTime:s}\r\n");
            sb.Append($"当前时间: {DateTime.Now:s}\r\n\r\n");

            foreach (var d in _statDictionary)
            {
                sb.Append($"{d.Key}: {d.Value}\r\n");
            }

            MessageBox.Show($"{sb}");
        }

        #endregion


        #region stat

        public string Total = "Total";
        public string Pass = "Pass";
        public string Fail = "Fail";


        private void OnUpdateStat()
        {
            long total = 0;
            if (_statDictionary.ContainsKey(Pass))
            {
                total += _statDictionary[Pass];
                labelPASSCOUNT.Text = _statDictionary[Pass].ToString();
            }
            else
            {
                labelPASSCOUNT.Text = 0.ToString();
            }

            if (_statDictionary.ContainsKey(Fail))
            {
                total += _statDictionary[Fail];
                labelFAILCOUNT.Text = _statDictionary[Fail].ToString();
            }
            else
            {
                labelFAILCOUNT.Text = 0.ToString();
            }

            labelTOTALCOUNT.Text = total.ToString();
        }

        public void InsertResult(TestResultObject result)
        {
            if (result.Status == TestResultStatus.Pass)
            {
                UpdateStatDict(Pass);
            }
            else
            {
                UpdateStatDict(Fail);
                if (!string.IsNullOrEmpty(result.Error))
                {
                    UpdateStatDict(result.Error);
                }
            }

            UpdateStatDict(Total);

            OnUpdateStat();
        }


        public void Clear()
        {
            _statDictionary.Clear();

            OnUpdateStat();
        }

        #endregion

        #region insert stat

        private DateTime _startTime;

        private readonly Dictionary<string, long> _statDictionary = new Dictionary<string, long>();

        private void UpdateStatDict(string key)
        {
            if (!_statDictionary.ContainsKey(key))
            {
                _statDictionary.Add(key, 0);
            }
            _statDictionary[key]++;
        }

        #endregion
    }
}