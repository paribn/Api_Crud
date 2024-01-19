namespace Api_task.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        public ICollection<Question> Questions { get; set; }

    }
}
