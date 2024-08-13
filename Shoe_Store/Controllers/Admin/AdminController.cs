using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shoe_Store.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe_Store.Controllers
{
    public class AdminController : Controller
    {
        private readonly Shoe_Store_DbContext _db;

        public AdminController(Shoe_Store_DbContext db)
        {
            _db = db;
        }

        public IActionResult ListSanPham()
        {
            var sanPhams = _db.SanPhams.ToList();
            return View(sanPhams);
        }

        // thêm sản phẩm
        public IActionResult AddSanPham()
        {
            var loais = _db.Loais.ToList();
            ViewBag.Loai = new SelectList(loais, "Id", "TenLoai");
            ViewBag.NhaCungCap = new SelectList(_db.NhaCungCaps.ToList(), "Id", "TenNhaCungCap");
            return View();
        }

        [HttpPost]
        public IActionResult AddSanPham(SanPham sanPham, IFormFile HinhAnh, IFormFile[] HinhAnhPhu)
        {

            // Xử lý ảnh chính
            if (HinhAnh != null && HinhAnh.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    HinhAnh.CopyTo(ms);
                    sanPham.HinhAnh = ms.ToArray();
                }
            }

            // Xử lý ảnh phụ
            if (HinhAnhPhu != null && HinhAnhPhu.Length > 0)
            {
                sanPham.SanPhamAnhChiTiets = new List<AnhChiTiet>();
                foreach (var file in HinhAnhPhu)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var anhChiTiet = new AnhChiTiet { HinhAnh = ms.ToArray() };
                        sanPham.SanPhamAnhChiTiets.Add(anhChiTiet);
                    }
                }
            }
            _db.SanPhams.Add(sanPham);
            _db.SaveChanges();

            return RedirectToAction("ListSanPham");

        }


        [HttpPost]
        public IActionResult AddNhaCungcap(NhaCungCap nhaCungCap)
        {
            _db.NhaCungCaps.Add(nhaCungCap);
            _db.SaveChanges();
            return RedirectToAction("ListSanPham");
        }


        public IActionResult UpdateSanPham(int id)
        {
            var sanPham = _db.SanPhams.Find(id);
            if (sanPham == null)
                return NotFound();

            ViewBag.NhaCungCap = new SelectList(_db.NhaCungCaps, "Id", "TenNhaCungCap", sanPham.NhaCungCapId);
            return View("ListSanPham");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSanPham(SanPham sp, List<IFormFile> HinhAnh)
        {
            var existingSanPham = await _db.SanPhams.FindAsync(sp.SanPhamId);
            if (existingSanPham == null)
                return NotFound();

            existingSanPham.Ten = sp.Ten;
            existingSanPham.Gia = sp.Gia;
            existingSanPham.MoTa = sp.MoTa;
            existingSanPham.SoLuong = sp.SoLuong;
            existingSanPham.MauSac = sp.MauSac;
            existingSanPham.NhaSanXuat = sp.NhaSanXuat;
            existingSanPham.NhaCungCapId = sp.NhaCungCapId;

            if (HinhAnh?.Any() == true)
            {
                var item = HinhAnh.First();
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        existingSanPham.HinhAnh = stream.ToArray();
                    }
                }
            }

            _db.SanPhams.Update(existingSanPham);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(ListSanPham));
        }

        public IActionResult RemoveSanPham(int id)
        {
            var sanPham = _db.SanPhams.Find(id);
            if (sanPham == null)
                return NotFound();

            _db.SanPhams.Remove(sanPham);
            _db.SaveChanges();
            return RedirectToAction("ListSanPham");
        }

        public IActionResult AddLoai()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddLoai(Loai loai)
        {
            _db.Loais.Add(loai);
            _db.SaveChanges();
            return RedirectToAction("ListSanPham");
        }
    }
}
