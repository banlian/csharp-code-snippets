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
    public partial class OperatorUserControl : UserControl
    {
        public OperatorUserControl()
        {
            InitializeComponent();
        }

        private void OperatorUserControl_Load(object sender, EventArgs e)
        {

        }

        public void SetOperatorName(string start, string stop, string reset)
        {
            buttonStart.Text = start;
            buttonStop.Text = stop;
            buttonReset.Text = reset;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            OnUserStartEvent();

            buttonStart.BackColor = Color.Lime;
            buttonStart.Enabled = false;

            buttonStop.BackColor = Color.LightGray;
            buttonStop.Enabled = true;

            buttonReset.BackColor = Color.LightGray;
            buttonReset.Enabled = false;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            OnUserStopEvent();

            buttonStart.BackColor = Color.LightGray;
            buttonStart.Enabled = false;

            buttonStop.BackColor = Color.Red;
            buttonStop.Enabled = false;

            buttonReset.BackColor = Color.LightGray;
            buttonReset.Enabled = true;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            OnUserResetEvent();

            buttonStart.BackColor = Color.LightGray;
            buttonStart.Enabled = true;

            buttonStop.BackColor = Color.LightGray;
            buttonStop.Enabled = false;

            buttonReset.BackColor = Color.Gold;
            buttonReset.Enabled = false;
        }


        #region user manual event

        public event Action UserStartEvent;
        public event Action UserStopEvent;
        public event Action UserResetEvent;

        protected virtual void OnUserStartEvent()
        {
            UserStartEvent?.Invoke();
        }

        protected virtual void OnUserStopEvent()
        {
            UserStopEvent?.Invoke();
        }

        protected virtual void OnUserResetEvent()
        {
            UserResetEvent?.Invoke();
        }

        #endregion

        #region user manulate 


        public void UserStart()
        {
            buttonStart_Click(null, null);
        }

        public void UserStop()
        {
            buttonStop_Click(null, null);
        }

        public void UserReset()
        {
            buttonReset_Click(null, null);
        }


        #endregion
    }
}
