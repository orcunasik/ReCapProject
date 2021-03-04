using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (CheckReturnDate(rental.CarId).Success)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(CheckReturnDate(rental.CarId).Message);
            }
            return new ErrorResult(CheckReturnDate(rental.CarId).Message);
            
        }

        public IResult CheckReturnDate(int id)
        {
            var result = _rentalDal.GetRentalDetails(x => x.CarId == id && x.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.RentalInValid);
            }
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult UpdateReturnDate(int id)
        {
            var result = _rentalDal.GetAll(x => x.CarId == id);
            var updateRent = result.LastOrDefault();
            if (updateRent.ReturnDate != null)
            {
                return new ErrorResult(Messages.RentalReturnDateError);
            }
            updateRent.ReturnDate = DateTime.Now;
            _rentalDal.Update(updateRent);
            return new SuccessResult(Messages.RentalUpdatedReturnDate);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalLİsted);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x => x.RentId == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails(int id)
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(x =>x.CarId == id));
        }

    }
}
