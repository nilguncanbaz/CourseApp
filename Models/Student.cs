using System.ComponentModel.DataAnnotations;
namespace CourseApp.Models
{
    public class Student
    {
        [Required(ErrorMessage="İsminizi Giriniz.")]
        public string Name { get; set; }
        [Required(ErrorMessage="Eposta adresinizi Giriniz.")]
        [EmailAddress(ErrorMessage="Epostayı düzgün Giriniz.")]
        public string Email { get; set; }
        [Required(ErrorMessage="Telefonunuzu Giriniz.")]
        public string Phone { get; set; }
        [Required(ErrorMessage="Katılım durumunuzu Giriniz.")]
        public bool? Confirm { get; set; } // true, false, null
    }
}