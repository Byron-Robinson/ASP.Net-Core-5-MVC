using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrowdyCloudBar.DomainData.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ICollection<Drink> Drinks { get; set; }

    }
}
