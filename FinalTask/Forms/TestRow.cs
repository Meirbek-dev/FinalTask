using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace UnionReporting.Forms;

public class TestRow: Form
{
    private ILabel TestName => FormElement.FindChildElement<ILabel>(By.XPath("/td[1]"), nameof(TestName));
    private ILabel TestMethod => FormElement.FindChildElement<ILabel>(By.XPath("/td[2]"), nameof(TestMethod));
    private ILabel TestResult => FormElement.FindChildElement<ILabel>(By.XPath("/td[3]"), nameof(TestResult));
    private ILabel TestStartTime => FormElement.FindChildElement<ILabel>(By.XPath("/td[4]"), nameof(TestStartTime));
    private ILabel TestEndTime => FormElement.FindChildElement<ILabel>(By.XPath("/td[5]"), nameof(TestEndTime));
    private ILabel TestDuration => FormElement.FindChildElement<ILabel>(By.XPath("/td[6]"), nameof(TestDuration));

    public TestRow(int rowNum) : base(By.XPath($"//table[@class='table']//tr[{rowNum}]"), $"{nameof(TestRow)} #{rowNum}")
    {
    }

    public bool IsDisplayed => FormElement.State.WaitForDisplayed();

    public string GetTestName()
    {
        return TestName.Text;
    }

    public string GetTestMethod()
    {
        return TestMethod.Text;
    }

    public string GetTestResult()
    {
        return TestResult.Text;
    }

    public string GetTestStartTime()
    {
        return TestStartTime.Text;
    }

    public string GetTestEndTime()
    {
        return TestEndTime.Text;
    }

    public string GetTestDuration()
    {
        return TestDuration.Text;
    }
}
