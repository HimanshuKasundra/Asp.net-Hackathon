using Microsoft.AspNetCore.Mvc;
using TBB_01_AccountGroup.Areas.ACC.Models;
using TBB_01_AccountGroup.BAL;
using TBB_01_AccountGroup.BAL.ACC_AccountGroup;
using TBB_01_AccountGroup.CF;
using TBB_01_AccountGroup.DAL;
using TBB_01_AccountGroup.DAL.ACC_AccountGroup;

namespace TBB_01_AccountGroup.Areas.ACC.Controllers
{
    [CheckAccess]
    [Area("ACC")]
    [Route("[Controller]/[action]")]
    public class ACC_AccountGroupController : Controller
    {
        #region 10.0 Local Variables
        ACC_AccountGroupBAL balACC_AccountGroup = new ACC_AccountGroupBAL();
        #endregion 10.0 Local Variables


        #region Constructor
        #endregion Constructor

        #region List Page Methods

        #region 11.0 Page Load Event - Index - List Page 
        public IActionResult Index()
        {
            FillDropDownList();
            return View();
        }
        #endregion

        #region _Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Delete(int AccountGroupID)
        {
            bool vReturen = balACC_AccountGroup.dbo_PR_ACC_AccountDelete_Delete(AccountGroupID);
            return RedirectToAction("Index");
        }
        #endregion



        #endregion

        #region FillLabels
        private void FillLabels(ControllerContext controllerContext)
        {
            var CurrentArea = controllerContext.RouteData.Values["area"].ToString();
            var CurrentController = controllerContext.RouteData.Values["controller"].ToString();
            var CurrentAction = controllerContext.RouteData.Values["action"].ToString();
            ViewBag.lblAccountVoucherName = "Account Voucher";
        }
        #endregion FillLabels

        #region 12.0 Search Result
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _SearchResult(ACC_AccountGroupModel modelACC_AccountGroup)
        {
            UserOperationRightsModel vUserOperationRightsModel = UserOperationRights.CheckForOperation(ControllerContext);
            ViewBag.UserOperationRights = vUserOperationRightsModel;

            #region 12.2 Set Default Value
            ViewBag.SearchResultHeaderText = CV.SearchResultHeaderText;

            modelACC_AccountGroup.F_PageNo = modelACC_AccountGroup.F_PageNo == null ? 1 : modelACC_AccountGroup.F_PageNo;
            modelACC_AccountGroup.F_PageSize = modelACC_AccountGroup.F_PageSize == null ? 25 : modelACC_AccountGroup.F_PageSize;
            #endregion 12.2 Set Default Value            

            //modelACC_AccountGroup.F_PageNo = 1;
            //modelACC_AccountGroup.F_PageSize = 25;

            var vChapterList = balACC_AccountGroup.dbo_PR_ACC_AccountGroup_SelectAll(modelACC_AccountGroup);

            PagedListPagerModel vPagedListPager = new PagedListPagerModel(vChapterList.First().TotalRecords, Convert.ToInt32(modelACC_AccountGroup.F_PageNo), Convert.ToInt32(modelACC_AccountGroup.F_PageSize));
            vPagedListPager.PageInfo = Pagination.GetPageInformation(vPagedListPager);
            vPagedListPager.PageSizeList = Pagination.GetPagedListPageSizes();

            var vModel = new Tuple<ACC_AccountGroupModel, PagedListPagerModel, List<dbo_PR_ACC_AccountGroup_SelectAll_Result>>(modelACC_AccountGroup, vPagedListPager, vChapterList);

            return PartialView("_ACC_AccountGroupList", vModel);
        }
        #endregion Search Result

        #region Fill DropDown List
        private void FillDropDownList()
        {
            ViewBag.GetAccountGroupList = CommonFillMethods.FillDropDownListGetAccountGroupID();
            ViewBag.ReportTypeList = CommonFillMethods.FillDropDownListReportTypeID();
            ViewBag.AccountInList = CommonFillMethods.FillDropDownListAccountInID();
        }
        #endregion

