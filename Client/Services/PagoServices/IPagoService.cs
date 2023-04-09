using ProStellar.Shared;

namespace ProStellar.Client.Services.PagoServices
{
    public interface IPagoService
    {

        List<Pago> ListPago { get; set; }

        Task GetList();

        Task<ServiceResponse<Pago>> SavePago (Pago pago);

        Task<ServiceResponse<string>> DeletePago(int Id);

        Task<Pago> GetPagoById(int Id);
    }
}
