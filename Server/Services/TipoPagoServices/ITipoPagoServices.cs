namespace ProStellar.Server.Services.TipoPagoServices
{
    public interface ITipoPagoServices
    {
        Task<ServiceResponse<List<TipoPago>>> GetTiposPagos();

        Task<ServiceResponse<TipoPago>> GetTipoPago(int id);

        Task<ServiceResponse<TipoPago>> AddTipoPago(TipoPago tipoPago);
        Task<ServiceResponse<TipoPago>> DeleteTipoPago(int id);
        Task<ServiceResponse<TipoPago>> ModifyTipoPago(TipoPago tipoPago);
    }
}
