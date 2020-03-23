using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.API.Services;
using Resourceedge.Appraisal.Domain.DBContexts;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Controllers
{
    [ApiController]
    [Route("api/resultarea")]
    public class ResultAreaController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IKeyResultArea resultArea;

        public ResultAreaController(IDbContext _ctx, IMapper _mapper, IKeyResultArea _resultArea)
        {
            mapper = _mapper;
            this.resultArea = _resultArea;
        }
        public async Task<IActionResult> Index(int? pageSize, int pageNumber)
        {
            var data = await resultArea.Get(pageSize, pageNumber);
            return Ok(data);
        }


        [HttpGet("{id}", Name = "Mykpi")]
        public ActionResult<IEnumerable<KeyResultAreaDtoForCreation>> GetPersonalKpis(int id)
        {
            var resultFromMap = resultArea.GetPersonalkpis(id);
            var mapInstance = mapper.Map<IEnumerable<KeyResultAreaDtoForCreation>>(resultFromMap);
            return Ok(mapInstance);
        }

        [HttpPost(Name = "CreateKeyOutcomes")]
        public IActionResult Index(IEnumerable<KeyResultAreaDtoForCreation> model)
        {
            var entityToAdd = mapper.Map<IEnumerable<KeyResultAreaDtoForCreation>, IEnumerable<KeyResultArea>>(model);
            resultArea.AddKeyOutcomes(entityToAdd);
            return CreatedAtRoute("Mykpi", new { id = model.ToArray()[0].myId }, entityToAdd);
        }

    }
}
