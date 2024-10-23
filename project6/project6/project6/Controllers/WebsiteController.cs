using Microsoft.AspNetCore.Mvc;
using project6.Models;

namespace project6.Controllers
{
    public class WebsiteController : Controller
    {
        public AppDbContext _context;
        public WebsiteController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.slider.ToList();
            var data1 = _context.Category.Where(x => x.visiblestatus == true).ToList();

            var alldata = new HomePage
            {
                slider = data,
                Category = data1
            };
            return View(alldata);
        }
        public IActionResult Shop()
        {
            return View();
        }
        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminLogin(string email, string password)
        {
            var data = _context.AdminLogin.FirstOrDefault(x => x.email == email && x.password == password);
            if (data != null)
            {
                HttpContext.Session.SetString("admin", email);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                TempData["msg"] = "Email or Password is not Matched";
                return RedirectToAction("AdminLogin");
            }
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var data = _context.register.FirstOrDefault(x => x.email == email && x.password == password);
            if (data != null)
            {
                HttpContext.Session.SetString("email", email);
                return RedirectToAction("Index", "Website");
            }
            else
            {
                TempData["msg"] = "Email or password is incorrect";
                return RedirectToAction("Login");
            }
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Products(int id)
        {
            var data = _context.product.Where(x => x.cid == id).ToList();
            return View(data);
        }


        public IActionResult register()
        {
            return View();


        }

        [HttpPost]


        public IActionResult SaveRegister(register r)
        {
            _context.register.Add(r);
            _context.SaveChanges();
            TempData["alert"] = "Registration_Success";
            TempData["username"] = r.name;
            TempData["Loginstatus"] = "true";

            return RedirectToAction("register");
        }


        public IActionResult AddToCard()
        {
            return View();
        }


        public IActionResult ViewDetails()
        {
            return View();
        }


      
    }
}


