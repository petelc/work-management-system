namespace Application.Dashboard.RequestCount
{
    public class RequestCountDto
    {
        public int id {get; set;}
        public string Title { get; set; }
        public int Value { get; set; }
        public int ValueMax { get; set; }
        public int startAngle { get; set; }
        public int endAngle { get; set; }
    }
}