        #region 11.0 Page Load Event - Add/Edit
        public IActionResult AddEdit(int? AccountGroupID)
        {
            #region 11.2 IsAdd, IsEdit Rights
            UserOperationRightsModel vUserOperationRightsModel = UserOperationRights.CheckForOperation(ControllerContext);
            ViewBag.UserOperationRights = vUserOperationRightsModel;

            if (!vUserOperationRightsModel.IsAdd && !vUserOperationRightsModel.IsEdit)
            {
                return RedirectToAction("Index", "Error", new { Area = "" });
            }
            else if (vUserOperationRightsModel.IsAdd && !vUserOperationRightsModel.IsEdit && AccountGroupID != null)
            {
                return RedirectToAction("Index", "Error", new { Area = "" });
            }
            else if (!vUserOperationRightsModel.IsAdd && vUserOperationRightsModel.IsEdit && AccountGroupID == null)
            {
                return RedirectToAction("Index", "Error", new { Area = "" });
            }
            #endregion 11.2 IsAdd, IsEdit Rights    

            #region 11.2 Fill Lables
            FillLabels(ControllerContext);
            #endregion 11.2 Fill Lables            

            #region 11.3 Dropdown List Fill Section
            FillDropDownList();
            #endregion 11.3 Dropdown List Fill Section

            #region 11.4 Set Control Default Value
            ACC_AccountGroupModel AccountGroupModel = new ACC_AccountGroupModel();
            #endregion 11.4 Set Control Default Value

            if (AccountGroupID != null || AccountGroupID > 0)
            {
                ViewBag.Action = "Edit";

                //var d = balACC_AccountVoucher.dbo_PR_ACC_AccountVoucher_SelectByPk(AccountVoucherID).SingleOrDefault();
                var d = balACC_AccountGroup.dbo_PR_ACC_AccountGroup_SelectByPk(AccountGroupID);

                //Mapper.Initialize(config => config.CreateMap<TBB_01_AccountGroup.DAL.dbo_PR_ACC_AccountVoucher_SelectByPK_Result, ACC_AccountVoucherModel>());
                //var vModel = AutoMapper.Mapper.Map<TBB_01_AccountGroup.DAL.dbo_PR_ACC_AccountVoucher_SelectByPK_Result, ACC_AccountVoucherModel>(d);

                return View("ACC_AccountGroupAddEdit", d);
                //var data = await balACC_AccountVoucher.ACC_AccountVoucher_SelectByPk(AccountVoucherID);
                //return View("ACC_AccountVoucherAddEdit", data);
            }
            ViewBag.Action = "Add";
            return View("ACC_AccountGroupAddEdit", AccountGroupModel);
            //ViewBag.Action = "Add";
            //return View("ACC_AccountVoucherAddEdit",null);
        }
        #endregion 11.0 Page Load Event - Add/Edit

        #region 15.0 Save Button Event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Save(ACC_AccountGroupModel modelACC_AccountGroup)
        {
            try
            {
                #region Validate Field
                string errorMsg = "";
                if (modelACC_AccountGroup.AccountGroupID == null)
                {
                    errorMsg += "<li>Select Account Group</li>";
                }
                if (modelACC_AccountGroup.AccountGroupPrintName == null)
                {
                    errorMsg += "<li>Enter Account Group printname</li>";
                }
                if (modelACC_AccountGroup.ReportType == null)
                {
                    errorMsg += "<li>Select Report type</li>";
                }
                if (modelACC_AccountGroup.AccountIn == null)
                {
                    errorMsg += "<li>Select Account In</li>";
                }
                if (errorMsg != "")
                {
                    TempData["ErrorMessage"] = errorMsg;
                    return View("ACC_AccountGroupAddEdit", modelACC_AccountGroup);
                }
                #endregion Validate Field

                #region Gather Data
                #endregion Gather Data

                if (modelACC_AccountGroup.AccountGroupID == 0)
                {
                    bool vReturn = balACC_AccountGroup.dbo_PR_ACC_AccountGroup_Insert(modelACC_AccountGroup);
                    if (vReturn)
                    {
                        TempData["SuccessMessage"] = "Record Inserted Successfully..!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Some Error Has Occured..!";
                    }
                }
                else
                {
                    bool vReturn = balACC_AccountGroup.dbo_PR_ACC_AccountGroup_Update(modelACC_AccountGroup);
                    if (vReturn)
                    {
                        TempData["SuccessMessage"] = "Record Updated Successfully..!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Some Error Has Occured..!";
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View("ACC_AccountGroupAddEdit", modelACC_AccountGroup);
            }
        }
        #endregion 15.0 Save Button Event
    }
}
