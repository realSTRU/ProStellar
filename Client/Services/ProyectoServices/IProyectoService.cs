namespace ProStellar.Client.Services.ProyectoServices
{
    public interface IProyectoService
    {
        List<Proyecto> ListProyecto { get; set; }

        Task<Proyecto> Find(int Id);

        Task<ServiceResponse<Proyecto>> Save(Proyecto proyecto);

        Task GetList();

        Task<ServiceResponse<string>> Delete(int Id);
    }
}
