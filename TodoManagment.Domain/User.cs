using System.ComponentModel.DataAnnotations;

namespace TodoManagment.Domain
{
    public class User: DbEntity
    {
        //public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<TodoTask>? Tasks { get; set; }

    }

    public class DbEntity
    {
        public int Id { get; set; }
    }
}
