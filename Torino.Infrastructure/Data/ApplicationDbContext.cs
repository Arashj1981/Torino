using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Torino.Domain.Entities;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

   
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<UserFavourite> UserFavourites { get; set; }
    public DbSet<TourImage> TourImages { get; set; }
    public DbSet<Tour> Tours { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<Reservatioan> Reservatioans { get; set; }
    public DbSet<FAQ> FAQs { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<ApplicationUser>()
            .HasMany(user => user.Comments)
            .WithOne(comment => comment.User)
            .HasForeignKey(comment => comment.UserId)  
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(user => user.Reservatioans)
            .WithOne(reserv => reserv.User)
            .HasForeignKey(reserv => reserv.UserId)  
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(user => user.Surveys)
            .WithOne(surv => surv.User)
            .HasForeignKey(surv => surv.UserId)  
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(user => user.UserFavourites)
            .WithOne(userfave => userfave.User)
            .HasForeignKey(userfave => userfave.UserId) 
            .OnDelete(DeleteBehavior.Restrict);

       
        modelBuilder.Entity<Tour>()
            .HasMany(tour => tour.Comments)
            .WithOne(comment => comment.Tour)
            .HasForeignKey(comment => comment.TourId)  
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Tour>()
            .HasMany(tour => tour.UserFavourites)
            .WithOne(userfav => userfav.Tour)
            .HasForeignKey(userfav => userfav.TourId)  
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Tour>()
            .HasMany(tour => tour.Surveys)
            .WithOne(survay => survay.Tour)
            .HasForeignKey(survay => survay.TourId)  
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Tour>()
            .HasMany(tour => tour.TourImages)
            .WithOne(tourImages => tourImages.Tour)
            .HasForeignKey(tourImages => tourImages.TourId)  
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Tour>()
            .HasMany(tour => tour.Reservatioans)
            .WithOne(reservatioans => reservatioans.Tour)
            .HasForeignKey(reservatioans => reservatioans.TourId)  
            .OnDelete(DeleteBehavior.Restrict);

        
        modelBuilder.Entity<Tour>()
            .Property(t => t.Price)
            .HasPrecision(18, 2);  

        modelBuilder.Entity<Reservatioan>()
            .Property(r => r.TotalPrice)
            .HasPrecision(18, 2);  

        
        modelBuilder.Entity<Ticket>()
            .HasOne(ticket => ticket.Tour)
            .WithMany(tour => tour.Tickets)
            .HasForeignKey(ticket => ticket.TourId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Ticket>()
            .HasOne(ticket => ticket.Reservatioan)
            .WithMany(reserv => reserv.Tickets)
            .HasForeignKey(ticket => ticket.ReservatioanId)  
            .OnDelete(DeleteBehavior.Cascade);

        
        
    }
}