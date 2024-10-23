using Microsoft.AspNetCore.Mvc;
using project6.Models;
using static System.Net.Mime.MediaTypeNames;

namespace project6.Controllers
{
    public class AdminController : Controller
    {
        public AppDbContext _context;
        public IWebHostEnvironment _environment;

        public AdminController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Website");
        }
        public IActionResult Slider()
        {
            if (HttpContext.Session.GetString("admin") == null)
            {
                return RedirectToAction("Index", "Website");
            }
            var data = _context.slider.ToList();

            return View(data);

        }
        [HttpPost]
        public async Task<IActionResult> AddSlider(IFormFile image)
        {
            string folderpath = Path.Combine(_environment.WebRootPath, "slider");
            string filename = image.FileName;
            string filepath = Path.Combine(folderpath, filename);
            var strem = new FileStream(filepath, FileMode.Create);
            await image.CopyToAsync(strem);

            slider s = new slider();
            s.image = filename;
            _context.slider.Add(s);
            _context.SaveChanges();


            return RedirectToAction("Slider");
        }
        public IActionResult DeleteSlider(slider p, int id)
        {
            var data = _context.slider.Find(id);
            _context.slider.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Slider");
        }
        public IActionResult Category()
        {
            var data = _context.Category.ToList();

            return View(data);
        }

        

        public IActionResult CategoryStatus(int id)
        {

            var data = _context.Category.Find(id);
            if (data.visiblestatus == null || data.visiblestatus == false)
            {
                data.visiblestatus = true;

            }
            else
            {
                data.visiblestatus = false;
            }
            _context.Category.Update(data);
            _context.SaveChanges();
            return RedirectToAction("Category");




        }

        [HttpPost]

        public async Task<IActionResult> SaveCategory(string title, string description, IFormFile picture)
        {
            string folderpath = Path.Combine(_environment.WebRootPath, "Category");
            string filename = picture.FileName;
            string filepsth = Path.Combine(folderpath, filename);
            var stream = new FileStream(filepsth, FileMode.Create);
            await picture.CopyToAsync(stream);

            Category c = new Category();
            c.title = title;
            c.description = description;
            c.picture = filename;


            _context.Category.Add(c);
            _context.SaveChanges();
            return RedirectToAction("Category");

        }
        public IActionResult Product()
        {
            ViewBag.categories = _context.Category.ToList();

            var data = _context.product.Where(x => x.deletestatus == null || x.deletestatus == false).ToList();

            return View(data);
        }


        public IActionResult UserSoftDelete(int id)
        {
            var data = _context.product.Find(id);
            data.deletestatus = true;
            _context.product.Update(data);
            _context.SaveChanges();
            return RedirectToAction("Product");

        }

        public IActionResult deletedUser()
        {
            var data = _context.product.Where(x => x.deletestatus == true).ToList();
            return View(data);
        }






        [HttpPost]
        public async Task<IActionResult> SaveProduct(string name, string price, string description, IFormFile image, string cid)
        {
            string folderpath = Path.Combine(_environment.WebRootPath, "product");
            string filename = image.FileName;
            string filepath = Path.Combine(folderpath, filename);
            var stream = new FileStream(filepath, FileMode.Create);
            await image.CopyToAsync(stream);


            product p = new product();
            p.name = name;
            p.price = price;
            p.description = description;
            p.image = filename;
            p.cid = int.Parse(cid);

            _context.product.Add(p);
            _context.SaveChanges();

            return RedirectToAction("product");

        }
        public IActionResult Delete(int id)
        {
            var data = _context.product.Find(id);
            _context.product.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Product");
        }
        public IActionResult DeleteCategory(int id)
        {
            var data = _context.Category.Find(id);
            _context.Category.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Category");
        }



        public IActionResult RestoreUser(int id)
        {
            var data = _context.product.Find(id);
            data.deletestatus = false;
            _context.product.Update(data);
            _context.SaveChanges();
            return RedirectToAction("deletedUser");
        }



        
        public IActionResult Invoice()
        {
            return View();
        }

    }
}
