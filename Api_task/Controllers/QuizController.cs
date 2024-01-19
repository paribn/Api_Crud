// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Api_task.Data;
using Api_task.Dtos.Quiz;
using Api_task.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_task.Controllers
{
    [Authorize]
    public class QuizController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public QuizController(AppDbContext appDbContext, IMapper mapper)
        {
            _context = appDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public IActionResult Get()
        {
            var quiz = _context.Quizzes
                .Select(x => _mapper.Map(x, new QuizGetDto()))
                .AsNoTracking()
                .ToList();
            return Ok(quiz);
        }

        // GET api/<QuizController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetById(int id)
        {
            var quiz = _context.Quizzes
                .Include(q => q.Questions)
                    .ThenInclude(q => q.Options)
                .FirstOrDefault(q => q.Id == id);

            if (quiz == null)
            {
                return NotFound("Quiz was not found");
            }

            var quizDto = _mapper.Map<QuizDetailedGetDto>(quiz);

            return Ok(quizDto);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] QuizPostDto quizPostDto)
        {
            var quiz = _mapper.Map<Quiz>(quizPostDto);

            _context.Quizzes.Add(quiz); // add dbset
            _context.SaveChanges();


            foreach (var questionDto in quizPostDto.Questions)
            {
                var question = _mapper.Map<Question>(questionDto);
                quiz.Questions.Add(question);

                foreach (var optionDto in questionDto.Options)
                {
                    var option = _mapper.Map<Option>(optionDto);
                    question.Options.Add(option);
                }
            }

            return Ok(quiz.Id);
        }


        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, [FromBody] QuizPutDto dto)
        {

            var quiz = _context.Quizzes.FirstOrDefault(x => x.Id == id);
            if (quiz is null) return NotFound();

            _mapper.Map(dto, quiz);

            _context.SaveChanges();
            return Ok(quiz.Id);
        }

        //// DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var quiz = _context.Quizzes.Include(q => q.Questions).ThenInclude(q => q.Options)
                              .FirstOrDefault(x => x.Id == id);

            if (quiz == null)
            {
                return NotFound("was not found");
            }

            // Remove associated questions and options
            foreach (var question in quiz.Questions)
            {
                _context.Options.RemoveRange(question.Options);
            }

            _context.Questions.RemoveRange(quiz.Questions);

            // Remove the quiz itself
            _context.Remove(quiz);

            _context.SaveChanges();

            return Ok();
        }
    }
}
