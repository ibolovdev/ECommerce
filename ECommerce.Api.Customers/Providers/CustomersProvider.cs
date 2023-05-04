﻿using AutoMapper;
using ECommerce.Api.Customers.DB;
using ECommerce.Api.Customers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Customers.Providers
{
     
        public class CustomersProvider : ICutomersProvider
        {
            private readonly CustomersDBContext dbContext;
            private readonly ILogger<CustomersProvider> logger;
            private readonly IMapper mapper;

            public CustomersProvider(CustomersDBContext dbContext, ILogger<CustomersProvider> logger, IMapper mapper)
            {
                this.dbContext = dbContext;
                this.logger = logger;
                this.mapper = mapper;
                SeedData();
            }

            private void SeedData()
            {
                if (!dbContext.Customers.Any())
                {
                    dbContext.Customers.Add(new DB.Customer() { Id = 1, Name = "Jessica Smith", Address = "20 Elm St." });
                    dbContext.Customers.Add(new DB.Customer() { Id = 2, Name = "John Smith", Address = "30 Main St." });
                    dbContext.Customers.Add(new DB.Customer() { Id = 3, Name = "William Johnson", Address = "100 10th St." });
                    dbContext.SaveChanges();
                }
            }

            public async Task<(bool IsSuccess, IEnumerable<Models.Customer> Customers, string ErrorMessage)> GetCustomersAsync()
            {
                try
                {
                    logger?.LogInformation("Querying customers");
                    var customers = await dbContext.Customers.ToListAsync();
                    if (customers != null && customers.Any())
                    {
                        logger?.LogInformation($"{customers.Count} customer(s) found");
                        var result = mapper.Map<IEnumerable<DB.Customer>, IEnumerable<Models.Customer>>(customers);
                        return (true, result, null);
                    }
                    return (false, null, "Not found");
                }
                catch (Exception ex)
                {
                    logger?.LogError(ex.ToString());
                    return (false, null, ex.Message);
                }
            }

            public async Task<(bool IsSuccess, Models.Customer Customer, string ErrorMessage)> GetCustomerAsync(int id)
            {
                try
                {
                    logger?.LogInformation("Querying customers");
                    var customer = await dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
                    if (customer != null)
                    {
                        logger?.LogInformation("Customer found");
                        var result = mapper.Map<DB.Customer, Models.Customer>(customer);
                        return (true, result, null);
                    }
                    return (false, null, "Not found");
                }
                catch (Exception ex)
                {
                    logger?.LogError(ex.ToString());
                    return (false, null, ex.Message);
                }
            }
        }
    
}
