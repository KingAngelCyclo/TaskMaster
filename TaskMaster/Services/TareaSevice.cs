﻿namespace TaskMaster.Services;
using TaskMaster.Data;
using TaskMaster.Data.Dtos;
using TaskMaster.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public partial class TareaService : ITareaSevice
{
    private readonly IApplicationDbContext dbContext;
    private readonly UserManager<ApplicationUser> _userManager;

    public TareaService(IApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
    {
        this.dbContext = dbContext;
        _userManager =  userManager;
    }
    public async Task<List<Tarea>> GetTasksForUserAsync(string userId)
    {
        return await dbContext.Tareas
            .Where(t => t.UserId == userId)
            .ToListAsync();
    }
    public async Task<Result> Create(TareaRequest tarea)
    {
        try
        {
            var entity = Tarea.Create(tarea.Titulo, descripcion: tarea.Descripcion,tarea.Estado,tarea.Prioridad,tarea.FechaCreacion,tarea.FechaLimite,tarea.IsCompleted,tarea.UserId);
            dbContext.Tareas.Add(entity);
            await dbContext.SaveChangesAsync();
            return Result.Success("Tarea registrada con exito!");
        }
        catch (Exception Ex)
        {
            return Result.Failure($"Error: {Ex.Message}");
        }
    }
    public async Task<Result> Update(TareaRequest tarea)
    {
        try
        {
            var entity = dbContext.Tareas.Where(p => p.Id == tarea.Id).FirstOrDefault();
            if (entity == null)
                return Result.Failure($"La Tarea '{tarea.Id}' no existe!");
            if (entity.Update(tarea.Titulo, tarea.Descripcion, tarea.Estado, tarea.Prioridad, tarea.FechaCreacion, tarea.FechaLimite, tarea.IsCompleted, tarea.UserId))
            {
                await dbContext.SaveChangesAsync();
                return Result.Success("La tarea actualizada con exito!");
            }
            return Result.Success("No has realizado ningun cambio!");
        }
        catch (Exception Ex)
        {
            return Result.Failure($"Error: {Ex.Message}");
        }
    }
    public async Task<Result> Delete(int Id)
    {
        try
        {
            var entity = dbContext.Tareas.Where(p => p.Id == Id).FirstOrDefault();
            if (entity == null)
                return Result.Failure($"La tarea '{Id}' no existe!");
            dbContext.Tareas.Remove(entity);
            await dbContext.SaveChangesAsync();
            return Result.Success("Tarea eliminada con exito!");
        }
        catch (Exception Ex)
        {
            return Result.Failure($"Error: {Ex.Message}");
        }
    }
    public async Task<Result<TareaDto>> GetById(int Id)
    {
        try
        {
            var entity = await dbContext.Tareas.Where(p => p.Id == Id)
                .Select(p => new TareaDto(
                    p.Id,
                    p.Titulo,
                    p.Descripcion,
                    p.Prioridad,
                    p.Estado,
                    p.FechaCreacion,
                    p.FechaLimite,
                    p.IsCompleted,
                    p.UserId
                    ))
                .FirstOrDefaultAsync();
            if (entity == null)
                return Result<TareaDto>.Failure($"La tarea '{Id}' no existe!");
            return Result<TareaDto>.Success(entity);
        }
        catch (Exception Ex)
        {
            return Result<TareaDto>.Failure($"Error: {Ex.Message}");
        }
    }
    public async Task<ResultList<TareaDto>> Get(string filtro = "")
    {
        try
        {
            var entities = await dbContext.Tareas
                .Where(p => p.Titulo.ToLower().Contains(filtro.ToLower()))
                .Select(p => new TareaDto(
                    p.Id,
                    p.Titulo, 
                    p.Descripcion,
                    p.Prioridad,
                    p.Estado,
                    p.FechaCreacion,
                    p.FechaLimite,
                    p.IsCompleted,
                    p.UserId
                    ))
                .ToListAsync();
            return ResultList<TareaDto>.Success(entities);
        }
        catch (Exception Ex)
        {
            return ResultList<TareaDto>.Failure($"Error: {Ex.Message}");
        }
    }
}