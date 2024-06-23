using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using pdksApi.Core.AppHelpers.Database;
using ViewLibrary.Pdks.Dtos.Pdks.EmployeeDtos;

namespace pdksApi.DataAccess.ORM;

public partial class pdksContext : DbContext
{
    public pdksContext()
    {
    }

    public pdksContext(DbContextOptions<pdksContext> options)
        : base(options)
    {
    }

	public virtual DbSet<AccessPoint> AccessPoints { get; set; }

	public virtual DbSet<Branch> Branches { get; set; }

	public virtual DbSet<Card> Cards { get; set; }

	public virtual DbSet<City> Cities { get; set; }

	public virtual DbSet<Company> Companies { get; set; }

	public virtual DbSet<Country> Countries { get; set; }

	public virtual DbSet<County> Counties { get; set; }

	public virtual DbSet<Employee> Employees { get; set; }

	public virtual DbSet<EmployeeCard> EmployeeCards { get; set; }

	public virtual DbSet<EmployeeLanguage> EmployeeLanguages { get; set; }

	public virtual DbSet<EmployeeLeave> EmployeeLeaves { get; set; }

	public virtual DbSet<EmployeeReferance> EmployeeReferances { get; set; }

	public virtual DbSet<EmployeeTitle> EmployeeTitles { get; set; }

	public virtual DbSet<Group> Groups { get; set; }

	public virtual DbSet<Language> Languages { get; set; }

	public virtual DbSet<Level> Levels { get; set; }

	public virtual DbSet<RevisedLeave> RevisedLeaves { get; set; }

	public virtual DbSet<Role> Roles { get; set; }

	public virtual DbSet<Size> Sizes { get; set; }

	public virtual DbSet<Title> Titles { get; set; }

	public virtual DbSet<User> Users { get; set; }

	public virtual DbSet<UserRole> UserRoles { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ContextHelper.GetConnectionString(Core.Enums.ConnectionStringType.ProductionDb));

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<AccessPoint>(entity =>
		{
			entity.ToTable("AccessPoint");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Code)
				.HasMaxLength(256)
				.IsUnicode(false)
				.HasColumnName("code");
			entity.Property(e => e.Creatadate)
				.HasColumnType("datetime")
				.HasColumnName("creatadate");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.LevelId).HasColumnName("level_id");
			entity.Property(e => e.Name)
				.HasMaxLength(512)
				.IsUnicode(false)
				.HasColumnName("name");

