
namespace ProStellar.Client.Services.NominaServices
{
    public interface INominaService
    {

        List<Nomina> ListNomina { get; set; }

        Task<Nomina> Find(int Id);

        Task GetList();

        Task<ServiceResponse<Nomina>> Save(Nomina nomina);

        Task<ServiceResponse<string>> Delete(int Id);
    }
}
