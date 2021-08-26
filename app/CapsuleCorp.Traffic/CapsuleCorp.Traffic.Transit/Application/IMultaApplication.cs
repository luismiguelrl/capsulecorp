namespace CapsuleCorp.Traffic.Transit.Application
{
    using CapsuleCorp.Traffic.Transit.Application.Dto;
    using CapsuleCorp.Traffic.Transit.Application.Request;

    public interface IMultaApplication
    {
        LevantarMultaResult LevantarMulta(string matricula, InformacionSensorRequest request);
        LevantarMultaBatchResult LevantarMultaBatch();
    }
}