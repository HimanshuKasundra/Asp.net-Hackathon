using System.Data;
using TBB_01_AccountGroup.Areas.ACC.Models;
using TBB_01_AccountGroup.CF;

namespace TBB_01_AccountGroup.DAL
{
    public class ACC_AccountGroupDALBase : DALHelper
    {
        #region Method: dbo_PR_ACC_AccountGroup_SelectAll
        public async Task<List<dbo_PR_ACC_AccountGroup_SelectAll_Result>?> dbo_PR_ACC_AccountGroup_SelectAll(ACC_AccountGroupModel modelACC_AccountGroup)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode ?? string.Empty},
                    { "PageOffset", modelACC_AccountGroup.F_PageOffset.ToString() ?? string.Empty},
                    { "PageSize", modelACC_AccountGroup.F_PageSize.ToString() ?? string.Empty},
                    { "CompanyID", CV.CompanyID.ToString() ?? string.Empty},
                    { "AccountGroupName", modelACC_AccountGroup.F_AccountGroupName ?? string.Empty},
                    { "AccountGroupPrintName", modelACC_AccountGroup.F_AccountGroupPrintName ?? string.Empty},
                    { "BalanceSheetName", modelACC_AccountGroup.F_BalanceSheetName ?? string.Empty},
                    { "ParentAccountGroup", modelACC_AccountGroup.F_ParentAccountID.ToString() ?? string.Empty},
                    { "ParentAccountID", modelACC_AccountGroup.F_ParentAccountID.ToString() ?? string.Empty},

                    { "TopAccountID", modelACC_AccountGroup.F_TopAccountID.ToString() ?? string.Empty},
                    { "RelativeAccountID", modelACC_AccountGroup.F_RelativeAccountID.ToString() ?? string.Empty},
                    { "ReportTypeID", modelACC_AccountGroup.F_ReportTypeID.ToString() ?? string.Empty},
                    { "AccountInID", modelACC_AccountGroup.F_AccountInID.ToString() ?? string.Empty},
                    //{ "AccountDocID", modelACC_AccountGroup.F_AccountDocID.ToString() ?? string.Empty},
                    //{ "FinYearID", CV.FinYearID.ToString() ?? string.Empty},
                    { "WarehouseID", modelACC_AccountGroup.F_WarehouseID.ToString() ?? string.Empty},

