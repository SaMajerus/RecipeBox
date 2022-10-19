using System.Collections.Generic;
using System;

namespace RecipeBox.Models
{
  public class Recipe
  {
    public Recipe()
    {
      this.JoinCatRec = new HashSet<CategoryRecipe>();
      this.JoinRecIng = new HashSet<RecipeIngredient>();
    }

    public int RecipeId { get; set; }
    public string Description { get; set; }
    public int Rating { get; set; }
    // public string Ingredients { get; set; }
    public string Steps { get; set; }
    public virtual ApplicationUser User { get; set; }  //Declared as 'virtual' to allow Entity to lazy-load the property's contents. 

    public virtual ICollection<CategoryRecipe> JoinCatRec { get;}
    public virtual ICollection<RecipeIngredient> JoinRecIng { get;}
  }
}