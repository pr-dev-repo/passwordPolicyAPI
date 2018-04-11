using PasswordPolicy.Models.MMPAY;
using PasswordPolicy.Models.MMPAY.DTOs;
using System.Data.Entity;

namespace DashboardApi.Data
{
    public class MmpayDbContext : DbContext
    {

        #region LOG Tables
        public DbSet<PasswordAPILog> ApiLog { get; set; }


        #endregion

        #region SECURITY TABLES

        public DbSet<CPSPasswordQuestions> CPSPasswordQuestions { get; set; }
        public DbSet<CPSUserPwdLog> CPSUserPwdLog { get; set; }

        #endregion

        #region USER TABLES

        public DbSet<CPSUsers> CPSUsers { get; set; }
        public DbSet<CPSUsersExtended> CPSUsersExtended { get; set; }

        #endregion

        #region AUDIT TRAIL TABLES

        public DbSet<AuditTrail> AuditTrail { get; set; }
        public DbSet<AuditTrailEntity> AuditTrailEntity { get; set; }
        public DbSet<AuditTrailAction> AuditTrailAction { get; set; }
        public DbSet<AuditTrailReport> AuditTrailReport { get; set; }

        #endregion

   
        public MmpayDbContext() : base("name=MmpayDbContext") { }

        protected override void OnModelCreating(DbModelBuilder builder)
        {

            #region EVENT LOG PROPERTIES

            // Exception Logger Table Properties
            // MessageMaxLength = 4000;
            builder.Entity<EventLog>()
                   .Property(e => e.ID)
                   .HasColumnName("ID");
            builder.Entity<EventLog>()
                   .Property(e => e.EventID)
                   .HasColumnName("EventID");
            builder.Entity<EventLog>()
                   .Property(e => e.LogLevel)
                   .HasMaxLength(50);
            builder.Entity<EventLog>()
                   .Property(e => e.UserID)
                   .HasColumnName("UserID");
            builder.Entity<EventLog>()
                   .Property(e => e.Location)
                   .HasMaxLength(100);
            builder.Entity<EventLog>()
                   .Property(e => e.Message)
                   .HasMaxLength(4000);

            #endregion

            #region AUDIT TRAIL RELATIONSHIP

            // One to Many: AuditTrail -> AuditTrailAction
            builder.Entity<AuditTrail>()
                   .HasRequired(a => a.AuditTrailAction)
                   .WithMany(b => b.AuditTrail)
                   .HasForeignKey(a => a.AuditTrailActionID);


            #endregion

            #region USER RELATIONSHIP


            // One to One: CPSUsersExtended -> CPSUsers 
            builder.Entity<CPSUsers>()
                   .HasRequired(u => u.UserExtInfo)
                   .WithRequiredPrincipal(ue => ue.User);


            #endregion  

            base.OnModelCreating(builder);

        }
    }

}