﻿namespace TBB_01_AccountGroup.CF
{
    public static class CV
    {
        private static IHttpContextAccessor _httpContextAccessor;

        #region Constructor
        static CV()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }
        #endregion

        #region Common Variables
        public static string SearchResultHeaderText = "Search Result";
        public static string InstituteCode = "LOC";
        public static int CompanyID = 1;
        public static int UserID = 1;
        public static int FinYearID = 1;
        public static int BankID = 2;
        public static string AccountInComboName = "AccountIn";
        public static string ReportTypeComboName = "ReportType";
        public static int AccountGroupID = 2;
        #endregion Common Variables
    }
}