using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kids_U_Database_Reporting.Models
{
    public class Organization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrganizationId { get; set; }

        [Required]
        public string OrganizationName { get; set; }
        public string ProgramNumber { get; set; }
        public string Address { get; set; }
        public string ContactName1 { get; set; }
        public string ContactEmail1 { get; set; }
        public string ContactPhone1 { get; set; }
        public string ContactName2 { get; set; }
        public string ContactEmail2 { get; set; }
        public string ContactPhone2 { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
