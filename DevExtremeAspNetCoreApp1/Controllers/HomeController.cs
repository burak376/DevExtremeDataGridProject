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
        /// <returns>mal kodu veya ad�na g�re ba�lang�� ve biti� tarihleri aras�ndaki datay� d�ner</returns>
        public IActionResult Index(string malKodu, DateTime baslangicTarihi,DateTime bitisTarihi)
        {
            //malKodu = "10086 S�EMENS";
            //baslangicTarihi = "2016-01-25 00:00:00";
            //baslangicTarihi = "2017-01-25 00:00:00";
            var basTar = Convert.ToInt32((baslangicTarihi).ToOADate());
            var bitisTar = Convert.ToInt32((bitisTarihi).ToOADate());
            var list = _context?.DataLists?.FromSqlInterpolated($"GetStokValues {malKodu},{basTar},{bitisTar}").ToList();
            return View(list);
        }
        /// <summary>
        /// mal kodu ve ad� Select2 i�erisine bind eder
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
