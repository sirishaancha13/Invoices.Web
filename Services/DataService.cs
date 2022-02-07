namespace Invoices.web.Services
{
    public interface IDataService
    {
        void SaveHealthStatus(string customerName, bool healthStatus);
    }

    public class DataService : IDataService
    {
        public void SaveHealthStatus(string customerName, bool healthStatus)
        {
            //Save Customer Name, health status and today's date
        }
    }
}
