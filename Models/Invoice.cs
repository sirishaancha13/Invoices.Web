using System;

namespace Invoices.web.Models
{
    public class Invoice
    {
        public string CustomerName { get; set; }
        public DateTime IssueDate { get; set; }
        public Decimal Amount { get; set; }
        public Decimal OutstandingAmount { get; set; }
        public bool IsIssueDateOld
        {
            get
            {
                return IssueDate < DateTime.Today.AddDays(-90);
            }
        }
    }
}
