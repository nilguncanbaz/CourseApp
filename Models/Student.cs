using System.ComponentModel.DataAnnotations;
namespace CourseApp.Models
{
    public class Student
    {
        [Required(ErrorMessage="İsminizi giriniz.")]
        public string Name { get; set; }
        [Required(ErrorMessage="Eposta adresinizi giriniz.")]
        [EmailAddress(ErrorMessage="Epostayı düzgün giriniz.")]
        public string Email { get; set; }
        [Required(ErrorMessage="Telefonunuzu giriniz.")]
        public string Phone { get; set; }
        [Required(ErrorMessage="Katılım durumunuzu giriniz.")]
        public bool? Confirm { get; set; } // true, false, null
    }
}