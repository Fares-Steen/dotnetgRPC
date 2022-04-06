using Grpc.Core;

namespace GrpcServer.Services;

public class CustomersService:Customer.CustomerBase
{
    private readonly ILogger<CustomersService> _logger;
    public CustomersService(ILogger<CustomersService> logger)
    {
        _logger = logger;
    }

    public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
    {
        CustomerModel output = new CustomerModel();

        if (request.UserId == 1)
        {
            output.FirstName="Fares";
            output.LastName = "Steen";
        }
        else if (request.UserId == 2)
        {
            output.FirstName = "Reema";
            output.LastName = "Steen";
        }
        else
        {
            output.FirstName = "Fadi";
            output.LastName = "Saibah";
        }

        return Task.FromResult(output);
    }

    public override  async Task GetNewCustomers(
        NewCustomerRequest request,
        IServerStreamWriter<CustomerModel> responseStream,
        ServerCallContext context)
    {
        List<CustomerModel> customers=new List<CustomerModel>{
            new CustomerModel
            {
                FirstName = "Fares",
                LastName = "Steen",
                EmailAddress = "f.steen@me.com",
                IsActive = true,
                Age = 40
            },
            new CustomerModel
            {
                FirstName = "Reema",
                LastName = "Steen",
                EmailAddress = "r.steen@me.com",
                IsActive = false,
                Age = 50
            },
            new CustomerModel
            {
                FirstName = "Fadi",
                LastName = "Saibah",
                EmailAddress = "f.saibah@me.com",
                IsActive = true,
                Age = 15
            }
        };

        foreach (var customer in customers)
        {
            await responseStream.WriteAsync(customer);
        }
    }
}