using Invoices.web.Models;
using Invoices.web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.web.Controllers
{
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("[action]")]
        public DataAnalysisReport GetInvoices()
        {
            return _invoiceService.GetLatestDataAnalysisReport("Test Customer");
        }
    }
}
