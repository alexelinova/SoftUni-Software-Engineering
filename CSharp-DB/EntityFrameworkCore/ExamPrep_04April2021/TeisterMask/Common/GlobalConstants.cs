namespace TeisterMask.Common
{
    public static class GlobalConstants
    {
        //Employee

        public const int UsernameMinLength = 3;
        public const int UsernameMaxLength = 40;
        public const string EmployeeUsernameRegex = @"^[A-Za-z0-9]+$";
        public const string EmployeePhoneNumberRegex = @"^\d{3}-\d{3}-\d{4}$";

        //Project

        public const int ProjectNameMaxLength = 40;
        public const int ProjectNameMinLength = 2;

        //Task

        public const int TaskNameMaxLength = 40;
        public const int TaskNameMinLength = 2;
        public const int TaskExecTypeMinValue = 0;
        public const int TaskExecTypeMaxValue = 3;
        public const int TaskLabelTypeMinValue = 0;
        public const int TaskLabeLTypeMaxValue = 4;

    }
}
