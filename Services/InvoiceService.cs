using Invoices.web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Invoices.web.Services
{
    public interface IInvoiceService
    {
        DataAnalysisReport GetLatestDataAnalysisReport(string customerName);
    }

    public class InvoiceService : IInvoiceService
    {
        private readonly IDataService _dataService;

        public InvoiceService(IDataService dataService)
        {
            _dataService = dataService;
        }
        public DataAnalysisReport GetLatestDataAnalysisReport(string customerName)
        {
            var invoices = GetInvoices(customerName);
            var totalOutstandingAmount = invoices.Sum(s => s.OutstandingAmount);
            var totalAmount = invoices.Sum(s => s.Amount);
            var healthStatus = totalAmount > 100000 && !invoices.Any(s => s.IsIssueDateOld);

            _dataService.SaveHealthStatus(customerName, healthStatus);

            return new DataAnalysisReport
            {
                Invoices = invoices.OrderByDescending(s => s.IssueDate).ToList(),
                TotalOutstandingAmount = totalOutstandingAmount,
                TotalAmount = totalAmount,
                HealthStatus = healthStatus
            };
        }

        private IEnumerable<Invoice> GetInvoices(string customerName)
        {
            //returning mock data 
            string jsonString = null;
            var rnd = new Random();
            var path = $"Data/InvoiceData{rnd.Next(1,5)}.json";
            using (var sr = new StreamReader(path))
            {
               jsonString = sr.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<IEnumerable<Invoice>>(jsonString);
        }
    }
}
