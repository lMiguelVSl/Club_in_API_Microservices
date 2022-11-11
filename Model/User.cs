namespace Club_in_API.UserType.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string UserType { get; set; }
        public bool IsActive { get; set; }
    }
}
