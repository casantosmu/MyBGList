namespace MyBGList.Dto;

public class RestDto<T>
{
    public T Data { get; set; } = default!;

    public List<LinkDto> Links { get; set; } = [];
}