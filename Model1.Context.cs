﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrame
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class autoAutoEntities : DbContext
    {
        public autoAutoEntities()
            : base("name=autoAutoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customers> Customerses { get; set; }
        public virtual DbSet<DetailNames> DetailNames { get; set; }
        public virtual DbSet<Detailss> Detailsses { get; set; }
        public virtual DbSet<DetailType> DetailTypes { get; set; }
        public virtual DbSet<Korzina> Korzinas { get; set; }
        public virtual DbSet<Marka> Markas { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Orders> Orderses { get; set; }
        public virtual DbSet<Customers_2> Customers_2s { get; set; }
    }
}