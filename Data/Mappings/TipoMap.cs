using FluentMappingApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentMappingApi.Data.Mappings
{
    public class TipoMap : IEntityTypeConfiguration<Tipo>
    {
        public void Configure(EntityTypeBuilder<Tipo> builder)
        {
            //tabela
            builder.ToTable("Tipo");

            //Chave PK
            builder.HasKey(x => x.Id)
                .HasName("PK_Tipo");

            //Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnName("Descricao")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);
        }
    }
}
