using Business.Concrete;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
using Core.Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //BrandTest();

            //CarTest();

            //UserTest();

            //CustomerTest();

            //RentalCarTest();

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("\nNosu \t\tMarka \t\t\tRenk \t\t\t\tGünlükFiyatı");
            var result = carManager.GetCarDetails();
            foreach (var car in result.Data)
            {
                //Console.WriteLine(car.CarId + "/ " + car.BrandName + "/ " + car.ColorName + "/ " + car.DailyPrice);
                Console.WriteLine($"{car.CarId}\t\t{car.BrandName}\t\t\t{car.ColorName}\t\t\t{car.DailyPrice}");
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var res = brandManager.GetById(4);
            if (res.Success)
            {
                Console.WriteLine("Marka---- {0}", res.Data.BrandName);
            }

            Console.Write("\nYeni Aracın Markasını Giriniz: ");
            brandManager.Add(new Brand { BrandName = (Console.ReadLine()) });
            Console.WriteLine("Yeni Aracın Markası Brands Tablosuna Eklendi, Yeni Liste:");
            Console.WriteLine("\nBrandId \tBrandName");

            var result = brandManager.GetAll();
            foreach (var brand in result.Data)
            {
                Console.WriteLine($"{brand.BrandId}\t\t{brand.BrandName}");
            }
        }

        /*private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add
                (
                new User
                {
                    FirstName = (Console.ReadLine()),
                    LastName = (Console.ReadLine()),
                    Email = (Console.ReadLine())

                }
                ); 
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }*/

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer = new Customer();
            Console.Write("\nKullanıcı Nosu: ");
            customer.UserId = int.Parse(Console.ReadLine());
            Console.Write("\nMüşteri Adınız: ");
            customer.CompanyName = Console.ReadLine();
            Console.WriteLine(customerManager.Add(customer).Message);

        }

        private static void RentalCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Car _car = new Car();
            var selectCustomer = customerManager.GetById(1);
            if (selectCustomer !=null  )
            {
                Rental rental = new Rental
                {
                    CarId = _car.CarId,
                    RentDate = DateTime.Now,
                    ReturnDate = null,
                    CustomerId = selectCustomer.Data.CustomerId
                };
                var result = rentalManager.Add(rental);
                if (result.Success)
                {
                    Console.WriteLine(result.Message);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
            }
        }

    }
}
