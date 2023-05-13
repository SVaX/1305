using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoAppAgain.Models;

public partial class DemoAppDbContext : DbContext
{
    public DemoAppDbContext()
    {
    }

    public DemoAppDbContext(DbContextOptions<DemoAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicationStatus> ApplicationStatuses { get; set; }

    public virtual DbSet<CompanyType> CompanyTypes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeMovement> EmployeeMovements { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<EquipmentMaster> EquipmentMasters { get; set; }

    public virtual DbSet<EquipmentState> EquipmentStates { get; set; }

    public virtual DbSet<Manufacture> Manufactures { get; set; }

    public virtual DbSet<ManufactureMaterial> ManufactureMaterials { get; set; }

    public virtual DbSet<Master> Masters { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MaterialHistory> MaterialHistories { get; set; }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<MovementType> MovementTypes { get; set; }

    public virtual DbSet<OperationType> OperationTypes { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<PriceHistory> PriceHistories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductApplication> ProductApplications { get; set; }

    public virtual DbSet<ProductStandart> ProductStandarts { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleHistory> SaleHistories { get; set; }

    public virtual DbSet<SalePoint> SalePoints { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<UnitType> UnitTypes { get; set; }

    public virtual DbSet<Workshop> Workshops { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CRMKZN224; Initial Catalog=DemoAppDb; TrustServerCertificate=True; Trusted_Connection=true; MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agent>(entity =>
        {
            entity.ToTable("Agent");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Kpp)
                .HasMaxLength(50)
                .HasColumnName("KPP");
            entity.Property(e => e.Logo).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Principal).HasMaxLength(50);
            entity.Property(e => e.Tin)
                .HasMaxLength(50)
                .HasColumnName("TIN");

            entity.HasOne(d => d.CompanyType).WithMany(p => p.Agents)
                .HasForeignKey(d => d.CompanyTypeId)
                .HasConstraintName("FK_Agent_CompanyType");
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.ToTable("Application");

            entity.Property(e => e.CreatedDate).HasColumnType("date");
            entity.Property(e => e.CreatingStartDate).HasColumnType("date");

            entity.HasOne(d => d.Agent).WithMany(p => p.Applications)
                .HasForeignKey(d => d.AgentId)
                .HasConstraintName("FK_Application_Agent");

            entity.HasOne(d => d.ApplicationStatus).WithMany(p => p.Applications)
                .HasForeignKey(d => d.ApplicationStatusId)
                .HasConstraintName("FK_Application_ApplicationStatus");
        });

        modelBuilder.Entity<ApplicationStatus>(entity =>
        {
            entity.ToTable("ApplicationStatus");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<CompanyType>(entity =>
        {
            entity.ToTable("CompanyType");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PassportNumber).HasMaxLength(50);
            entity.Property(e => e.PassportSeries).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK_Employee_Position");
        });

        modelBuilder.Entity<EmployeeMovement>(entity =>
        {
            entity.ToTable("EmployeeMovement");

            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeMovements)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeeMovement_Employee");

            entity.HasOne(d => d.MovementType).WithMany(p => p.EmployeeMovements)
                .HasForeignKey(d => d.MovementTypeId)
                .HasConstraintName("FK_EmployeeMovement_MovementType");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.EquipmentState).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.EquipmentStateId)
                .HasConstraintName("FK_Equipment_EquipmentState");
        });

        modelBuilder.Entity<EquipmentMaster>(entity =>
        {
            entity.ToTable("EquipmentMaster");

            entity.HasOne(d => d.Equipment).WithMany(p => p.EquipmentMasters)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("FK_EquipmentMaster_Equipment");

            entity.HasOne(d => d.Master).WithMany(p => p.EquipmentMasters)
                .HasForeignKey(d => d.MasterId)
                .HasConstraintName("FK_EquipmentMaster_Master");
        });

        modelBuilder.Entity<EquipmentState>(entity =>
        {
            entity.ToTable("EquipmentState");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Manufacture>(entity =>
        {
            entity.ToTable("Manufacture");

            entity.HasOne(d => d.Product).WithMany(p => p.Manufactures)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Manufacture_Product");

            entity.HasOne(d => d.ProductNavigation).WithMany(p => p.Manufactures)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Manufacture_Workshop");
        });

        modelBuilder.Entity<ManufactureMaterial>(entity =>
        {
            entity.ToTable("ManufactureMaterial");

            entity.HasOne(d => d.Manufacture).WithMany(p => p.ManufactureMaterials)
                .HasForeignKey(d => d.ManufactureId)
                .HasConstraintName("FK_ManufactureMaterial_Manufacture");

            entity.HasOne(d => d.Material).WithMany(p => p.ManufactureMaterials)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK_ManufactureMaterial_Material");
        });

        modelBuilder.Entity<Master>(entity =>
        {
            entity.ToTable("Master");

            entity.HasOne(d => d.Employee).WithMany(p => p.Masters)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Master_Employee");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.ToTable("Material");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Picture).HasMaxLength(50);

            entity.HasOne(d => d.MaterialType).WithMany(p => p.Materials)
                .HasForeignKey(d => d.MaterialTypeId)
                .HasConstraintName("FK_Material_MaterialType");

            entity.HasOne(d => d.UnitType).WithMany(p => p.Materials)
                .HasForeignKey(d => d.UnitTypeId)
                .HasConstraintName("FK_Material_UnitType");
        });

        modelBuilder.Entity<MaterialHistory>(entity =>
        {
            entity.ToTable("MaterialHistory");

            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.Material).WithMany(p => p.MaterialHistories)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK_MaterialHistory_Material");

            entity.HasOne(d => d.OperationType).WithMany(p => p.MaterialHistories)
                .HasForeignKey(d => d.OperationTypeId)
                .HasConstraintName("FK_MaterialHistory_OperationType");
        });

        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.ToTable("MaterialType");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<MovementType>(entity =>
        {
            entity.ToTable("MovementType");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<OperationType>(entity =>
        {
            entity.ToTable("OperationType");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.ToTable("Position");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<PriceHistory>(entity =>
        {
            entity.ToTable("PriceHistory");

            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.Product).WithMany(p => p.PriceHistories)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_PriceHistory_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Article).HasMaxLength(50);
            entity.Property(e => e.CertificatePicture).HasMaxLength(50);
            entity.Property(e => e.PackageSize).HasMaxLength(50);
            entity.Property(e => e.Picture).HasMaxLength(50);

            entity.HasOne(d => d.ProductStandart).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductStandartId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Product_ProductStandart");

            entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductTypeId)
                .HasConstraintName("FK_Product_ProductType");
        });

        modelBuilder.Entity<ProductApplication>(entity =>
        {
            entity.ToTable("ProductApplication");

            entity.HasOne(d => d.Application).WithMany(p => p.ProductApplications)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("FK_ProductApplication_Application");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductApplications)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductApplication_Product");
        });

        modelBuilder.Entity<ProductStandart>(entity =>
        {
            entity.ToTable("ProductStandart");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.ToTable("ProductType");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.ToTable("Sale");

            entity.Property(e => e.Sale1).HasColumnName("Sale");
        });

        modelBuilder.Entity<SaleHistory>(entity =>
        {
            entity.ToTable("SaleHistory");

            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.Product).WithMany(p => p.SaleHistories)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_SaleHistory_Product");
        });

        modelBuilder.Entity<SalePoint>(entity =>
        {
            entity.ToTable("SalePoint");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Agent).WithMany(p => p.SalePoints)
                .HasForeignKey(d => d.AgentId)
                .HasConstraintName("FK_SalePoint_Agent");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Supplier");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Tin)
                .HasMaxLength(50)
                .HasColumnName("TIN");

            entity.HasOne(d => d.CompanyType).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.CompanyTypeId)
                .HasConstraintName("FK_Supplier_CompanyType");

            entity.HasOne(d => d.MaterialHistory).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.MaterialHistoryId)
                .HasConstraintName("FK_Supplier_MaterialHistory");
        });

        modelBuilder.Entity<UnitType>(entity =>
        {
            entity.ToTable("UnitType");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Workshop>(entity =>
        {
            entity.ToTable("Workshop");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
