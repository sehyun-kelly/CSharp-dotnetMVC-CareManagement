using System;
using Microsoft.EntityFrameworkCore;
using CareManagement.Data;
using CareManagement.Models.SCHDL;

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
                Guid Invoice1 = Guid.NewGuid();
                Guid Invoice2 = Guid.NewGuid();
                Guid Invoice3 = Guid.NewGuid();

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

