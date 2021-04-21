using System;
using System.Collections.Generic;
using System.Text;

namespace EVDS.Entities
{
    public class CurrencyResponse
    {
        public string SERIE_CODE { get; set; }
        public string DATAGROUP_CODE { get; set; }
        public string SERIE_NAME { get; set; }
        public string SERIE_NAME_ENG { get; set; }
        public string FREQUENCY_STR { get; set; }
        public string DEFAULT_AGG_METHOD_STR { get; set; }
        public string DEFAULT_AGG_METHOD { get; set; }
        public string TAG { get; set; }
        public string TAG_ENG { get; set; }
        public string DATASOURCE { get; set; }
        public string DATASOURCE_ENG { get; set; }
        public string METADATA_LINK { get; set; }
        public string METADATA_LINK_ENG { get; set; }
        public string REV_POL_LINK { get; set; }
        public string REV_POL_LINK_ENG { get; set; }
        public string APP_CHA_LINK { get; set; }
        public string APP_CHA_LINK_ENG { get; set; }
        public string START_DATE { get; set; }
        public string END_DATE { get; set; }

    }
}
