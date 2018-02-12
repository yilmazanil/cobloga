using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cobloga.Data.DataModel
{
    public class CbaPost
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ID { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
