using System.ComponentModel.DataAnnotations;

namespace Shoe_Store.Models
{
    public class ChiTietDonHang
    {
        [Key]
        public int Id { get; set; }
        public int DonHangId { get; set; }
        public DonHang DonHang { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }
        public int SanPhamId { get; set; }
        public SanPham SanPham { get; set; }
    }
}
