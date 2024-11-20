namespace School.Api.Abstractions.Consts
{
    public class DefaultRoles
    {
        public const string SuperAdmin = nameof(SuperAdmin);
        public const string SuperAdminRoleId = "019345fe-bb7d-790c-abdf-ef88b30687a2";
        public const string SuperAdminRoleConcurrencyStamp = "019345ff-090c-7748-ba51-09e06a734587";


        public const string Admin = nameof(Admin);
        public const string AdminRoleId = "01934600-95c1-7430-96c8-c97677056b8c";
        public const string AdminRoleConcurrencyStamp = "01934601-739d-7054-9fe3-0550e1893eb9";


        public const string Teacher = nameof(Teacher);
        public const string TeacherRoleId = "01934601-bbe7-7b3e-9982-60e2b51d5e55";
        public const string TeacherRoleConcurrencyStamp = "01934601-f5d0-7439-b8bd-51b0880b2529";



        public const string Student = nameof(Student);
        public const string StudentRoleId = "01934602-2963-7780-ad48-e2bbcfd78696";
        public const string StudentRoleConcurrencyStamp = "01934602-5f50-7ad5-aa71-d9ef64a0255f";
    }
}
