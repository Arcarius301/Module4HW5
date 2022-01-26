using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Data.Entities;

namespace Module4HW3.Data.EntityConfigurations
{
    public class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("ClientId").ValueGeneratedOnAdd();
            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.MiddleName).HasMaxLength(50);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.DateOfBirth).HasColumnType("date");

            builder.HasData(
                new Client { Id = 1, FirstName = "Eliza", MiddleName = "Louise", LastName = "Warren" },
                new Client { Id = 2, FirstName = "Eliza2", MiddleName = "Louise2", LastName = "Warren2" },
                new Client { Id = 3, FirstName = "Eliza3", MiddleName = "Louise3", LastName = "Warren3" },
                new Client { Id = 4, FirstName = "Eliza", MiddleName = "Louise", LastName = "Warren" },
                new Client { Id = 5, FirstName = "Eliza5", MiddleName = "Louise5", LastName = "Warren5" });
        }
    }
}
