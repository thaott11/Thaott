using Shoe_Store.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoe_Store.Models
{
    public class NguoiDung
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TenNguoiDung { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public ICollection<DonHang> DonHangs { get; set; }
        public ICollection<DanhGia> DanhGias { get; set; }
    }

}