                    { "UserID", CV.UserID.ToString() ?? string.Empty},
                    { "SecOperationID", modelACC_AccountGroup.F_SecOperationID.ToString() ?? string.Empty},
                };

                string APIURL = "AccountGroupSelectPage/CommonAccount/getAccountGroupSelectPage";
                List<dbo_PR_ACC_AccountGroup_SelectAll_Result>? resultList = await GetJSONResponseFromAPI<dbo_PR_ACC_AccountGroup_SelectAll_Result>(APIURL, data);
                if (resultList != null)
                {
                    DataTable dt = resultList.ToDataTable();
                    return ConvertDataTableToEntity<dbo_PR_ACC_AccountGroup_SelectAll_Result>(dt).ToList();
                }
                return null;
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return null;
            }
        }
        #endregion

        #region Method: dbo_PR_ACC_AccountGroup_SelectByPk
        //public async Task<List<dbo_PR_ACC_AccountVoucher_SelectByPK_Result>?> dbo_PR_ACC_AccountVoucher_SelectByPk(int? AccountVoucherID)
        //{
        //	try
        //	{
        //		var data = new Dictionary<string, string>()
        //		{
        //			{ "InstituteCode", CV.InstituteCode.ToString() ?? string.Empty},
        //			{ "AccountVoucherID", AccountVoucherID.ToString() ?? string.Empty},
        //		};

        //		string APIURL = "AccountVoucherSelectPK/CommonAccount/getAccountVoucherSelectPK";
        //		List<dbo_PR_ACC_AccountVoucher_SelectByPK_Result>? result = await GetJSONResponseFromAPI<dbo_PR_ACC_AccountVoucher_SelectByPK_Result>(APIURL, data);
        //		return result;
        //	}
        //	catch (Exception ex)
        //	{
        //		var vExceptionHandler = ExceptionHandler(ex);
        //		if (vExceptionHandler.IsToThrowAnyException)
        //			throw vExceptionHandler.ExceptionToThrow;
        //		return null;
        //	}
        //}
        public async Task<ACC_AccountGroupModel?> dbo_PR_ACC_AccountGroup_SelectByPk(int? AccountGroupID)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode.ToString() ?? string.Empty},
                    { "AccountGroupID", AccountGroupID.ToString() ?? string.Empty},
                };

                string APIURL = "AccountGroupSelectPK/CommonAccount/getAccountGroupSelectPK";
                List<ACC_AccountGroupModel>? result = await GetJSONResponseFromAPI<ACC_AccountGroupModel>(APIURL, data);
                if (result[0] == null)
                {

                }
                return result[0];
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return null;
            }
        }
        #endregion


        #region Method: dbo_PR_ACC_AccountGroup_Delete
        public async Task<bool> dbo_PR_ACC_AccountGroup_Delete(int AccountGroupID)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode ?? string.Empty},
                    { "AccountGroupID", AccountGroupID.ToString() ?? string.Empty},
                    { "UserID", CV.UserID.ToString() ?? string.Empty},
                    { "DeleteReason", "Testing Delete" ?? string.Empty}
                };

                string APIURL = "AccountGroupDelete/CommonAccount/AccountGroupDelete";
                bool result = await GetJSONResponseSuccess(APIURL, data);
                if (result)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return false;
            }
        }
        #endregion DeleteIncome

        #region Method: dbo_PR_ACC_AccountGroup_Insert
        public async Task<bool> dbo_PR_ACC_AccountGroup_Insert(ACC_AccountGroupModel modelACC_AccountGroup)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode ?? string.Empty},
                    { "AccountGroupID", modelACC_AccountGroup.AccountGroupID.ToString() ?? string.Empty},
                    { "AccountGroupName", modelACC_AccountGroup.AccountGroupName ?? string.Empty},
                    { "AccountGroupPrintName", modelACC_AccountGroup.AccountGroupPrintName ?? string.Empty},
                    { "ParentAccountGroupID", modelACC_AccountGroup.ParentAccountGroupID.ToString()?? string.Empty},
                    //{ "ParentAccountGroupName", modelACC_AccountGroup.ParentAccountGroupName ?? string.Empty},
                     { "BalanceSheetName", modelACC_AccountGroup.BalanceSheetName ?? string.Empty},
                    //{"TopAccountGroupID", modelACC_AccountGroup.TopAccountGroupID.ToString() ?? string.Empty},
                    { "TopAccountGroupName", modelACC_AccountGroup.RelativeAccountGroupName ?? string.Empty},
                    {"RelativeAccountGroupID", modelACC_AccountGroup.RelativeAccountGroupID.ToString() ?? string.Empty},
                    //{ "RelativeAccountGroupName", modelACC_AccountGroup.TopAccountGroupName ?? string.Empty},
                    { "ReportType", modelACC_AccountGroup.ReportType ?? string.Empty},
                    { "AccountIn", modelACC_AccountGroup.AccountIn ?? string.Empty},
                    { "Remarks", modelACC_AccountGroup.Remarks ?? string.Empty},
                    { "BalanceOn", modelACC_AccountGroup.BalanceOn.ToString() ?? string.Empty},
                    { "CompanyID", CV.CompanyID.ToString() ?? string.Empty},
                 { "FlowType", modelACC_AccountGroup.FlowType?? string.Empty},
                  { "DisplayMessage", modelACC_AccountGroup.DisplayMessage?? string.Empty},
                 { "IsEditable", modelACC_AccountGroup.IsEditable.ToString()?? string.Empty},
                    { "UserID", CV.UserID.ToString() ?? string.Empty},
                    { "Created", DateTime.Now.Date.ToString("yyyy-MM-dd") ?? string.Empty},
                    { "Modified", DateTime.Now.Date.ToString("yyyy-MM-dd") ?? string.Empty},
                };

                string APIURL = "AccountGroupInsert/CommonAccount/AccountGroupInsert";
                bool result = await GetJSONResponseSuccess(APIURL, data);
                if (result)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return false;
            }
        }
        #endregion SaveIncome

        #region Method: dbo_PR_ACC_AccountVoucher_Update
        public async Task<bool> dbo_PR_ACC_AccountGroup_Update(ACC_AccountGroupModel modelACC_AccountGroup)
        {
            try
            {
                var data = new Dictionary<string, string>()
                 {
                    { "InstituteCode", CV.InstituteCode ?? string.Empty},
                    { "AccountGroupID", modelACC_AccountGroup.AccountGroupID.ToString() ?? string.Empty},
                    { "AccountGroupName", modelACC_AccountGroup.AccountGroupName ?? string.Empty},
                    { "AccountGroupPrintName", modelACC_AccountGroup.AccountGroupPrintName ?? string.Empty},
                    { "ParentAccountGroupID", modelACC_AccountGroup.ParentAccountGroupID.ToString()?? string.Empty},
                    { "ParentAccountGroupName", modelACC_AccountGroup.ParentAccountGroupName ?? string.Empty},
                    {"TopAccountGroupID", modelACC_AccountGroup.TopAccountGroupID.ToString() ?? string.Empty},
                    { "TopAccountGroupName", modelACC_AccountGroup.RelativeAccountGroupName ?? string.Empty},
                    { "BalanceSheetName", modelACC_AccountGroup.BalanceSheetName ?? string.Empty},
                    {"RelativeAccountGroupID", modelACC_AccountGroup.RelativeAccountGroupID.ToString() ?? string.Empty},
                    { "RelativeAccountGroupName", modelACC_AccountGroup.TopAccountGroupName ?? string.Empty},
                    { "ReportType", modelACC_AccountGroup.ReportType ?? string.Empty},
                    { "AccountIn", modelACC_AccountGroup.AccountIn ?? string.Empty},
                    { "Remarks", modelACC_AccountGroup.Remarks ?? string.Empty},
                    { "BalanceOn", modelACC_AccountGroup.BalanceOn.ToString() ?? string.Empty},
                    { "CompanyID", CV.CompanyID.ToString() ?? string.Empty},
                    { "DisplayMessage", modelACC_AccountGroup.DisplayMessage?? string.Empty},
                    { "FlowType", modelACC_AccountGroup.FlowType?? string.Empty},
                 { "IsEditable", modelACC_AccountGroup.IsEditable.ToString()?? string.Empty},
                    { "UserID", CV.UserID.ToString() ?? string.Empty},
                    { "Created", DateTime.Now.Date.ToString("yyyy-MM-dd") ?? string.Empty},
                    { "Modified", DateTime.Now.Date.ToString("yyyy-MM-dd") ?? string.Empty},
                };
                string APIURL = "AccountGroupUpdate/CommonAccount/AccountGroupUpdate";
                bool result = await GetJSONResponseSuccess(APIURL, data);
                if (result)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return false;
            }
        }
        #endregion SaveIncome


        #region Method: dbo_PR_GetAccountGroup_SelectComboBox_Result
        public async Task<List<dbo_PR_GetAccountGroup_SelectComboBox_Result>?> dbo_PR_GetAccountGroup_SelectComboBox_Result(string InstituteCode, int CompanyID)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", InstituteCode},
                    { "CompanyID", CompanyID.ToString()}
                };

                string APIURl = "AccountGroupSelectRelativeAccountGroupComboBox/CommonAccount/getAccountGroupSelectRelativeAccountGroupComboBox";
                List<dbo_PR_GetAccountGroup_SelectComboBox_Result>? result = await GetJSONResponseFromAPI<dbo_PR_GetAccountGroup_SelectComboBox_Result>(APIURl, data);
                Console.WriteLine(result);
                DataTable dt = result.ToDataTable();

                return ConvertDataTableToEntity<dbo_PR_GetAccountGroup_SelectComboBox_Result>(dt).ToList();
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return null;
            }
        }
        #endregion

        #region Method: dbo_PR_ACC_GetAccountIn_SelectComboBox_Result
        public async Task<List<dbo_PR_GetAccountIn_SelectComboBox_Result>?> dbo_PR_GetAccountIn_SelectComboBox_Result(string InstituteCode, string ComboName)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", InstituteCode},
                    { "ComboName", ComboName}
                };

                string APIURl = "HardcodeComboSelectComboBoxByComboName/CommonAccount/getHardcodeComboSelectComboBoxByComboName";
                List<dbo_PR_GetAccountIn_SelectComboBox_Result>? result = await GetJSONResponseFromAPI<dbo_PR_GetAccountIn_SelectComboBox_Result>(APIURl, data);
                DataTable dt = result.ToDataTable();

                return ConvertDataTableToEntity<dbo_PR_GetAccountIn_SelectComboBox_Result>(dt).ToList();
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return null;
            }
        }
        #endregion

        #region Method: dbo_PR_ReportType_SelectComboBox_Result
        public async Task<List<dbo_PR_ReportType_SelectComboBox_Result>?> dbo_PR_ReportType_SelectComboBox_Result(string InstituteCode, string ComboName)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", InstituteCode},
                    { "ComboName", ComboName}
                };

                string APIURl = "HardcodeComboSelectComboBoxByComboName/CommonAccount/getHardcodeComboSelectComboBoxByComboName";
                List<dbo_PR_ReportType_SelectComboBox_Result>? result = await GetJSONResponseFromAPI<dbo_PR_ReportType_SelectComboBox_Result>(APIURl, data);
                DataTable dt = result.ToDataTable();

                return ConvertDataTableToEntity<dbo_PR_ReportType_SelectComboBox_Result>(dt).ToList();
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return null;
            }
        }
        #endregion


    }

    #region Entity: dbo_PR_ACC_AccountGroup_SelectAll_Result
    public partial class dbo_PR_ACC_AccountGroup_SelectAll_Result : DALHelper
    {
        #region Properties
        public int? TotalRecords { get; set; }
        public int AccountGroupID { get; set; }
        public string? AccountGroupName { get; set; }
        public string? AccountGroupPrintName { get; set; }
        public string? BalanceSheetName { get; set; }
        public int? ParentAccountGroupID { get; set; }
        public int? ParentAccountGroupID1 { get; set; }
        public string? ParentAccountGroupName { get; set; }
        public int? TopAccountGroupID { get; set; }
        public string? TopAccountGroupName { get; set; }
        public int? RelativeAccountGroupID { get; set; }
        public string? RelativeAccountGroupName { get; set; }
        public string? ReportType { get; set; }
        public string? AccountIn { get; set; }
        public string? BalanceOn { get; set; }
        public bool? IsEditable { get; set; }
        public string? Remarks { get; set; }
        public int? CompanyID { get; set; }
        public string? CompanyName { get; set; }

        public int? UserID { get; set; }
        public string? UserName { get; set; }
        public string? IsEdit { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        //public DateTime? VerificationDateTime { get; set; }
        //public int? VerificationByUserID { get; set; }
        //public string? VerificationMessage { get; set; }
        public string? DisplayMessage { get; set; }
        public bool IsLocked { get; set; }
        public string? RowColor { get; set; }
        public string NevigateURL { get; set; }
        #endregion

        #region Convert Entity to String
        public override String ToString()
        {
            return EntityToString(this);
        }
        #endregion
    }
    #endregion

    #region Entity: dbo_PR_ACC_AccountGroup_SelectByPK_Result
    public partial class dbo_PR_ACC_AccountGroup_SelectByPK_Result : DALHelper
    {
        #region Properties
        public int? TotalRecords { get; set; }
        public int AccountGroupID { get; set; }
        public string? AccountGroupName { get; set; }
        public string? AccountGroupPrintName { get; set; }
        public string? BalanceSheetName { get; set; }
        public int? ParentAccountGroupID { get; set; }
        public int? TopAccountGroupID { get; set; }

        public int? RelativeAccountGroupID { get; set; }

        public string? ReportType { get; set; }
        public string? AccountIn { get; set; }

        public string? BalanceOn { get; set; }
        public bool? IsEditable { get; set; }
        public string? FlowType { get; set; }
        public string? Remarks { get; set; }
        public string? DisplayMessage { get; set; }
        public int? CompanyID { get; set; }
        public int? UserID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }


        #endregion

        #region Convert Entity to String
        public override String ToString()
        {
            return EntityToString(this);
        }
        #endregion
    }
    #endregion

    #region Entity: dbo_PR_GetAccountGroup_SelectComboBox_Result
    public partial class dbo_PR_GetAccountGroup_SelectComboBox_Result : DALHelper
    {
        #region Properties
        public int TopAccountGroupID { get; set; }
        public string AccountGroupName { get; set; }
        #endregion

        #region Convert Entity to String
        public override String ToString()
        {
            return EntityToString(this);
        }
        #endregion
    }
    #endregion

    #region Entity: dbo_PR_GetAccountIn_SelectComboBox_Result
    public partial class dbo_PR_GetAccountIn_SelectComboBox_Result : DALHelper
    {
        #region Properties
        public string DisplayName { get; set; }
        public string Value { get; set; }
        #endregion

        #region Convert Entity to String
        public override String ToString()
        {
            return EntityToString(this);
        }
        #endregion
    }
    #endregion

    #region Entity: dbo_PR_ReportType_SelectComboBox_Result
    public partial class dbo_PR_ReportType_SelectComboBox_Result : DALHelper
    {
        #region Properties
        public string DisplayName { get; set; }
        public string Value { get; set; }
        #endregion

        #region Convert Entity to String
        public override String ToString()
        {
            return EntityToString(this);
        }
        #endregion
    }
    #endregion

}
