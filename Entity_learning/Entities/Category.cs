using System.Collections.ObjectModel;

namespace Entity_learning.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual ICollection<Product> Products { get; set; }
    }
}
