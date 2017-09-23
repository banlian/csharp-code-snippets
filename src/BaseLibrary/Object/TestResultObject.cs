using System;
using System.IO;
using System.Text;
using BaseLibrary.CsvValue;
using BaseLibrary.Extension;

namespace BaseLibrary.Object
{
    public interface ITestResult : ICsvValue
    {
        DateTime StartTime { get; set; }
        DateTime FinishTime { get; set; }
        float CycleTime { get; set; }
        TestResultStatus Status { get; set; }
        string Error { get; set; }

        void UpdateStart();
        void Update();
        void UpdateError(string error);

        void SaveResult(string filename);
        void SaveToCsv(string dir);
    }


    public class TestResultObject : ITestResult
    {
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public float CycleTime { get; set; }

        public TestResultStatus Status { get; set; }
        public string Error { get; set; }

        public string Version { get; set; }

        #region

        public virtual void UpdateStart()
        {
            StartTime = DateTime.Now;
            FinishTime = DateTime.Now;
            Status = TestResultStatus.Pass;
        }

        public virtual void Update()
        {
            FinishTime = DateTime.Now;
            CycleTime = (float)(FinishTime - StartTime).TotalSeconds;
        }

        public virtual void UpdateError(string error)
        {
            Status = TestResultStatus.Fail;
            Error = error;
        }

        #endregion

        #region csv 

        public virtual void Clear()
        {
            Status = TestResultStatus.Pass;

            StartTime = DateTime.MinValue;
            FinishTime = DateTime.MinValue;
            CycleTime = 0;

            Error = string.Empty;
        }

        public virtual string CsvHeaders()
        {
            var sb = new StringBuilder();

            sb.AppendSuffix($"{nameof(StartTime)}");
            sb.AppendSuffix($"{nameof(FinishTime)}");
            sb.AppendSuffix($"{nameof(CycleTime)}");
            sb.AppendSuffix($"{nameof(Status)}");
            sb.AppendSuffix($"{nameof(Error)}");
            sb.Append($"{nameof(Version)}");

            return sb.ToString();
        }

        public virtual string CsvValues()
        {
            var sb = new StringBuilder();

            sb.AppendSuffix($"{StartTime:yyyyMMdd-HHmmss}");
            sb.AppendSuffix($"{FinishTime:yyyyMMdd-HHmmss}");
            sb.AppendSuffix($"{CycleTime:F2}");
            sb.AppendSuffix($"{Status}");
            sb.AppendSuffix($"{Error}");
            sb.Append($"{Version}");

            return sb.ToString();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"StartTime:{StartTime:yyyyMMdd-HHmmss}");
            sb.AppendLine($"FinishTime:{FinishTime:yyyyMMdd-HHmmss}");
            sb.AppendLine($"CycleTime:{CycleTime:F2}");
            sb.AppendLine($"Status:{Status}");
            sb.AppendLine($"Error:{Error}");
            sb.Append($"Version:{Version}");

            return sb.ToString();
        }

        #endregion

        #region save

        public void SaveToSingleDoc(string filename, string dir = @".\Data")
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var dw = new StringDataWriter();
            dw.Open(Path.Combine(dir, filename), Encoding.UTF8);
            dw.WriteLine(CsvValues());
            dw.Close();
        }

        public void SaveResult(string filename)
        {
            if (!File.Exists(filename))
            {
                var dw = new StringDataWriter();
                dw.Open(filename, Encoding.UTF8);
                dw.WriteLine(CsvHeaders());
                dw.WriteLine(CsvValues());
                dw.Close();
            }
            else
            {
                var dw = new StringDataWriter();
                dw.Open(filename, Encoding.UTF8);
                dw.WriteLine(CsvValues());
                dw.Close();
            }
        }

        public void SaveToCsv(string dir = @".\Data")
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            SaveResult(Path.Combine(dir, $"{DateTime.Now.ToString("yyyyMMdd")}.csv"));
        }

        #endregion
    }


    public class TestResultWithSerialObject : TestResultObject
    {
        public long Index;
        public string Serial;


        public override void Clear()
        {
            Index++;
            Serial = string.Empty;
            base.Clear();
        }


        public override string CsvHeaders()
        {
            var sb = new StringBuilder();

            sb.AppendSuffix($"{base.CsvHeaders()}");
            sb.AppendSuffix($"{nameof(Index)}");
            sb.Append($"{nameof(Serial)}");

            return sb.ToString();
        }


        public override string CsvValues()
        {
            var sb = new StringBuilder();

            sb.AppendSuffix($"{base.CsvValues()}");
            sb.AppendSuffix($"{Index}");
            sb.Append($"{Serial}");

            return sb.ToString();
        }


        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine($"{nameof(Index)}:{Index}");
            sb.Append($"{nameof(Serial)}:{Serial}");

            return sb.ToString();
        }
    }


    public enum TestResultStatus
    {
        Pass,
        Fail,
        Null
    }
}