using System;

namespace ScanText.Domain.DomainObjects
{
    public class Entity<TEntity> where TEntity : Entity<TEntity>
    {
        public Guid Id { get; set; }
    }
}
