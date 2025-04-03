namespace api.Models
{
    public class Usuario
    {
        private static int contador = 1;
        public int Id { get; set; }
        public string Username {  get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public Usuario(string username, string email, string passwordHash)
        {
            Id = contador++;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}
