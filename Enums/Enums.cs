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
        public enum eNatedEngineering
        {
            ElectricalEngineeringN1N6,
            MechanicalEngineeringN4N6,
            MotorMechanicN1N3,
            BoilerMakingN1N3,
            FitterAndTurnerN1N3,
            DieselMechanicN1N3,
            CivilEngineeringN4N6
        }

        public enum eNatedBusiness
        {
            FarmingManagementN4N6,
            HumanResourceManagementN4N6,
            FinancialManagementN4N6,
            PublicManagementN4N6,
            MarkertingManagementN4N6
        }

        public enum eOccupationalTrades
        {
            Electrician,
            Plumber,
            Welder,
            Bricklayer,
            Painter,
            PlasterAndTiler
        }

        public enum eOccapactionalNonTrades
        {
            Bookkeeper,
            OfficeAdministration,
            PestManagementOfficer,
            OccupationalHealthAndSafetyPractitioner,
            ComputerTechnician,
            SupplyChainPractitioner,
            ProjectManagement
        }

        public enum eArplAndTradeTest
        {
            Electrician,
            Plumber,
            Welder,
            Bricklayer,
            Painter,
            PlasterAndTiler
        }

        public enum Agriculture
        {
            AnimalProduction,
            GeneralAbattoirProcesses,
            PlantProduction,
            PoultryProduction,
            AbattoirSlaughteringProcess,
            MacadamiaProductionandDehusking,
            PestControlOperations
        }
    }
}
