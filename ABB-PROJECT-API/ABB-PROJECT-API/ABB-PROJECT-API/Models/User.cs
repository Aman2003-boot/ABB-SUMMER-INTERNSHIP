using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABB_PROJECT_API.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public int? CreatedBy { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public bool? IsActive { get; set; } = true;

    }
}
