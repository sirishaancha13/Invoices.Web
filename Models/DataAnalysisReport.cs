using System.Collections.Generic;

namespace Invoices.web.Models
{
    public class DataAnalysisReport
    {
        public List<Invoice> Invoices { get; set; }
        public bool HealthStatus { get; set; }
        public decimal TotalOutstandingAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
