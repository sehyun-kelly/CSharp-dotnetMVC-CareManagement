using System;
using Microsoft.EntityFrameworkCore;
using CareManagement.Data;
using CareManagement.Models.SCHDL;
using CareManagement.Models.OM;
using CareManagement.Models.CRM;
using CareManagement.Models.AUTH;
using Microsoft.AspNetCore.Identity;

namespace CareManagement.Models
{
	public static class SeedData
	{
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CareManagementContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CareManagementContext>>()))
            {
                IPasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
                ILookupNormalizer normalizer = new UpperInvariantLookupNormalizer();

                Guid Qualification1 = Guid.NewGuid();
                Guid Qualification2 = Guid.NewGuid();
                Guid Qualification3 = Guid.NewGuid();
                Guid e1 = Guid.NewGuid();
                Guid e2 = Guid.NewGuid();
                Guid Invoice1 = Guid.NewGuid();
                Guid Invoice2 = Guid.NewGuid();
                Guid Invoice3 = Guid.NewGuid();

                if (!context.AppUser.Any())
                {
                    AppUser user1 = new AppUser
                    {
                        UserName = "admin",
                        Email = "admin@test.com",
                        NormalizedUserName = normalizer.NormalizeName("admin"),
                        NormalizedEmail = normalizer.NormalizeEmail("admin@test.com")
                    };
                    user1.PasswordHash = passwordHasher.HashPassword(user1, "Admin_123");
                    AppUser user2 = new AppUser
                    {
                        UserName = "user",
                        Email = "user@test.com",
                        NormalizedUserName = normalizer.NormalizeName("user"),
                        NormalizedEmail = normalizer.NormalizeEmail("user@test.com")
                    };
                    user2.PasswordHash = passwordHasher.HashPassword(user2, "User_123");
                    context.AppUser.AddRange(
                        user1,
                        user2
                    );
                }
                if (!context.Qualification.Any())
                {
                    context.Qualification.AddRange(
                        new Qualification
                        {
                            QualificationId = Qualification1,
                            QualificationDescription = "Certified Therapist",
                        },

                        new Qualification
                        {
                            QualificationId = Qualification2,
                            QualificationDescription = "Certified Nurse",
                        },

                        new Qualification
                        {
                            QualificationId = Qualification3,
                            QualificationDescription = "Certified Consultant",
                        }
                    );
                }
                if (!context.Service.Any())
                {
                    context.Service.AddRange(
                        new Service
                        {
                            Rate = 20,
                            Hours = 2,
                            Type = "Therapy Session",
                            QualificationId = Qualification1
                        },

                        new Service
                        {
                            Rate = 40,
                            Hours = 6,
                            Type = "Nursing",
                            QualificationId = Qualification2
                        },

                        new Service
                        {
                            Rate = 35,
                            Hours = 3,
                            Type = "Homecare",
                            QualificationId = Qualification3
                        }
                    );
                }
                if (!context.Employee.Any())
                {
                    context.Employee.AddRange(
                        new Employee
                        {
                            EmployeeId = e1,
                            QualificationId = Qualification1,
                            FirstName = "Bruce",
                            LastName = "Wayne",
                            Address = "1234 BCIT st, Burnaby, BC",
                            EmergencyContact = 1,
                            Phone = "111-111-1111",
                            EmployeeType = OM.Enum.EType.Full_time,
                            PayRate = 35.35F,
                            PayType = OM.Enum.PaymentType.Hourly,
                            VacationDays = 14,
                            EmployeeStatus = OM.Enum.EStatus.Layoff,
                            SickDays = 4,
                            Title = OM.Enum.EmployeeTitle.Nurse,
                            StartDate = DateTime.Now
                        },
                        new Employee
                        {
                            EmployeeId = e2,
                            QualificationId = Qualification2,
                            FirstName = "Tony",
                            LastName = "Stark",
                            Address = "1234 BCIT st, Burnaby, BC",
                            EmergencyContact = 1,
                            Phone = "111-111-1111",
                            EmployeeType = OM.Enum.EType.Full_time,
                            PayRate = 35.35F,
                            PayType = OM.Enum.PaymentType.Hourly,
                            VacationDays = 14,
                            EmployeeStatus = OM.Enum.EStatus.Layoff,
                            SickDays = 4,
                            Title = OM.Enum.EmployeeTitle.Nurse,
                            StartDate = DateTime.Now
                        }
                    );
                }
                if (!context.Shift.Any())
                {
                    context.Shift.AddRange(
                        new Shift
                        {
                            EmployeeId = e1,
                            ManagerId = e1,
                            StartTime = new DateTime(2023, 3, 31, 8, 0, 0),
                            EndTime = new DateTime(2023, 3, 31, 16, 0, 0),
                            Sick = false
                        },
                        new Shift
                        {
                            EmployeeId = e2,
                            ManagerId = e2,
                            StartTime = new DateTime(2023, 3, 31, 12, 0, 0),
                            EndTime = new DateTime(2023, 3, 31, 20, 0, 0),
                            Sick = false
                        }
                    );
                }
                if (!context.Renter.Any())
                {
                    context.Renter.AddRange(
                        new Renter
                        {
                            Name = "Albert Dumbledore",
                            Age = 142,
                            Gender = "Male",
                            Address = "Hogwart",
                            ContactingNumber = "111-111-1111",
                            EmergencyContactingNumber = "111-111-1111",
                            FamilyDoctor = "Poppy Pomfrey",
                            SharingInfo = "No Voldmort",
                            Income = 3124500,
                            Employer = "World of Magic",
                            Email = "dumbledore@hogwarts.edu",
                            RmNumber = 245
                        },
                        new Renter
                        {
                            Name = "Minerva McGonagall",
                            Age = 71,
                            Gender = "Female",
                            Address = "Hogwart",
                            ContactingNumber = "111-111-1111",
                            EmergencyContactingNumber = "111-111-1111",
                            FamilyDoctor = "Poppy Pomfrey",
                            SharingInfo = "No Voldmort",
                            Income = 3124500,
                            Employer = "World of Magic",
                            Email = "dumbledore@hogwarts.edu",
                            RmNumber = 245
                        }
                        );
                }
                if (!context.Invoice.Any())
                {
                    context.Invoice.AddRange(
                        new Invoice
                        {
                            InvoiceNumber = Invoice1,
                            StartDate = new DateTime(2023,3,3),
                            EndDate = new DateTime(2023,3,4),
                            TotalHours = 3,
                            TotalCost = 50,
                            DatePaid = new DateTime(2023, 3, 5),
                            IsSent= true,
                            DueDate= new DateTime(2023, 3, 10)
                        },

                        new Invoice
                        {
                            InvoiceNumber = Invoice2,
                            StartDate = new DateTime(2023, 4, 3),
                            EndDate = new DateTime(2023, 4, 4),
                            TotalHours = 7,
                            TotalCost = 500,
                            DatePaid = new DateTime(2023, 4, 5),
                            IsSent = false,
                            DueDate = new DateTime(2023, 4, 10)
                        },

                        new Invoice
                        {
                            InvoiceNumber = Invoice3,
                            StartDate = new DateTime(2023, 5, 3),
                            EndDate = new DateTime(2023, 5, 4),
                            TotalHours = 9,
                            TotalCost = 90,
                            DatePaid = new DateTime(2023, 5, 5),
                            IsSent = true,
                            DueDate = new DateTime(2023, 5, 10)
                        }
                    );
                }
                context.SaveChanges();
                return;
            }

        }
    }
}

