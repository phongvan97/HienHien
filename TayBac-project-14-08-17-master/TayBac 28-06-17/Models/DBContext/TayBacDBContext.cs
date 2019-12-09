namespace TayBac_28_06_17.Models.DBContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using EntityModels;

    public partial class TayBacDBContext : DbContext
    {
        public TayBacDBContext()
            : base("name=TayBacDBContext")
        {
            Database.SetInitializer<TayBacDBContext>(new DbInit());
        }

        public virtual DbSet<bacsy> bacsies { get; set; }
        public virtual DbSet<benhnhan> benhnhans { get; set; }
        public virtual DbSet<benhnhanIoT> benhnhanIoTs { get; set; }
        public virtual DbSet<benhsu> benhsus { get; set; }
        public virtual DbSet<benhvien> benhviens { get; set; }
        public virtual DbSet<bn_bs> bn_bs { get; set; }
        public virtual DbSet<daithaoduong> daithaoduongs { get; set; }
        public virtual DbSet<giuong> giuongs { get; set; }
        public virtual DbSet<henphequan> henphequans { get; set; }
        public virtual DbSet<huyen> huyens { get; set; }
        public virtual DbSet<huyetap> huyetaps { get; set; }
        public virtual DbSet<khoa> khoas { get; set; }
        public virtual DbSet<laophoi> laophois { get; set; }
        public virtual DbSet<tinh> tinhs { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<xa> xas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<bacsy>()
                .Property(e => e.idbsy)
                .IsFixedLength();

            modelBuilder.Entity<bacsy>()
                .Property(e => e.pass)
                .IsUnicode(false);

            modelBuilder.Entity<bacsy>()
                .Property(e => e.idbv)
                .IsFixedLength();

            modelBuilder.Entity<bacsy>()
                .Property(e => e.dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<bacsy>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<bacsy>()
                .Property(e => e.idxa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<bacsy>()
                .Property(e => e.idhuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<bacsy>()
                .Property(e => e.idtinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<benhnhan>()
                .Property(e => e.idbn)
                .IsFixedLength();

            modelBuilder.Entity<benhnhan>()
                .Property(e => e.pass)
                .IsUnicode(false);

            modelBuilder.Entity<benhnhan>()
                .Property(e => e.dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<benhnhan>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<benhnhan>()
                .Property(e => e.idxa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<benhnhan>()
                .Property(e => e.idhuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<benhnhan>()
                .Property(e => e.idtinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<benhnhan>()
                .Property(e => e.idbv)
                .IsFixedLength();

            modelBuilder.Entity<benhnhan>()
                .Property(e => e.idgiuong)
                .IsFixedLength();

            modelBuilder.Entity<benhnhan>()
                .Property(e => e.idkhoa)
                .IsFixedLength();

            modelBuilder.Entity<benhnhanIoT>()
                .Property(e => e.idbnIoT)
                .IsFixedLength();

            modelBuilder.Entity<benhnhanIoT>()
                .Property(e => e.idbn)
                .IsFixedLength();

            modelBuilder.Entity<benhsu>()
                .Property(e => e.idbs)
                .IsFixedLength();

            modelBuilder.Entity<benhsu>()
                .Property(e => e.idbn)
                .IsFixedLength();

            modelBuilder.Entity<benhvien>()
                .Property(e => e.idbv)
                .IsFixedLength();

            modelBuilder.Entity<benhvien>()
                .Property(e => e.dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<benhvien>()
                .Property(e => e.fax)
                .IsUnicode(false);

            modelBuilder.Entity<benhvien>()
                .Property(e => e.IP)
                .IsFixedLength();

            modelBuilder.Entity<benhvien>()
                .Property(e => e.idxa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<benhvien>()
                .Property(e => e.idhuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<benhvien>()
                .Property(e => e.idtinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<benhvien>()
                .HasMany(e => e.users)
                .WithRequired(e => e.benhvien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<bn_bs>()
                .Property(e => e.idbn)
                .IsFixedLength();

            modelBuilder.Entity<bn_bs>()
                .Property(e => e.idbsy)
                .IsFixedLength();

            modelBuilder.Entity<daithaoduong>()
                .Property(e => e.iddaithaoduong)
                .IsFixedLength();

            modelBuilder.Entity<daithaoduong>()
                .Property(e => e.idbs)
                .IsFixedLength();

            modelBuilder.Entity<giuong>()
                .Property(e => e.idgiuong)
                .IsFixedLength();

            modelBuilder.Entity<giuong>()
                .Property(e => e.idkhoa)
                .IsFixedLength();

            modelBuilder.Entity<henphequan>()
                .Property(e => e.idhenphequan)
                .IsFixedLength();

            modelBuilder.Entity<henphequan>()
                .Property(e => e.idbs)
                .IsFixedLength();

            modelBuilder.Entity<huyen>()
                .Property(e => e.idhuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<huyen>()
                .Property(e => e.idtinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<huyetap>()
                .Property(e => e.idhuyetap)
                .IsFixedLength();

            modelBuilder.Entity<huyetap>()
                .Property(e => e.idbs)
                .IsFixedLength();

            modelBuilder.Entity<huyetap>()
                .Property(e => e.idnd)
                .IsFixedLength();

            modelBuilder.Entity<khoa>()
                .Property(e => e.idkhoa)
                .IsFixedLength();

            modelBuilder.Entity<khoa>()
                .Property(e => e.idbv)
                .IsFixedLength();

            modelBuilder.Entity<laophoi>()
                .Property(e => e.idlaophoi)
                .IsFixedLength();

            modelBuilder.Entity<laophoi>()
                .Property(e => e.idbs)
                .IsFixedLength();

            modelBuilder.Entity<tinh>()
                .Property(e => e.idtinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.idnd)
                .IsFixedLength();

            modelBuilder.Entity<user>()
                .Property(e => e.idbv)
                .IsFixedLength();

            modelBuilder.Entity<user>()
                .Property(e => e.pass)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.idxa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.idhuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.idtinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<xa>()
                .Property(e => e.idxa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<xa>()
                .Property(e => e.idhuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<xa>()
                .Property(e => e.idtinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<xa>()
                .HasMany(e => e.benhnhans)
                .WithOptional(e => e.xa)
                .HasForeignKey(e => e.idxa);

            modelBuilder.Entity<xa>()
                .HasMany(e => e.benhnhans1)
                .WithOptional(e => e.xa1)
                .HasForeignKey(e => e.idxa);
        }
    }
}
