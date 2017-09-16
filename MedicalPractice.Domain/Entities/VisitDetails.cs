using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPractice.Domain.Entities
{
    public class VisitDetails
    {
        [Required(ErrorMessage = "Proszę podać imię.")]
        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwisko.")]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Proszę podać PESEL")]
        [Display(Name = "PESEL")]
        public string Pesel { get; set; }

        [Required(ErrorMessage = "Proszę podać Datę urodzenia")]
        [Display(Name = "Data urodzenia")]
        public string BirthdayDate { get; set; }

    }
}
