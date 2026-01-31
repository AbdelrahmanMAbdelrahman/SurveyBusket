using SurveyBasket.ValidationAttributeFolder;
using System.ComponentModel;

namespace SurveyBasket.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [MinAge(20,ErrorMessage = "age must be at least 18")]
        [DisplayName("date of birth")]
        public DateTime? DateOfBirth { get; set; }
        public string PollTitle { get; set; }
    }
}
