using Api_task.Dtos.Option;
using Api_task.Dtos.Qeustion;
using Api_task.Dtos.Quiz;
using Api_task.Entities;
using AutoMapper;

namespace Api_task.AutoMapper
{
    public class QuizProfile : Profile
    {
        public QuizProfile()
        {

            ///get
            CreateMap<Quiz, QuizGetDto>().ReverseMap();

            // getId

            CreateMap<Quiz, QuizDetailedGetDto>()
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions));
            CreateMap<Question, QuestionGetDto>();
            CreateMap<Option, OptionGetDto>();


            ////Post
            CreateMap<QuizPostDto, Quiz>();
            CreateMap<QuestionPostDto, Question>();
            CreateMap<OptionPostDto, Option>();


            //Put
            CreateMap<QuizPutDto, Quiz>();

            //other
            CreateMap<QuestionPutDto, Question>();
            CreateMap<OptionPutDto, Option>();
        }
    }
}
