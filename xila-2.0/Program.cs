using xila_2._0;

ApiCallService apiCallService = new ApiCallService();
while (true)
{
    Console.WriteLine(apiCallService.GetKey());
    Console.ReadKey();
}

Console.WriteLine(Environment.UserDomainName);
Console.ReadKey();
