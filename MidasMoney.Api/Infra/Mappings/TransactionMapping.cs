using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MidasMoney.Core.Models;

namespace MidasMoney.Api.Infra.Mappings;

public class TransactionMapping : IEntityTypeConfiguration<Transection>
{
    public void Configure(EntityTypeBuilder<Transection> builder)
    {
        builder.ToTable("Transaction");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        builder.Property(x => x.Type)
            .IsRequired()
            .HasColumnType("SMALLINT");
        builder.Property(x => x.Amount)
            .IsRequired()
            .HasColumnType("MONEY");
        builder.Property(x => x.CreatedAt)
            .IsRequired();
        builder.Property(x => x.PaidOrReceivedAt)
            .IsRequired(false);
        builder.Property(x => x.UserId)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);
    }
}