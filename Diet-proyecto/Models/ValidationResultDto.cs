namespace Diet_proyecto.Models
{
    public class ValidationResultDto
    {
        public List<string> ErrorMessages { get; set; }
        
        public string ErrorMessage
        {
            get { return String.Join(Environment.NewLine, ErrorMessages); }
        }

        public bool IsValid
        {
            get { return ErrorMessages == null || ErrorMessages.Count == 0; }
        }
    }
}
