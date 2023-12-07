using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models;
using CCIH.Entities;
using System.Threading.Tasks;

public class ProfesoresController : Controller
{
    private readonly IProfesorModel _profesorModel;

    public ProfesoresController(IProfesorModel profesorModel)
    {
        _profesorModel = profesorModel;
    }

    // Método para mostrar la lista de profesores
    public async Task<IActionResult> Index()
    {
        var profesores = await _profesorModel.ListarProfesoresAsync();
        return View(profesores);
    }

    // Método para mostrar el formulario de nuevo profesor
    public IActionResult Create()
    {
        return View(new ProfesorEnt()); // Envía un modelo vacío a la vista
    }

    // Método para procesar la creación de un profesor
    [HttpPost]
    [ValidateAntiForgeryToken] // Ayuda a prevenir ataques de falsificación de solicitud en sitios cruzados (CSRF)
    public async Task<IActionResult> Create(ProfesorEnt profesor)
    {
        if (!ModelState.IsValid)
        {
            return View(profesor);
        }
        var resultado = await _profesorModel.RegistrarProfesorAsync(profesor);
        if (resultado == 1)
        {
            // Redirige al índice/lista después de un registro exitoso
            return RedirectToAction(nameof(Index));
        }
        // Si el método no fue exitoso, muestra un mensaje de error
        ModelState.AddModelError("", "No se pudo registrar al profesor.");
        return View(profesor);
    }

    // Método para mostrar el formulario de editar un profesor
    public async Task<IActionResult> Edit(long id)
    {
        var profesor = await _profesorModel.ConsultarProfesorAsync(id);
        if (profesor == null)
        {
            return NotFound();
        }
        return View(profesor);
    }

    // Método para procesar la actualización de un profesor
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, ProfesorEnt profesor)
    {
        if (!ModelState.IsValid)
        {
            return View(profesor);
        }
        var resultado = await _profesorModel.ActualizarProfesorAsync(profesor);
        if (resultado == 1)
        {
            return RedirectToAction(nameof(Index));
        }
        ModelState.AddModelError("", "No se pudo actualizar al profesor.");
        return View(profesor);
    }

    // Método para cambiar el estado de un profesor
    [HttpPost]
    public async Task<IActionResult> ChangeStatus(long id)
    {
        var profesor = await _profesorModel.ConsultarProfesorAsync(id);
        if (profesor == null)
        {
            return NotFound();
        }
        var nuevoEstado = !profesor.Activo;
        var resultado = await _profesorModel.CambiarEstadoProfesorAsync(id, nuevoEstado);
        if (resultado == 1)
        {
            return RedirectToAction(nameof(Index));
        }
        ModelState.AddModelError("", "No se pudo cambiar el estado del profesor.");
        return View(nameof(Index), await _profesorModel.ListarProfesoresAsync()); // Recarga la lista
    }

    // ... Incluiría métodos para detalles y eliminación si es necesario ...
}


