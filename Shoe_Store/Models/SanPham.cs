using System.ComponentModel.DataAnnotations;

namespace Shoe_Store.Models
{
    public class SanPham
    {
        [Key]
        public int SanPhamId { get; set; }
        [Required]
        public string Ten { get; set; }
        [Required]
        public decimal Gia { get; set; }
        [Required]
        public string MoTa { get; set; }
        [Required]
        public int SoLuong { get; set; }
        [Required]
        public string MauSac { get; set; }
        [Required]
        public string NhaSanXuat { get; set; }
        [Required]
        public byte[] HinhAnh { get; set; }
        public ICollection<AnhChiTiet> SanPhamAnhChiTiets { get; set; }
        public ICollection<Loai> Loais { get; set; }
        public ICollection<DanhGia> DanhGias { get; set; }
        public int NhaCungCapId { get; set; }
        public NhaCungCap NhaCungCap { get; set; }
        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public ICollection<SanPhamSize> sanPhamSizes { get; set; }
    }

}
