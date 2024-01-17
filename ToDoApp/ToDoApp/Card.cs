﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    public class Card
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public TeamMember AssignedMember { get; set; }
        public Size CardSize { get; set; }

        public Card(string title, string content, TeamMember assignedMember, Size cardSize)
        {
            Title = title;
            Content = content;
            AssignedMember = assignedMember;
            CardSize = cardSize;
        }
    }
}
