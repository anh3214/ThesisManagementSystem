using ThesisManagement.Entities;

namespace ThesisManagementSystem
{
    public static class UserSession
    {
        public static Guid UserID { get; set; }
        public static string Username { get; set; }
        public static Role Role { get; set; }
        public static void Logout()
        {
            UserID = Guid.Empty;
            Username = string.Empty;
            Role = default;
        }
    }
}
