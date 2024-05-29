using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace portfolioapi.Functions
{
    public class GetEducation
    {
        private readonly PortfolioContext _context;

        public GetEducation(PortfolioContext context)
        {
            _context = context;
        }

        [FunctionName("GetEducation")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "education")] HttpRequest req,
            ILogger log)
        {
            var educations = await _context.Educations.ToListAsync();
            return new OkObjectResult(educations);
        }
    }
}
