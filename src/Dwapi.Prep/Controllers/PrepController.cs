using System;
using System.Linq;
using System.Threading.Tasks;
using Dwapi.Prep.Core.Command;
using Dwapi.Prep.Core.Domain.Dto;
using Dwapi.Prep.Core.Interfaces.Repository;
using Dwapi.Prep.Core.Interfaces.Service;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
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
            
            // check if version allowed to send
            var version = manifestDto.Manifest.Cargoes.Select(x =>  x).Where(m => m.Items.Contains("MnchService")).FirstOrDefault().Items;
            // var DwapiVersionSending = _manifestRepository.GetDWAPIversionSending(manifest.Manifest.SiteCode);
            var DwapiVersionSending = Int32.Parse((JObject.Parse(version)["Version"].ToString()).Replace(".", string.Empty));
            
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var DwapiVersionCuttoff = Int32.Parse(config["DwapiVersionCuttoff"]);;
            
            var currentLatestVersion = config["currentLatestVersion"];;;
            
            if (DwapiVersionSending < DwapiVersionCuttoff)
            {
                return StatusCode(500, $" ====> You're using DWAPI Version [{DwapiVersionSending}]. Older Versions of DWAPI are " +
                                       $"not allowed to send to NDWH. UPGRADE to the latest version {currentLatestVersion} and RELOAD and SEND");
            }
            
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
        
        
        [HttpPost("PrepMonthlyRefill")]
        public IActionResult ProcessPrepMonthlyRefill([FromBody] PrepExtractsDto extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _prepService.Process(extract.PrepMonthlyRefillExtracts));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "PrepMonthlyRefill error");
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
                    version = "v1.0.0.1",
                    build = "05JUL221256"
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
