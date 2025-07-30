using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BusinessObject;

public partial class FinalProjectGreaterContext : DbContext
{
    public FinalProjectGreaterContext()
    {
    }

    public FinalProjectGreaterContext(DbContextOptions<FinalProjectGreaterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<AttendanceCard> AttendanceCards { get; set; }

    public virtual DbSet<AttendanceLog> AttendanceLogs { get; set; }

    public virtual DbSet<IconSet> IconSets { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderItemGroup> OrderItemGroups { get; set; }

    public virtual DbSet<PriceSize> PriceSizes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<RewardCard> RewardCards { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<ShiftType> ShiftTypes { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=27.75.93.31;User ID=BunBo;Password=123456;Database=FinalProjectGreater;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA586204E1062");

            entity.ToTable("Account", tb => tb.HasTrigger("trg_AutoIncrement_AccountID"));

            entity.HasIndex(e => e.PhoneNumber, "UQ__Account__85FB4E38000A096B").IsUnique();

            entity.Property(e => e.AccountId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AccountID");
            entity.Property(e => e.AvatarLink).IsUnicode(false);
            entity.Property(e => e.CardId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CardID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.GoogleId)
                .IsUnicode(false)
                .HasColumnName("GoogleID");
            entity.Property(e => e.IsWorking).HasDefaultValue(true);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.StoreId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("StoreID");
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.Card).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.CardId)
                .HasConstraintName("FK_Account_AttendanceCard");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Account__RoleID__4316F928");

            entity.HasOne(d => d.Store).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK__Account__StoreID__440B1D61");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => new { e.AccountId, e.ShiftId, e.Date });

            entity.ToTable("Attendance");

            entity.Property(e => e.AccountId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AccountID");
            entity.Property(e => e.ShiftId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ShiftID");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("isDeleted");
            entity.Property(e => e.Otend)
                .HasColumnType("datetime")
                .HasColumnName("OTEnd");
            entity.Property(e => e.Otstart)
                .HasColumnType("datetime")
                .HasColumnName("OTStart");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("future")
                .HasColumnName("status");

            entity.HasOne(d => d.Account).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Account");

            entity.HasOne(d => d.Shift).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.ShiftId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Shift");
        });

        modelBuilder.Entity<AttendanceCard>(entity =>
        {
            entity.HasKey(e => e.CardId).HasName("PK__tmp_ms_x__55FECD8E27EE06B0");

            entity.ToTable("AttendanceCard", tb => tb.HasTrigger("trg_Insert_Cards"));

            entity.Property(e => e.CardId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CardID");
            entity.Property(e => e.IsWorking)
                .HasDefaultValue(true)
                .HasColumnName("isWorking");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.Uid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UID");
        });

        modelBuilder.Entity<AttendanceLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Attendan__5E5499A8BEA2CFEF");

            entity.ToTable("AttendanceLog");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("IPAddress");
            entity.Property(e => e.IsRecognized).HasDefaultValue(false);
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.ScanTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Uid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UID");
        });

        modelBuilder.Entity<IconSet>(entity =>
        {
            entity.HasKey(e => e.IconId).HasName("PK__IconSet__43C7AD2F5775E040");

            entity.ToTable("IconSet");

            entity.Property(e => e.IconId).HasColumnName("IconID");
            entity.Property(e => e.DisplayName).HasMaxLength(100);
            entity.Property(e => e.IconName).HasMaxLength(100);
            entity.Property(e => e.IconUrl).HasColumnName("IconURL");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__tmp_ms_x__C3905BAFC5B978C6");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("OrderID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AccountID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.Account).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__AccountID__1CBC4616");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30C2BAA158E");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderDetailId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("OrderDetailID");
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.OrderId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("OrderID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ProductID");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.UnitId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("UnitID");

            entity.HasOne(d => d.Group).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_OrderDetail_OrderItemGroup");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__1DB06A4F");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Produ__2CF2ADDF");

            entity.HasOne(d => d.Unit).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__UnitI__5FB337D6");
        });

        modelBuilder.Entity<OrderItemGroup>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__OrderIte__149AF30A02E13F3B");

            entity.ToTable("OrderItemGroup");

            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.OrderId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("OrderID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItemGroups)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__1BC821DD");
        });

        modelBuilder.Entity<PriceSize>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.UnitId }).HasName("PK__PriceSiz__F04398246DD58605");

            entity.ToTable("PriceSize");

            entity.HasIndex(e => new { e.ProductId, e.UnitId }, "idx_pricesize_product_unit");

            entity.Property(e => e.ProductId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ProductID");
            entity.Property(e => e.UnitId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("UnitID");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.Product).WithMany(p => p.PriceSizes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PriceSize__Produ__2BFE89A6");

            entity.HasOne(d => d.Unit).WithMany(p => p.PriceSizes)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PriceSize__UnitI__68487DD7");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__tmp_ms_x__B40CC6ED0368C45E");

            entity.ToTable("Product", tb => tb.HasTrigger("trg_AutoIncrement_ProductID"));

            entity.HasIndex(e => e.Status, "idx_product_status");

            entity.HasIndex(e => e.StoreId, "idx_storeid");

            entity.Property(e => e.ProductId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ProductID");
            entity.Property(e => e.ImageLink).IsUnicode(false);
            entity.Property(e => e.IsTopping)
                .HasDefaultValue(0)
                .HasColumnName("isTopping");
            entity.Property(e => e.IsWorking).HasDefaultValue(true);
            entity.Property(e => e.ProductName).HasMaxLength(100);
            entity.Property(e => e.PtId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PT_ID");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.StoreId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("StoreID");

            entity.HasOne(d => d.Pt).WithMany(p => p.Products)
                .HasForeignKey(d => d.PtId)
                .HasConstraintName("FK__Product__PT_ID__2B0A656D");

            entity.HasOne(d => d.Store).WithMany(p => p.Products)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__StoreID__2A164134");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.PtId).HasName("PK__ProductT__6836DDD3DA9C0723");

            entity.ToTable("ProductType", tb => tb.HasTrigger("trg_AutoIncrement_PT_ID"));

            entity.Property(e => e.PtId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PT_ID");
            entity.Property(e => e.IconId).HasColumnName("IconID");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.StoreId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("StoreID");
            entity.Property(e => e.TypeProductName).HasMaxLength(100);

            entity.HasOne(d => d.Icon).WithMany(p => p.ProductTypes)
                .HasForeignKey(d => d.IconId)
                .HasConstraintName("FK_ProductType_IconSet");

            entity.HasOne(d => d.Store).WithMany(p => p.ProductTypes)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductTy__Store__5441852A");
        });

        modelBuilder.Entity<RewardCard>(entity =>
        {
            entity.HasKey(e => e.RewardCardId).HasName("PK__RewardCa__E4B5269FB5A7C820");

            entity.ToTable("RewardCard");

            entity.Property(e => e.RewardCardId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RewardCardID");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.StoreId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("StoreID");

            entity.HasOne(d => d.Store).WithMany(p => p.RewardCards)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RewardCar__Store__48CFD27E");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3A063D1688");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("RoleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.ToTable("Shift", tb => tb.HasTrigger("trg_AutoIncrement_ShiftID"));

            entity.Property(e => e.ShiftId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ShiftID");
            entity.Property(e => e.IsWorking)
                .HasDefaultValue(true)
                .HasColumnName("isWorking");
            entity.Property(e => e.ShiftName).HasMaxLength(100);
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.Stid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("STID");

            entity.HasOne(d => d.St).WithMany(p => p.Shifts)
                .HasForeignKey(d => d.Stid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Shift__STID__46B27FE2");
        });

        modelBuilder.Entity<ShiftType>(entity =>
        {
            entity.HasKey(e => e.StId).HasName("PK__ShiftTyp__EBDB13EF973409DD");

            entity.ToTable("ShiftType", tb => tb.HasTrigger("trg_AutoIncrement_ST_ID"));

            entity.Property(e => e.StId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ST_ID");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.StoreId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("StoreID");

            entity.HasOne(d => d.Store).WithMany(p => p.ShiftTypes)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK__ShiftType__Store__2DE6D218");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__Store__3B82F0E17E73C10C");

            entity.ToTable("Store");

            entity.HasIndex(e => e.StoreId, "idx_storeid");

            entity.Property(e => e.StoreId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("StoreID");
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.LogoLink).IsUnicode(false);
            entity.Property(e => e.OrderPhoneNum)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.StoreName).HasMaxLength(200);
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("PK__Unit__44F5EC952745E71C");

            entity.ToTable("Unit", tb =>
                {
                    tb.HasTrigger("trg_AutoDeleteUnitOnStatusZero");
                    tb.HasTrigger("trg_Unit_AutoID");
                });

            entity.HasIndex(e => e.UnitId, "idx_unitid");

            entity.Property(e => e.UnitId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("UnitID");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.StoreId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("StoreID");
            entity.Property(e => e.UnitName)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Store).WithMany(p => p.Units)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Unit__StoreID__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
