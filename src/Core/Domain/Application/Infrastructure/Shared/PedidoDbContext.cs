using Microsoft.EntityFrameworkCore;
using unifesopoo.Api.Core.Domain.Shared.Repositories;
using unifesopoo.Api.Core.Domain.ClienteAgg.Entities;

namespace unifesopoo.Api.Core.Infrastructure.Shared
{
    public class PedidoDbContext : DbContext, IUnitOfWork
    {
        public PedidoDbContext(DbContextOptions<PedidoDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes {get;set;}


        void IUnitOfWork.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}

