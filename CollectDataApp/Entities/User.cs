﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CollectDataApp.Entities
{
    class User
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public List<Post> Posts { get; set; }
        public List<ToDo> ToDos { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
