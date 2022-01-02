using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MyResume.Models
{
    public class ToDoListGenreViewModel
    {
        public List<ToDoList> ToDoLists { get; set; }
        public SelectList Genres { get; set; }
        [DataType(DataType.Date)]
        public DateTime TaskData { get; set; }
        [RegularExpression(@"(Высокий)+|(Средний)+|(Низкий)", ErrorMessage = "Некорректный priority")]
        public string TaskPriority { get; set; }
        public bool Completed { get; set; }
    }

}
