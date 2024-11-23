namespace caso_de_estudio_1_backend.DTOs
{
    public class ApiResponse<T>
    {
        public bool Ok { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public string[] Errors { get; set; }
    }
}
