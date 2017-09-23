using System;
using System.IO;
using System.Text;
using BaseLibrary.Object;
using IniParser;
using IniParser.Model;

namespace BaseLibrary.IniEdit
{
    public class IniObject : LogEventObject
    {
        public IniObject(string filename = "Default.ini")
        {
            IniFile = filename;
        }

        public string IniFile { get; private set; }
        protected IniData Data = new IniData();
        protected FileIniDataParser FileIniDataParser = new FileIniDataParser();

        protected virtual void CreateDefault()
        {
            FileIniDataParser.WriteFile(IniFile, Data, Encoding.UTF8);
            Info($"CreateDefault {IniFile} Finish!");
        }


        public virtual void Load()
        {
            if (!File.Exists(IniFile))
            {
                Error($"Load {IniFile} Error!");
                CreateDefault();
            }

            FileIniDataParser.Parser.Configuration.CommentString = "#";
            Data = FileIniDataParser.ReadFile(IniFile, Encoding.UTF8);

            Info($"Load {IniFile} Finish!");
        }

        public virtual void Save()
        {
            FileIniDataParser.WriteFile(IniFile, Data, Encoding.UTF8);

            Info($"Save {IniFile} Finish!");
        }


        public event Action ReloadEvent;
        public virtual void OnReloadEvent()
        {
            ReloadEvent?.Invoke();
        }
    }
}