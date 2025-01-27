Praticando Mapeamento de entidades com Fluent API. Neste projeto pratiquei até HasOne / WithMany - HasMany / WithOne
   
    // Relacionamento com Tecnico (1:N)
    builder.HasOne(t => t.StatusAtivoInativo)
        .WithMany(t=>t.Tecnico)
        .HasForeignKey(t=>t.StatusAtivoInativoId)
        .HasConstraintName("FK_StatusAtivoInativo")
        .OnDelete(DeleteBehavior.Restrict);

            //Relacionamento
    builder.HasMany(x=>x.Tecnico)
        .WithOne(x=>x.StatusAtivoInativo)
         .HasForeignKey(x=>x.StatusAtivoInativoId)
         .HasConstraintName("FK_Tecnico_StatusAtivoInativo")
       .OnDelete(DeleteBehavior.Restrict);
}
