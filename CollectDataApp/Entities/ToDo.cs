﻿using System;
using System.Collections.Generic;
using System.Text;
using CollectDataApp.Interfaces;

namespace CollectDataApp.Entities
{
    class ToDo : IEndpoint
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
