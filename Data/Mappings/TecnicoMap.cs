using FluentMappingApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentMappingApi.Data.Mappings
{
    public class TecnicoMap : IEntityTypeConfiguration<Tecnico>
    {
        public void Configure(EntityTypeBuilder<Tecnico> builder)
        {
            //Tabela
            builder.ToTable("Tecnico");
            //Chave PK
            builder.HasKey(x => x.Id);
            //Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();


            builder.Property(t => t.Nome)
                   .IsRequired()
                   .HasMaxLength(100);


            builder.Property(t => t.Email)
                   .IsRequired()
                   .HasMaxLength(100);


            builder.Property(t => t.Telefone)
                   .IsRequired()
                   .HasMaxLength(11);


            builder.Property(t => t.Senha)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(t => t.DataCadastro)
                    .HasDefaultValueSql("GETDATE()")
                     .IsRequired();

            // Relacionamento com Tecnico (1:N)
            builder.HasOne(t => t.StatusAtivoInativo)
                .WithMany(t=>t.Tecnico)
                .HasForeignKey(t=>t.StatusAtivoInativoId)
                .HasConstraintName("FK_StatusAtivoInativo")
                .OnDelete(DeleteBehavior.Restrict);
                   
        }
    }
}

