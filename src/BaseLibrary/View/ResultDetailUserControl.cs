using System;
using System.Drawing;
using System.Windows.Forms;
using BaseLibrary.Object;

namespace BaseLibrary.View
{
    public partial class ResultDetailUserControl : UserControl
    {
        public string Fail = "FAIL";
        public string Pass = "PASS";
        public string ProcessString = "Testing";


        public string WaitString = "Waiting";

        public ResultDetailUserControl()
        {
            InitializeComponent();
        }

        private void ResultDetailUserControl_Load(object sender, EventArgs e)
        {
            InitDgv();

            SetSplitter(0.25);
        }

        public void SetSplitter(double split1, double split2 = 0.15)
        {
            if (split1 < 0 || split1 > 1 || split2 < 0 || split2 > 1)
            {
                return;
            }

            splitContainer1.SplitterDistance = (int) (splitContainer1.Height*split1);
            splitContainer2.SplitterDistance = (int) (splitContainer2.Height*(1 - split2));
        }

        #region update process

        public void Clear()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(Clear));
            }
            else
            {
                labelResult.Text = WaitString;
                labelResult.BackColor = Color.LightGray;
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
                labelResult.Text = ProcessString;
                labelResult.BackColor = Color.Gold;

                UpdateDgv(result);
            }
        }

        /// <summary>
        ///     Update labelResult and change color gold
        /// </summary>
        /// <param name="obj"></param>
        public void UpdateStatus(object obj)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object>(UpdateStatus), obj);
            }
            else
            {
                labelResult.Text = obj?.ToString();
                labelResult.BackColor = Color.Gold;
            }
        }

        /// <summary>
        ///     Update labelResult without change color
        /// </summary>
        /// <param name="obj"></param>
        public void UpdateState(object obj)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object>(UpdateState), obj);
            }
            else
            {
                labelResult.Text = obj?.ToString();
            }
        }

        public void UpdateDetails(TestResultObject result)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<TestResultObject>(UpdateDetails), result);
            }
            else
            {
                if (result == null)
                {
                    labelResult.Text = "NULL";
                    return;
                }

                UpdateDgv(result);
            }
        }

        public void UpdateResult(TestResultObject result)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<TestResultObject>(UpdateResult), result);
            }
            else
            {
                if (result == null)
                {
                    labelResult.Text = "NULL";
                    return;
                }

                UpdateDgv(result);

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


                statisticsControl.InsertResult(result);
            }
        }

        #endregion

        #region update calib details

        private void InitDgv()
        {
            dgvDetails.Columns.Clear();
            dgvDetails.Columns.Add("Properties", "Properties");
            dgvDetails.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetails.Columns[0].ReadOnly = true;
            dgvDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetails.Columns.Add("Values", "Values");
            dgvDetails.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetails.Columns[1].ReadOnly = true;
            dgvDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void UpdateDgv(TestResultObject result)
        {
            if (result == null)
            {
                return;
            }

            InitDgv();

            var values = result.CsvValues().Split(',');

            if (dgvDetails.Rows.Count != values.Length)
            {
                dgvDetails.Rows.Clear();
                dgvDetails.Rows.Add(values.Length);
                var headers = result.CsvHeaders().Split(',');
                for (var i = 0; i < values.Length && i < headers.Length; i++)
                {
                    dgvDetails.Rows[i].Cells[0].Value = headers[i];
                    dgvDetails.Rows[i].Cells[1].Value = values[i];
                }
            }
            else
            {
                for (var i = 0; i < values.Length; i++)
                {
                    dgvDetails.Rows[i].Cells[1].Value = values[i];
                }
            }

            dgvDetails.Update();
        }

        #endregion
    }
}