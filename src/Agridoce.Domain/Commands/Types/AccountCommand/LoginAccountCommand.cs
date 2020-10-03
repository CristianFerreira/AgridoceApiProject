namespace Agridoce.Domain.Commands.Types.AccountCommand
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
