using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cafetaria.Common.Helpers
{
 public   class ExtentReport
    {
        public static ExtentReports Extent { get; set; }
        public static ExtentTest ExtentTest { get; set; }
        private static  readonly string Type = "HTML";
        public static string ScreenshotPath { get; } = Path.GetTempPath() + @"SchoolCafe\Screenshots\";
        public static string ExtentReportPath { get; } = Path.GetTempPath() + @"Schoolcafe\Reports\index.html";
        public static string HtmlReportTitle { get; } = @"Automation Test Report";
        public static string HtmlReportName { get; } = @"Functional Report";
        public static Theme HtmlReportTheme { get; } = Theme.Standard;
        public static string EnvironmentName { get; set; } = "Test Environment";
        public static string CurrentUserName { get; } = Environment.UserName;
        public static void InitiateExtentReport(string reportName = null)
        {
            Extent = new ExtentReports();
            switch (Type)
            {
                case "BOTH":
                    ExtentKlovReporter reporter = SetExtentKlovReport(reportName);
                    ExtentHtmlReporter htmlReport = SetExtentHtmlReport(ExtentReportPath);
                    Extent.AttachReporter(reporter);
                    Extent.AttachReporter(htmlReport);
                    break;
                case "HTML":
                    ExtentHtmlReporter htmlReport1 = SetExtentHtmlReport(ExtentReportPath);
                    Extent.AttachReporter(htmlReport1);
                    break;
                case "KLOV":
                    ExtentKlovReporter reporter1 = SetExtentKlovReport(reportName);
                    Extent.AttachReporter(reporter1);
                    break;
                default:
                    break;
            }

            SetExtentSystemInfo();
        }

        private static ExtentHtmlReporter SetExtentHtmlReport(string reportPath)
        {
            //To DO: refer this report- http://relevantcodes.com/Tools/ExtentReports2/samples/ChildNodesView.html#!
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.Config.DocumentTitle = HtmlReportTitle;
            htmlReporter.Config.ReportName = HtmlReportName;
            htmlReporter.Config.Theme = HtmlReportTheme;

            return htmlReporter;
        }

        private static ExtentKlovReporter SetExtentKlovReport(string reportName = null)
        {
            //To DO: refer this report- http://relevantcodes.com/Tools/ExtentReports2/samples/ChildNodesView.html#!
            if (reportName == null)
            {
                reportName = "PrimeroedgeNext ";
            }

            //ExtentKlovReporter klovReporter = new ExtentKlovReporter("PrimeroedgeNext", reportName + " " + DateTime.Now.ToString());
            //klovReporter.InitMongoDbConnection(EnvironmentManager.KlovReportMongoDbHost, EnvironmentManager.KlovReportMongoDbPort);
            //klovReporter.InitKlovServerConnection(EnvironmentManager.KlovReportServerConnectionURL);
            return null;
            //return klovReporter;
        }

        public static void CreateExtentTest(string testname)
        {
            ExtentTest = Extent.CreateTest(testname);
        }

        private static void SetExtentSystemInfo()
        {
            Extent.AddSystemInfo("Environment", EnvironmentName);
            Extent.AddSystemInfo("Username", CurrentUserName);
        }

        public static MediaEntityModelProvider CreateScreenCapture(string path)
        {
            return MediaEntityBuilder.CreateScreenCaptureFromPath(path).Build();
        }

        public static void CreateExtentNode(string nodeName)
        {
            ExtentTest.CreateNode(nodeName);
        }
    }

}

