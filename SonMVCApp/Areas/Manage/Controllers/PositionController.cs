using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SonMVCApp.Areas.Manage.Helpers.Exception;
using SonMVCApp.Areas.Manage.ViewModels.Position;
using SonMVCApp.DAL.Context;
using SonMVCApp.Models;

namespace SonMVCApp.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class PositionController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public PositionController(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var positions = await dbContext.Positions.Include(x => x.Agents).ToListAsync();
            return View(positions);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePositionVm vm)
        {

            if (!ModelState.IsValid) return View(vm);
            if (await dbContext.Positions.AnyAsync(x => x.Name == vm.Name))
            {
                ModelState.AddModelError("", "Hal hazirda position var");
                return View(vm);
            }
            var position = mapper.Map<Position>(vm);
            await dbContext.Positions.AddAsync(position);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            if (id <= 0)
            {
                throw new NegativeIdException();
            }
            var position = await dbContext.Positions.FirstOrDefaultAsync(x => x.Id == id);
            if (position == null)
            {
                throw new NotFoundException<Position>();
            }
            var newPosition = mapper.Map<UpdatePositionVm>(position);
            return View(newPosition);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePositionVm vm)
        {
            if (!ModelState.IsValid) return View();
            var position = await dbContext.Positions.FirstOrDefaultAsync(x => x.Id == vm.Id);
            if (position == null)
            {
                throw new NotFoundException<Position>();
            }
            if (await dbContext.Positions.AnyAsync(x => x.Name == vm.Name))
            {
                ModelState.AddModelError("", "Hal hazirda position var");
                return View(vm);
            }
            position.Name = vm.Name;

            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                throw new NegativeIdException();
            }
            var position = await dbContext.Positions.FirstOrDefaultAsync(x => x.Id == id);
            if (position == null)
            {
                throw new NotFoundException<Position>();
            }
            dbContext.Positions.Remove(position);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}