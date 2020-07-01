using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectCursoXamarin.Entities.Models;
using ProjectCursoXamarin.Services;

namespace ProjectCursoXamarin.Controllers
{
    /// /Crear la ruta de mi controlador, es la misma ruta para todos los controladores
    [Route("api/v1/ProjectCursoXamarin/[controller]")]
    public class CategoriasController : Controller
    {
        private DemoContext _context = new DemoContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new DemoContext());

        //Creacion de endPoints
        //Retorna todos las categorias
        public IActionResult GetAllCategorias()
        {
            var categorias = _unitOfWork.Categorias.Get();

            //Validacion
            if (categorias != null)
            {
                return Ok(categorias);

            }
            else
            {
                return Ok();
            }
        }

        //Obtener categoria especifica
        [HttpGet("id")]
        public IActionResult GetByIdCategoria(int id)
        {
            Categorias categorias= _unitOfWork.Categorias.GetById(id);

            //Validacion
            if (categorias != null)
            {
                return Ok(categorias);

            }
            else
            {
                return BadRequest("No se encuentra la categoria solicitada");
            }
        }


        //Update, con el put
        [HttpPut]
        //Va a recibir toda la entidad Categoria
        public IActionResult UpdateCategoria([FromBody] Categorias categorias)
        {
            try
            {
                //Primero validamos
                if (ModelState.IsValid)
                {
                    _unitOfWork.Categorias.Update(categorias);
                    _unitOfWork.Saved();
                    return Ok();
                }
                else
                    return BadRequest();
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }

        }


        //Metodo que trae por defecto que no vamos a utilizar
        public IActionResult Index()
        {
            return View();
        }
    }
}
