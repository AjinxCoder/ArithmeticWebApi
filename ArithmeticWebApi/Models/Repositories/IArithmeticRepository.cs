using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArithmeticWebApi.Models.Repositories
{
    public interface IArithmeticRepository
    {
        Task<decimal> Add(Arithmetic arithmetic);
        Task<decimal> Substract(Arithmetic arithmetic);
        Task<decimal> Multiply(Arithmetic arithmetic);
        Task<decimal> Divide(Arithmetic arithmetic);
        Task<IEnumerable<Arithmetic>> GetByCount(int count);
        Task<Arithmetic> Create(Arithmetic arithmetic);
    }
}
