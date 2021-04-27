using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using ScanText.Domain.Utils.Validators.Base;

namespace ScanText.Domain.EntityDomain
{
    public abstract class Entity<TEntity> where TEntity : Entity<TEntity>
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        [BsonIgnore]
        [NotMapped]
        public BaseValidation<TEntity> Validator { get; protected set; }

        public Entity()
        {
            Validator = new BaseValidation<TEntity>();
        }

        public abstract void Validate();
    }
}
