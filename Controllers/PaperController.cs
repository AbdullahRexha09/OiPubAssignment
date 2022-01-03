using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using OiPubAssignment.DTOModels;
using OiPubAssignment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OiPubAssignment.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/v1/paper")]
    [ApiController]
    public class PaperController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        public PaperController(AppDbContext appDbContext) 
        {
            this.appDbContext = appDbContext;
        }

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("")]
        public async Task<IActionResult> AddPaper([FromBody] PaperAuthorDTO paperAuthor) 
        {
      
            var paper = new Paper
            {
                Title = paperAuthor.Title,
                DatePublished = paperAuthor.DatePublished,
                ReferenceCount = paperAuthor.ReferenceCount,
                NumberOfCitations = paperAuthor.NumberOfCitations
            };
            var sPaper = await appDbContext.Paper.AddAsync(paper);
            await appDbContext.SaveChangesAsync();

            var pAuthor = new PaperAuthor 
            {
                PaperId = sPaper.Entity.Id,
                AuthorId = paperAuthor.AuthorId
            };

            await appDbContext.PaperAuthor.AddAsync(pAuthor);
            await appDbContext.SaveChangesAsync();


            return Created("Created", sPaper);
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("")]

        public async Task<IActionResult> GetPapers(int page = 1, int pageSize = 10) 
        {
            var list = appDbContext.Paper.ToList();
            return Ok(list.Skip(page - 1 * pageSize).Take(pageSize).ToList());
        }
    }
}
