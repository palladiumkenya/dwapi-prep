using System;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dwapi.Prep;
using Dwapi.Prep.Core.Command;
using Dwapi.Prep.Core.Domain.Dto;
using Dwapi.Prep.Core.Interfaces.Repository;
using Dwapi.Prep.Core.Interfaces.Service;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
namespace Dwapi.Crs.Controllers
{
    [ApiController]
    [Route("file")]
    public class BoardRoomController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IManifestService _manifestService;
        private readonly IPrepService _prepService;
        public HttpClient Client { get; set; }
        private IWebHostEnvironment _appEnvironment;

        public BoardRoomController(IMediator mediator, IManifestRepository manifestRepository, IWebHostEnvironment appEnvironment,
        IManifestService manifestService, IPrepService prepService)
        {
            _mediator = mediator;
            _manifestService = manifestService;
            _prepService = prepService;
            _appEnvironment = appEnvironment;
        }
        [HttpPost]
        public async Task<IActionResult> UploadAsync([FromForm] IFormFile file)
        {
            string text;
            var client = Client ?? new HttpClient();
            int count = 0;
            int sendCound = 0;
            //var responses = new List<SendManifestResponse>();
            using (var stream = file.OpenReadStream())
            {
                var archive = new ZipArchive(stream);
                foreach (var item in archive.Entries)
                {
                    count++;
                    if (item.FullName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                    {
                        using (StreamReader sr = new StreamReader(item.Open()))
                        {
                            try
                            {
                                text = await sr.ReadToEndAsync(); // OK                         

                                byte[] base64EncodedBytes = Convert.FromBase64String(text);
                                var Extract = Encoding.UTF8.GetString(base64EncodedBytes);

                                if (count == 1)
                                {
                                    try
                                    {
                                        ManifestExtractDto messageManifest = JsonConvert.DeserializeObject<ManifestExtractDto>(Extract);
                                        var manifest = new SaveManifest(messageManifest.Manifest);
                                        manifest.AllowSnapshot = Startup.AllowSnapshot;
                                        var faciliyKey = await _mediator.Send(manifest, HttpContext.RequestAborted);
                                        BackgroundJob.Enqueue(() => _manifestService.Process(manifest.Manifest.SiteCode));
                                        //return Ok(new
                                        //{
                                        //    FacilityKey = faciliyKey
                                        //});
                                    }
                                    catch (Exception e)
                                    {
                                        Log.Error(e, "manifest error");
                                        return StatusCode(500, e.Message);
                                    }
                                }
                                else
                                {
                                    PrepExtractsDto extract = JsonConvert.DeserializeObject<PrepExtractsDto>(Extract);
                                    if (extract != null && extract.PatientPrepExtracts.Count > 0)
                                    {
                                        try
                                        {
                                            var id = BackgroundJob.Enqueue(() => _prepService.Process(extract.PatientPrepExtracts));

                                            //return Ok(new { BatchKey = id });

                                        }

                                        catch (Exception ex)
                                        {
                                           // return StatusCode(500, ex.Message);

                                        }
                                    }
                                   else if (extract != null && extract.PrepBehaviourRiskExtracts.Count >0)
                                    {
                                        try
                                        {
                                            var id = BackgroundJob.Enqueue(() => _prepService.Process(extract.PrepBehaviourRiskExtracts));

                                           // return Ok(new { BatchKey = id });

                                        }

                                        catch (Exception ex)
                                        {
                                            return StatusCode(500, ex.Message);

                                        }
                                    }
                                   else  if (extract != null && extract.PrepVisitExtracts.Count >0)
                                    {
                                        try
                                        {
                                            var id = BackgroundJob.Enqueue(() => _prepService.Process(extract.PrepVisitExtracts));

                                            //return Ok(new { BatchKey = id });

                                        }

                                        catch (Exception ex)
                                        {
                                            return StatusCode(500, ex.Message);

                                        }
                                    }
                                  else  if (extract != null && extract.PrepLabExtracts.Count >0)
                                    {
                                        try
                                        {
                                            var id = BackgroundJob.Enqueue(() => _prepService.Process(extract.PrepLabExtracts));

                                           // return Ok(new { BatchKey = id });

                                        }

                                        catch (Exception ex)
                                        {
                                            return StatusCode(500, ex.Message);

                                        }
                                    }
                                    else if (extract != null && extract.PrepPharmacyExtracts.Count >0)
                                    {
                                        try
                                        {
                                            var id = BackgroundJob.Enqueue(() => _prepService.Process(extract.PrepPharmacyExtracts));

                                            //return Ok(new { BatchKey = id });

                                        }

                                        catch (Exception ex)
                                        {
                                            return StatusCode(500, ex.Message);

                                        }
                                    }
                                   else if (extract != null && extract.PrepAdverseEventExtracts.Count >0)
                                    {
                                        try
                                        {
                                            var id = BackgroundJob.Enqueue(() => _prepService.Process(extract.PrepAdverseEventExtracts));

                                           // return Ok(new { BatchKey = id });

                                        }

                                        catch (Exception ex)
                                        {
                                            return StatusCode(500, ex.Message);

                                        }
                                    }
                                   else if (extract != null && extract.PrepCareTerminationExtracts.Count >0)
                                    {
                                        try
                                        {
                                            var id = BackgroundJob.Enqueue(() => _prepService.Process(extract.PrepCareTerminationExtracts));

                                           // return Ok(new { BatchKey = id });

                                        }

                                        catch (Exception ex)
                                        {
                                            return StatusCode(500, ex.Message);

                                        }
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Log.Error(e, $"Send Manifest Error");
                                throw;
                            }
                        }
                    }
                }

            }

            return Ok();
        }


    }
}
