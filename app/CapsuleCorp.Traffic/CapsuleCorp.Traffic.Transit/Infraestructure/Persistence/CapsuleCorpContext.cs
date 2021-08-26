using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CapsuleCorp.Traffic.Transit.Domain.Model;

namespace CapsuleCorp.Traffic.Transit.Infraestructure.Persistence
{
    public class CapsuleCorpContext : DbContext
    {
        public CapsuleCorpContext (DbContextOptions<CapsuleCorpContext> options)
            : base(options)
        {
        }

        public DbSet<CapsuleCorp.Traffic.Transit.Domain.Model.City> City { get; set; }
        public DbSet<CapsuleCorp.Traffic.Transit.Domain.Model.TrafficFine> TrafficFine { get; set; }        
    }
}
