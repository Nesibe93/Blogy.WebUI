﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.EntityLayer.Concreate
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; } // ?: Null olabilir
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public string? CoverImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int WriterId { get; set; }
        public Writer Writer { get; set; }
        public List<Comment> Comments { get; set; }
    }
}