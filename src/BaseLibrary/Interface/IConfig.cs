using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser.Model;

namespace BaseLibrary.Interface
{
    interface IConfig
    {
        void LoadConfigData(IniData data);

        IniData GetConfigDAta();



        void LoadConfig(object config);

        object GetConfig();

    }
}
