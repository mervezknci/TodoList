using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
        DateTime CreatedDate { get; set; }
    }

    [Serializable]
    public abstract class Entity<T> : IEntity<T>
    {
        /// <summary>
        ///     Gets or sets the entity identifier
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }

        private DateTime? createdDate;
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get { return createdDate ?? DateTime.UtcNow; }
            set { createdDate = value; }
        }


    }
}
