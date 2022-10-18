using System.Collections.Generic;
using System;

namespace RecipeBox.Models
{
  public class Item
  {
    public Item()
    {
      this.JoinEntities = new HashSet<CategoryItem>();
    }

    public int ItemId { get; set; }
    public string Description { get; set; }
    public virtual ApplicationUser User { get; set; } //Declared as 'virtual' to allow Entity to lazy-load the property's contents. 
    public bool Completed { get; set; }
    public DateTime DueDate { get; set; }

    // public readonly static IEnumerable<Item> DateOrder { get; }
    public virtual ICollection<CategoryItem> JoinEntities { get;}
  }
}