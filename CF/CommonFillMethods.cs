using TBB_01_AccountGroup.BAL;
using TBB_01_AccountGroup.BAL.ACC_AccountGroup;
using TBB_01_AccountGroup.DAL;

namespace TBB_01_AccountGroup.CF
{
    public class CommonFillMethods
    {
        public static List<dbo_PR_AccountDoc_SelectComboBox_Result>? FillDropDownListAccountDocID()
        {
            ACC_AccountVoucherBAL balACC_AccountVoucher = new ACC_AccountVoucherBAL();
            return balACC_AccountVoucher.dbo_PR_ACC_AccountDoc_SelectComboBox(CV.InstituteCode, CV.CompanyID);
        }

		public static List<dbo_PR_ACC_Account_SelectComboBox_Result>? FillDropDownListAccountID()
		{
			ACC_AccountVoucherBAL balACC_AccountVoucher = new ACC_AccountVoucherBAL();
			return balACC_AccountVoucher.dbo_PR_ACC_Account_SelectComboBox();
		}

        public static List<dbo_PR_GetAccountGroup_SelectComboBox_Result>? FillDropDownListGetAccountGroupID()
        {
            ACC_AccountGroupBAL balACC_AccountGroup = new ACC_AccountGroupBAL();
            return balACC_AccountGroup.dbo_PR_GetAccountGroup_SelectComboBox(CV.InstituteCode, CV.CompanyID);
        }

        public static List<dbo_PR_GetAccountIn_SelectComboBox_Result>? FillDropDownListReportTypeID()
        {
            ACC_AccountGroupBAL balACC_AccountGroup = new ACC_AccountGroupBAL();
            return balACC_AccountGroup.dbo_PR_GetAccountIn_SelectComboBox(CV.InstituteCode, CV.AccountInComboName);
        }

        public static List<dbo_PR_ReportType_SelectComboBox_Result>? FillDropDownListAccountInID()
        {
            ACC_AccountGroupBAL balACC_AccountGroup = new ACC_AccountGroupBAL();
            return balACC_AccountGroup.dbo_PR_ReportType_SelectComboBox(CV.InstituteCode, CV.ReportTypeComboName);
        }

    }
}
