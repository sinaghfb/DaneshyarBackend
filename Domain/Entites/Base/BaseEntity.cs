using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.Base
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            State = EntityState.Active;
            TimeStamp = 1;
        }
        [Required]
        [Key]
        public string Id { get; set; }
        [Required]
        [Timestamp]
        public int TimeStamp { get; set; }
        [Required]
        public EntityState State { get; set; }
    }
}
