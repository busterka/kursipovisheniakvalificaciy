﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kursipovisheniakvalificaciy.entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KursyPovysheniyaKvalifikaciiEntities : DbContext
    {
        public KursyPovysheniyaKvalifikaciiEntities()
            : base("name=KursyPovysheniyaKvalifikaciiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Gruppy> Gruppy { get; set; }
        public virtual DbSet<Nagruzka> Nagruzka { get; set; }
        public virtual DbSet<Pol> Pol { get; set; }
        public virtual DbSet<Polzovateli> Polzovateli { get; set; }
        public virtual DbSet<Prepodavateli> Prepodavateli { get; set; }
        public virtual DbSet<Roli> Roli { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
