using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using portfolioapi.Models;

namespace portfolioapi.Functions
{
    public class GetProjectById
    {

        private readonly PortfolioContext _context;

        public GetProjectById(PortfolioContext context)
        {
            _context = context;
        }

        [FunctionName("GetProjectById")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "project/{Id}")] HttpRequest req, int Id,
            ILogger log)
        {
            var project = await _context.Projects
                            .Include(p => p.Tags)
                            .ThenInclude(pt => pt.PTag)
                            .FirstOrDefaultAsync(p => p.Id == Id);

            if (project == null)
            {
                return new NotFoundObjectResult("Project not found");
            }

            var result = new
            {
                id = project.Id,
                name = project.Name,
                developers = project.Developers,
                year = project.Year,
                summary = project.Summary,
                description = project.Description,
                projectLink = project.ProjectLink,
                pictures = project.Pictures.Split(','),
                tags = project.Tags.Select(t => new
                {
                    id = t.PTag.Id,
                    key = t.PTag.Key,
                    color = t.PTag.Color,
                    icon = t.PTag.Icon,
                    type = t.PTag.Type
                }).ToList()
            };

            var jsonResult = new ContentResult
            {
                Content = JsonConvert.SerializeObject(result),
                ContentType = "application/json",
                StatusCode = 200
            };

            return jsonResult;
        }
    }



}
