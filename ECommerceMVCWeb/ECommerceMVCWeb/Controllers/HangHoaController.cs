﻿using ECommerceMVCWeb.Data;
using ECommerceMVCWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVCWeb.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly Hshop2025Context db;

        public HangHoaController(Hshop2025Context context) {
            db = context;
        }
        public IActionResult Index(int? loai)
        {
            var hangHoas = db.HangHoas.AsQueryable();
            if (loai.HasValue) {
                hangHoas = hangHoas.Where(p=>p.MaLoai == loai.Value );
            }
            var result = hangHoas.Select(p => new HangHoaVM
            {
                MaHh = p.MaHh,
                TenHh = p.TenHh,
                DonGia = p.DonGia ?? 0,
                Hinh = p.Hinh ?? "",
                MoTaNgan = p.MoTaDonVi ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai,   
            }); 

            return View(result);
        }

        public IActionResult Search(string? query)
        {
            var hangHoas = db.HangHoas.AsQueryable();
            if (query !=null)
            {
                hangHoas = hangHoas.Where(p => p.TenHh.Contains(query));
            }
            var result = hangHoas.Select(p => new HangHoaVM
            {
                MaHh = p.MaHh,
                TenHh = p.TenHh,
                DonGia = p.DonGia ?? 0,
                Hinh = p.Hinh ?? "",
                MoTaNgan = p.MoTaDonVi ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai,
            });

            return View(result);
        }
    }
}
