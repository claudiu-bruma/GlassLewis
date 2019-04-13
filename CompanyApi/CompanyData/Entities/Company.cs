using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyData.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Exchange { get; set; }
        public string StockTicker { get; set; }
        public string ISIN { get; set; }
        public string Website { get; set; }

    }
}
