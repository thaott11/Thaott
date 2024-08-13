using Shoe_Store.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Shoe_Store.Models
{
    public class NhaCungCap
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TenNhaCungCap { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public ICollection<SanPham> SanPhams { get; set; }
    }
}
