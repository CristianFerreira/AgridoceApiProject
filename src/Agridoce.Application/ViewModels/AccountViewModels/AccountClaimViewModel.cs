namespace Agridoce.Application.ViewModels.AccountViewModels
{
    public class AccountClaimViewModel
    {
        public AccountClaimViewModel(string type, string value)
        {
            Type = type;
            Value = value;
        }

        public string Type { get; set; }
        public string Value { get; set; }
    }
}
