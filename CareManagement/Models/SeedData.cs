using System;
using Microsoft.EntityFrameworkCore;
using CareManagement.Data;
using CareManagement.Models.SCHDL;
using CareManagement.Models.OM;
using CareManagement.Models.CRM;

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
                Guid q1 = Guid.NewGuid();
                Guid q2 = Guid.NewGuid();
                Guid q3 = Guid.NewGuid();
                Guid e1 = Guid.NewGuid();
                Guid e2 = Guid.NewGuid();

                if (!context.Qualification.Any())
                {
                    context.Qualification.AddRange(
                        new Qualification
                        {
                            QualificationId = q1,
                            QualificationDescription = "Certified Therapist",
                        },

                        new Qualification
                        {
                            QualificationId = q2,
                            QualificationDescription = "Certified Nurse",
                        },

                        new Qualification
                        {
                            QualificationId = q3,
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
                            QualificationId = q1
                        },

                        new Service
                        {
                            Rate = 40,
                            Hours = 6,
                            Type = "Nursing",
                            QualificationId = q2
                        },

                        new Service
                        {
                            Rate = 35,
                            Hours = 3,
                            Type = "Homecare",
                            QualificationId = q3
                        }
                    );
                }
                if (!context.Employee.Any())
                {
                    context.Employee.AddRange(
                        new Employee
                        {
                            EmployeeId = e1,
                            QualificationId = q1,
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
                            QualificationId = q2,
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
                context.SaveChanges();
                return;
            }

        }
    }
}

