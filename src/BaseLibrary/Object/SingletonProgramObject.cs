using System;
using System.Threading;
using System.Windows.Forms;
using BaseLibrary.Util;

namespace BaseLibrary.Object
{
    public class SingletonProgramObject
    {
        public static void Run(string name, Type form)
        {
            using (var mutex = new Mutex(false, name))
            {
                if (!mutex.WaitOne(0, true))
                {
                    MessageBox.Show("程序运行中！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Application.ThreadException += OnApplicationThreadException;
                    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                    AppDomain.CurrentDomain.UnhandledException += OnDomainUnhandledException;

                    //try
                    //{
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run((Form)Activator.CreateInstance(form));
                    //}
                    //catch (Exception ex)
                    //{
                    //    Logger.Line(ex.Message);
                    //    ScreenShot.Shot($"{name}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_{ex.HResult}");
                    //    OnExceptionEvent(ex);
                    //}

                    Application.Exit();
                }
            }
        }


        private static void OnDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (AppDomain.CurrentDomain.FriendlyName.EndsWith("vshost.exe"))
            {
                var exception = e.ExceptionObject as Exception;
                if (exception != null) throw exception;
                return;
            }
            var ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                string exception = $"{ex.GetType()} {ex.Message}\r\n{ex.StackTrace}";

                Logger.Line("Exception", $"{exception}");
                ScreenShot.Shot($"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_{ex.HResult}");
                MessageBox.Show(exception);
            }

            MessageBox.Show(((Exception)e.ExceptionObject).Message + "\r\n" + ((Exception)e.ExceptionObject).StackTrace, "系统信息");
        }


        private static void OnApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (AppDomain.CurrentDomain.FriendlyName.EndsWith("vshost.exe"))
            {
                if (e.Exception != null) throw e.Exception;
                return;
            }
            var ex = e.Exception;
            if (ex != null)
            {
                string exception = $"{ex.GetType()} {ex.Message}\r\n{ex.StackTrace}";

                Logger.Line("Exception", $"{exception}");
                ScreenShot.Shot($"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_{ex.HResult}");
                MessageBox.Show(exception);
            }
        }


        public static event Action<Exception> ExceptionEvent;

        protected static void OnExceptionEvent(Exception ex)
        {
            ExceptionEvent?.Invoke(ex);
        }
    }
}