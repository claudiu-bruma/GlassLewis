using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyServices
{
    public class CompanyDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Exchange { get; set; }
        public string StockTicker { get; set; }
        public string Isin { get; set; }
        public string  Website { get; set; }
    }
}
