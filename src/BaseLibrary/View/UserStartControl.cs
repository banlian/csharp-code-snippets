using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaseLibrary.View
{
    public partial class UserStartControl : UserControl
    {
        private string _runningString;
        private string _waitString;

        public UserStartControl()
        {
            InitializeComponent();

            buttonUserStart.Focus();

            UpdateFinish();
        }

        private void buttonUserStart_Click(object sender, EventArgs e)
        {
            OnUserStartEvent();
        }

        public event Action UserStartEvent;


        protected virtual void OnUserStartEvent()
        {
            UserStartEvent?.Invoke();
        }

        public void SetText(string running, string waiting)
        {
            _runningString = running;
            _waitString = waiting;

            buttonUserStart.Text = _waitString;
        }

        public void Activate()
        {
            buttonUserStart.Focus();
            buttonUserStart.Select();
        }


        public void UpdateStart(string run = null)
        {
            if (string.IsNullOrEmpty(run) && string.IsNullOrEmpty(_runningString))
            {
                buttonUserStart.Text = "运行中";
            }
            else
            {
                buttonUserStart.Text = _runningString;
            }

            buttonUserStart.Enabled = false;
            buttonUserStart.BackColor = Color.Gold;
        }


        public void UpdateState(string state)
        {
            buttonUserStart.Text = state;
        }

        public void UpdateFinish(string wait = null)
        {
            if (string.IsNullOrEmpty(wait) && string.IsNullOrEmpty(_waitString))
            {
                buttonUserStart.Text = "启动";
            }
            else
            {
                buttonUserStart.Text = _waitString;
            }

            buttonUserStart.Enabled = true;
            buttonUserStart.BackColor = Color.White;

            buttonUserStart.Focus();
            buttonUserStart.Select();
        }


    }
}