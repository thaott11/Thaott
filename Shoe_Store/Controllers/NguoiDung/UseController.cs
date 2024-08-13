using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoe_Store.Models;

namespace Shoe_Store.Controllers.NguoiDung
{
    public class UseController : Controller
    {
        private readonly Shoe_Store_DbContext _db;

        public UseController(Shoe_Store_DbContext db)
        {
            this._db = db;
        }
        public IActionResult UseIndex()
        {
            List<SanPham> sanphams = _db.SanPhams.ToList();
            return View(sanphams);
        }

        public IActionResult SanPhamChiTiet(int id)
        {
            var sanpham = _db.SanPhams
                .Include(sp => sp.SanPhamAnhChiTiets)
                .Include(sp => sp.sanPhamSizes)
                .FirstOrDefault(sp => sp.SanPhamId == id);

            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

    }
}
