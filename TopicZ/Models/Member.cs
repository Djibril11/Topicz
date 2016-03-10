namespace TopicZ
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Member")]
    public partial class Member
    {
        public Member()
        {
            Answers = new HashSet<Answer>();
            Topics = new HashSet<Topic>();
        }

        public int MemberId { get; set; }

        [Required]
        [StringLength(50)]
        public string MemberName { get; set; }

        [Required]
        [StringLength(200)]
        public string MemberEmail { get; set; }

        [Required]
        [StringLength(50)]
        public string MemberPassword { get; set; }

        public DateTime MemberDateTime { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
    }
}
