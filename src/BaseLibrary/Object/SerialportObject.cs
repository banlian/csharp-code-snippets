using System;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using BaseLibrary.Extension;
using BaseLibrary.Interface;
using BaseLibrary.Util;

namespace BaseLibrary.Object
{
    public class SerialportSlaveObject : LogEventObject
    {
        public event Action<object> RecvDataEvent;

        public event Action<object> SendDataEvent;

        protected virtual void OnRecvDataEvent(object obj)
        {
            RecvDataEvent?.Invoke(obj);
        }

        protected virtual void OnSendDataEvent(object obj)
        {
            SendDataEvent?.Invoke(obj);
        }

        public IByteParser<object> Parser { get; set; }

        #region serial port field

        protected SerialPort Com;
        private Thread _comThread;
        private volatile bool _isRun;

        #endregion

        #region connect

        public void Open(string name, int baudrate, int databits = 8, StopBits stopbits = StopBits.One,
            Parity parity = Parity.None)
        {
            if (Com != null)
            {
                Close();
            }

            Com = new SerialPort(name, baudrate)
            {
                DataBits = databits,
                StopBits = stopbits,
                Parity = parity,
                NewLine = "\r\n",
            };
            Com.Open();
            Info($"{Com.PortName} {Com.BaudRate} Open!");

            if (Parser != null)
            {
                _comThread = new Thread(ComProcessThread);
                _comThread.Start();
                Info("Com Process Thread Start...");
            }
            else
            {
                Error("Com data parser is not Set! Com thread not running!");
            }
        }


        public void Close()
        {
            if (Com != null)
            {
                if (_comThread != null)
                {
                    Info($"{Com.PortName} {Com.BaudRate} Closing!");
                    _isRun = false;
                    _comThread.Join();
                    _comThread = null;
                }

                Info($"{Com.PortName} {Com.BaudRate} Close!");
                Com.Close();
                Com = null;
            }
        }


        public void Send(byte[] data)
        {
            if (Com != null && Com.IsOpen)
            {
                Com.Write(data, 0, data.Length);
                Info("Send:" + data.HexString());
            }
            else
            {
                Error("Send Fail:" + data.HexString());
            }
        }

        private void ComProcessThread()
        {
            if (_isRun)
            {
                return;
            }

            _isRun = true;
            while (_isRun)
            {
                if (Com.BytesToRead >= Parser.MsgLength)
                {
                    byte[] buffer = new byte[Com.BytesToRead];
                    Com.Read(buffer, 0, buffer.Length);

                    OnRecvDataEvent(Parser.ParseData(buffer));
                }
                Thread.Sleep(50);
            }
        }

        #endregion
    }


    public class SerialportMasterObject : LogEventObject
    {
        private readonly object _sync = new object();

        private bool _isInit = false;

        protected SerialPort Com;

        public bool Open(string name, int baudrate, int databits = 8, StopBits stopbits = StopBits.One,
            Parity parity = Parity.None)
        {
            if (Com != null)
            {
                Close();
            }

            if (!SerialPort.GetPortNames().Contains(name))
            {
                Error($"{name} Not Found!");
                return false;
            }

            Com = new SerialPort(name, baudrate)
            {
                DataBits = databits,
                StopBits = stopbits,
                Parity = parity,
                NewLine = "\r\n",
            };
            Com.Open();
            _isInit = true;
            Info($"{Com.PortName} {Com.BaudRate} {Com.IsOpen} Open!");
            return true;
        }

        public void Close()
        {
            if (Com != null && Com.IsOpen)
            {
                Info($"{Com.PortName} {Com.BaudRate} Close!");
                Com.Close();
                Com.Dispose();
                Com = null;
                _isInit = false;
            }
        }

        public bool Send(byte[] data)
        {
            lock (_sync)
            {
                if (!_isInit)
                {
                    Error(ToString() + "Not Open!");
                    return false;
                }

                try
                {
                    if (Com != null && Com.IsOpen)
                    {
                        Com.Write(data, 0, data.Length);
                        Debug("Send:" + data.HexString());
                    }
                    else
                    {
                        Error("Send Fail:" + data.HexString());
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Error(ex.ToString());
                    return false;
                }

                return true;
            }
        }

        public byte[] Recv()
        {
            if (!_isInit)
            {
                Error(ToString() + "Not Open!");
                return null;
            }

            if (Com != null && Com.IsOpen)
            {
                byte[] buffer = new byte[Com.BytesToRead];
                Com.Read(buffer, 0, buffer.Length);
                Debug("Recv:" + buffer.HexString());
                return buffer;
            }
            Error("Recv Fail!");
            return null;
        }

        public byte[] Recv(int len)
        {
            if (!_isInit)
            {
                Error(ToString() + "Not Open!");
                return null;
            }

            if (Com != null && Com.IsOpen)
            {
                int i = 0;
                while (Com.BytesToRead < len && i++ < 10)
                {
                    Thread.Sleep(100);
                }

                if (Com.BytesToRead >= len)
                {
                    byte[] buffer = new byte[len];
                    Com.Read(buffer, 0, buffer.Length);
                    Debug("Recv:" + buffer.HexString());
                    return buffer;
                }
            }
            Error("Recv Fail!");
            return null;
        }

        public override string ToString()
        {
            if (_isInit)
            {
                return $"Com: {Com.PortName} Baudrate: {Com.BaudRate}";
            }
            return "Com: NULL";
        }
    }


    public class SerialportMasterSimulateObject : LogEventObject
    {
        private bool _isInit = false;
        private readonly object _sync = new object();

        private string _name;
        private int _baudrate;
        private int _databits;
        private StopBits _stopbits;

        #region open close

        public void Open(string name, int baudrate, int databits = 8, StopBits stopbits = StopBits.One,
            Parity parity = Parity.None)
        {
            _isInit = true;
            this._name = name;
            this._baudrate = baudrate;
            this._databits = databits;
            this._stopbits = stopbits;

            Info($"ComSimulate Open {name} {baudrate} {databits} {stopbits}");
        }

        public void Close()
        {
            _isInit = false;
            Info($"ComSimulate Close {_name} {_baudrate} {_databits} {_stopbits}");
        }

        #endregion

        #region communication

        public void Send(byte[] data)
        {
            lock (_sync)
            {
                if (!_isInit)
                {
                    Error(ToString() + "Not Open!");
                    return;
                }

                Debug("ComSimulate Send:" + data.HexString());
            }
        }

        public byte[] Recv(byte[] recvSim = null)
        {
            if (!_isInit)
            {
                Error(ToString() + "Not Open!");
                return null;
            }

            if (recvSim == null)
            {
                byte[] buffer = Encoding.ASCII.GetBytes("ComSimulate Recv\r\n");

                Debug("ComSimulate Recv: ");
                return buffer;
            }
            else
            {
                Debug("ComSimulate Recv:" + recvSim.HexString());
                return recvSim;
            }
        }

        #endregion

        public override string ToString()
        {
            if (_isInit)
            {
                return $"ComSimulate: {_name} Baudrate: {_baudrate}";
            }
            return "ComSimulate: NULL";
        }
    }
}