using System;
using System.Linq;

namespace BaseLibrary.CsvValue
{
    public interface ICsvValue
    {
        void Clear();
        string CsvHeaders();
        string CsvValues();
    }


    public class CsvValueObject : ICsvValue
    {
        public virtual void Clear()
        {
            //todo
            //GetType().GetFields().Select(f => f.SetValue(this, ));
        }

        public string CsvHeaders(string appendix)
        {
            return string.Join(",", GetType().GetFields().Select(f => $"{f.Name}{appendix}"));
        }

        public string CsvHeaders()
        {
            return string.Join(",", GetType().GetFields().Select(f => f.Name));
        }

        public string CsvValues()
        {
            //boxing all fields
            return string.Join(",", GetType().GetFields().Select(f => f.GetValue(this).ToString()));
        }

        public override string ToString()
        {
            return string.Join("\r\n", GetType().GetFields().Select(f => $"{f.Name}:{f.GetValue(this)}"));
        }
    }
}