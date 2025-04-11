using System.Globalization;
using System.Text.RegularExpressions;
using Medical_Insurence.Models;
using Medical_Insurence.Repositorys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Insurence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogicQuestionsController : ControllerBase
    {
        private readonly LogicQuestionsRepository _repository;

        public LogicQuestionsController(LogicQuestionsRepository repository)
        {
            _repository = repository;
        }

        //Post a query list and return the pontuation.
        [HttpPost("CalculedScore")]
        public IActionResult CalculedScore([FromBody] List<CalculedScore> situations)
        {
            var value = _repository.Calc(situations);

            //assign the result to the variable
            var result = new CalculedScoreResult { pontuacaoTotal = value };

            return Ok(result);
        }


        [HttpPost("ValidationCard")]
        public bool ValidationCard(string idCardBenef)
        {
            //search-strings
            string sPattern = @"^[A-Z]{3}-\d{6}$";

            if (Regex.IsMatch(idCardBenef, sPattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Verification of six month dates of the atend.
        [HttpPost("DateSixMonth")]
        public bool SixMonthInterval([FromBody] List<string> dates)
        {   //if no data, false.
            if(dates == null || dates.Count < 2)
            {
                return false;
            }

            //setTheDates
            DateTime dateFinal = DateTime.Parse("2000-01-01");
            DateTime dateInitial = DateTime.Parse("2000-01-01");

            //sorts and traverses the array.
            foreach (var d in dates.OrderBy(d => d))
            {
                dateInitial = DateTime.Parse(d);

                if((dateInitial - dateFinal).TotalDays > 180)
                {
                    return true;
                }

                dateFinal = dateInitial;
            }

            return false;
        }
    }
}
