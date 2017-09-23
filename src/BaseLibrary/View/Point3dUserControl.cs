using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseLibrary.View
{
    public partial class Point3DUserControl : UserControl
    {
        public Point3DUserControl()
        {
            InitializeComponent();
        }

        public void UpdatePosition(Tuple<float, float, float> pos)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Tuple<float, float, float>>(UpdatePosition), pos);
            }
            else
            {
                textBoxX.Text = pos.Item1.ToString("F");
                textBoxY.Text = pos.Item2.ToString("F");
                textBoxZ.Text = pos.Item3.ToString("F");
            }
        }

    }
}
