using Prova1.Application.Features.Products.Commands;
using Prova1.Domain;
using Prova1.Domain.Products;
using System;

namespace Prova1.Common.Tests.Features.ObjectMothers
{
    public static partial class ObjectMother
    {
        public static Product GetProductValid()
        {
            return new Product()
            {
                Id = 1,
                Name = "test",
                IsAvailable = false,
                Expense = 20,
                Expiration = DateTime.Now,
                Manufacture = DateTime.Now.AddMonths(-1),
                Sale = 50
            };
        }

        public static ProductRegisterCommand GetProductValidToRegister()
        {
            return new ProductRegisterCommand()
            {
                Name = "test",
                IsAvailable = false,
                Expense = 20,
                Expiration = DateTime.Now,
                Manufacture = DateTime.Now.AddMonths(-1),
                Sale = 50
            };
        }

        public static ProductRemoveCommand GetProductValidToRemove()
        {
            return new ProductRemoveCommand()
            {
                Id = 1,
            };
        }

        public static ProductUpdateCommand GetProductValidToUpdate()
        {
            return new ProductUpdateCommand()
            {
                Id = 1,
                Name = "test update",
                IsAvailable = false,
                Expense = 20,
                Expiration = DateTime.Now.ToString("o"),
                Manufacture = DateTime.Now.AddMonths(-1).ToString("o"),
                Sale = 50
            };
        }
    }
}
