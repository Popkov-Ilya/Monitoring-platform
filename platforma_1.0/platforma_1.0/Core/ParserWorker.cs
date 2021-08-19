using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace platforma_1._0.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;
        bool isActive;
        HtmlLoader loader;

        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;


        public IParser<T> Parser
        {
            get 
            { 
                return parser; 
            }
            set
            {
                parser = value;
            }
        }
        public IParserSettings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }
        public bool IsActive
        {
            get => isActive;
        }

        public ParserWorker(IParser<T> parser) 
        {
            this.parser = parser;
        }
        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) :this(parser)
        {
            this.parserSettings = parserSettings;
        }
        
        public void Start()
        {
            isActive = true;
            Worker();
        }
        public void Abort()
        {
            isActive = false;
        }

        private async void Worker()
        {
            if (!isActive)
            {
                OnCompleted?.Invoke(this);
                return;
            }
            var source = await loader.GetSourceByPage();
            var domParser = new HtmlParser();
            var document = await domParser.ParseDocumentAsync(source);

            var result = parser.Parse(document);
            OnNewData?.Invoke(this, result);
            OnCompleted?.Invoke(this);
            isActive = false;
        }
    }
}
