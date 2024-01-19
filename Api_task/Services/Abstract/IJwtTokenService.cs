namespace Api_task.Services.Abstract
{
    public interface IJwtTokenService
    {
        public string GenerateToken(string name, string surname, string username, List<string> Roles);

    }
}
