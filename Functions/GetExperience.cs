using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
namespace portfolioapi.Functions
{
    public class GetExperience
    {

        private readonly PortfolioContext _context;

        public GetExperience(PortfolioContext context)
        {
            _context = context;
        }
        [FunctionName("GetExperience")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "experience")] HttpRequest req,
            ILogger log)
        {
            var experiences = await _context.Experiences.ToListAsync();
            return new OkObjectResult(experiences);
        }
    }
    
}
