using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models
{
    public class Usermodel
    {
        [Required (ErrorMessage = "Bitte schreiben Sie Ihren VorNamen")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bitte schreiben Sie Ihren NachNamen")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Bitte schreiben Sie Ihre E-Mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bitte schreiben Sie Ihre TelefonNumer")]
        public string Telefonno { get; set; }
        [Required(ErrorMessage = "Bitte schreiben Sie Ihren Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bitte schreiben Sie Ihren PasswordConfirm")]
        [Compare("Password",ErrorMessage =("Die Wörter reimen sich also nicht."))]
        public string PasswordConfirm { get; set; }

    }
}
