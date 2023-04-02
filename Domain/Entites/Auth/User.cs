using Domain.Entites.BaseInfo;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entites.Base;

namespace Domain.Entites.Auth
{
    public class User:BaseEntity
    {
        public User()
        {
            ThePerson = new Person();
            TheRole = new Role();
        }
        [Required]
        public virtual Person ThePerson { get; set; }
        [Required]
        public virtual Role TheRole { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string HashedPassword { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        [Required]
        public string RoleId { get; set; }
        [Required]
        public string PersonId { get; set; }
    }
}
