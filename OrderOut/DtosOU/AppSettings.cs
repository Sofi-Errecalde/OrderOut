namespace OrderOut.DtosOU
{
    public class AppSettings
    {

    }

    public class AuthSettings
    {
        public string SecretKey { get; set; }

        public int TokenDays { get; set; }

        public static string SectionName => "AuthSettings";
    }

}
