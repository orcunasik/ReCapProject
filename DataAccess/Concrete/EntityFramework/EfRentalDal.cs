using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarDBContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarDBContext context = new CarDBContext())
            {
                var result = from rent in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join car in context.Cars
                             on rent.CarId equals car.CarId
                             join cust in context.Customers
                             on rent.CustomerId equals cust.CustomerId
                             join user in context.Users
                             on cust.CustomerId equals user.UserId
                             select new RentalDetailDto
                             {
                                 RentId =rent.RentId,
                                 CarId = car.CarId,
                                 UserName = user.FirstName + " " + user.LastName,
                                 CustomerName = cust.CompanyName,
                                 RentDate = rent.RentDate,
                                 ReturnDate = rent.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
