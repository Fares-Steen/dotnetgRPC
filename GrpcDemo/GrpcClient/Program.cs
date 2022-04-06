// See https://aka.ms/new-console-template for more information


using Grpc.Net.Client;
using GrpcServer;

var input = new HelloRequest {Name = "Fares"};

var channel = GrpcChannel.ForAddress("http://localhost:5054");
var client = new Greeter.GreeterClient(channel);

var reply = await client.SayHelloAsync(input);

Console.WriteLine(reply.Message);
Console.ReadLine();