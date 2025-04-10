using System.ComponentModel.DataAnnotations;
using TodoManagment.Domain;

namespace TodoManagment.Api.Dtos
{
    public class TaskDtoCreate
    {
        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(500)]
        public string Description { get; set; }

        public TaskStatusEnum Status { get; set; }
    }

    public class TaskDtoView : TaskDtoCreate
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime createTime { get; set; }
    }
}
