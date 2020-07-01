using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectCursoXamarin.Entities.Models;
using ProjectCursoXamarin.Services;

namespace ProjectCursoXamarin.Controllers
{
    public class RestaurantesAmburguesasController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new DemoContext());
        [HttpGet("idRestaurante,idAmburguesa")]
        public IActionResult GetRestaurantesAmburguesas(int idRestaurante, int idAmburguesa)
        {
            if (idRestaurante != 0 && idAmburguesa != 0)
            {
                //Validar si el restaurante y la amburguesa realmente existen
                //Por medio del filtero expresion
                var idRestaurantes = _unitOfWork.Restaurantes.Get(x => x.IdRestaurante == idRestaurante);
                var idAmburguesas = _unitOfWork.Amburguesas.Get(x => x.IdAmburguesa == idAmburguesa);

                if (idRestaurantes != null && idAmburguesas != null)
                {
                    //Alya validar que existen,se busca en la relacional
                    var restaurantes = _unitOfWork.RestaurantesAmburguesas.Get(x => x.IdRestaurante == idRestaurante);
                    var amburguesas = _unitOfWork.RestaurantesAmburguesas.Get(x => x.IdAmburguesa == idAmburguesa);
                    //Hacemos uso del json convert y hacemos el mapetObject
                    var result = CreatedMappedObjet(idRestaurantes, idAmburguesas);
                    var serializedList = JsonConvert.SerializeObject(result, Formatting.Indented,
                        //aqui vamos a decirle que cree una nuevainstancia de json serializer
                        new JsonSerializerSettings()
                        {
                            //Para que no traiga una referencia infinta, decirle como hacemos referencia de como manejar relaciones y que no sea infinitas
                            ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                        }
                        );
                    return Ok(serializedList);
                }
                //Si no existe el restaurante o la amburguesa
                else
                    return NoContent();
            }
            else
                return BadRequest();
           
        }
    

        private object CreatedMappedObjet(IEnumerable<Restaurantes> idRestaurantes, IEnumerable<Amburguesas> idAmburguesas)
        {
            throw new NotImplementedException();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
