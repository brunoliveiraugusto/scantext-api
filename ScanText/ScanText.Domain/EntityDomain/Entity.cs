using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;

namespace ScanText.Domain.EntityDomain
{
    public abstract class Entity<TEntity> where TEntity : Entity<TEntity>
    {
        public Guid Id { get; set; }

        [BsonIgnore]
        [JsonIgnore]
        [NotMapped]
        public AbstractValidator<TEntity> Validator { get; private set; }

        public abstract void Validate();
    }
}
