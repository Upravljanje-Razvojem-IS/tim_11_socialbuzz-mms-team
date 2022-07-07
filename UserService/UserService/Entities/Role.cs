using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserService.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }


    }
}
