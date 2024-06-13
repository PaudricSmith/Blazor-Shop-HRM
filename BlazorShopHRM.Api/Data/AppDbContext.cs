using Microsoft.EntityFrameworkCore;
using BlazorShopHRM.Shared.Domain;
using BlazorShopHRM.Shared.Enums;

namespace BlazorShopHRM.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<PerformanceReview> PerformanceReviews { get; set; }
        public DbSet<Announcement> Announcements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Country
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, Name = "Ireland" },
                new Country { CountryId = 2, Name = "Germany" },
                new Country { CountryId = 3, Name = "Netherlands" },
                new Country { CountryId = 4, Name = "USA" },
                new Country { CountryId = 5, Name = "Japan" },
                new Country { CountryId = 6, Name = "China" },
                new Country { CountryId = 7, Name = "UK" },
                new Country { CountryId = 8, Name = "France" },
                new Country { CountryId = 9, Name = "Brazil" }
            );

            // Seed data for JobCategory
            modelBuilder.Entity<JobCategory>().HasData(
                new JobCategory { JobCategoryId = 1, JobCategoryName = "Pie Baker" },
                new JobCategory { JobCategoryId = 2, JobCategoryName = "Pastry Chef" },
                new JobCategory { JobCategoryId = 3, JobCategoryName = "Cashier" },
                new JobCategory { JobCategoryId = 4, JobCategoryName = "Customer Service Representative" },
                new JobCategory { JobCategoryId = 5, JobCategoryName = "Store Manager" },
                new JobCategory { JobCategoryId = 6, JobCategoryName = "Delivery Driver" },
                new JobCategory { JobCategoryId = 7, JobCategoryName = "Cleaner" },
                new JobCategory { JobCategoryId = 8, JobCategoryName = "Inventory Manager" },
                new JobCategory { JobCategoryId = 9, JobCategoryName = "Marketing Specialist" }
            );

            // Seed data for Employee
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    CountryId = 1,
                    MaritalStatus = MaritalStatus.Single,
                    BirthDate = new DateTime(1979, 1, 16),
                    City = "Dublin",
                    Email = "barbara@barbaraspieshop.com",
                    FirstName = "Barbara",
                    LastName = "Smith",
                    Gender = Gender.Female,
                    PhoneNumber = "35312345677",
                    Smoker = false,
                    Street = "1 Parnell Street",
                    Zip = "D01 HR61",
                    JobCategoryId = 1,
                    Comment = "Owner of Barbaras Shop",
                    ExitDate = null,
                    JoinedDate = new DateTime(2015, 3, 1),
                    Latitude = 53.279580,
                    Longitude = -6.137590
                },
                new Employee
                {
                    EmployeeId = 2,
                    CountryId = 1,
                    MaritalStatus = MaritalStatus.Married,
                    BirthDate = new DateTime(1970, 5, 24),
                    City = "Dublin",
                    Email = "peter.bloggs@example.com",
                    FirstName = "Peter",
                    LastName = "Bloggs",
                    Gender = Gender.Male,
                    PhoneNumber = "35312345678",
                    Smoker = false,
                    Street = "15 Camden Street Lower",
                    Zip = "D02 W095",
                    JobCategoryId = 2,
                    Comment = "Dedicated and hardworking.",
                    ExitDate = null,
                    JoinedDate = new DateTime(2018, 6, 1),
                    Latitude = 53.334231,
                    Longitude = -6.264573
                }
            );

            // Seed data for Leave
            modelBuilder.Entity<Leave>().HasData(
                new Leave
                {
                    LeaveId = 1,
                    EmployeeId = 1,
                    StartDate = new DateTime(2023, 6, 1),
                    EndDate = new DateTime(2023, 6, 10),
                    LeaveType = LeaveType.Vacation,
                    Reason = "Family vacation."
                },
                new Leave
                {
                    LeaveId = 2,
                    EmployeeId = 2,
                    StartDate = new DateTime(2023, 7, 15),
                    EndDate = new DateTime(2023, 7, 20),
                    LeaveType = LeaveType.Sick,
                    Reason = "Medical leave."
                },
                new Leave
                {
                    LeaveId = 3,
                    EmployeeId = 1,
                    StartDate = new DateTime(2023, 7, 24),
                    EndDate = new DateTime(2023, 7, 29),
                    LeaveType = LeaveType.Personal,
                    Reason = "Funeral."
                },
                new Leave
                {
                    LeaveId = 4,
                    EmployeeId = 2,
                    StartDate = new DateTime(2023, 8, 25),
                    EndDate = new DateTime(2023, 8, 30),
                    LeaveType = LeaveType.Other,
                    Reason = "Prefer not to say."
                }
            );

            // Seed data for Payroll
            modelBuilder.Entity<Payroll>().HasData(
                new Payroll
                {
                    PayrollId = 1,
                    EmployeeId = 1,
                    Month = new DateTime(2023, 6, 1),
                    Amount = 2000.50m
                },
                new Payroll
                {
                    PayrollId = 2,
                    EmployeeId = 2,
                    Month = new DateTime(2023, 6, 1),
                    Amount = 2200.75m
                },
                new Payroll
                {
                    PayrollId = 3,
                    EmployeeId = 1,
                    Month = new DateTime(2023, 7, 1),
                    Amount = 2000.50m
                },
                new Payroll
                {
                    PayrollId = 4,
                    EmployeeId = 2,
                    Month = new DateTime(2023, 7, 1),
                    Amount = 2200.75m
                }
            );

            // Seed data for PerformanceReview
            modelBuilder.Entity<PerformanceReview>().HasData(
                new PerformanceReview
                {
                    PerformanceReviewId = 1,
                    EmployeeId = 1,
                    ReviewDate = new DateTime(2023, 5, 1),
                    Score = 4.5,
                    Comments = "Excellent performance"
                },
                new PerformanceReview
                {
                    PerformanceReviewId = 2,
                    EmployeeId = 2,
                    ReviewDate = new DateTime(2023, 5, 1),
                    Score = 4.0,
                    Comments = "Very good performance"
                },
                new PerformanceReview
                {
                    PerformanceReviewId = 3,
                    EmployeeId = 1,
                    ReviewDate = new DateTime(2023, 6, 1),
                    Score = 4.5,
                    Comments = "Excellent performance"
                },
                new PerformanceReview
                {
                    PerformanceReviewId = 4,
                    EmployeeId = 2,
                    ReviewDate = new DateTime(2023, 6, 1),
                    Score = 4.0,
                    Comments = "Very good performance"
                }
            );

            // Seed data for Announcement
            modelBuilder.Entity<Announcement>().HasData(
                new Announcement
                {
                    AnnouncementId = 1,
                    Title = "Office Closed",
                    Content = "The office will be closed on the 4th of July.",
                    DatePosted = new DateTime(2023, 7, 1)
                },
                new Announcement
                {
                    AnnouncementId = 2,
                    Title = "New Employee Orientation",
                    Content = "New employee orientation will be held on the 10th of July.",
                    DatePosted = new DateTime(2023, 7, 5)
                },
                new Announcement
                {
                    AnnouncementId = 3,
                    Title = "Office Closed",
                    Content = "The office will be closed on the 12th of July.",
                    DatePosted = new DateTime(2023, 7, 10)
                },
                new Announcement
                {
                    AnnouncementId = 4,
                    Title = "New Employee Orientation",
                    Content = "New employee orientation will be held on the 20th of July.",
                    DatePosted = new DateTime(2023, 7, 15)
                }
            );

            // Explicitly define relationships
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Country)
                .WithMany()
                .HasForeignKey(e => e.CountryId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.JobCategory)
                .WithMany()
                .HasForeignKey(e => e.JobCategoryId);

            modelBuilder.Entity<Leave>()
                .HasOne(l => l.Employee)
                .WithMany()
                .HasForeignKey(l => l.EmployeeId);

            modelBuilder.Entity<Payroll>()
                .HasOne(p => p.Employee)
                .WithMany()
                .HasForeignKey(p => p.EmployeeId);

            modelBuilder.Entity<PerformanceReview>()
                .HasOne(pr => pr.Employee)
                .WithMany()
                .HasForeignKey(pr => pr.EmployeeId);

            // Specify precision and scale for Payroll.Amount
            modelBuilder.Entity<Payroll>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);
        }
    }
}
