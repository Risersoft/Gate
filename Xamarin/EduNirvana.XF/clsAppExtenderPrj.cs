using EduNirvana.Global;
using EduNirvana.XF.Pages;
using risersoft.shared;
using risersoft.shared.portable.Models.Nav;
using risersoft.shared.Providers;
using Risersoft.Framework.Global;
using Risersoft.Framework.Pages;
using Risersoft.Framework.Pages.Framework;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EduNirvana
{
    public class clsAppExtenderPrj : clsXamAppExtendBase

    {
        public override string StartupAppCode()
        {
            
            return "nlms";
        }

        public override IForm AboutBox()
        {
            throw new NotImplementedException();
        }


        public override clsCollecString<Type> dicFormModelTypes()
        {
            throw new NotImplementedException();
        }

        public override clsCollecString<Type> dicReportProviderTypes(clsAppController myContext)
        {
            throw new NotImplementedException();
        }

        public override clsCollecString<Type> dicTaskProviderTypes()
        {
            throw new NotImplementedException();
        }

        public override clsCollecString<Type> dicWOInfoTypes()
        {
            throw new NotImplementedException();
        }
        public override Page AddPage(string str1)
        {
            switch (str1.ToLower().Trim())

            {
                case "frmcontentunitview":
                    return new FrmContentUnitView();
                case "frmassessassignview":
                    return new FrmAssessAssignView();
                case "frmassesssurveyview":
                    return new FrmAssessSurveyView();
                case "frmassesstestview":
                    return new FrmAssessTestView();
                case "frmforumpost":
                    return new FrmForumpost();
                default:
                    return new Page();
            }

        }

        public override string ProgramName()
        {
            return "EdNirvana Learner";
        }
        public override string ProgramCode()
        {
            return "lms";
        }
        public override IAppDataProvider CreateDataProvider(clsAppController context, IAsyncWCFCallBack cb)
        {
            //InstanceContext cbcontext = new InstanceContext(cb);
            //var str1 = AppConstants.WCFServiceHost();
            //var Provider = ChannelProxyFactory.CreateNetHttp<IAppDataProviderDuplexClient>(cbcontext, str1, context.Police as IServiceAuthorizer);
            //return Provider;
            var str1 = AppConstants.RestServiceHost();
            
            var provider = new clsAppDataProviderREST(context,str1,(clsXamPolice)context.Police);
            return provider;

        }

        public override IForm frmDel(clsView pView, string IDX, string sysentXML)
        {
            throw new NotImplementedException();
        }
    }

}
