using System;
using System.Threading.Tasks;
using Dwapi.Prep.Core.Command;
using Dwapi.Prep.Core.Domain.Dto;
using Dwapi.Prep.Core.Interfaces.Repository;
using Dwapi.Prep.Core.Interfaces.Service;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Dwapi.Prep.Controllers
{
    [Route("api/[controller]")]
    public class PrepController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IManifestService _manifestService;
        private readonly IPrepService _prepService;

        public PrepController(IMediator mediator, IManifestRepository manifestRepository,
            IManifestService manifestService, IPrepService prepService)
        {
            _mediator = mediator;
            _manifestService = manifestService;
            _prepService = prepService;
        }

        // POST api/Prep/verify
        [HttpPost("Verify")]
        public async Task<IActionResult> Verify([FromBody] SubscriberDto subscriber)
        {
            if (null == subscriber)
                return BadRequest();

            try
            {
                var dockect = await _mediator.Send(new VerifySubscriber(subscriber.SubscriberId,subscriber.AuthToken), HttpContext.RequestAborted);
                return Ok(dockect);
            }
            catch (Exception e)
            {
                Log.Error(e, "verify error");
                return StatusCode(500, e.Message);
            }
        }

        // POST api/Prep/Manifest
        [HttpPost("Manifest")]
        public async Task<IActionResult> ProcessManifest([FromBody] ManifestExtractDto manifestDto)
        {
            if (null == manifestDto)
                return BadRequest();
            try
            {
                var manifest = new SaveManifest(manifestDto.Manifest);
                manifest.AllowSnapshot = Startup.AllowSnapshot;
                var faciliyKey = await _mediator.Send(manifest, HttpContext.RequestAborted);
                BackgroundJob.Enqueue(() => _manifestService.Process(manifest.Manifest.SiteCode));
                return Ok(new
                {
                    FacilityKey = faciliyKey
                });
            }
            catch (Exception e)
            {
                Log.Error(e, "manifest error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("PatientPrep")]
        public IActionResult ProcessPatientPrep([FromBody] PrepExtractsDto extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _prepService.Process(extract.PatientPrepExtracts));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "PatientPrep error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("PrepAdverseEvent")]
        public IActionResult ProcessPrepAdverseEvent([FromBody] PrepExtractsDto extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _prepService.Process(extract.PrepAdverseEventExtracts));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "PrepAdverseEvent error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("PrepBehaviourRisk")]
        public IActionResult ProcessPrepBehaviourRisk([FromBody] PrepExtractsDto extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _prepService.Process(extract.PrepBehaviourRiskExtracts));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "PrepBehaviourRisk error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("PrepCareTermination")]
        public IActionResult ProcessPrepEnrolment([FromBody] PrepExtractsDto extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _prepService.Process(extract.PrepCareTerminationExtracts));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "PrepEnrolment error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("PrepLab")]
        public IActionResult ProcessPrepLab([FromBody] PrepExtractsDto extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _prepService.Process(extract.PrepLabExtracts));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "PrepPharmacy error");
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost("PrepPharmacy")]
        public IActionResult ProcessPrepPharmacy([FromBody] PrepExtractsDto extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _prepService.Process(extract.PrepPharmacyExtracts));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "PrepPharmacy error");
                return StatusCode(500, e.Message);
            }
        }



        [HttpPost("PrepVisit")]
        public IActionResult ProcessPrepVisit([FromBody] PrepExtractsDto extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _prepService.Process(extract.PrepVisitExtracts));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "PrepVisit error");
                return StatusCode(500, e.Message);
            }
        }

        // POST api/Prep/Status
        [HttpGet("Status")]
        public IActionResult GetStatus()
        {
            try
            {
                var ver = GetType().Assembly.GetName().Version;
                return Ok(new
                {
                    name = "Dwapi Central - API (PREP)",
                    status = "running",
                    version = "v1.0.0.0",
                    build = "10APR222146"
                });
            }
            catch (Exception e)
            {
                Log.Error(e, "status error");
                return StatusCode(500, e.Message);
            }
        }
    }
}
