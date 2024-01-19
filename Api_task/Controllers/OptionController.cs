using Api_task.Data;
using Api_task.Dtos.Option;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_task.Controllers
{
    [Authorize]
    public class OptionController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OptionController(AppDbContext appDbContext, IMapper mapper)
        {
            _context = appDbContext;
            _mapper = mapper;
        }



        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, [FromBody] OptionPutDto dto)
        {

            var option = _context.Options.FirstOrDefault(x => x.Id == id);
            if (option is null) return NotFound("was not found");

            _mapper.Map(dto, option);

            _context.SaveChanges();
            return Ok(option.Id);
        }


    }
}
