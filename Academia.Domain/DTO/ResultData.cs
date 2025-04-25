namespace Academia10.Domain.DTO;

public class ResultData<T>
{
    public T? Data { get; set; }
    public string ErrorDescription { get; set; } = string.Empty;
    public bool Success { get; set; }
}
