using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBookStore.BusinessObjects.Entities
{
    public class Publisher
    {
        [Column("pub_id")]
        public required string PublisherId { get; set; }
        
        [Column("publisher_name")]
        public required string PublisherName { get; set; }
        
        [Column("city")]
        public string? City { get; set; }
        
        [Column("state")]
        public string? State { get; set; }
        
        [Column("country")]
        public string? Country { get; set; }
        
        // Navigation Property
        public virtual ICollection<User>? Users { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
    }
}