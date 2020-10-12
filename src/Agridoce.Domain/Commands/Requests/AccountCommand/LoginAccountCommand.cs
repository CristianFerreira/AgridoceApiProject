namespace Agridoce.Domain.Commands.Requests.AccountCommand
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
