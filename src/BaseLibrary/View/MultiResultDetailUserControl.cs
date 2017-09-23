using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseLibrary.Extension;
using BaseLibrary.Object;

namespace BaseLibrary.View
{
    public partial class MultiResultDetailUserControl : UserControl
    {
        public string Fail = "FAIL";
        public string Pass = "PASS";
        public string ProcessString = "Testing";


        public string WaitString = "Waiting";

        public MultiResultDetailUserControl()
        {
            InitializeComponent();
        }

        private void MultiResultDetailUserControl_Load(object sender, EventArgs e)
        {
            InitDgv();

        }


        private void InitDgv()
        {
            dgvDetails.Columns.Clear();
            dgvDetails.Columns.Add("Properties", "Properties");
            dgvDetails.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetails.Columns[0].ReadOnly = true;

            dgvDetails.Rows.Clear();
            dgvDetails.Rows.Add(1);
            dgvDetails.Rows[0].Cells[0].Value = "PASS/FAIL";
        }

        public void ClearResult()
        {
            InitDgv();
        }

        public void UpdateErrors(string[] errors)
        {
            for (int i = 0; i < errors.Length; i++)
            {
                if (errors[i].IsNullOrEmpty())
                {
                    continue;
                }
                dgvDetails.Rows[0].Cells[i + 1].Value = errors[i];
                dgvDetails.Rows[0].Cells[i + 1].Style.BackColor = Color.Red;

            }
        }


        public void AppendResults(IEnumerable<TestResultObject> resultObjects, bool isUpdateColor = false)
        {
            foreach (var res in resultObjects)
            {
                AppendResult(res,isUpdateColor);
            }
        }
        public void AppendResult(TestResultObject result, bool isUpdateColor = false)
        {
            int c = dgvDetails.ColumnCount;
            var col = dgvDetails.Columns.Add($"Result{c}", $"Result{c}");
            dgvDetails.Columns[col].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetails.Columns[col].ReadOnly = true;
            dgvDetails.Columns[col].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (result == null)
            {
                return;
            }

            var values = result.CsvValues().Split(',');
            if (dgvDetails.Rows.Count < values.Length)
            {
                dgvDetails.Rows.Add(values.Length - dgvDetails.RowCount + 1);
                var headers = result.CsvHeaders().Split(',');
                for (var i = 0; i < values.Length && i < headers.Length; i++)
                {
                    dgvDetails.Rows[i + 1].Cells[0].Value = headers[i];
                    dgvDetails.Rows[i + 1].Cells[col].Value = values[i];
                }
            }
            else
            {
                for (var i = 0; i < values.Length; i++)
                {
                    dgvDetails.Rows[i + 1].Cells[col].Value = values[i];
                }
            }

            dgvDetails.Rows[0].Cells[col].Value = result.Status.ToString();
            if (isUpdateColor)
            {
                dgvDetails.Rows[0].Cells[col].Style.BackColor = result.Status == TestResultStatus.Pass ? Color.Lime : Color.Red;
            }

            dgvDetails.Update();


        }
    }
}
