using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitStop.Core.Entities
{
    [Table("customer")]
    public class Customer
    {
        [Key]
        [Column("cus_id")]
        public long? CusId { get; set; }

        [Column("cus_type_id")]
        public short? CusTypeId { get; set; }

        [RegularExpression(Constants.GreekOrEnglishRegexp, ErrorMessage = Constants.GreekOrEnglishError)]
        [Column("name")]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Το επώνυμο πελάτη είναι υποχρεωτικό")]
        [Column("lastname")]
        [StringLength(100)]
        public string? Lastname { get; set; }

        [Required(ErrorMessage = "Η διεύθυνση κατοικίας πελάτη είναι υποχρεωτική")]
        [RegularExpression(Constants.GreekOrEnglishRegexp, ErrorMessage = Constants.GreekOrEnglishError)]
        [Column("address")]
        [StringLength(500)]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Η πόλη κατοικίας είναι υποχρεωτική")]
        [RegularExpression(Constants.GreekOrEnglishRegexp, ErrorMessage = Constants.GreekOrEnglishError)]
        [Column("city")]
        [StringLength(100)]
        public string? City { get; set; }

        [Column("state")]
        [StringLength(100)]
        public string? State { get; set; }

        [RegularExpression(Constants.TelephoneRegexp, ErrorMessage = Constants.TelephoneError)]
        [Column("telephone")]
        [StringLength(20)]
        public string? Telephone { get; set; }

        [RegularExpression(Constants.MobileRegexp, ErrorMessage = Constants.MobileError)]
        [Column("mobile")]
        [StringLength(20)]
        public string? Mobile { get; set; }

        [EmailAddress(ErrorMessage = Constants.EmailError)]
        [Column("email")]
        [StringLength(100)]
        public string? Email { get; set; }

        [Column("gdpr")]
        public bool Gdpr { get; set; }

        [Column("gdpr_date")]
        public DateTime? GdprDate { get; set; }

        [Column("gdpr_allow_letter_flag")]
        public bool? GdprAllowLetterFlag { get; set; }

        [Column("gdpr_allow_call_flag")]
        public bool? GdprAllowCallFlag { get; set; }

        [Column("gdpr_allow_sms_flag")]
        public bool? GdprAllowSmsFlag { get; set; }

        [Column("gdpr_allow_email_flag")]
        public bool? GdprAllowEmailFlag { get; set; }

        [Column("gdpr_allow_analytic_flag")]
        public bool? GdprAllowAnalyticFlag { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty(Mobile) && String.IsNullOrEmpty(Telephone))
            {
                yield return new ValidationResult(
                    $"Πρέπει να συμπληρώσετε ένα τηλέφωνο επικοινωνίας (Σταθερό ή Κινητό).");
            }

            if (!CusTypeId.HasValue)
            {
                yield return new ValidationResult(
                    $"Ο τύπος του πελάτη είναι υποχρεωτικός.");
            }
        }
    }
}
