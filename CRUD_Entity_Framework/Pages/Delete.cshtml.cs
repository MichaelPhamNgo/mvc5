using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD_Entity_Framework.Models;

namespace CRUD_Entity_Framework
{
    public class DeleteModel : PageModel
    {
        private readonly CRUD_Entity_Framework.Models.EmpContext _context;

        public DeleteModel(CRUD_Entity_Framework.Models.EmpContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmpRegistration = await _context.EmpRegistration.FindAsync(id);

            if (EmpRegistration != null)
            {
                _context.EmpRegistration.Remove(EmpRegistration);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
