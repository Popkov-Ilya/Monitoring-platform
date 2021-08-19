using AngleSharp.Html.Dom;
using platforma_1._0.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace platforma_1._0.Analyse
{
    class Parser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            int persent = 0;
            string[] static_list = new string[]
            {
                @"Основные.*сведения",
                @"Структура.*и.*органы.*управления.*образовательной.*организацией",
                @"Документы",
                @"Образование",
                @"Руководство..*Педагогический.*\(.*научно.*-.*педагогический.*\).*состав",
                @"Материально.*-.*техническое.*обеспечение.*и.*оснащенность.*образовательного.*процесса",
                @"Платные.*образовательные.*услуги",
                @"Финансово.*-.*хозяйственная.*деятельность",
                @"Вакантные.*места.*для.*приема.*\(.*перевода.*\).*обучающихся",
                @"Доступная.*среда",
                @"Международное.*сотрудничество"
            };
            var list = new List<string>();
            var items = document.QuerySelectorAll("a").Where(item => item.TextContent != "");
            foreach (string slovo in static_list)
            {
                string slovo2 = slovo.Replace(".*", " ").Replace(@"\", "").Replace(" - ", "-").Replace(" (", "(").Replace(") ", ")");
                foreach (var item in items)
                {
                    Match m = Regex.Match(item.TextContent, $"{slovo}",  RegexOptions.IgnoreCase);
                    
                    if (m.Success && !list.Contains($"{slovo2} - есть"))
                    {
                        list.Add($"{slovo2} - есть");
                        persent += 9;
                    }
                }
                if (!list.Contains($"{slovo2} - есть"))
                {
                    list.Add($"{slovo2} - нет");
                }
                

            }
            if (persent == 99) persent = 100;
            list.Add($"Процент выполнения требований = {persent}%");
            return list.ToArray();

        }
    }
}
