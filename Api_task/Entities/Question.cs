namespace Api_task.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Points { get; set; }
        public int QuizId { get; set; }
        public Quiz quiz { get; set; }

        public ICollection<Option> Options { get; set; }
    }
}
