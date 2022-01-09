using MyResume.Models;




namespace MyResume.Data
{
    public class DbInitializer
    {
        public static void Initialize(WebToDoListContext context)
        {
            var ToDoList = new ToDoList { CompletedNotCompleted = true, id = 01920192, dateOfCompletion = DateTime.Parse("05.01.2022 0:00:00"), priority = "Высокий", Task = "тут что-то должно быть " };
            context.Add(ToDoList);
            context.SaveChangesAsync();
        }
    }
}
