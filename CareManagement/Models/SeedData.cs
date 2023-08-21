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
                Guid Qualification1 = Guid.NewGuid();
                Guid Qualification2 = Guid.NewGuid();
                Guid Qualification3 = Guid.NewGuid();
                Guid Service1 = Guid.NewGuid();
                Guid Service2 = Guid.NewGuid();
                Guid Service3 = Guid.NewGuid();
                Guid e1 = Guid.NewGuid();
                Guid e2 = Guid.NewGuid();
                Guid e3 = Guid.NewGuid();
                Guid e4 = Guid.NewGuid();
                Guid e5 = Guid.NewGuid();
                Guid e6 = Guid.NewGuid();
                Guid Shift1 = Guid.NewGuid();
                Guid Shift2 = Guid.NewGuid();
                Guid Shift3 = Guid.NewGuid();
                Guid Shift4 = Guid.NewGuid();
                Guid Shift5 = Guid.NewGuid();
                Guid Shift6 = Guid.NewGuid();
                Guid Renter1 = Guid.NewGuid();
                Guid Renter2 = Guid.NewGuid();
                Guid Invoice1 = Guid.NewGuid();
                Guid Invoice2 = Guid.NewGuid();
                Guid Invoice3 = Guid.NewGuid();


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
                            ServiceId = Service1,
                            Rate = 20,
                            Hours = 2,
                            Type = "Therapy Session",
                            QualificationId = Qualification1
                        },

                        new Service
                        {
                            ServiceId = Service2,
                            Rate = 40,
                            Hours = 2,
                            Type = "Nursing",
                            QualificationId = Qualification2
                        },

                        new Service
                        {
                            ServiceId = Service3,
                            Rate = 35,
                            Hours = 4,
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
                            FirstName = "Pearlie",
                            LastName = "Huerta",
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
                            FirstName = "Ethan",
                            LastName = "Wilson",
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
                            EmployeeId = e3,
                            QualificationId = Qualification3,
                            FirstName = "Pablo",
                            LastName = "Sellers",
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
                            EmployeeId = e4,
                            QualificationId = Qualification1,
                            FirstName = "Alonzo",
                            LastName = "Carney",
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
                            EmployeeId = e5,
                            QualificationId = Qualification2,
                            FirstName = "Kara",
                            LastName = "Snow",
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
                            EmployeeId = e6,
                            QualificationId = Qualification3,
                            FirstName = "Leah",
                            LastName = "Farley",
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
                            ShiftId = Shift1,
                            EmployeeId = e1,
                            ManagerId = e1,
                            StartTime = new DateTime(2023, 4, 1, 8, 0, 0),
                            EndTime = new DateTime(2023, 4, 1, 14, 0, 0),
                            Sick = false
                        },
                        new Shift
                        {
                            ShiftId = Shift2,
                            EmployeeId = e2,
                            ManagerId = e1,
                            StartTime = new DateTime(2023, 4, 1, 8, 0, 0),
                            EndTime = new DateTime(2023, 4, 1, 14, 0, 0),
                            Sick = false
                        },
                        new Shift
                        {
                            ShiftId = Shift3,
                            EmployeeId = e3,
                            ManagerId = e1,
                            StartTime = new DateTime(2023, 4, 5, 8, 0, 0),
                            EndTime = new DateTime(2023, 4, 5, 14, 0, 0),
                            Sick = false
                        },
                        new Shift
                        {
                            ShiftId = Shift4,
                            EmployeeId = e4,
                            ManagerId = e1,
                            StartTime = new DateTime(2023, 4, 3, 12, 0, 0),
                            EndTime = new DateTime(2023, 4, 3, 20, 0, 0),
                            Sick = false
                        },
                        new Shift
                        {
                            ShiftId = Shift5,
                            EmployeeId = e5,
                            ManagerId = e1,
                            StartTime = new DateTime(2023, 4, 2, 12, 0, 0),
                            EndTime = new DateTime(2023, 4, 2, 20, 0, 0),
                            Sick = false
                        },
                        new Shift
                        {
                            ShiftId = Shift6,
                            EmployeeId = e6,
                            ManagerId = e1,
                            StartTime = new DateTime(2023, 4, 1, 12, 0, 0),
                            EndTime = new DateTime(2023, 4, 1, 20, 0, 0),
                            Sick = false
                        }
                    );
                }
                if (!context.Renter.Any())
                {
                    context.Renter.AddRange(
                        new Renter
                        {
                            RenterId = Renter1,
                            Name = "Stuart Benjamin",
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
                            RenterId = Renter2,
                            Name = "Miriam Meyers",
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
                if (!context.Schedule.Any())
                {
                    context.Schedule.AddRange(
                        new Schedule
                        {
                            StartTime = new DateTime(2023, 4, 5, 8, 0, 0),
                            EndTime = new DateTime(2023, 4, 5, 9, 30, 0),
                            RenterId = Renter2,
                            ServiceId = Service3,
                            ShiftID = Shift3
                        },
                        new Schedule
                        {
                            StartTime = new DateTime(2023, 4, 3, 15, 0, 0),
                            EndTime = new DateTime(2023, 4, 3, 17, 0, 0),
                            RenterId = Renter1,
                            ServiceId = Service1,
                            ShiftID = Shift4
                        },
                        new Schedule
                        {
                            StartTime = new DateTime(2023, 4, 2, 18, 0, 0),
                            EndTime = new DateTime(2023, 4, 2, 20, 0, 0),
                            RenterId = Renter1,
                            ServiceId = Service2,
                            ShiftID = Shift5
                        }
                        );
                }
                if (!context.Invoice.Any())
                {
                    context.Invoice.AddRange(
                        new Invoice
                        {
                            InvoiceNumber = Invoice1,
                            RenterId = Renter1,
                            StartDate = new DateTime(2023, 3, 3),
                            EndDate = new DateTime(2023, 3, 4),
                            TotalHours = 3,
                            TotalCost = 50,
                            DatePaid = new DateTime(2023, 3, 5),
                            IsSent = true,
                            DueDate = new DateTime(2023, 3, 10)
                        },

                        new Invoice
                        {
                            InvoiceNumber = Invoice2,
                            RenterId = Renter2,
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
                            RenterId = Renter2,
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

