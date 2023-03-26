namespace EventsManagement.Web.Core.Constants
{
    public static class Constants
    {
        public static class Roles
        {
            public const string Admin = "Admin";
            public const string Moderator = "Moderator";
            public const string User = "User";
        }

        public static class Policies
        {
            public const string RequireAdmin = "RequireAdmin";
            public const string RequireModerator = "RequireModerator";
        }
    }
}
