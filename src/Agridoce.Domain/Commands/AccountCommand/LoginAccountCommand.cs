namespace Agridoce.Domain.Commands.AccountCommand
{
    public class LoginAccountCommand :AccountCommand
    {
        public LoginAccountCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
