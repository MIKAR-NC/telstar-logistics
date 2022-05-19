namespace TelstarRoutePlanner.Controllers.API.Request_Models
{
    public class SignInRequest
    {
        public string username { get; set; }
        public string password { get; set; }

        public SignInRequest(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
