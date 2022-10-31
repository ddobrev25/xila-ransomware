using System.Security.Cryptography;
using System.Text;
using xila_2._0;


ApiCallService apiCallService = new ApiCallService();

Console.ReadKey();
while (true)
{
    Console.WriteLine(apiCallService.GetKey());
    Console.ReadKey();
}

Console.WriteLine(Environment.UserDomainName);
Console.ReadKey();


