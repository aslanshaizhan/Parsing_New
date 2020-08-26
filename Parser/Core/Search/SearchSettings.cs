using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core.Search
{
    class SearchSettings : IParserSettings
    {
        public SearchSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }

        public string BaseUrl { get; set; } = "https://qamqor.gov.kz/portal/page/portal/POPageGroup/Services/SuRet?_piref36_264068_36_223091_223091.__ora_navigState=search%3Dgallery%26eventSubmit_doSearch%3D%25D0%259F%25D0%25BE%25D0%25BA%25D0%25B0%25D0%25B7%25D0%25B0%25D1%2582%25D1%258C%26obl%3D19%26sureg%3D-1%26ret_type%3D2&_piref36_264068_36_223091_223091.__ora_navigValues=";

        public string Prefix { get; set; } = "page{CurrentId}";

        public int StartPoint { get; set; }

        public int EndPoint { get; set; }
    }
}
