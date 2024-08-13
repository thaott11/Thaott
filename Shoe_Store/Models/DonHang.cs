using System.ComponentModel.DataAnnotations;

namespace Shoe_Store.Models
{
    public class DonHang
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MaDonHang { get; set; }
        public string TenDonHang { get; set; }
        public decimal TongGia { get; set; }
        public DateTime NgayMua { get; set; }
        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public int NguoiDungId { get; set; }
        public NguoiDung NguoiDung { get; set; }
    }


}
