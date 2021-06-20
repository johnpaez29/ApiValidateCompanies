using LibraryCompanies.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryCompanies.DataAccess
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) 
        {

        }
        
        public DbSet<Company> Companies { get; set; }

        public DbSet<CompanyValidation> companyValidations { get; set; }

        public DbSet<InvalidateReason> InvalidateReasons { get; set; }

    }
}
