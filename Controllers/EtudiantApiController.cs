using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Xml.Linq;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Models.Dto;

namespace WebAPI.Controllers
{
    [Route("api/Etudiants")]
    [ApiController]

    public class EtudiantApiController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<EtudiantDto>> GetEtudiants()
        {
            return Ok(EtudiantStore.EtudiantList);
        }

        [HttpGet("{id:int}",Name ="getEtudiant")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public ActionResult<EtudiantDto> GetEtudiantbyid(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            EtudiantDto etudiant = EtudiantStore.EtudiantList.FirstOrDefault(e => e.Id == id);
            if (etudiant == null)
            {
                return NotFound();
            }
            else return Ok(etudiant);

        }


        [HttpPost("CreateEtudiant")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<EtudiantDto> CreateEtudiant([FromBody]EtudiantDto etudiant)
        {

            if (etudiant == null)
            {
                return BadRequest();
            }else if (etudiant.Id < 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else{
                etudiant.Id = EtudiantStore.EtudiantList.OrderByDescending(e => e.Id).FirstOrDefault().Id + 1;
                EtudiantStore.EtudiantList.Add(etudiant);
                return CreatedAtRoute("getEtudiant",new {id = etudiant.Id}, etudiant);
            }
        }

        [HttpDelete("deleteEtudiant/{id:int}", Name ="deleteEtudiant")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<EtudiantDto> deleteEtudiant(int id)
        {
            if(id == 0) { return BadRequest(); }
            else
            {
                var etudiant = EtudiantStore.EtudiantList.FirstOrDefault(e => e.Id == id);
                if (etudiant == null)
                {
                    return NotFound();
                }

                    EtudiantStore.EtudiantList.Remove(etudiant);
                    return Ok("Etudiant "+etudiant.Id +" deleted");

            }
        }

        [HttpPut("updateEtudiant/{id:int}", Name = "updateEtudiant")]
        public ActionResult<EtudiantDto> updateEtudiant(int id, [FromBody] EtudiantDto etudiant)
        {
            if (id == 0) { return BadRequest(); }
            else
            {
                var e = EtudiantStore.EtudiantList.FirstOrDefault(e => e.Id == id);
                if (etudiant == null)
                {
                    return NotFound();
                }
                e!.Name = etudiant.Name;
                e!.Lastname= etudiant.Lastname;
                return Ok("Etudiant " + e.Id + " Modifié avec Succés");

            }
        }
    }
}
