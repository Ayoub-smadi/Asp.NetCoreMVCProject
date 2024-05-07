using GG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GG.Controllers
{
    public class Login_RegisterController : Controller
    {
        private readonly ModelContext _context;


        public Login_RegisterController(ModelContext context)
        {
            _context = context;
        }
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> LogIn(User user)
        {
            var log = await _context.Users.Where(x => x.Username == user.Username && x.Password == user.Password).SingleOrDefaultAsync();


            if (log != null)
            {

                switch (log.Roleid)
                {


                    case 1:

                        return RedirectToAction("Index", "Admin");

                    case 2:

                        return RedirectToAction("AboutUs", "Home");

                    case 3:

                        return RedirectToAction("ContactUs", "Home");


                }




            }




            return View();
        }






        [HttpPost]
        public IActionResult Register(User user, string Username, string Password)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(user);
                _context.SaveChanges();

               
                user.Username = Username;
                user.Password = Password;

               
                user.Roleid = 3; 

                _context.SaveChanges();
            }

            return View();
        }








        
    }
}
