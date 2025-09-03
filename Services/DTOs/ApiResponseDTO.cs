namespace PaymentGateways.Services.DTOs;
public class ApiResponseDTO<T>
{
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public T? Data { get; set; } 
}
