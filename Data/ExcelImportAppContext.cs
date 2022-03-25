#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExcelImportApp.Model;

namespace ExcelImportApp.Data
{
    public class ExcelImportAppContext : DbContext
    {
        public ExcelImportAppContext (DbContextOptions<ExcelImportAppContext> options)
            : base(options)
        {
        }

        public DbSet<ClientModel> ClientModel { get; set; }
    }
}
