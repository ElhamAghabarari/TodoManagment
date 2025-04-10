using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoManagment.Api.Dtos
{
    public class UserDtoCreate
    {
        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
    public class UserDtoView: UserDtoCreate
    {
        public int Id { get; set; }
    }
}
