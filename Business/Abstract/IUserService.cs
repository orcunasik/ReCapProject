using Core.Utilities.Results;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        //IDataResult<List<OperationClaim>> GetClaims(User user);
        //IDataResult<User> GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        IDataResult<User> GetById(int id);
        //IResult Add(User user);
        void Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
    }
}
