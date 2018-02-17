using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobloga.Business.ViewModel
{
    public class BlogPostViewModel
    {
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual UserViewModel User { get; set; }

        public bool IsPublic { get; set; }
    }
}
