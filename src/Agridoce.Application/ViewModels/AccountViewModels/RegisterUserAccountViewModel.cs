namespace Agridoce.Application.ViewModels.AccountViewModels
{
    public abstract class RegisterUserAccountViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
