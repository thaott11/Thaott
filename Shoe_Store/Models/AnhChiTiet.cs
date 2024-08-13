using System.ComponentModel.DataAnnotations;

namespace Shoe_Store.Models
{
    public class AnhChiTiet
    {
        [Key]
        public int ChiTietId { get; set; }
        public byte[] HinhAnh { get; set; } 
        public int SanPhamId { get; set; } 
        public SanPham SanPham { get; set; } 
    }
}
