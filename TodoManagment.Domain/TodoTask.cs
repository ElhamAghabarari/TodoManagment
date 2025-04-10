using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TodoManagment.Domain
{
    public class TodoTask: DbEntity
    {
        [Required(AllowEmptyStrings =false)]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime createTime { get; set; }
        public TaskStatusEnum Status { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
