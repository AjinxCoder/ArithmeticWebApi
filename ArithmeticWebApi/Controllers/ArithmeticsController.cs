using ArithmeticWebApi.Models;
using ArithmeticWebApi.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArithmeticWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArithmeticsController : ControllerBase
    {
        private readonly IArithmeticRepository arithmeticRepository;
        public ArithmeticsController(IArithmeticRepository arithmeticRepository)
        {
            this.arithmeticRepository = arithmeticRepository;
        }

        [HttpGet("{count}")]
        public async Task<ActionResult<IEnumerable<Arithmetic>>> GetByCount(int count)
        {
            try
            {
                return Ok(await arithmeticRepository.GetByCount(count));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving last " + count + " records from the database");
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult<decimal>> Add(Arithmetic arithmetic)
        {
            try
            {
                if (arithmetic == null)
                {
                    return BadRequest();
                }

                var solution = await arithmeticRepository.Add(arithmetic);
                return Ok(solution);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Addition");
            }
        }

        [HttpPost("Substract")]
        public async Task<ActionResult<decimal>> Substract(Arithmetic arithmetic)
        {
            try
            {
                if (arithmetic == null)
                {
                    return BadRequest();
                }

                var solution = await arithmeticRepository.Substract(arithmetic);
                return Ok(solution);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Substraction");
            }
        }

        [HttpPost("Multiply")]
        public async Task<ActionResult<decimal>> Multiply(Arithmetic arithmetic)
        {
            try
            {
                if (arithmetic == null)
                {
                    return BadRequest();
                }

                var solution = await arithmeticRepository.Multiply(arithmetic);
                return Ok(solution);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Multiplication");
            }
        }

        [HttpPost("Divide")]
        public async Task<ActionResult<decimal>> Divide(Arithmetic arithmetic)
        {
            try
            {
                if (arithmetic == null)
                {
                    return BadRequest();
                }

                var solution = await arithmeticRepository.Divide(arithmetic);
                return Ok(solution);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Division");
            }
        }
    }
}
