using System;
using System.Collections.Generic;
using System.Text;
using CollectDataApp.Interfaces;

namespace CollectDataApp.Entities
{
    class Comment : IEndpoint
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Body { get; set; }
        public int Likes { get; set; }
    }
}
