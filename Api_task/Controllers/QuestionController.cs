using Api_task.Data;
using Api_task.Dtos.Qeustion;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_task.Controllers
{
    [Authorize]
    public class QuestionController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public QuestionController(AppDbContext appDbContext, IMapper mapper)
        {
            _context = appDbContext;
            _mapper = mapper;
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, [FromBody] QuestionPutDto dto)
        {

            var question = _context.Questions.FirstOrDefault(x => x.Id == id);
            if (question is null) return NotFound("was not found");

            _mapper.Map(dto, question);

            _context.SaveChanges();
            return Ok(question.Id);
        }

    }
}
