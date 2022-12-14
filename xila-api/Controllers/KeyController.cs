using Microsoft.AspNetCore.Mvc;
using xila_api.Models.Db;

namespace xila_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KeyController : ControllerBase
    {
        private XilaDbContext _dbContext;
        public KeyController(XilaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public string GenerateKey(string envUsername, string ipAddress)
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

            GeneratedKeyRecord generatedKeyRecord = new GeneratedKeyRecord()
            {
                Key = key,
                TimeGenerated = DateTime.UtcNow,
                DesktopUsername = envUsername,
                IpAddress = ipAddress
            };

            _dbContext.GeneratedKeyRecords.Add(generatedKeyRecord);
            _dbContext.SaveChanges();

            return key;
        }
    }
}
