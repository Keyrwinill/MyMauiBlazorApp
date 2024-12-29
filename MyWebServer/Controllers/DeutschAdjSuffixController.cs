using DataAccessLibrary.Models;     //+20241229
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebServer.Controllers
{
    //[Route("api/[controller]")]     //-20241229
    [Route("[controller]")]     //-20241229
    [ApiController]
    public class DeutschAdjSuffixController : ControllerBase
    {
        private readonly MypersonaldbContext _mypersonaldbContext;      //+20241229

        // GET: api/<DeutschAdjSuffixController>
        //+>>20241229
        public DeutschAdjSuffixController(MypersonaldbContext mypersonaldbContext)
        {
            _mypersonaldbContext = mypersonaldbContext;
        }
        //+<<20241229

        [HttpGet]
        //+>>20241229
        public ActionResult<IEnumerable<DeutschAdjSuffix>> Get()
        {
            return _mypersonaldbContext.DeutschAdjSuffixes;
        }
        //+<<20241229
        //->>20241229
        /*
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */
        //-<<20241229

        // GET api/<DeutschAdjSuffixController>/5
        [HttpGet("{id}")]
        //+>>20241229
        public ActionResult<IEnumerable<DeutschAdjSuffix>> Get(Guid id)
        {
            var res = (from data in _mypersonaldbContext.DeutschAdjSuffixes
                       where data.Oid == id
                       select GetSuffixInfo(data));

            if (res.Any())
            {
                return Ok(res);
            }
            else
            {
                return NotFound("No correspond data!");
            }
        }
        //+<<20241229
        //->>20241229
        /*
        public string Get(int id)
        {
            return "value";
        }
        */
        //-<<20241229

        // POST api/<DeutschAdjSuffixController>
        [HttpPost]
        //+>>20241229
        public ActionResult<IEnumerable<DeutschAdjSuffix>> Post([FromBody] DeutschAdjSuffix value)
        {
            _mypersonaldbContext.DeutschAdjSuffixes.Add(value);
            _mypersonaldbContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = value.Oid }, value);
        }
        //+<<20241229
        //->>20241229
        /*
        public void Post([FromBody] string value)
        {
        }
        */
        //-<<20241229

        // PUT api/<DeutschAdjSuffixController>/5
        [HttpPut("{id}")]
        //+>>20241229
        public IActionResult Put(Guid oid, [FromBody] DeutschAdjSuffix deutschAdjSuffix)
        {
            if (oid != deutschAdjSuffix.Oid)
            {
                return BadRequest();
            }

            _mypersonaldbContext.Entry(deutschAdjSuffix).State = EntityState.Modified;

            try
            {
                _mypersonaldbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_mypersonaldbContext.DeutschAdjSuffixes.Any(e => e.Oid == oid))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, "Service Error");
                }
            }
            return NoContent();
        }
        //+<<20241229
        //->>20241229
        /*
        public void Put(int id, [FromBody] string value)
        {
        }
        */
        //-<<20241229

        // DELETE api/<DeutschAdjSuffixController>/5
        [HttpDelete("{id}")]
        //->>20241229
        /*
        public void Delete(int id)
        {
        }
        */
        //-<<20241229
        //+>>20241229
        public IActionResult Delete(Guid oid)
        {
            var data = _mypersonaldbContext.DeutschAdjSuffixes.Find(oid);
            if (data == null)
            {
                return NotFound();
            }
            _mypersonaldbContext.DeutschAdjSuffixes.Remove(data);
            _mypersonaldbContext.SaveChanges();
            return NoContent();
        }
        private static DeutschAdjSuffix GetSuffixInfo(DeutschAdjSuffix adjSuffix)
        {
            return new DeutschAdjSuffix
            {
                Oid = adjSuffix.Oid,
                Gender = adjSuffix.Gender,
                GermanCase = adjSuffix.GermanCase,
                Type = adjSuffix.Type,
            };
        }
        //+<<20241229
    }
}
