using Microsoft.AspNetCore.Mvc;

namespace xila_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KeyController : ControllerBase
    {
        [HttpGet]
        public string GenerateKey()
        {
            char[] symbols = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
                'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y',
                'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I','J', 'K', 'L', 'M', 'N', 'O',
                'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4',
                '5', '6', '7', '8', '9', '!', '@', '#', '$', '%', '^', '&', '*' };

            string key = string.Empty;

            Random r = new Random();

            for(int i = 1; i <= 8; i++)
                key += symbols[r.Next(0, symbols.Length - 1)];

            return key;
        }
    }
}
