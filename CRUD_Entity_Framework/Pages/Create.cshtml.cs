using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRUD_Entity_Framework.Models;

namespace CRUD_Entity_Framework
{
    public class CreateModel : PageModel
    {
        private readonly CRUD_Entity_Framework.Models.EmpContext _context;

        public CreateModel(CRUD_Entity_Framework.Models.EmpContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EmpRegistration EmpRegistration { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EmpRegistration.Add(EmpRegistration);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}