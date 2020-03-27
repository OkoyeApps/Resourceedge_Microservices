using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Resourceedge.Appraisal.API.Interfaces;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using Resourceedge.Common.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Controllers
{
    [ApiController]
    [Route("api/corevalue")]
    public class CoreValueController : ControllerBase
    {
        private readonly ICoreValue coreValueRepo;
        private readonly IMapper mapper;

        public CoreValueController(ICoreValue _coreValueRepo, IMapper _mapper)
        {
            coreValueRepo = _coreValueRepo;
            mapper = _mapper;
        }

        [HttpGet(Name = "AllCoreValues")]
        public IActionResult Index([FromQuery]PaginationResourceParameter pagination)
        {
            var data = coreValueRepo.Get(pagination);
            var resultForView = mapper.Map<IEnumerable<CoreValueKRAForViewDto>>(data);

            return Ok(resultForView);
        }

        [HttpGet("{Id}", Name = "CoreValue")]
        public IActionResult GetCoreValue(string Id)
        {
            ObjectId objId = new ObjectId(Id);

            var result = coreValueRepo.GetSingle(objId);
            var resultForView = mapper.Map<CoreValueKRAForViewDto>(result);

            return Ok(resultForView);
        }
        [HttpPost]
        public IActionResult Create(IEnumerable<CoreValueForCreationDto> model)
        {
            var entityToAdd = mapper.Map<IEnumerable<CoreValuesKRA>>(model);
            coreValueRepo.Insert(entityToAdd);

            var entityToReturn = mapper.Map<IEnumerable<CoreValueForCreationDto>>(entityToAdd);

            return CreatedAtRoute("AllCoreValues", entityToReturn);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(string id, JsonPatchDocument<CoreValueForUpdateDto> updateDto)
        {
            ObjectId Id = new ObjectId(id);

            var entityToUpdate = new CoreValueForUpdateDto();
            updateDto.ApplyTo(entityToUpdate);

            var res = await coreValueRepo.UpdateCoreValue(Id, entityToUpdate);
            if(res != null)
            {
                var entityReturn = mapper.Map<CoreValueKRAForViewDto>(res);

                return CreatedAtRoute("CoreValue", new { Id = Id, entityReturn });

            }

            return NotFound();
        }

        [HttpPatch("{coreValueId}/KeyOutcome/{KeyOutcomeId}")]
        public async Task<IActionResult> UpdateKeyOutcome(int empId, string coreValueId, string KeyOutcomeId, JsonPatchDocument<KeyOutcomeForUpdateDto> entityForUpdate)
        {
            var keyOutcomeForUpdate = new KeyOutcomeForUpdateDto();
            entityForUpdate.ApplyTo(keyOutcomeForUpdate);

            ObjectId Id = new ObjectId(coreValueId);
            ObjectId keyOutcomeId = new ObjectId(KeyOutcomeId);

            var result = await coreValueRepo.UpdateCoreValueKeyOutcome(Id, keyOutcomeId, keyOutcomeForUpdate);
            if (result > 0)
            {
                return CreatedAtAction("CoreValue", new { Id = Id });
            }

            return NotFound();
        }

        public IActionResult SearchForCoreValue(PaginationResourceParameter resourceParam)
        {
            var res = coreValueRepo.GetCoreValuesSearch(resourceParam);

            var entityToReturn = mapper.Map<PagedList<CoreValueKRAForViewDto>>(res);
            return Ok(entityToReturn);
        }
    }
}
