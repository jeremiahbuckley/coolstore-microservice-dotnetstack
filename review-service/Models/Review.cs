using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewService.Models
{
    [Table("review")]
    public class Review
    {
        [Key]
        [Column("reviewid")]
        public int ReviewId { get; set; }
        
        [Column("itemid")]
        public string ItemId { get; set; }
        [Column("rating")]
        public int Rating { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column("username")]
        public string username { get; set; }
        [Column("title")]
        public string Title { get; set; }

        [DataType(DataType.DateTime)]
        [Column("createdate")]
        public DateTime CreateDate { get; set; }
    }
}