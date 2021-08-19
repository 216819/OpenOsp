using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;

using OpenOsp.Api.Services;
using OpenOsp.Model.Dtos.Mappers;
using OpenOsp.Api.Exceptions;
using System.Threading.Tasks;

namespace OpenOsp.Api.Controllers {

  [Route("[controller]")]
  public class Controller<T, TCreateDto, TReadDto, TUpdateDto> : ControllerBase
    where T : class
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class {

    public Controller(
      IService<T> service,
      IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper
    ) {
      _service = service;
      _mapper = mapper;
    }

    protected readonly IService<T> _service;

    protected readonly IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> _mapper;

    [HttpGet]
    public virtual async Task<ActionResult<IEnumerable<TReadDto>>> ReadAll() {
      try {
        var entities = await _service.ReadAll();
        var dtos = entities.Select(e => _mapper.MapRead(e)).ToList();
        return Ok(dtos);
      }
      catch (UnauthorizedException) {
        return Unauthorized();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPost]
    public virtual async Task<ActionResult<TReadDto>> Create(TCreateDto createDto) {
      try {
        var entity = await CreateEntity(createDto);
        var readDto = _mapper.MapRead(entity);
        return CreatedAtAction(null, readDto);
      }
      catch (UnauthorizedException) {
        return Unauthorized();
      }
      catch (ValidationProblemException) {
        return ValidationProblem();
      }
      catch (DbTransactionException) {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    protected async Task<T> CreateEntity(T entity) {
      await _service.CreateAsync(entity);
      return entity;
    }

    protected virtual async Task<T> CreateEntity(TCreateDto createDto) {
      if (!TryValidateModel(createDto)) {
        throw new ValidationProblemException();
      }
      var entity = _mapper.MapCreate(createDto);
      return await CreateEntity(entity);
    }

    protected virtual ActionResult<TReadDto> ReadEntity(T entity) {
      var readDto = _mapper.MapRead(entity);
      return Ok(readDto);
    }

    protected virtual async Task<ActionResult> UpdateEntity(TUpdateDto updateDto, T entity) {
      try {
        if (!TryValidateModel(updateDto)) {
          throw new ValidationProblemException();
        }
        _mapper.MapUpdate(updateDto, entity);
        await _service.UpdateAsync(entity);
        return NoContent();
      }
      catch (ValidationProblemException) {
        return ValidationProblem();
      }
      catch (DbTransactionException) {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    protected virtual async Task<ActionResult> PatchEntity(JsonPatchDocument<TUpdateDto> patchDoc, T entity) {
      try {
        var entityToPatch = _mapper.MapPatch(entity);
        patchDoc.ApplyTo(entityToPatch);
        if (!TryValidateModel(entityToPatch)) {
          throw new ValidationProblemException();
        }
        _mapper.MapUpdate(entityToPatch, entity);
        await _service.UpdateAsync(entity);
        return NoContent();
      }
      catch (ValidationProblemException) {
        return ValidationProblem();
      }
      catch (DbTransactionException) {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    protected virtual async Task<ActionResult> DeleteEntity(T entity) {
      try {
        await _service.DeleteAsync(entity);
        return NoContent();
      }
      catch (DbTransactionException) {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

  }

}