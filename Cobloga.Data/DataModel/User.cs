using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cobloga.Data.DataModel
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public ICollection<CbaPost> Posts { get; set; }

    }
}
