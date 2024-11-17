using System.ComponentModel.DataAnnotations;

namespace School.Api.Entities
{
    public sealed class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}