using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArithmeticWebApi.Models.Repositories
{
    public class ArithmeticRepository : IArithmeticRepository
    {
        private readonly ArithmeticContext context;

        public ArithmeticRepository(ArithmeticContext context)
        {
            this.context = context;
        }

        public async Task<Arithmetic> Create(Arithmetic arithmetic)
        {
            var result = await context.Arithmetics.AddAsync(arithmetic);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<Arithmetic>> GetByCount(int count)
        {
            return await context.Arithmetics.OrderByDescending(x => x.CalculatedOn).Take(count).ToListAsync();
        }

        public async Task<decimal> Add(Arithmetic arithmetic)
        {
            arithmetic.Result = arithmetic.FirstNumber + arithmetic.SecondNumber;
            arithmetic.Operator = nameof(Add);
            var arithmeticResult = await Create(arithmetic);
            
            return arithmeticResult.Result;
        }
        public async Task<decimal> Substract(Arithmetic arithmetic)
        {
            arithmetic.Result = arithmetic.FirstNumber - arithmetic.SecondNumber;
            arithmetic.Operator = nameof(Substract);
            var arithmeticResult = await Create(arithmetic);

            return arithmeticResult.Result;
        }

        public async Task<decimal> Multiply(Arithmetic arithmetic)
        {
            arithmetic.Result = Math.Round(arithmetic.FirstNumber * arithmetic.SecondNumber,2);
            arithmetic.Operator = nameof(Multiply);
            var arithmeticResult = await Create(arithmetic);

            return arithmeticResult.Result;
        }

        public async Task<decimal> Divide(Arithmetic arithmetic)
        {
            arithmetic.Result = Math.Round(arithmetic.FirstNumber / arithmetic.SecondNumber, 2);
            arithmetic.Operator = nameof(Divide);
            var arithmeticResult = await Create(arithmetic);

            return arithmeticResult.Result;
        }
    }
}
