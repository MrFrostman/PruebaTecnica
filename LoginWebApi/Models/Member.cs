using LoginWebApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;

namespace LoginWebApi
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberId  { get; set; } 
        public string Email { get; set; } = string.Empty;
        public byte[] PassworSalt { get; set; }
        public byte[] PasswordHash { get ; set; }

    }
}
