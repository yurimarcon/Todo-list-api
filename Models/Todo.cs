namespace testAPI_2.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Done { get; set; }

        public Todo(string title, bool done)
        {
            Title = title;
            Done = done;
        }
    }
}