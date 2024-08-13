using System.ComponentModel.DataAnnotations;

namespace Shoe_Store.Models
{
    public class SanPhamSize
    {
        [Key]
        public int SizeId { get; set; }
        [Required]
        public string Size { get; set; }
        public int SanPhamId { get; set; }
        public SanPham SanPham { get; set; }
    }
}
