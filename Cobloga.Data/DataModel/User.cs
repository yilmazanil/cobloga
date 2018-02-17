using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cobloga.Data.DataModel
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        [StringLength(155)]
        public string Password { get; set; }
       
        [StringLength(155)]
        public string Name { get; set; }

        public ICollection<BlogPost> Posts { get; set; }

    }
}
