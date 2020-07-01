using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectCursoXamarin.Services;
using ProjectCursoXamarin.Entities.DTOs;
using ProjectCursoXamarin.Entities.Models;

namespace ProjectCursoXamarin.Controllers
{
    public class AmburguesasController : Controller
    {
      
        private UnitOfWork _unitOfWork = new UnitOfWork(new DemoContext());
        //Este metodo cambia porque vamos a devolver un metodo serializado,porque vamos a  devolever un objeto padremas los hijos, por lo tanto
        //se debe utilizar un paquete para serializar los json
        [HttpGet("idCategoria")]
        public IActionResult GetAllAmburguesasByCatgeoria(int idCategoria)
        {
            if (idCategoria != 0)
            {
                //Validar si el restaurante y la amburguesa realmente existen
                //Por medio del filtero expresion
                var idCategorias = _unitOfWork.Categorias.Get(x => x.IdCategoria == idCategoria);
                if (idCategorias != null)
                {
                    var amburguesas = _unitOfWork.Amburguesas.Get(x => x.IdCategoria == idCategoria);
                    //Hacemos uso del json convert y hacemos el mapetObject
                    var result = CreateMappedObject(amburguesas, idCategoria);
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

        private object CreateMappedObject(IEnumerable<Amburguesas> amburguesas, int idCategoria)
        {
            throw new NotImplementedException();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
