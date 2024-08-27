using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace UnionReporting.Forms.Pages;

public class MainPage: Form
{
    private ILabel VariantLbl => ElementFactory.GetLabel(By.XPath("//p[contains(@class, 'footer-text')]/span"), nameof(VariantLbl));
    private IButton AddProjectBtn => ElementFactory.GetButton(By.XPath("//a[contains(text(),'+Add')]"), nameof(AddProjectBtn));

    private IButton ProjectBtn(string projectName)
    {
        return ElementFactory.GetButton(By.XPath($"//a[text()='{projectName}']"), nameof(ProjectBtn));
    }

    public MainPage() : base(By.XPath("//div[contains(text(), 'Available projects')]"), nameof(MainPage))
    {
    }

    public bool IsDisplayed => FormElement.State.WaitForDisplayed();

    public bool IsProjectDisplayed(string projectName)
    {
        return ProjectBtn(projectName).State.WaitForDisplayed();
    }

    public string GetProjectId(string projectName)
    {
        return ProjectBtn(projectName).GetAttribute("href")[^1].ToString();
    }

    public string GetVariant()
    {
        return VariantLbl.Text[^1].ToString();
    }

    public void ClickAddProjectBtn()
    {
        AddProjectBtn.Click();
    }

    public void GoToProjectPage(string projectName)
    {
        ProjectBtn(projectName).Click();
    }
}
