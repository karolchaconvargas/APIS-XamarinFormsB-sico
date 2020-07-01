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

    /// <summary>
    /// /Crear la ruta de mi controlador
    [Route("api/v1/ProjectCursoXamarin/[controller]")]

    public class RestaurantesController : Controller
    {
        ///Creamos dependencias y se incializan 
        private DemoContext _context = new DemoContext();
        //Debemos recibir un demoContext,porque el recibe ese parametro cuando se creo, secreauna nueva intancia,y se recibe en el contructor
        private UnitOfWork _unitOfWork = new UnitOfWork(new DemoContext());


        //Creacion de endPoints
        //Retorna todos los restaurantes
        //Le estamos diciendo que para acceder a este metododebe utilizar la rutay hacerun get y devuleve todos los restaurantes
        [HttpGet]
        public IActionResult GetAllRestaurates()
        {
            //Se accede por medio deunity ofwork,porque es por medio de el que accedemos a la data
            //En el get como no agregamos ningun filtro nos vaa retornar a todos
            var restaurantes = _unitOfWork.Restaurantes.Get();

            //Validacion
            if (restaurantes != null)
            {
                return Ok(restaurantes);

            }
            else
            {
                return Ok();
            }
        }


        //Obtener restaurante especifico
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            Restaurantes restaurantes = _unitOfWork.Restaurantes.GetById(id);

            //Validacion
            if (restaurantes != null)
            {
                return Ok(restaurantes);

            }
            else
            {
                return BadRequest("No se encuentra el registro solicitado");
            }
        }


        //Update, con el put
        [HttpPut]
        //Va a recibir toda la entidad
        public IActionResult UpdateRestaurante([FromBody] Restaurantes restaurantes)
        {
            try
            {
                //Primero validamos
                if (ModelState.IsValid)
                {
                    //recibe entidad que vamos a modificar
                    _unitOfWork.Restaurantes.Update(restaurantes);
                    //Es lo mismo que decir savechages
                    _unitOfWork.Saved();
                    //Se retorna ok a la vista
                    return Ok();
                }
                else
                    //Si algo falla al hacer el update, aparte de decir detalles de excepcion
                    return BadRequest();
            }
            catch (DataException ex)
            {
                //Tambien retorna excepcion con elex,para que vea que fue lo que fallo
                return BadRequest(ex);
            }

        }
        //Lo crea por defecto pero no lo vamos a utulizar
        public IActionResult Index()
        {
            return View();
        }

        //Diferentes formasde hacerlo[HttpDelete]
        [HttpDelete("id")]
        public IActionResult DeleteRestaurantes(int id)
        {
            //Se consulta por valor diferente de cero, porque es id,y id es entero
            if (id != 0)
            {
                _unitOfWork.Restaurantes.Delete(id);
                _unitOfWork.Saved();
                return Ok("Restaurante Eliminado");
            }
            else
            {
                return NoContent();
            }
        }
    }
}

