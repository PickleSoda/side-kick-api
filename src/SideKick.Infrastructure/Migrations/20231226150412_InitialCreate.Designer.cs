﻿// <auto-generated />
using System;
using SideKick.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SideKick.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231226150412_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("SideKick.Domain.Reminders.Reminder", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDismissed")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("SubscriptionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("SideKick.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("_dismissedReminderIds")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("DismissedReminderIds");

                    b.Property<string>("_reminderIds")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("ReminderIds");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SideKick.Domain.Users.User", b =>
                {
                    b.OwnsOne("SideKick.Domain.Subscriptions.Subscription", "Subscription", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("Id")
                                .HasColumnType("TEXT")
                                .HasColumnName("SubscriptionId");

                            b1.Property<string>("SubscriptionType")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("SideKick.Domain.Users.Calendar", "_calendar", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("_calendar")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("CalendarDictionary");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Subscription")
                        .IsRequired();

                    b.Navigation("_calendar");
                });
#pragma warning restore 612, 618
        }
    }
}
