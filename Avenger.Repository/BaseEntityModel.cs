using System.ComponentModel.DataAnnotations;

namespace Avenger.Repository
{
    public abstract class BaseEntityModel<T>
    {
        [Required]
        public T ID { get; set; }
    }
}
