using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseLibrary.Network
{
    public partial class NetworkControl : UserControl
    {
        public NetworkControl()
        {
            InitializeComponent();
        }

        private void NetworkControl_Load(object sender, EventArgs e)
        {
            comboBoxNIC.Items.AddRange(WMIHelper.GetNICNames().ToArray());
            if (comboBoxNIC.Items.Count > 0)
            {
                comboBoxNIC.SelectedIndex = 0;
                if (comboBoxNIC.SelectedItem != null)
                {
                    UpdateNIC();
                }
            }
        }

        private void comboBoxNIC_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNIC();
        }

        private void UpdateNIC()
        {
            string[] ip;
            string[] mask;
            string[] gateway;
            string[] dns;

            WMIHelper.GetIP(comboBoxNIC.SelectedItem.ToString(), out ip, out mask, out gateway, out dns);

            UpdateDgvNIC(ip, mask, gateway, dns);
        }


        private void UpdateDgvNIC(string[] ip, string[] mask, string[] gateway, string[] dns)
        {
            dgvNIC.Rows.Clear();
            dgvNIC.Columns.Clear();
            dgvNIC.Columns.Add("Props", "Property");
            dgvNIC.Columns.Add("Details", "Value");
            dgvNIC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            if (ip != null && ip.Length > 0)
            {
                int r = dgvNIC.Rows.Add();

                dgvNIC.Rows[r].Cells[0].Value = "IP";
                dgvNIC.Rows[r].Cells[1].Value = ip[0];
            }


            if (mask != null && mask.Length > 0)
            {
                int r = dgvNIC.Rows.Add();

                dgvNIC.Rows[r].Cells[0].Value = "SubMask";
                dgvNIC.Rows[r].Cells[1].Value = mask[0];
            }


            if (gateway != null && gateway.Length > 0)
            {
                int r = dgvNIC.Rows.Add();

                dgvNIC.Rows[r].Cells[0].Value = "Gateway";
                dgvNIC.Rows[r].Cells[1].Value = gateway[0];
            }


            if (dns != null && dns.Length > 0)
            {
                int r = dgvNIC.Rows.Add();

                dgvNIC.Rows[r].Cells[0].Value = "DNS";
                dgvNIC.Rows[r].Cells[1].Value = dns[0];
            }
        }

        private void buttonSetNIC_Click(object sender, EventArgs e)
        {
            string nic = comboBoxNIC.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(nic))
            {
                return;
            }

            if (dgvNIC.RowCount >= 5)
            {
                string ip = dgvNIC.Rows[0].Cells[1].Value.ToString();
                string submask = dgvNIC.Rows[1].Cells[1].Value.ToString();
                string gateway = dgvNIC.Rows[2].Cells[1].Value.ToString();
                string dns = dgvNIC.Rows[3].Cells[1].Value.ToString();

                WMIHelper.SetIP(nic, ip, submask, gateway, dns);
                MessageBox.Show("SetIP Finish!");
            }

            if (dgvNIC.RowCount == 4)
            {
                string ip = dgvNIC.Rows[0].Cells[1].Value.ToString();
                string submask = dgvNIC.Rows[1].Cells[1].Value.ToString();
                string gateway = dgvNIC.Rows[2].Cells[1].Value.ToString();

                WMIHelper.SetIP(nic, ip, submask, gateway);
                MessageBox.Show("SetIP Finish!");
            }

            if (dgvNIC.RowCount == 3)
            {
                string ip = dgvNIC.Rows[0].Cells[1].Value.ToString();
                string submask = dgvNIC.Rows[1].Cells[1].Value.ToString();

                WMIHelper.SetIP(nic, ip, submask);
                MessageBox.Show("SetIP Finish!");
            }

        }
    }
}