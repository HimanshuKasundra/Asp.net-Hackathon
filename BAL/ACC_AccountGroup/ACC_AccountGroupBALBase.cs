using TBB_01_AccountGroup.Areas.ACC.Models;
using TBB_01_AccountGroup.DAL;
using TBB_01_AccountGroup.DAL.ACC_AccountGroup;

namespace TBB_01_AccountGroup.BAL.ACC_AccountGroup
{
    public class ACC_AccountGroupBALBase
    {
        #region Method: dbo_PR_ACC_AccountGroup_SelectAll
        public List<dbo_PR_ACC_AccountGroup_SelectAll_Result>? dbo_PR_ACC_AccountGroup_SelectAll(ACC_AccountGroupModel modelACC_AccountGroup)
        {
            ACC_AccountGroupDAL dalACC_AccountModel = new ACC_AccountGroupDAL();
            return dalACC_AccountModel.dbo_PR_ACC_AccountGroup_SelectAll(modelACC_AccountGroup).Result;
        }
        #endregion

        #region Method: dbo_PR_ACC_AccountGroup_SelectByPk
        //public List<dbo_PR_ACC_AccountVoucher_SelectByPK_Result>? dbo_PR_ACC_AccountVoucher_SelectByPk(int? AccountVoucherID)
        //      {
        //          ACC_AccountVoucherDAL dalACC_AccountModel = new ACC_AccountVoucherDAL();
        //          return dalACC_AccountModel.dbo_PR_ACC_AccountVoucher_SelectByPk(AccountVoucherID).Result;
        //      }
        public ACC_AccountGroupModel? dbo_PR_ACC_AccountGroup_SelectByPk(int? AccountGroupID)
        {
            ACC_AccountGroupDAL dalACC_GroupModel = new ACC_AccountGroupDAL();
            return dalACC_GroupModel.dbo_PR_ACC_AccountGroup_SelectByPk(AccountGroupID).Result;
        }
        #endregion

        #region Method: dbo_PR_ACC_AccountDelete_Delete
        public bool dbo_PR_ACC_AccountDelete_Delete(int AccountGroupID)
        {
            ACC_AccountGroupDAL dalACC_GroupModel = new ACC_AccountGroupDAL();
            return dalACC_GroupModel.dbo_PR_ACC_AccountGroup_Delete(AccountGroupID).Result;
        }
        #endregion

        #region Method: dbo_PR_ACC_AccountGroup_Insert
        public bool dbo_PR_ACC_AccountGroup_Insert(ACC_AccountGroupModel modelACC_AccountGroup)
        {
            ACC_AccountGroupDAL dalACC_GroupModel = new ACC_AccountGroupDAL();
            return dalACC_GroupModel.dbo_PR_ACC_AccountGroup_Insert(modelACC_AccountGroup).Result;
        }
        #endregion

        #region Method: dbo_PR_ACC_AccountGroup_Update
        public bool dbo_PR_ACC_AccountGroup_Update(ACC_AccountGroupModel modelACC_AccountGroup)
        {
            ACC_AccountGroupDAL dalACC_GroupModel = new ACC_AccountGroupDAL();
            return dalACC_GroupModel.dbo_PR_ACC_AccountGroup_Update(modelACC_AccountGroup).Result;
        }
        #endregion

        #region Method: dbo_PR_GetAccountGroup_SelectComboBox_Result
        public List<dbo_PR_GetAccountGroup_SelectComboBox_Result>? dbo_PR_GetAccountGroup_SelectComboBox(string InstituteCode, int CompanyID)
        {
            ACC_AccountGroupDAL dalACC_AccountModel = new ACC_AccountGroupDAL();
            return dalACC_AccountModel.dbo_PR_GetAccountGroup_SelectComboBox_Result(InstituteCode, CompanyID).Result;
        }
        #endregion

        #region Method: dbo_PR_GetAccountIn_SelectComboBox_Result
        public List<dbo_PR_GetAccountIn_SelectComboBox_Result>? dbo_PR_GetAccountIn_SelectComboBox(string InstituteCode, string ComboName)
        {
            ACC_AccountGroupDAL dalACC_AccountModel = new ACC_AccountGroupDAL();
            return dalACC_AccountModel.dbo_PR_GetAccountIn_SelectComboBox_Result(InstituteCode, ComboName).Result;
        }
        #endregion

        #region Method: dbo_PR_ReportType_SelectComboBox_Result
        public List<dbo_PR_ReportType_SelectComboBox_Result>? dbo_PR_ReportType_SelectComboBox(string InstituteCode, string ComboName)
        {
            ACC_AccountGroupDAL dalACC_AccountModel = new ACC_AccountGroupDAL();
            return dalACC_AccountModel.dbo_PR_ReportType_SelectComboBox_Result(InstituteCode, ComboName).Result;
        }
        #endregion



    }
}
