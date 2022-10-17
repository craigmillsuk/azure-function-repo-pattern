using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<Customer> SaveNewCustomer(Customer customer);
    }
}
