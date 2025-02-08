using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sucur.Data;
using Sucur.Models;
using Sucur.Models.Entities;

namespace Sucur.Controllers 
{
    public class UserController : Controller
    {

        private readonly AppDbContext dbContext;

        public UserController(AppDbContext dbContex)
        {
            this.dbContext = dbContex;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserViewModel viewModel)
        {
            var user = new User
            {
                Nombre = viewModel.Name,
                Numero = viewModel.Phone,
                Fecha = viewModel.Date,
                Email = viewModel.Email
            };

            await dbContext.Usuarios.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> UsersList()
        {
            var users = await dbContext.Usuarios.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await dbContext.Usuarios.FindAsync(id);
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(User viewModel)
        {
            var user = await dbContext.Usuarios.FindAsync(viewModel.IdUsuario);

            if (user is not null)
            {
                user.Nombre = viewModel.Nombre;
                user.Numero = viewModel.Numero;
                user.Fecha = viewModel.Fecha;
                user.Email = viewModel.Email;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("UsersList", "Users");

        }


        [HttpGet]
        public async Task<IActionResult> Remove(UserViewModel viewModel)
        {
            var user = await dbContext.Usuarios.AsNoTracking().
                FirstOrDefaultAsync( x => x.IdUsuario == viewModel.IdUser);

            if (user is not null)
            {
                //dbContext.Usuarios.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("UsersList", "Users");

        }

    }
}