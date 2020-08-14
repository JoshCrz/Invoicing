namespace Service
{
    public interface IServiceResponse<TIn, TResponse>
    {
        TIn Command { get; set; }
        TResponse Data { get; set; }
    }

}
