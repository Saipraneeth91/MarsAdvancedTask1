using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Configuration;
using MarsAdvancedTask1.Pages;
using MarsAdvancedTask1.Pages.Components.Profilepage;

public class DriverFactory : IDisposable
{
    public static IWebDriver? driver { get; private set; }
    protected static ExtentReports extent;
    protected static ExtentTest test;

    [OneTimeSetUp]
    public void Setup()
    {
        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        string reportsFolder = Path.Combine(projectDirectory, "Reports");
        if (!Directory.Exists(reportsFolder))
        {
            Directory.CreateDirectory(reportsFolder);
        }

        string reportPath = Path.Combine(reportsFolder, "TestReport.html");
        var htmlReporter = new ExtentHtmlReporter(reportPath)
        {
            Config = { ReportName = "Automation Test Report", DocumentTitle = "Test Report" }
        };

        extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);
        extent.AddSystemInfo("Host Name", "Local host");
        extent.AddSystemInfo("Username", "Sai Praneeth");

        // Start browser for tests
        StartBrowser();
        DeleteAllExistingData();
    }

    public void StartBrowser()
    {
        // Create a test node with the current test name
        test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

        string browser = ConfigurationManager.AppSettings.Get("browser");
        string url = ConfigurationManager.AppSettings.Get("url");
        InitBrowser(browser);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl(url);
    }

    public void InitBrowser(string browser)
    {
        switch (browser)
        {
            case "Chrome":
                driver = new ChromeDriver();
                break;
            case "Firefox":
                driver = new FirefoxDriver();
                break;
            default:
                throw new ArgumentException("Browser not supported: " + browser);
        }
    }

    [TearDown]
    public void Cleanup()
    {
        var testResult = TestContext.CurrentContext.Result;
        var status = testResult.Outcome.Status;
        var stackTrace = testResult.StackTrace;
        DateTime time = DateTime.Now;
        string fileName = "Screenshot_" + time.ToString("yyyyMMdd_HHmmss") + ".png";
        string screenshotsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");

        if (!Directory.Exists(screenshotsFolder))
        {
            Directory.CreateDirectory(screenshotsFolder);
        }

        string filePath = Path.Combine(screenshotsFolder, fileName);

        if (status == NUnit.Framework.Interfaces.TestStatus.Failed || status == NUnit.Framework.Interfaces.TestStatus.Passed)
        {
            try
            {
                CaptureScreenshot(filePath);
                var screenshotMedia = MediaEntityBuilder.CreateScreenCaptureFromPath(filePath).Build();
                test?.Log(status == NUnit.Framework.Interfaces.TestStatus.Failed ? Status.Fail : Status.Pass,
                         "Test " + (status == NUnit.Framework.Interfaces.TestStatus.Failed ? "failed" : "passed"),
                         screenshotMedia);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to capture screenshot: " + ex.Message);
            }
        }

        // Dispose driver after each test
        driver?.Quit();
        driver?.Dispose();
        driver = null;

        // Flush ExtentReports for the current test
        extent?.Flush();
    }

    private void CaptureScreenshot(string filePath)
    {
        if (driver != null)
        {
            try
            {
                ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                screenshot.SaveAsFile(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to capture screenshot: " + ex.Message);
            }
        }
    }
    private void DeleteAllExistingData()
    {
        var loginPage = new LoginPage(driver);
        var languagetab = new Profilelanguagetab(driver);
        var skilltab = new Profileskillstab(driver);
        loginPage.LoginActions("saipraneethg.91@gmail.com", "Praneeth@1");
        languagetab.ClearLanguage();
        skilltab.ClearSkills();
    }

    [OneTimeTearDown]
    public void EndReport()
    {
        // Flush extent reports after all tests
        extent?.Flush();
    }

    public void Dispose()
    {
        // Dispose resources, if necessary
        driver?.Dispose();
        extent?.Flush();
    }
}

