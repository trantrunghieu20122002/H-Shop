using ECommerceMVCWeb.Data;
using ECommerceMVCWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVCWeb.ViewComponents
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        private readonly Hshop2025Context db;
        public MenuLoaiViewComponent(Hshop2025Context context) => db = context;
        public IViewComponentResult Invoke()
        {
            var data = db.Loais.Select(lo => new MenuLoaiVM
            {
                MaLoai = lo.MaLoai,
                TenLoai = lo.TenLoai, 
                SoLuong = lo.HangHoas.Count
            }).OrderBy(p => p.TenLoai);
            return View(data); //Default.schtml
        }
        
    }
}
