using platforma_1._0.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace platforma_1._0.Analyse
{
    class ParserSettings : IParserSettings
    {
        public ParserSettings()
        {

        }

        public ParserSettings(string url)
        {
            BaseUrl = url;
        }
        public string BaseUrl { get; set; } = "http://ufaschool1.ru/svedeniya-ob-oo/struktura-i-organy-upravleniya-oo";
        //public string BaseUrl { get; set; } = "http://www.school-77.ru/index/svedenija_ob_obrazovatelnoj_organizacii/0-198";
        //public string BaseUrl { get; set; } = "https://school32.centerstart.ru";
        public string Prefix { get; set; } = "";
    }
}
