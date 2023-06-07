using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SimApi.Base.Model;
using SimApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Data.Domain
{
    [Table("Customer", Schema = "dbo")]
    public class Customer : BaseModel
    {
        public int CustomerNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsValid { get; set; }

        public virtual List<Account> Accounts { get; set; }

    }
}


public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
public void Configure(EntityTypeBuilder<Customer> builder)
{
    builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
    builder.Property(x => x.CreatedAt).IsRequired(false);
    builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(30);
    builder.Property(x => x.UpdatedAt).IsRequired(false);
    builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(30);

    builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(30);
    builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(30);
    builder.Property(x => x.DateOfBirth).IsRequired(true);
    builder.Property(x => x.CustomerNumber).IsRequired(true).HasDefaultValue(0);
    builder.Property(x => x.IsValid).IsRequired(true).HasDefaultValue(true);

    builder.HasIndex(x => x.CustomerNumber).IsUnique(true);

    builder.HasMany(x => x.Accounts)
        .WithOne(x => x.Customer)
        .HasForeignKey(x => x.CustomerId)
        .IsRequired(true);
}
}
