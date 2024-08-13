using System.ComponentModel.DataAnnotations;

namespace Shoe_Store.Models
{
    public class DanhGia
    {
        [Key]
        public int Id { get; set; }
        public int Diem { get; set; }
        [MaxLength(1000)]
        public string BinhLuan { get; set; }
        public int NguoiDungId { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public int SanPhamId { get; set; }
        public SanPham SanPham { get; set; }
    }



}
