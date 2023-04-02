using Domain.Entites.Auth;
using Domain.Entites.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entites.BaseInfo
{
    public class Person:BaseEntity
    {
        public Person()
        {
            TheUsers = new List<User>();
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Family { get; set; }

        public string FatherName { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string NationalNo { get; set; }
        public virtual List<User> TheUsers { get; set; }
    }
}
