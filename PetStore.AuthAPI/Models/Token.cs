namespace PetStore.AuthAPI.Models
{
    public class Token
    {
        public Token(string value)
        {
            this.Value = value;
        }
        
        public string Value { get; set; }
    }
}
