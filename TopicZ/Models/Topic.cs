namespace TopicZ
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Topic")]
    public partial class Topic
    {
        public Topic()
        {
            Answers = new HashSet<Answer>();
        }

        public int TopicId { get; set; }

        [Required]
        [StringLength(100)]
        public string TopicHeadline { get; set; }

        [StringLength(400)]
        public string TopicBody { get; set; }

        public int AuthorId { get; set; }

        public DateTime TopicDateTime { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public virtual Member Member { get; set; }
    }
}
