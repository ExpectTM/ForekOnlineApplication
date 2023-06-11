using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace ForekOnlineApplication.Enums
{
    public class Enums
    {
        public enum eProvince
        {
            [Display(Name = "Mpumalanga")]
            Mpumalanga,
            [Display(Name = "Gauteng")]
            Gauteng,
            [Display(Name = "Limpopo")]
            Limpopo,
            [Display(Name = "North West")]
            North_West,
            [Display(Name = "KwaZulu Natal")]
            KwaZulu_Natal,
            [Display(Name = "Eastern Cape")]
            Eastern_Cape,
            [Display(Name = "Free States")]
            Free_States,
            [Display(Name = "Northern Cape")]
            Northern_Cape,
            [Display(Name = "Western Cape")]
            Western_Cape,
        }

        public enum eGender 
        {
            Male,
            Female,
            Other
        }

        public enum eRace
        {
            Black,
            Coloured,
            White,
            Other
        }

        public enum eTitle
        {
            Mr,
            Mrs,
            Ms
        }

        public enum eNationality
        {
            [Display(Name = "South African")]
            SouthAfrican,
            Other
        }

        public enum eRelationship
        {
            Father,
            Mother,
            Guardian
        }

        public enum eCountry
        {
            [Display(Name = "South Africa")]
            SouthAfrica,
            Other
        }
        

        public enum eStatus
        {
            Rejected,
            Accepted,
            Pedding
        }

        public enum elevel
        {
            [Display(Name = "Level 1/N1")]
            Level1,

            [Display(Name = "Level 2/N2")]
            Level2,

            [Display(Name = "Level 3/N3")]
            Level3,

            [Display(Name = "Level 4/N4")]
            Level4,

            [Display(Name = "Level 5")]
            Level5,

            [Display(Name = "Level 6")]
            Level6,

            [Display(Name = "Level 7")]
            Level7,

            [Display(Name = "Level 8")]
            Level8
        }

        public enum eGrade
        {
            [Display(Name = "Grade 9")]
            Grade9,

            [Display(Name = "Grade 10")]
            Grade10,

            [Display(Name = "Grade 11")]
            Grade11,

            [Display(Name = "Grade 12")]
            Grade12
        }
    }
}
