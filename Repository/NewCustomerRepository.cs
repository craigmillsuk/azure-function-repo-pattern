using Domain.Interfaces;
using Domain.Models;
using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;

namespace Repository
{
    public class NewCustomerRepository : ICustomerRepository
    {
        private readonly Container _container;
        private const string _databaseName = "CustomerDb";
        private const string _containerName = "Customer";

        public NewCustomerRepository(CosmosClient cosmosDbClient)
        {
            _container = cosmosDbClient.GetContainer(_databaseName, _containerName);
        }

        public async Task<Customer> SaveNewCustomer(Customer customer)
        {
            var response = await _container.UpsertItemAsync(customer);
            return response.Resource;
        }
    }
}
