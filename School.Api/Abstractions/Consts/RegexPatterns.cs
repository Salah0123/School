namespace School.Api.Abstractions.Consts
{
    public static class RegexPatterns
    {
        public const string Password = "(?=(.*[0-9]))(?=.*[\\!@#$%^&*()\\\\[\\]{}\\-_+=~`|:;\"'<>,./?])(?=.*[a-z])(?=(.*[A-Z]))(?=(.*)).{8,}";
        public const string Phone = "/^\\+966\\s?(5\\d{8}|1\\d{8})$/"; //"/^(05\\d{8}|01\\d{8})$/"; //"^(\\+966|0)?5\\d{8}$";
    }
}