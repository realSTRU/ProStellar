﻿using ProStellar.Shared.Models;
using ProStellar.Shared;
namespace ProStellar.Server.Services.TrabajoServices
{
    public interface ITrabajoService
    {

        Task<ServiceResponse<List<Trabajo>>> GetTrabajos();

        Task<ServiceResponse<Trabajo>> AddTrabajo(Trabajo trabajo);
        Task<ServiceResponse<Trabajo>> ModifyTrabajo(Trabajo trabajo);
        Task<ServiceResponse<Trabajo>> DeleteTrabajo(int id);
        Task<ServiceResponse<Trabajo>> GetTrabajo(int id);

        Task<bool> Existe(int Id);

        Task<ServiceResponse<Trabajo>> SaveTrabajo(Trabajo trabajo);
    }
}
