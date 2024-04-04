using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mytask.Data;
using Mytask.Models;

namespace Mytask.Controllers
{
    public class MyUserController : Controller
    {

        private readonly MyDBContext context1;

        public MyUserController(MyDBContext demoDbContext)
        {
            this.context1= demoDbContext;
        }

        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Add(AddUser u)
        {
            var user1 = new User()
            {
                Id = Guid.NewGuid(),
                UserId = u.UserId,
                Name = u.Name,
                Email = u.Email,
                Phone = u.Phone,
                Address = u.Address,
                Salary = u.Salary,
                CreatedDate = u.CreatedDate,
                Department = u.Department,
                Description = u.Description

            };

            await context1.Users.AddAsync(user1);
            await context1.SaveChangesAsync();
            return RedirectToAction("Add");
        }





        public async Task<IActionResult> Index()
        {

            var u1 = await context1.Users.ToListAsync();
            return View(u1);
        }

        [HttpGet]
        public IActionResult DisplayById()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>DisplayById(int uid,string sub)
        {
            if(sub=="Display")
            {
                var userdata=await context1.Users.FirstOrDefaultAsync(x=>x.UserId==uid);
                return View(userdata);
            }
            else if(sub=="Delete")
            {
                var userdata= await context1.Users.FirstOrDefaultAsync(x=> x.UserId==uid);
                if(userdata!=null)
                {
                    context1.Users.Remove(userdata);
                    await context1.SaveChangesAsync();
                    return RedirectToAction("DisplayById");
                }
                return View();
            }
            else
            {
                var userdata = await context1.Users.FirstOrDefaultAsync(x => x.UserId==uid);
                var u = new UpdateUser()
                {
                    Id = userdata.Id,
                    UserId = userdata.UserId,
                    Name = userdata.Name,
                    Email = userdata.Email,
                    Phone = userdata.Phone,
                    Address = userdata.Address,
                    Salary = userdata.Salary,
                    CreatedDate = userdata.CreatedDate,
                    Department = userdata.Department,
                    Description = userdata.Description

                };

                return View("Edit",u);



            }
        }


        public async Task<IActionResult>Update(UpdateUser u)
        {

            var user=await context1.Users.FirstOrDefaultAsync(x=>x.UserId==u.UserId);
            if(user!=null) 
            { 
                user.Name= u.Name;
                user.Email= u.Email;
                user.Phone= u.Phone;
                user.Address= u.Address;
                user.Salary= u.Salary;
                user.CreatedDate = u.CreatedDate;
                user.Department= u.Department;
                user.Description= u.Description;
                await context1.SaveChangesAsync();
                return RedirectToAction("DisplayById");
            }
            return View("DisplayById");
        }


        [HttpGet]

        public async Task<IActionResult>A_Delete(int id)
        {

            var userdata=await context1.Users.FirstOrDefaultAsync(x=>x.UserId == id);
            if(userdata!=null)
            {
                context1.Users.Remove(userdata);
                await context1.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }



        [HttpGet]
        public async Task<IActionResult>A_Edit(int id)
        {
            var userdata = await context1.Users.FirstOrDefaultAsync(x => x.UserId == id);
            var u = new UpdateUser()
            {
                UserId = userdata.UserId,
                Name = userdata.Name,
                Email = userdata.Email,
                Phone = userdata.Phone,

                Address = userdata.Address,
                Salary = userdata.Salary,
                CreatedDate = userdata.CreatedDate,
                Department = userdata.Department




            };
            return await Task.Run(() => View("Edit", u));
        }


        [HttpPost]
        public async Task<IActionResult>A_Edit(UpdateUser u)
        {
            var user=await context1.Users.FirstOrDefaultAsync(x=>x.UserId == u.UserId);
            if(user!=null) 
            { 
                user.Name= u.Name;  
                user.Email= u.Email;
                user.Phone= u.Phone;
                user.Address= u.Address;
                    
                user.Salary= u.Salary;
                user.CreatedDate = u.CreatedDate;
                user.Department = u.Department;
                await context1.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
         
      

     
    }
}
