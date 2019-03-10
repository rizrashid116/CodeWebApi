using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWebApi.Models;
using CodeWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeController : ControllerBase
    {
        private readonly CodeService _codeService;
        private readonly SpyService _spyService;

        public CodeController(CodeService codeService, SpyService spyService)
        {
            _codeService = codeService;
            _spyService = spyService;
        }

        [HttpGet]
        public ActionResult<List<Code>> Get()
        {
            return _codeService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetCode")]        
        public ActionResult<Code> Get(string id)
        {
            var spycode = _codeService.Get(id);

            if (spycode == null)
            {
                return NotFound();
            }

            return spycode;
        }

        [HttpGet("GetSpy")]
        public IActionResult GetSpy(string spy, string message)
        {
            var spycode = _codeService.FindCodeName(spy);
            if (spycode == null)
            {
                return NotFound();
            }

            bool findflag = _spyService.FindSpy(spycode.CodeName, message);
            return Ok(findflag);
        }

        [HttpPost]
        public ActionResult<Code> Create(Code spyCode)
        {
            _codeService.Create(spyCode);

            return CreatedAtRoute("GetCode", new { id = spyCode.Id.ToString() }, spyCode);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Code spyCodeIn)
        {
            var spycode = _codeService.Get(id);

            if (spycode == null)
            {
                return NotFound();
            }

            _codeService.Update(id, spyCodeIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var spycode = _codeService.Get(id);

            if (spycode == null)
            {
                return NotFound();
            }

            _codeService.Remove(spycode.Id);

            return NoContent();
        }
    }
}