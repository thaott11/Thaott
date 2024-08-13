using Shoe_Store.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoe_Store.Models
{
    public class Loai
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Ten { get; set; }
        public ICollection<SanPham> SanPhams { get; set; }
    }

}