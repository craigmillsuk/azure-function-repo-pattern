using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace NewCustomer
{
    public class NewCustomer
    {
        private readonly ICustomerRepository _customerRepository;

        public NewCustomer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string firstName = req.Query["firstName"];
            string lastName = req.Query["lastName"];
            string age = req.Query["age"];

            Customer customerModel = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = Convert.ToInt32(age)
            };

            var response = _customerRepository.SaveNewCustomer(customerModel);

            return new OkObjectResult(response);
        }
    }
}
