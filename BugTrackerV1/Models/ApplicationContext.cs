using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Reflection.Metadata;
using System.Security;

namespace BugTrackerV1.Models
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Sprint> Sprint { get; set; }
        public virtual DbSet<Issue> Issue { get; set; }
        public virtual DbSet<IssuePriority> IssuePriority { get; set; }
        public virtual DbSet<IssueStatus> IssueStatus { get; set; }
        public virtual DbSet<IssueType> IssueType { get; set; }
        public virtual DbSet<IssueAttachment> IssueAttachment { get; set; }
        public virtual DbSet<IssueComment> IssueComment { get; set; }
        public virtual DbSet<IssueHistory> IssueHistory { get; set; }
        public virtual DbSet<Label> Label { get; set; }
        public virtual DbSet<LabelIssue> LabelIssue { get; set; }
        public virtual DbSet<StepsToReproduce> StepsToReproduce { get; set; }
        public virtual DbSet<RolePermissions> RolePermissions { get; set; }
        public virtual DbSet<UserPermissions> UserPermissions { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<ProjectUsers> ProjectUsers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<ProjectUsers>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.ProjectUsers)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<ProjectUsers>()
                .HasOne(ur => ur.Project)
                .WithMany(r => r.ProjectUsers)
                .HasForeignKey(ur => ur.ProjectId);

            modelBuilder.Entity<UserPermissions>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserPermissions)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserPermissions>()
                .HasOne(up => up.Permission)
                .WithMany(p => p.UserPermissions)
                .HasForeignKey(up => up.PermissionId);

            modelBuilder.Entity<RolePermissions>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);

            modelBuilder.Entity<RolePermissions>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.User)
                .WithMany(u => u.Project)
                .HasForeignKey(p => p.ProjectManagerId);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Sprint)
                .WithOne()
                .HasForeignKey<Project>(p => p.ActiveSprintId);

            modelBuilder.Entity<Sprint>()
                .HasOne(s => s.Project)
                .WithMany(p => p.Sprints)
                .HasForeignKey(s => s.ProjectId);

            modelBuilder.Entity<Issue>()
                .HasOne(i => i.Project)
                .WithMany(p => p.Issue)
                .HasForeignKey(i => i.ProjectId);

            modelBuilder.Entity<Issue>()
                .HasOne(i => i.Sprint)
                .WithMany(s => s.Issue)
                .HasForeignKey(i => i.SprintId);

            modelBuilder.Entity<Issue>()
                .HasOne(i => i.CreatedBy)
                .WithMany(u => u.CreatedIssues)
                .HasForeignKey(i => i.CreatedById);

            modelBuilder.Entity<Issue>()
                .HasOne(i => i.AssignedTo)
                .WithMany(u => u.AssignedIssues)
                .HasForeignKey(i => i.AssignedToId);

            modelBuilder.Entity<Issue>()
                .HasOne(i => i.Priority)
                .WithMany(ip => ip.Issue)
                .HasForeignKey(i => i.PriorityId);

            modelBuilder.Entity<Issue>()
                .HasOne(i => i.Status)
                .WithMany(ib => ib.Issue)
                .HasForeignKey(i => i.StatusId);

            modelBuilder.Entity<Issue>()
                .HasOne(i => i.Type)
                .WithMany(ik => ik.Issue)
                .HasForeignKey(i => i.TypeId);

            modelBuilder.Entity<IssueAttachment>()
                .HasOne(ia => ia.Issue)
                .WithMany(i => i.IssueAttachment)
                .HasForeignKey(ia => ia.IssueId);

            modelBuilder.Entity<IssueAttachment>()
                .HasOne(ia => ia.User)
                .WithMany(u => u.IssueAttachment)
                .HasForeignKey(ia => ia.UploadedById);

            modelBuilder.Entity<IssueComment>()
                .HasOne(ic => ic.Issue)
                .WithMany(i => i.IssueComment)
                .HasForeignKey(ic => ic.IssueId);

            modelBuilder.Entity<IssueComment>()
                .HasOne(ic => ic.User)
                .WithMany(u => u.IssueComment)
                .HasForeignKey(ic => ic.CommentAuthorId);

            modelBuilder.Entity<IssueHistory>()
                .HasOne(ih => ih.Issue)
                .WithMany(i => i.IssueHistory)
                .HasForeignKey(ih => ih.IssueId);

            modelBuilder.Entity<LabelIssue>()
                .HasOne(li => li.Label)
                .WithMany(l => l.LabelIssue)
                .HasForeignKey(li => li.LabelId);

            modelBuilder.Entity<LabelIssue>()
                .HasOne(li => li.Issue)
                .WithMany(i => i.LabelIssue)
                .HasForeignKey(li => li.IssueId);

            modelBuilder.Entity<StepsToReproduce>()
                .HasOne(str => str.Issue)
                .WithMany(i => i.StepsToReproduce)
                .HasForeignKey(str => str.IssueId);


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
