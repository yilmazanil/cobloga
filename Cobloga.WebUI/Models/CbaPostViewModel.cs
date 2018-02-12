using System;

namespace Cobloga.WebUI.Models
{
    public class CbaPostViewModel
    {
        public Guid ID { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? UserId { get; set; }
    }
}