			entity.HasOne(d => d.Level).WithMany(p => p.AccessPoints)
				.HasForeignKey(d => d.LevelId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_AccessPoint_Level");
		});

		modelBuilder.Entity<Branch>(entity =>
		{
			entity.ToTable("Branch");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Address)
				.IsUnicode(false)
				.HasColumnName("address");
			entity.Property(e => e.CompanyId).HasColumnName("company_id");
			entity.Property(e => e.CountyId).HasColumnName("county_id");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.Name)
				.HasMaxLength(2056)
				.IsUnicode(false)
				.HasColumnName("name");

			entity.HasOne(d => d.Company).WithMany(p => p.Branches)
				.HasForeignKey(d => d.CompanyId)
				.HasConstraintName("FK_Branch_Company");

			entity.HasOne(d => d.County).WithMany(p => p.Branches)
				.HasForeignKey(d => d.CountyId)
				.HasConstraintName("FK_Branch_County");
		});

		modelBuilder.Entity<Card>(entity =>
		{
			entity.ToTable("Card");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Cardno)
				.HasMaxLength(256)
				.IsUnicode(false)
				.HasColumnName("cardno");
			entity.Property(e => e.Code)
				.HasMaxLength(128)
				.IsUnicode(false)
				.HasColumnName("code");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.Cancelled).HasColumnName("cancelled");
			entity.Property(e => e.Name)
				.HasMaxLength(128)
				.IsUnicode(false)
				.HasColumnName("name");
			entity.Property(e => e.Cancelleddate)
				.HasColumnType("datetime")
				.HasColumnName("cancelleddate");
			entity.Property(e => e.Type).HasColumnName("type");
		});

		modelBuilder.Entity<City>(entity =>
		{
			entity.ToTable("City");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Code)
				.HasMaxLength(8)
				.IsUnicode(false)
				.HasColumnName("code");
			entity.Property(e => e.CountryId).HasColumnName("country_id");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.Name)
				.HasMaxLength(256)
				.IsUnicode(false)
				.HasColumnName("name");

			entity.HasOne(d => d.Country).WithMany(p => p.Cities)
				.HasForeignKey(d => d.CountryId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_City_Country");
		});

		modelBuilder.Entity<Company>(entity =>
		{
			entity.ToTable("Company");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Address)
				.IsUnicode(false)
				.HasColumnName("address");
			entity.Property(e => e.CountyId).HasColumnName("county_id");
			entity.Property(e => e.Detail)
				.HasColumnType("text")
				.HasColumnName("detail");
			entity.Property(e => e.Email)
				.HasMaxLength(256)
				.HasColumnName("email");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.Name)
				.HasMaxLength(2056)
				.IsUnicode(false)
				.HasColumnName("name");
			entity.Property(e => e.Phone)
				.HasMaxLength(24)
				.IsUnicode(false)
				.HasColumnName("phone");
		});

		modelBuilder.Entity<Country>(entity =>
		{
			entity.ToTable("Country");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Code)
				.HasMaxLength(3)
				.IsUnicode(false)
				.HasColumnName("code");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.Name)
				.HasMaxLength(256)
				.IsUnicode(false)
				.HasColumnName("name");
		});

		modelBuilder.Entity<County>(entity =>
		{
			entity.ToTable("County");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.CityId).HasColumnName("city_id");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.Name)
				.HasMaxLength(256)
				.IsUnicode(false)
				.HasColumnName("name");

			entity.HasOne(d => d.City).WithMany(p => p.Counties)
				.HasForeignKey(d => d.CityId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_County_City");
		});

		modelBuilder.Entity<Employee>(entity =>
		{
			entity.ToTable("Employee");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Address)
				.IsUnicode(false)
				.HasColumnName("address");
			entity.Property(e => e.Birthdate)
				.HasColumnType("date")
				.HasColumnName("birthdate");
			entity.Property(e => e.BranchId).HasColumnName("branch_id");
			entity.Property(e => e.CountyId).HasColumnName("county_id");
			entity.Property(e => e.Detail)
				.HasColumnType("text")
				.HasColumnName("detail");
			entity.Property(e => e.Email)
				.HasMaxLength(256)
				.IsUnicode(false)
				.HasColumnName("email");
			entity.Property(e => e.Gender).HasColumnName("gender");
			entity.Property(e => e.Identityno)
				.HasMaxLength(11)
				.IsUnicode(false)
				.HasColumnName("identityno");
			entity.Property(e => e.Image)
				.HasMaxLength(256)
				.IsUnicode(false)
				.HasColumnName("image");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.Name)
				.HasMaxLength(256)
				.IsUnicode(false)
				.HasColumnName("name");
			entity.Property(e => e.Phone)
				.HasMaxLength(24)
				.IsUnicode(false)
				.HasColumnName("phone");
			entity.Property(e => e.Servicedetail)
				.HasMaxLength(512)
				.IsUnicode(false)
				.HasColumnName("servicedetail");
			entity.Property(e => e.Surname)
				.HasMaxLength(256)
				.IsUnicode(false)
				.HasColumnName("surname");

			entity.HasOne(d => d.Branch).WithMany(p => p.Employees)
				.HasForeignKey(d => d.BranchId)
				.HasConstraintName("FK_Employee_Branch");

			entity.HasOne(d => d.Counties).WithMany(p => p.Employees)
				.HasForeignKey(d => d.CountyId)
				.HasConstraintName("FK_Employee_County");
		});

		modelBuilder.Entity<EmployeeCard>(entity =>
		{
			entity.ToTable("EmployeeCard");

			entity.Property(e => e.Id)
				.ValueGeneratedNever()
				.HasColumnName("id");
			entity.Property(e => e.CardId).HasColumnName("card_id");
			entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
			entity.Property(e => e.EndDate)
				.HasColumnType("datetime")
				.HasColumnName("end_date");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.StartDate)
				.HasColumnType("datetime")
				.HasColumnName("start_date");
			entity.Property(e => e.Status).HasColumnName("status");

			entity.HasOne(d => d.Card).WithMany(p => p.EmployeeCards)
				.HasForeignKey(d => d.CardId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_EmployeeCard_Card");

			entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeCards)
				.HasForeignKey(d => d.EmployeeId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_EmployeeCard_Employee");
		});

		modelBuilder.Entity<EmployeeLanguage>(entity =>
		{
			entity.ToTable("EmployeeLanguage");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Createdate)
				.HasColumnType("datetime")
				.HasColumnName("createdate");
			entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.LanguageId).HasColumnName("language_id");

			entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeLanguages)
				.HasForeignKey(d => d.EmployeeId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_EmployeeLanguage_Employee");

			entity.HasOne(d => d.Language).WithMany(p => p.EmployeeLanguages)
				.HasForeignKey(d => d.LanguageId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_EmployeeLanguage_Language");
		});

		modelBuilder.Entity<EmployeeLeave>(entity =>
		{
			entity.ToTable("EmployeeLeave");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Approvedate)
				.HasColumnType("datetime")
				.HasColumnName("approvedate");
			entity.Property(e => e.Createdate)
				.HasColumnType("datetime")
				.HasColumnName("createdate");
			entity.Property(e => e.Detail)
				.HasColumnType("text")
				.HasColumnName("detail");
			entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
			entity.Property(e => e.Enddate)
				.HasColumnType("datetime")
				.HasColumnName("enddate");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.Revise).HasColumnName("revise");
			entity.Property(e => e.Startdate)
				.HasColumnType("datetime")
				.HasColumnName("startdate");
			entity.Property(e => e.Statu).HasColumnName("statu");

			entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeLeaves)
				.HasForeignKey(d => d.EmployeeId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_EmployeeLeave_Employee");
		});

		modelBuilder.Entity<EmployeeReferance>(entity =>
		{
			entity
				.HasNoKey()
				.ToTable("EmployeeReferance");

			entity.Property(e => e.Email)
				.HasMaxLength(512)
				.IsUnicode(false)
				.HasColumnName("email");
			entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
			entity.Property(e => e.Id)
				.ValueGeneratedOnAdd()
				.HasColumnName("id");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.Name)
				.HasMaxLength(512)
				.IsUnicode(false)
				.HasColumnName("name");
			entity.Property(e => e.Phone)
				.HasMaxLength(24)
				.IsUnicode(false)
				.HasColumnName("phone");

			entity.HasOne(d => d.Employee).WithMany()
				.HasForeignKey(d => d.EmployeeId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_EmployeeReferance_Employee");
		});

		modelBuilder.Entity<EmployeeTitle>(entity =>
		{
			entity.ToTable("EmployeeTitle");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Createdate)
				.HasColumnType("datetime")
				.HasColumnName("createdate");
			entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.TitleId).HasColumnName("title_id");

			entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeTitles)
				.HasForeignKey(d => d.EmployeeId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_EmployeeTitle_Employee");

			entity.HasOne(d => d.Title).WithMany(p => p.EmployeeTitles)
				.HasForeignKey(d => d.TitleId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_EmployeeTitle_Title");
		});

		modelBuilder.Entity<Group>(entity =>
		{
			entity.ToTable("Group");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Createdate)
				.HasColumnType("datetime")
				.HasColumnName("createdate");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.Name)
				.HasMaxLength(512)
				.IsUnicode(false)
				.HasColumnName("name");
		});

		modelBuilder.Entity<Language>(entity =>
		{
			entity.ToTable("Language");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Code)
				.HasMaxLength(2)
				.IsUnicode(false)
				.HasColumnName("code");
			entity.Property(e => e.Flag)
				.HasMaxLength(512)
				.IsUnicode(false)
				.HasColumnName("flag");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.Name)
				.HasMaxLength(128)
				.IsUnicode(false)
				.HasColumnName("name");
		});

		modelBuilder.Entity<Level>(entity =>
		{
			entity.ToTable("Level");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Createdate)
				.HasColumnType("datetime")
				.HasColumnName("createdate");
			entity.Property(e => e.GroupId).HasColumnName("group_id");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.Name)
				.HasMaxLength(512)
				.IsUnicode(false)
				.HasColumnName("name");

			entity.HasOne(d => d.Group).WithMany(p => p.Levels)
				.HasForeignKey(d => d.GroupId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Level_Group");
		});

		modelBuilder.Entity<RevisedLeave>(entity =>
		{
			entity.ToTable("RevisedLeave");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Datail)
				.HasColumnType("text")
				.HasColumnName("datail");
			entity.Property(e => e.EmployeeleaveId).HasColumnName("employeeleave_id");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.Reviseddate)
				.HasColumnType("datetime")
				.HasColumnName("reviseddate");

			entity.HasOne(d => d.Employeeleave).WithMany(p => p.RevisedLeaves)
				.HasForeignKey(d => d.EmployeeleaveId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_RevisedLeave_EmployeeLeave");
		});

		modelBuilder.Entity<Role>(entity =>
		{
			entity.ToTable("Role");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Createdate)
				.HasColumnType("datetime")
				.HasColumnName("createdate");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.Name)
				.HasMaxLength(256)
				.IsUnicode(false)
				.HasColumnName("name");
		});

		modelBuilder.Entity<Size>(entity =>
		{
			entity.ToTable("Size");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Code)
				.HasMaxLength(128)
				.IsUnicode(false)
				.HasColumnName("code");
			entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.Name)
				.HasMaxLength(64)
				.IsUnicode(false)
				.HasColumnName("name");

			entity.HasOne(d => d.Employee).WithMany(p => p.Sizes)
				.HasForeignKey(d => d.EmployeeId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Size_Employee");
		});

		modelBuilder.Entity<Title>(entity =>
		{
			entity.ToTable("Title");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Code)
				.HasMaxLength(128)
				.IsUnicode(false)
				.HasColumnName("code");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.Name)
				.HasMaxLength(512)
				.IsUnicode(false)
				.HasColumnName("name");
		});

		modelBuilder.Entity<User>(entity =>
		{
			entity.ToTable("User");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Createdate)
				.HasColumnType("datetime")
				.HasColumnName("createdate");
			entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
			entity.Property(e => e.Enddate)
				.HasColumnType("datetime")
				.HasColumnName("enddate");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.Password)
				.HasMaxLength(16)
				.IsUnicode(false)
				.HasColumnName("password");
			entity.Property(e => e.Startdate)
				.HasColumnType("datetime")
				.HasColumnName("startdate");
			entity.Property(e => e.Username)
				.HasMaxLength(32)
				.IsUnicode(false)
				.HasColumnName("username");

			entity.HasOne(d => d.Employee).WithMany(p => p.Users)
				.HasForeignKey(d => d.EmployeeId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_User_Employee");
		});

		modelBuilder.Entity<UserRole>(entity =>
		{
			entity.ToTable("UserRole");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Createdate)
				.HasColumnType("datetime")
				.HasColumnName("createdate");
			entity.Property(e => e.CreateduserId).HasColumnName("createduser_id");
			entity.Property(e => e.Isactive).HasColumnName("isactive");
			entity.Property(e => e.Isdelete).HasColumnName("isdelete");
			entity.Property(e => e.RoleId).HasColumnName("role_id");
			entity.Property(e => e.UserId).HasColumnName("user_id");

			entity.HasOne(d => d.Createduser).WithMany(p => p.UserRoleCreatedusers)
				.HasForeignKey(d => d.CreateduserId)
				.HasConstraintName("FK_UserRole_User3");

			entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
				.HasForeignKey(d => d.RoleId)
				.HasConstraintName("FK_UserRole_Role");

			entity.HasOne(d => d.User).WithMany(p => p.UserRoleUsers)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("FK_UserRole_User2");
		});

		OnModelCreatingPartial(modelBuilder);
	}


	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


	public DbSet<ViewLibrary.Pdks.Dtos.Pdks.EmployeeDtos.EmployeeAddDto> EmployeeAddDto { get; set; } = default!;
}
