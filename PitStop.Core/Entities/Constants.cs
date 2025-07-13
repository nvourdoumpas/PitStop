using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitStop.Core.Entities
{
    internal class Constants
    {
        // Regular expressions consts
        public const string GreekOrEnglishRegexp = "^((?=[A-Za-z])[A-Za-z0-9 -.&]+|[Α-Ωα-ω0-9ΈΎΊΌΆΉΏΫΪέύίόάήώϋϊ -.&]+)$";
        public const string GreekOrEnglishCapitalRegexp = "^((?=[A-Z])[A-Z0-9 -.&]+|[Α-Ω0-9ΈΎΊΌΆΉΏΫΪ -.&]+)$";
        public const string OnlyEnglishRegexp = "^[A-Za-z0-9 -.]+$";
        public const string OnlyGreekRegexp = "^[Α-Ωα-ω0-9ΈΎΊΌΆΉΏΫΪέύίόάήώϋϊ -.&]+$";
        public const string OnlyNumberRegexp = "^[0-9.,]+$";
        public const string LicensePlateRegexp = "^((?<=^$|^)[A-Za-z0-9 -]+|[Α-Ω0-9 -]+)$";
        public const string TelephoneRegexp = "^(2)[0-9]{9,9}$";
        public const string MobileRegexp = "(^(69)[0-9]{8,8})|(^(00)[0-9]{10,18})$";

        // Error messages
        public const string GreekOrEnglishError = "Το πεδίο μπορεί περιέχει μόνο Ελληνικούς ή Αγγλικούς χαρακτήρες";
        public const string GreekOrEnglishCapitalError = "Το πεδίο μπορεί περιέχει μόνο κεφαλαίους Ελληνικούς ή Αγγλικούς χαρακτήρες";
        public const string OnlyEnglishError = "Το πεδίο μπορεί περιέχει μόνο Αγγλικούς χαρακτήρες";
        public const string OnlyGreekError = "Το πεδίο μπορεί περιέχει μόνο Ελληνικούς χαρακτήρες";
        public const string OnlyNumberError = "Το πεδίο μπορεί περιέχει μόνο αριθμούς";
        public const string LicensePlateError = "Το πεδίο μπορεί περιέχει μόνο κεφαλαίους Ελληνικούς ή Αγγλικούς χαρακτήρες χωρίς κενά";
        public const string TelephoneError = "Παρακαλώ συμπληρώστε ένα έγκυρο σταθερό τηλέφωνο";
        public const string MobileError = "Παρακαλώ συμπληρώστε ένα έγκυρο κινητό τηλέφωνο";
        public const string EmailError = "Παρακαλώ συμπληρώστε ένα email";
    }
}
