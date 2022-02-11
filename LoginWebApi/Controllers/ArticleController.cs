using LoginWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LoginWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticleController : ControllerBase
    {
        private readonly DataContext _context;

        public ArticleController(DataContext context)
        {
            _context = context;

        }

        [HttpGet(Name ="GetArticles"),AllowAnonymous]
        public async Task<ActionResult<List<Article>>>  Get(int MemberID)
        {
            var Articles=await  _context.Articles.Where(x => x.MemberID == MemberID).ToListAsync();

            return Articles;
        }

        [HttpPost(Name ="Create Article"),Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Article>>> Create(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            return await Get(article.MemberID);
        }


    }
}
