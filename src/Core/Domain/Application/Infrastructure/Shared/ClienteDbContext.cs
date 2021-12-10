using Microsoft.EntityFrameworkCore;
using unifesopoo.Api.Core.Domain.Shared.Repositories;
using unifesopoo.Api.Core.Domain.ClienteAgg.Entities;

namespace unifesopoo.Api.Core.Infrastructure.Shared
{
    public class ClienteDbContext : DbContext, IUnitOfWork
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes {get;set;}

        void IUnitOfWork.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}

