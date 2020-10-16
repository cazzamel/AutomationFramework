using System;
using AutomationFramework.Base;
using AutomationFramework.Helpers;
using EAEmployeeTest.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;


namespace EAEmployeeTest
{
    [TestClass]
    public class UnitTest1 : HookInitialize
    {

        [TestMethod]
        public void TestMethod1()
        {
            Login();
            
        }

        public void Login()
        {

            CurrentPage = GetInstance<HomePage>();
            CurrentPage = CurrentPage.As<HomePage>().ClickLogin();

            //Populate data in collection
            string fileName = Environment.CurrentDirectory.ToString() + @"\Data\UserName.xlsx";
            //Console.WriteLine(fileName);
            ExcelHelpers.PopulateInCollection(fileName);

            //Read data from Excel Sheet
            //Console.WriteLine($"UserName: {ExcelHelpers.ReadData(1, "UserName")} and Password: {ExcelHelpers.ReadData(1, "Password")}");

            string username = ExcelHelpers.ReadData(1, "UserName");
            string password = ExcelHelpers.ReadData(1, "Password");

            CurrentPage.As<LoginPage>().EnterLoginDetails(username, password);
            CurrentPage = CurrentPage.As<LoginPage>().ClickLogin();
            
            NUnit.Framework.Assert.AreEqual("Hello " + username + "!", CurrentPage.As<HomePage>().LoggedInName());

            //CurrentPage = CurrentPage.As<HomePage>().ClickEmployeeListLink();
            //CurrentPage = CurrentPage.As<LoginPage>().ClickEmployeeListLink();

            //var table = CurrentPage.As<EmployeePage>().GetEmployeeList();

            //HtmlTableHelper.ReadTable(table, "Benefits", "Edit", "Delete");
            //HtmlTableHelper.PerformActionOnCell("Benefits", "Benefits13");

            //CurrentPage.As<EmployeePage>().ClickCreateNew();


        }

        public void ClickEmployeeList()
        {
        }
    }
}
