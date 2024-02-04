using CQRS_Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS_Shop.Infra.Data.Mappings;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("CUSTOMER");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
        .HasColumnName("ID");

        builder.Property(x => x.Name)
        .HasColumnName("NAME");

        builder.Property(x => x.Email)
        .HasColumnName("EMAIL");

        builder.OwnsOne(x => x.Document, document =>{
            document.Property(x => x.Type)
            .HasColumnName("TYPE_DOCUMENT");

            document.Property(x => x.Description)
            .HasColumnName("DOCUMENT");
        });

        builder.Property(x => x.CreatedBy)
        .HasColumnName("CREATED_BY");

        builder.Property(x => x.CreatedIn)
        .HasColumnName("CREATED_IN");

        builder.Property(x => x.UpdatedBy)
        .HasColumnName("UPDATED_BY")
        .IsRequired(false);

        builder.Property(x => x.UpdatedIn)
        .HasColumnName("UPDATED_IN")
        .IsRequired(false);
    }
}