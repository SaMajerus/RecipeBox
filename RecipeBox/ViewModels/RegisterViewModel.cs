using System.ComponentModel.DataAnnotations; 

namespace RecipeBox.ViewModels
{
  public class RegisterViewModel 
  {
    [Required]
    [EmailAddress]
    [Display(Name = "Email")] 
    public string Email { get; set; } 

    [Required]
    [DataType(DataType.Password)]  //"Identity's default setting for a Password is at least 6 characters, a Capital letter, a digit, and a special character" ([Overall-] Wk 13, Lsn 6). 
    [Display(Name = "Password")] 
    public string Password { get; set; } 

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")] 
    public string ConfirmPassword { get; set; }
  }

}