using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GG.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<Reciperequest> Reciperequests { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Testimonial> Testimonials { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("USER ID=C##ALI;PASSWORD=00000;DATA SOURCE=localhost:1521/xe");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("C##ALI")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("SYS_C008475");

            entity.ToTable("CATEGORIES");

            entity.Property(e => e.Categoryid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CATEGORYID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.Recipeid).HasName("SYS_C008477");

            entity.ToTable("RECIPES");

            entity.Property(e => e.Recipeid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("RECIPEID");
            entity.Property(e => e.Approvalstatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APPROVALSTATUS");
            entity.Property(e => e.Categoryid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CATEGORYID");
            entity.Property(e => e.Chefid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CHEFID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Imagefile)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IMAGEFILE");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TITLE");

            entity.HasOne(d => d.Category).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.Categoryid)
                .HasConstraintName("SYS_C008479");

            entity.HasOne(d => d.Chef).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.Chefid)
                .HasConstraintName("SYS_C008478");
        });

        modelBuilder.Entity<Reciperequest>(entity =>
        {
            entity.HasKey(e => e.Requestid).HasName("SYS_C008481");

            entity.ToTable("RECIPEREQUESTS");

            entity.Property(e => e.Requestid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("REQUESTID");
            entity.Property(e => e.Recipeid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("RECIPEID");
            entity.Property(e => e.Requestdate)
                .HasColumnType("DATE")
                .HasColumnName("REQUESTDATE");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USERID");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Reciperequests)
                .HasForeignKey(d => d.Recipeid)
                .HasConstraintName("SYS_C008483");

            entity.HasOne(d => d.User).WithMany(p => p.Reciperequests)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("SYS_C008482");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("SYS_C008469");

            entity.ToTable("ROLES");

            entity.Property(e => e.Roleid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ROLEID");
            entity.Property(e => e.Rolename)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROLENAME");
        });

        modelBuilder.Entity<Testimonial>(entity =>
        {
            entity.HasKey(e => e.Testimonialid).HasName("SYS_C008485");

            entity.ToTable("TESTIMONIALS");

            entity.Property(e => e.Testimonialid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TESTIMONIALID");
            entity.Property(e => e.Content)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CONTENT");
            entity.Property(e => e.Recipeid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("RECIPEID");
            entity.Property(e => e.Testimonialdate)
                .HasColumnType("DATE")
                .HasColumnName("TESTIMONIALDATE");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USERID");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Testimonials)
                .HasForeignKey(d => d.Recipeid)
                .HasConstraintName("SYS_C008487");

            entity.HasOne(d => d.User).WithMany(p => p.Testimonials)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("SYS_C008486");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Transactionid).HasName("SYS_C008489");

            entity.ToTable("TRANSACTIONS");

            entity.Property(e => e.Transactionid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TRANSACTIONID");
            entity.Property(e => e.Amount)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("AMOUNT");
            entity.Property(e => e.Paymentdate)
                .HasColumnType("DATE")
                .HasColumnName("PAYMENTDATE");
            entity.Property(e => e.Paymentstatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PAYMENTSTATUS");
            entity.Property(e => e.Recipeid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("RECIPEID");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USERID");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.Recipeid)
                .HasConstraintName("SYS_C008491");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("SYS_C008490");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("SYS_C008471");

            entity.ToTable("USERS");

            entity.HasIndex(e => e.Username, "SYS_C008472").IsUnique();

            entity.Property(e => e.Userid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USERID");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Imagefile)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("IMAGEFILE");
            entity.Property(e => e.Isactive)
                .HasPrecision(1)
                .HasColumnName("ISACTIVE");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Roleid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ROLEID");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USERNAME");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.Roleid)
                .HasConstraintName("SYS_C008473");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
