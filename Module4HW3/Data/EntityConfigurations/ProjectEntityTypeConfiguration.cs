using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Data.Entities;

namespace Module4HW3.Data.EntityConfigurations
{
    public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project").HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ProjectId").ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Budget).IsRequired().HasColumnType("money");
            builder.Property(p => p.StartedDate).IsRequired().HasMaxLength(7);

            builder.HasOne(p => p.Client)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Project { Id = 1, Name = "PName1", Budget = 2000, StartedDate = DateTime.UtcNow, ClientId = 1 },
                new Project { Id = 2, Name = "PName2", Budget = 100, StartedDate = DateTime.UtcNow, ClientId = 2 },
                new Project { Id = 3, Name = "PName3", Budget = 5000, StartedDate = DateTime.UtcNow, ClientId = 3 },
                new Project { Id = 4, Name = "PName4", Budget = 8000, StartedDate = DateTime.UtcNow, ClientId = 2 },
                new Project { Id = 5, Name = "PName5", Budget = 1000, StartedDate = DateTime.UtcNow, ClientId = 1 });
        }
    }
}
