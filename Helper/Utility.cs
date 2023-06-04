namespace ForekOnlineApplication.Helper
{
    public class Utility
    {
        public static Guid GenerateGuid()
        {
            return Guid.NewGuid();
        }

        public static string CurrentDateTime()
        {
            return DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm tt");
        }
    }
}
