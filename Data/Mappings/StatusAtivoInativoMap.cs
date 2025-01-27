using FluentMappingApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentMappingApi.Data.Mappings
{
    public class StatusAtivoInativoMap : IEntityTypeConfiguration<StatusAtivoInativo>
    {
        public void Configure(EntityTypeBuilder<StatusAtivoInativo> builder)
        {
            //tabela
            builder.ToTable("StatusAtivoInativo");

            //Chave PK
            builder.HasKey(x => x.Id)
                .HasName("PK_StatusAtivoInativo");

            //Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Descricao)
               .IsRequired()
               .HasColumnName("Descricao")
               .HasColumnType("NVARCHAR")
               .HasMaxLength(20);

            //Relacionamento
            builder.HasMany(x=>x.Tecnico)
                .WithOne(x=>x.StatusAtivoInativo)
                 .HasForeignKey(x=>x.StatusAtivoInativoId)
                 .HasConstraintName("FK_Tecnico_StatusAtivoInativo")
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
