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
}