using Amizade.Domain.Model.Entities;
using Amizade.Domain.Model.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infnet.Etapa4.Presentation.AmizadeWebMvc.Controllers
{
    public class AmigoController : Controller
    {
        private readonly IAmigoService _domainService;

        public AmigoController(IAmigoService domainService)
        {
            _domainService = domainService;
        }

        // GET: Amigo
        public async Task<IActionResult> Index()
        {
            return View(await _domainService.GetAllAsync());
        }

        // GET: Amigo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amigoEntity = await _domainService.GetByIdAsync(id.Value);

            if (amigoEntity == null)
            {
                return NotFound();
            }

            return View(amigoEntity);
        }

        // GET: Amigo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amigo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AmigoEntity amigoEntity)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Form.Files.SingleOrDefault();

                await _domainService.InsertAsync(amigoEntity, file?.OpenReadStream());

                return RedirectToAction(nameof(Index));
            }
            return View(amigoEntity);
        }

        // GET: Amigo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amigoEntity = await _domainService.GetByIdAsync(id.Value);
            if (amigoEntity == null)
            {
                return NotFound();
            }
            return View(amigoEntity);
        }

        // POST: Amigo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AmigoEntity amigoEntity)
        {
            if (id != amigoEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //TODO: improvement
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmigoEntityExists(amigoEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(amigoEntity);
        }

        // GET: Amigo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amigoEntity = await _domainService.GetByIdAsync(id.Value);
            if (amigoEntity == null)
            {
                return NotFound();
            }

            return View(amigoEntity);
        }

        // POST: Amigo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //TODO: improvement

            return RedirectToAction(nameof(Index));
        }

        private bool AmigoEntityExists(int id)
        {
            return _domainService.GetByIdAsync(id) != null;
        }

    }
}
