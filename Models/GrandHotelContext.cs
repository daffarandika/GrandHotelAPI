using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GrandHotelAPI.Models;

public partial class GrandHotelContext : DbContext
{
    public GrandHotelContext()
    {
    }

    public GrandHotelContext(DbContextOptions<GrandHotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CleaningRoom> CleaningRooms { get; set; }

    public virtual DbSet<CleaningRoomDetail> CleaningRoomDetails { get; set; }

    public virtual DbSet<CleaningRoomItem> CleaningRoomItems { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DTime> DTimes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemStatus> ItemStatuses { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<ReservationCheckOut> ReservationCheckOuts { get; set; }

    public virtual DbSet<ReservationRequestItem> ReservationRequestItems { get; set; }

    public virtual DbSet<ReservationRoom> ReservationRooms { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-GHNE639;Initial Catalog=GrandHotel;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CleaningRoom>(entity =>
        {
            entity.ToTable("CleaningRoom");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            entity.HasOne(d => d.Employee).WithMany(p => p.CleaningRooms)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CleaningRoom_Employee");
        });

        modelBuilder.Entity<CleaningRoomDetail>(entity =>
        {
            entity.ToTable("CleaningRoomDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CleaningRoomId).HasColumnName("CleaningRoomID");
            entity.Property(e => e.FinishDateTime).HasColumnType("datetime");
            entity.Property(e => e.Note).HasColumnType("text");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.StartDateTime).HasColumnType("datetime");
            entity.Property(e => e.StatusCleaning)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CleaningRoom).WithMany(p => p.CleaningRoomDetails)
                .HasForeignKey(d => d.CleaningRoomId)
                .HasConstraintName("FK_CleaningRoomDetail_CleaningRoom");

            entity.HasOne(d => d.Room).WithMany(p => p.CleaningRoomDetails)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CleaningRoomDetail_Room");
        });

        modelBuilder.Entity<CleaningRoomItem>(entity =>
        {
            entity.ToTable("CleaningRoomItem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CleaningRoomDetailId).HasColumnName("CleaningRoomDetailID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CleaningRoomDetail).WithMany(p => p.CleaningRoomItems)
                .HasForeignKey(d => d.CleaningRoomDetailId)
                .HasConstraintName("FK_CleaningRoomItem_CleaningRoomDetail");

            entity.HasOne(d => d.Item).WithMany(p => p.CleaningRoomItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CleaningRoomItem_Item");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nik)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NIK");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DTime>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dTime");

            entity.Property(e => e.DateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.JobId).HasColumnName("JobID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Job).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Job");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("Item");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItemStatus>(entity =>
        {
            entity.ToTable("ItemStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.ToTable("Job");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.ToTable("Reservation");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DateTime).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservation_Customer");

            entity.HasOne(d => d.Employee).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservation_Employee");
        });

        modelBuilder.Entity<ReservationCheckOut>(entity =>
        {
            entity.ToTable("ReservationCheckOut");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.ItemStatusId).HasColumnName("ItemStatusID");
            entity.Property(e => e.ReservationRoomId).HasColumnName("ReservationRoomID");

            entity.HasOne(d => d.Item).WithMany(p => p.ReservationCheckOuts)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservationCheckOut_Item");

            entity.HasOne(d => d.ItemStatus).WithMany(p => p.ReservationCheckOuts)
                .HasForeignKey(d => d.ItemStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservationCheckOut_ItemStatus");

            entity.HasOne(d => d.ReservationRoom).WithMany(p => p.ReservationCheckOuts)
                .HasForeignKey(d => d.ReservationRoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservationCheckOut_ReservationRoom");
        });

        modelBuilder.Entity<ReservationRequestItem>(entity =>
        {
            entity.ToTable("ReservationRequestItem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.ReservationRoomId).HasColumnName("ReservationRoomID");
        });

        modelBuilder.Entity<ReservationRoom>(entity =>
        {
            entity.ToTable("ReservationRoom");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CheckInDateTime).HasColumnType("datetime");
            entity.Property(e => e.CheckOutDateTime).HasColumnType("datetime");
            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.StartDateTime).HasColumnType("date");

            entity.HasOne(d => d.Room).WithMany(p => p.ReservationRooms)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservationRoom_Room");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("Room");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.RoomFloor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");

            entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Room_RoomType");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.ToTable("RoomType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Capacity)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
