using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp
{
    public class SmsDbContext : DbContext
    {
        public SmsDbContext() { }

        public SmsDbContext(DbContextOptions<SmsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TwilioSmsModel> TwilioSmsModels { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<SmsModel>().HasData(
        //        new SmsModel {
        //            Sid =  "a101",
        //            MessageBody ="hi there",
        //            DeliveryStatus =SmsDelieveryStatus.New,
        //            SmsPhoneNumber ="4081112222",SmsSentDateTime=DateTime.Now
        //        });


        //}
    }
}
