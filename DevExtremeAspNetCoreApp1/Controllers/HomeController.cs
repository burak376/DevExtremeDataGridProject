using DevExtremeAspNetCoreApp1.Models.Ef;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevExtremeAspNetCoreApp1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestContext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = new TestContext();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="malKodu"></param>
        /// <param name="baslangicTarihi"></param>
        /// <param name="bitisTarihi"></param>
        /// <returns>mal kodu veya adýna göre baþlangýç ve bitiþ tarihleri arasýndaki datayý döner</returns>
        public IActionResult Index(string malKodu, DateTime baslangicTarihi,DateTime bitisTarihi)
        {
            //malKodu = "10086 SÝEMENS";
            //baslangicTarihi = "2016-01-25 00:00:00";
            //baslangicTarihi = "2017-01-25 00:00:00";
            var basTar = Convert.ToInt32((baslangicTarihi).ToOADate());
            var bitisTar = Convert.ToInt32((bitisTarihi).ToOADate());
            var list = _context?.DataLists?.FromSqlInterpolated($"GetStokValues {malKodu},{basTar},{bitisTar}").ToList();
            return View(list);
        }
        /// <summary>
        /// mal kodu ve adý Select2 içerisine bind eder
        /// </summary>
        /// <returns></returns>
        public List<Stk> GetAllSTK()
        {
            return _context?.Stks.ToList();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
