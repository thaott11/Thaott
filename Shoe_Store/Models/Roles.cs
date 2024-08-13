using System.ComponentModel.DataAnnotations;

namespace Shoe_Store.Models
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
