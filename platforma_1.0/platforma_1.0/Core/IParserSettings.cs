﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace platforma_1._0.Core
{
    interface IParserSettings
    {
        string BaseUrl { get; set; }
        string Prefix { get; set; }
    }
}
