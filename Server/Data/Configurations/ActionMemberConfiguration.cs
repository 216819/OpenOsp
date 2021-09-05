using Microsoft.EntityFrameworkCore;
using OpenOsp.Model.Models;
using OpenOsp.Model.Enums;

namespace OpenOsp.Server.Data.Configurations {

  internal class ActionMemberConfiguration : IEntityConfiguration {

    public void AddConfiguration(ModelBuilder builder) {
      builder.Entity<ActionMember>(entity => {
        /// Properties
        entity.HasKey(e => new { e.Id1, e.Id2 });
        entity.Property(e => e.Id1)
          .HasColumnName("ActionId")
          .IsRequired();
        entity.Property(e => e.Id2)
          .HasColumnName("MemberId")
          .IsRequired();
        entity.Property(e => e.Role)
          .IsRequired()
          .HasDefaultValue(ActionMemberRole.Member);
        /// Relations
        entity.HasOne(e => e.Action)
          .WithMany(e => e.Members)
          .HasForeignKey(e => e.Id1)
          .OnDelete(DeleteBehavior.NoAction);
        entity.HasOne(e => e.Member)
          .WithMany(e => e.Actions)
          .HasForeignKey(e => e.Id2)
          .OnDelete(DeleteBehavior.NoAction);
      });
    }

    public void SeedData(ModelBuilder builder) {
      // builder.Entity<>().HasData(
      //   new {

      //   }
      // );
    }

  }

}