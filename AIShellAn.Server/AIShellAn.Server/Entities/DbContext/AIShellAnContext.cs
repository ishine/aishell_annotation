using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIShellAn.Server.Entities
{
    public class AIShellAnContext : DbContext
    {
        public AIShellAnContext(DbContextOptions<AIShellAnContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //配置团队与标注任务的多对多关系
            builder.Entity<TeamAnnotationTask>(entity =>
            {
                entity.HasKey(x => new
                {
                    x.TeamId,
                    x.AnnotationTaskId
                });

                entity.HasOne(x => x.Team)
                .WithMany(x => x.TeamTask)
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.AnnotationTask)
                .WithMany(x => x.TeamTask)
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
            });


            //配置团队与用户的多对多关系
            builder.Entity<TeamUser>(entity =>
            {
                entity.HasKey(x => new
                {
                    x.TeamId,
                    x.UserId
                });
                entity.HasOne(x => x.Team)
                .WithMany(x => x.TeamUser)
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.User)
                .WithMany(x => x.TeamUser)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            });


            builder.Entity<User>(e=> 
            {
                //配置创建者与成员的一堆多关系
                e.HasOne(x => x.Creator).WithMany(x => x.Members).HasForeignKey(x=>x.CreatorId);


            });

            builder.Entity<Team>(e =>
            {
                //配置创建者与团队的一对多关系
                e.HasOne(x => x.Creator).WithMany(x => x.Teams).HasForeignKey(x => x.CreatorId);
            });

            builder.Entity<ShortSpeechItem>(e =>
            {
                //配置短音频数据与 数据包的一对多关系
                e.HasOne(x => x.Package).WithMany(x => x.ShortSpeechItems).HasForeignKey(x => x.PackageId);



            });

            builder.Entity<LongSpeechItem>(e =>
            {
                //配置长音频数据与 数据包的一对多关系
                e.HasOne(x => x.Package).WithMany(x => x.LongSpeechItems).HasForeignKey(x => x.PackageId);
                //配置长音频的文本与长音频的关系
                e.HasMany(x => x.Texts).WithOne(x => x.LongSpeechItem).HasForeignKey(x => x.LongSpeechItemId);
            });


            builder.Entity<AnnotationTask>(e =>
            {
                //配置标注任务与模板的多对一关系
                e.HasOne(x => x.AnnotationTemplate).WithMany(x => x.AnnotationTasks).HasForeignKey(x => x.TemplateId);
                //配置任务与数据包的一对多关系
                e.HasMany(x => x.Packages).WithOne(x => x.AnnotationTask).HasForeignKey(x => x.AnnotationTaskId);
                //配置项目经理与标注任务的一对多关系
                e.HasOne(x => x.Manager).WithMany(x => x.AnnotationTasks).HasForeignKey(x => x.ManagerId);
            });

            builder.Entity<DataPackage>(e =>
            {
                //配置数据项与数据包的多对一关系
                e.HasMany(x => x.ShortSpeechItems).WithOne(x => x.Package).HasForeignKey(x => x.PackageId);
                e.HasMany(x => x.LongSpeechItems).WithOne(x => x.Package).HasForeignKey(x => x.PackageId);
                //配置标注用户与数据包的一对多关系
                e.HasOne(x => x.AnnotationUser).WithMany(x => x.DataPackages).HasForeignKey(x => x.AnnotationUserId);
            });


            builder.Entity<AnnotationTemplate>(e =>
            {
                //配置标注任务模板与模板项一对多的关系
                e.HasMany(x => x.TemplateItems).WithOne(x => x.AnnotationTemplate).HasForeignKey(x => x.AnnotationTemplateId);
            });



            builder.Entity<InspectionTask>(e =>
            {
                //配置创建者与质检任务的一对多关系
                e.HasOne(x => x.Creator).WithMany(x => x.InspectionTasks).HasForeignKey(x => x.CreatorId);

                e.HasOne(x => x.AnnotationTask).WithMany(x => x.InspectionTasks).HasForeignKey(x => x.AnnotationTaskId);

                e.HasMany(x => x.InspectionPackageRecords).WithOne(x => x.InspectionTask).HasForeignKey(x => x.InspectionTaskId);

            });

            builder.Entity<InspectionPackageRecord>(e =>
            {
                e.HasMany(x => x.InspectionItemRecords).WithOne(x => x.InspectionPackageRecord).HasForeignKey(x => x.InspectionPackageRecordId);

                e.HasOne(x => x.Package).WithMany(x => x.InspectionPackageRecords).HasForeignKey(x => x.PackageId);
            });

            builder.Entity<InspectionItemRecord>(e =>
            {
                e.HasOne(x => x.InspectionUser).WithMany(x => x.InspectionItemRecords).HasForeignKey(x => x.InspectionPackageRecordId);
            });


            base.OnModelCreating(builder);

            builder.HasPostgresExtension("uuid-ossp");
        }


        public DbSet<User> User { get; set; }

        public DbSet<Team> Team { get; set; }

        public DbSet<DataPackage> DataPackage { get; set; }


        public DbSet<TeamUser> TeamUser { get; set; }
        public DbSet<TeamAnnotationTask> TeamTask { get; set; }
        public DbSet<ShortSpeechItem> ShortSpeechItem { get; set; }
        public DbSet<LongSpeechText> LongSpeechText { get; set; }
        public DbSet<LongSpeechItem> LongSpeechItem { get; set; }
        public DbSet<InspectionTask> InspectionTask { get; set; }
        public DbSet<InspectionPackageRecord> InspectionPackageRecord { get; set; }

        public DbSet<AnnotationTemplateItem> AnnotationTemplateItem { get; set; }

        public DbSet<AnnotationTemplate> AnnotationTemplate { get; set; }

        public DbSet<AnnotationTask> AnnotationTask { get; set; }

        public DbSet<AnnotationResult> AnnotationResult { get; set; }

    }
}
