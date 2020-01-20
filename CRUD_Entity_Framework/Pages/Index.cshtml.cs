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
    public class IndexModel : PageModel
    {
        private readonly CRUD_Entity_Framework.Models.EmpContext _context;

        public IndexModel(CRUD_Entity_Framework.Models.EmpContext context)
        {
            _context = context;
        }

        public IList<EmpRegistration> EmpRegistration { get;set; }

        public async Task OnGetAsync()
        {
            EmpRegistration = await _context.EmpRegistration.ToListAsync();
        }
    }
}
