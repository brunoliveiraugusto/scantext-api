using System;

namespace ScanText.Domain.EntityDomain
{
    public class Entity<TEntity> where TEntity : Entity<TEntity>
    {
        public Guid Id { get; set; }
    }
}
