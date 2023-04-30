using BelasitsaSkyRun.Umbraco.Models;
using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core;
using umbraco.NodeFactory;
using System;
using Umbraco.Web;

namespace BelasitsaSkyRun.Umbraco.Controllers
{
    public class MemberController : SurfaceController
    {
        public ActionResult RenderLogin()
        {
            return PartialView("_Login", new LoginModel());
        }
        public ActionResult SubmitLogin([Bind(Include = "UserName,Email,BirthPlace,BirthDate,Gender")] LoginModel model)
        {


            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            var memberService = Services.MemberService;
            if (memberService.GetByEmail(model.Email) != null)
            {
                ModelState.AddModelError("", "Member already exists");
                return CurrentUmbracoPage();
            }
            var member = memberService.CreateMemberWithIdentity(model.UserName, model.Email, model.BirthPlace, "Member");
            member.SetValue("UserName", model.UserName);
            member.SetValue("Email", model.Email);
            member.SetValue("BirthPlace", model.BirthPlace);
            member.SetValue("BirthDate", model.BirthDate);
            member.SetValue("Gender", model.Gender);



            MemberService.Saving += MemberServiceOnSaving;

            memberService.Save(member);
            //MemberType demoMemberType = new MemberType(1044); //id of membertype ‘demo’
            //Member newMember = Member.MakeNew(model.BirthDate + " " + model.BirthPlace + " " + model.Email + " " + model.Gender + " " + model.UserName , demoMemberType, new umbraco.BusinessLogic.User(0));
            //newMember.Email = "test@testmail.com";
            //newMember.Password = "password";
            //newMember.LoginName = "Test";
            //newMember.getProperty("firstName").Value = "test";
            //newMember.Save();     
            // memberService.SavePassword(member, model.Password);

            Members.Login(model.Email, model.Email);



            return Redirect("/");
        }





        private void MemberServiceOnSaving(IMemberService sender, SaveEventArgs<IMember> e)
        {
            foreach (var member in e.SavedEntities)
            {
                bool IsApprovedBug = member.IsApproved; //BUG: Always return true

                var m = ApplicationContext.Current.Services.MemberService.GetById(member.Id);
                //m.AdditionalData.Add.e();
                //var IsApproved = m.IsApproved; //Correct value


            }
        }


        public ActionResult RenderLogout()
        {
            return PartialView("_Logout", null);
        }

        public ActionResult SubmitLogout()
        {
            TempData.Clear();
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToCurrentUmbracoPage();
        }

    }
}