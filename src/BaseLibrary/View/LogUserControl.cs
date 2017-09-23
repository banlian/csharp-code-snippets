using System;
using System.Windows.Forms;
using BaseLibrary.Object;

namespace BaseLibrary.View
{
    public partial class LogUserControl : UserControl
    {
        private readonly Action _clearLogAction;

        private readonly Action<string> _logAction;

        private int index;

        private readonly object logLock = new object();


        public int LogThreshold = 500;

        public LogLevel LogLevel = LogLevel.Info;

        public LogUserControl()
        {
            InitializeComponent();

            _logAction = UpdateLog;

            _clearLogAction = Clear;
        }


        public void Clear()
        {
            lock (logLock)
            {
                if (InvokeRequired)
                {
                    Invoke(_clearLogAction);
                }
                else
                {
                    richTextBoxLog.Clear();
                    index = 0;
                }
            }
        }

        public void UpdateLog(string log)
        {
            lock (logLock)
            {
                if (InvokeRequired)
                {
                    BeginInvoke(_logAction, log);
                }
                else
                {
                    if (richTextBoxLog == null || richTextBoxLog.IsDisposed)
                    {
                        return;
                    }

                    if (index++ > LogThreshold)
                    {
                        index = 0;
                        richTextBoxLog.Clear();
                    }

                    richTextBoxLog.AppendText($"{DateTime.Now.ToString("HH:mm:ss.fff")}:{log}\r\n");
                    richTextBoxLog.ScrollToCaret();
                }
            }
        }

        private void contextMenuStripLog_Opened(object sender, EventArgs e)
        {
            UpdateLogLevel(LogLevel);
        }


        public void UpdateLogLevel(LogLevel level)
        {
            foreach (ToolStripMenuItem item in contextMenuStripLog.Items)
            {
                item.Checked = item.Text == level.ToString();
            }
        }

        public event Action<string> LogLevelClickEvent;

        protected virtual void OnLogMenuClickEvent(string obj)
        {
            LogLevelClickEvent?.Invoke(obj);
        }

        private void contextMenuStripLog_MouseClick(object sender, MouseEventArgs e)
        {
            ContextMenuStrip logMenuStrip = (ContextMenuStrip)sender;

            if (logMenuStrip.GetItemAt(e.Location).Text != "Clear")
            {
                OnLogMenuClickEvent(logMenuStrip.GetItemAt(e.Location).Text);

                LogLevel = (LogLevel)Enum.Parse(typeof(LogLevel), logMenuStrip.GetItemAt(e.Location).Text);
            }
            else
            {
                Clear();
            }

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}