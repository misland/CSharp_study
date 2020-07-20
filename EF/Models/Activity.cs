using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models
{
    public class Activity
    {
        public Activity()
        {
            Trips = new List<Trip>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid AId { get; set; }
        [Required,MaxLength(50)]
        public virtual string Name { get; set; }
        public virtual List<Trip> Trips { get; set; }
    }
}