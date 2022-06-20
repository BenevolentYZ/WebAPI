using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementDomain.Models;
using TaskManagementRepository.IRepository;

namespace TaskManagementSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuoteController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public QuoteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Quote>>> Get()
        {
            return Ok(_unitOfWork.Quote.GetAll());
        }
        [HttpPost]
        public async Task<ActionResult<List<Quote>>> AddQuote(Quote quote)
        {
            _unitOfWork.Quote.Add(quote);
            _unitOfWork.Save();
            return Ok(_unitOfWork.Quote.GetAll());
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> Get(int id)
        {
            var quote = _unitOfWork.Quote.GetFirstOrDefault(q => q.QuoteId == id);
            if (quote == null)
            {
                return BadRequest("Quote Not Found");
            }
            return Ok(quote);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Quote>> Update(int id, Quote request)
        {
            var quote = _unitOfWork.Quote.GetFirstOrDefault(q => q.QuoteId == id);
            if (quote == null)
            {
                return BadRequest("Quote Not Found");
            }
            quote.QuoteType = request.QuoteType;
            quote.Task = request.Task;
            quote.DueDate = request.DueDate;
            quote.Contact = request.Contact;
            quote.TaskType = request.TaskType;

            _unitOfWork.Save();
            return Ok(_unitOfWork.Quote.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Quote>> Delete(int id)
        {
            var quote = _unitOfWork.Quote.GetFirstOrDefault(q => q.QuoteId == id);
            if (quote == null)
            {
                return BadRequest("Quote Not Found");
            }
            _unitOfWork.Quote.Remove(quote);
            _unitOfWork.Save();
            return Ok(_unitOfWork.Quote.GetAll());
        }
    }
}
