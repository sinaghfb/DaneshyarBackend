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
            State = ObjectStateEnum.Active;
            CreateDateTime = DateTime.Now;
        }
        [Required]
        [Key]
        public string Id { get; set; }
        [Required]
        [Timestamp]
        public byte[] TimeStamp { get; set; }
        [Required]
        public ObjectStateEnum State { get; set; }
        [ConcurrencyCheck]
        public DateTime CreateDateTime { get; set; }
    }
}
