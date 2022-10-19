using System.Collections.Generic;
using System; //this is present in recipe but not category

namespace RecipeBox.Models
{
  public class Ingredient
  {
    public Ingredient()
    {
      this.JoinRecIng = new HashSet<RecipeIngredient>();
    }

    public int IngredientId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<RecipeIngredient> JoinRecIng { get; set; }
  }
}