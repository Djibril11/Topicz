namespace TopicZ
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TopicZContext : DbContext
    {
        public TopicZContext()
            : base("name=TopicZContext")
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .Property(e => e.AnswerBody)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.MemberName)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.MemberEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.MemberPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Topics)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.TopicHeadline)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.TopicBody)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Topic)
                .WillCascadeOnDelete(false);
        }
    }
}
