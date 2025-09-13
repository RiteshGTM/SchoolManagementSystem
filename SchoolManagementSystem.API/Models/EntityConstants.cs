using System.Runtime.InteropServices;

namespace SchoolManagementSystem.API.Models
{
    public static class EntityConstants
    {
        public const string RequiredErrorMessage = "{0} is required";
        public const string MaxLengthErrorMessage = "{0} can't be more than {1} characters";
        public const string MinLengthErrorMessage = "{0} can't be less than {1} characters";
        public const string MinNumLengthErrorMessage = "{0} can't be less than {1}";
        public const string RangErrorMessage = "Value for {0} must be between 1 to 10 digits";

        public const string RegxLoginIdPattern = @"/^([0-9]{10})|([A-Za-z0-9._-]+@[a-z0-9.\-]+\.[a-z]{2,3})|([A-Za-z0-9._]+)$";
        public const string LoginIdErrorMessage = "Enter valid LoginId";

        public const string RegxPasswordPattern = @"^.*(?=.*[A-Z])(?=.*[@#$%^&+=]).*$";
        public const string PasswordErrorMessage = "Password has to be of min 6 chars and contain at least 1 capital and 1 special chars.";

        public const string RegxEmailPattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        public const string EmailErrorMessage = "Enter valid Email Address";

        public const string RegxMobilePattern = @"^\(?([0-9]{3})\)?([0-9]{3})([0-9]{4})$";
        public const string MobileErrorMessage = "Enter valid Mobile number";

        public const string SecretKey = "CoreTech^Veejan%Service@Jun^20#25";


        // India Standard Time  Indian      Eastern Standard Time
        private static TimeZoneInfo IndianTimeZone = null;

        public static DateTime GetCurrentDateTime
        {
            get
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    IndianTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    IndianTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Kolkata");

                return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, IndianTimeZone);
            }
        }
    }
}