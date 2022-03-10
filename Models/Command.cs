using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Howto { get; set; }
        [Required]
        public string CommadLine { get; set; }
        [Required]
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}