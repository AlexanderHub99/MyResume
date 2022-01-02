using System.ComponentModel.DataAnnotations;

namespace MyResume.Models
{
    public class ToDoList
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Task:")]
        public string Task { get; set; }


        [Display(Name = "On what date:")]
        [DataType(DataType.Date)]
        public DateTime dateOfCompletion { get; set; }


        [Display(Name = "Priority:")]
        [RegularExpression(@"(Высокий)+|(Средний)+|(Низкий)", ErrorMessage = "Некорректный priority")]
        public string priority { get; set; }

        [Display(Name = "Выполнил")]
        public bool CompletedNotCompleted { get; set; }


    }
}
