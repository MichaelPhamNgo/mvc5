using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_Entity_Framework.Models;

namespace CRUD_Entity_Framework
{
    public class EditModel : PageModel
    {
        private readonly CRUD_Entity_Framework.Models.EmpContext _context;

        public EditModel(CRUD_Entity_Framework.Models.EmpContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmpRegistration EmpRegistration { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmpRegistration = await _context.EmpRegistration.FirstOrDefaultAsync(m => m.Empid == id);

            if (EmpRegistration == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EmpRegistration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpRegistrationExists(EmpRegistration.Empid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmpRegistrationExists(int id)
        {
            return _context.EmpRegistration.Any(e => e.Empid == id);
        }
    }
}
