using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Controllers
{
  public class IngredientsController : Controller
  {
    private readonly RecipeBoxContext _db;

    public IngredientsController(RecipeBoxContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Ingredient> model = _db.Ingredients.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Ingredient ingredient)
    {
      _db.Ingredients.Add(ingredient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisIngredient = _db.Ingredients
        .Include(ingredient => ingredient.JoinRecIng)
        .ThenInclude(join => join.Recipe)
        .FirstOrDefault(ingredient => ingredient.IngredientId == id);
      return View(thisIngredient);
    }

    public ActionResult Edit(int id)
    {
      Ingredient thisIngredient = _db.Ingredients.FirstOrDefault(ingredient => ingredient.IngredientId == id);
      return View(thisIngredient);
    }

    [HttpPost]
    public ActionResult Edit(Ingredient ingredient)
    {
      _db.Entry(ingredient).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Ingredient thisIngredient = _db.Ingredients.FirstOrDefault(ingredient => ingredient.IngredientId == id);
      return View(thisIngredient);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Ingredient thisIngredient = _db.Ingredients.FirstOrDefault(ingredient => ingredient.IngredientId == id);
      _db.Ingredients.Remove(thisIngredient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}