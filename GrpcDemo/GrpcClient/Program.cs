// See https://aka.ms/new-console-template for more information


using Grpc.Net.Client;
using GrpcServer;

// var input = new HelloRequest {Name = "Fares"};
//
// var channel = GrpcChannel.ForAddress("http://localhost:5054");
// var client = new Greeter.GreeterClient(channel);
//
// var reply = await client.SayHelloAsync(input);
//
// Console.WriteLine(reply.Message);


var input = new CustomerLookupModel
{
    UserId = 1
};
var channel=GrpcChannel.ForAddress("http://localhost:5054");
var customerClient=new Customer.CustomerClient(channel);

var reply = await customerClient.GetCustomerInfoAsync(input);
Console.WriteLine($"{reply.FirstName} {reply.LastName}");


using (var call=customerClient.GetNewCustomers(new NewCustomerRequest()))
{
    while (await call.ResponseStream.MoveNext(CancellationToken.None))
    {
        var currentCustomer = call.ResponseStream.Current;
        Console.WriteLine($"{currentCustomer.FirstName} {currentCustomer.LastName} {currentCustomer.EmailAddress}");
    }
}



Console.ReadLine();