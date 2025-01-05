using System.ComponentModel.DataAnnotations;

namespace Trier_3.Dtos
{
    public class RoleDto
    {
        [Required]
        public string RoleName { get; set; }
    }
}
