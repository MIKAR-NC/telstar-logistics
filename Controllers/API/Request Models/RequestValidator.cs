using System.ComponentModel.DataAnnotations;
using TelstarRoutePlanner.Controllers.API.Enums;

namespace TelstarRoutePlanner.Controllers.API.Request_Models
{
    public static class RequestValidator
    {
        public static void ValidateFrom(string from)
        {
            if (from.Any(char.IsUpper))
            {
                throw new ValidationException("From has to be all lower case!");
            }
        }
        public static void ValidateTo(string to)
        {
            if (to.Any(char.IsUpper))
            {
                throw new ValidationException("To has to be all lower case!");
            }
        }
        //TODO NOTE TIL SELV ANDREAS, DU BØR FLYTTE DENNE TIL BUSINESS LAGER LOGIK
        public static void ValidateWeight(double weight)
        {
            if (weight > 40)
            {
                throw new ValidationException("Weight can not exceed 40 kg!");
            }
        }

        //TODO NOTE TIL SELV ANDREAS, DU BØR FLYTTE DENNE TIL BUSINESS LAGER LOGIK
        public static void ValidateType(ParcelType type)
        {
            switch (type)
            {
                case ParcelType.Standard:
                    break;
                case ParcelType.LiveAnimals:
                    break;
                case ParcelType.DeadAnimals:
                    break;
                case ParcelType.Refrigerated:
                    break;
                case ParcelType.Children:
                    break;
                case ParcelType.Cautious:
                    break;
                case ParcelType.Furniture:
                    break;
                case ParcelType.Weapons:
                    throw new ValidationException("Shipping of weapons is not allowed!");
                case ParcelType.Recorded:
                    break;
                default:
                    break;
            }
        }
    }
}
