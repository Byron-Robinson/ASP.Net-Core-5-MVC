using System.ComponentModel.DataAnnotations;

namespace CrowdyCloudBar.UserInterface.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter a user name")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
