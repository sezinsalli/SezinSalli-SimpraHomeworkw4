using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SimApi.Base.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimApi.Data.Domain;

namespace SimApi.Data.Domain

{
    [Table("UserLog", Schema = "dbo")]
    public class UserLog : BaseModel
    {
        public string UserName { get; set; }
        public DateTime TransactionDate { get; set; }
        public string LogType { get; set; }
    }
}

public class UserLogConfiguration : IEntityTypeConfiguration<UserLog>
{
    public void Configure(EntityTypeBuilder<UserLog> builder)
    {
        builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
        builder.Property(x => x.CreatedAt).IsRequired(false);
        builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(30);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(30);

        builder.Property(x => x.UserName).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.TransactionDate).IsRequired(true);
        builder.Property(x => x.LogType).IsRequired(true).HasMaxLength(20);
    }
}
