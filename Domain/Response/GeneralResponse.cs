namespace Domain.Response
{
    public class GeneralResponse<T>
    {
        public bool Success { get; set; }
        public T? Data  { get; set; }
        public string? Message {  get; set; }
        public Dictionary<string, List<string>>? Errors { get; set; }=new Dictionary<string, List<string>>();
        public DateTime dateTime = DateTime.Now;
      
    }
}
