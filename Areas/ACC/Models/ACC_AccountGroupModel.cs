using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel.DataAnnotations;

namespace TBB_01_AccountGroup.Areas.ACC.Models
{
    public class ACC_AccountGroupModel
    {

        /*******************************************************************
                *	FILTERS
                *******************************************************************/

        [Display(Name = "Account Group", Prompt = "Enter Account Group")]
        public string? F_AccountGroupName { get; set; }

        [Display(Name = "Account Group Print", Prompt = "Enter Account Group Print")]
        public string? F_AccountGroupPrintName { get; set; } = null;

        [Display(Name = "Balance Sheet", Prompt = "Enter Balance Sheet")]
        public string? F_BalanceSheetName { get; set; } = null;

        [Display(Name = "Parent Account Group", Prompt = "Select Parent Account Group")]
        public int? F_ParentAccountID { get; set; }

        [Display(Name = "Top Account Group", Prompt = "Select Top Account Group")]
        public int? F_TopAccountID { get; set; }

        [Display(Name = "Relative Account Group", Prompt = "Select Relative Account Group")]
        public int? F_RelativeAccountID { get; set; }

        [Display(Name = "Report Type", Prompt = "Select Report Type")]
        public int? F_ReportTypeID { get; set; }

        [Display(Name = "Account In", Prompt = "Select Account In")]
        public int? F_AccountInID { get; set; }
        public int? F_WarehouseID { get; set; }
        public int? F_SecOperationID { get; set; }
        [Display(Name = "F_PageNo")]
        public int? F_PageNo { get; set; }

        [Display(Name = "F_PageSize")]
        public int? F_PageSize { get; set; }

        [Required, Display(Name = "No. of Rows")]
        public int F_NoOfRows { get; set; }
        public int F_PageOffset { get; set; } = 0;

        /*******************************************************************
		 *	ADDEDIT FORM
		 *******************************************************************/
        //[Display(Name = "Account Group", Prompt = "Select Account Group")]
        public int AccountGroupID { get; set; }
        [Display(Name = "Account Group Name", Prompt = "Select Account GroupName")]
        public string? AccountGroupName { get; set; }
        [Display(Name = "Account Group Print", Prompt = "Select Account Group print")]
        public string? AccountGroupPrintName { get; set; }
        [Display(Name = "BalanceSheet", Prompt = "Select Balancesheet")]
        public string? BalanceSheetName { get; set; }
        [Display(Name = "Parent Account Group", Prompt = "Select Parent Account Group")]
        public int? ParentAccountGroupID { get; set; }
        public string? ParentAccountGroupName { get; set; }
        [Display(Name = "Top Account Group", Prompt = "Select Top Account Group")]
        public string? TopAccountGroupName { get; set; }
        public int? TopAccountGroupID { get; set; }
        [Display(Name = "Relative Account Group", Prompt = "Select Relative Account Group")]
        public int? RelativeAccountGroupID { get; set; }
        public string? RelativeAccountGroupName { get; set; }
        [Display(Name = "Report Type", Prompt = "Select Report Type")]
        public string? ReportType { get; set; }

        [Display(Name = "Account In", Prompt = "Select Account In")]
        public string? AccountIn { get; set; }

        [Display(Name = "BalanceOn", Prompt = "Select Balance On")]
        public string? BalanceOn { get; set; }
        public string? DisplayMessage { get; set; } = "kishan";
        public bool IsEditable { get; set; }
        public string? FlowType { get; set; }
        public string? Remarks { get; set; }
        public int? CompanyID { get; set; }
        public int? UserID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int? WarehouseID { get; set; }
        public int? SecOperationID { get; set; }
    }

    public class ACC_AccountGroupModelList
    {
        public List<ACC_AccountGroupModel> vACC_AccountGroupModelList { get; set; }
    }
}
