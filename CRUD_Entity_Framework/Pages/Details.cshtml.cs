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
    public class DetailsModel : PageModel
    {
        private readonly CRUD_Entity_Framework.Models.EmpContext _context;

        public DetailsModel(CRUD_Entity_Framework.Models.EmpContext context)
        {
            _context = context;
        }

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
    }
}
