using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityReposiyoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
           var context = new NorthwindContext();

            var result = from operationClaim in context.OperationClaims
                         join userOperationClaim in context.UserOperationClaims
                         on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim
                         {
                             Id = operationClaim.Id,
                             Name = operationClaim.Name,
                         };
            return result.ToList();
        }
    }
}
