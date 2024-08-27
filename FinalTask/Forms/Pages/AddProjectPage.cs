using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace UnionReporting.Forms.Pages;

public class AddProjectPage: Form
{
    private ITextBox EnterProjectNameTxb => FormElement.FindChildElement<ITextBox>(By.Id("projectName"), nameof(EnterProjectNameTxb));
    private ILabel SuccessfulSaveMsg => FormElement.FindChildElement<ILabel>(By.ClassName("alert-success"), "Save project response message");
    private IButton SaveProjectBtn => FormElement.FindChildElement<IButton>(By.XPath("//button[contains(text(),'Save')]"), nameof(SaveProjectBtn));

    public AddProjectPage() : base(By.Id("addProjectForm"), nameof(AddProjectPage))
    {
    }

    public bool IsClosed => FormElement.State.WaitForNotDisplayed();
    public bool IsProjectSavedSuccesfully => SuccessfulSaveMsg.State.WaitForDisplayed();

    public void EnterProjectName(string projectName)
    {
        EnterProjectNameTxb.ClearAndType(projectName);
    }

    public void SaveProject()
    {
        SaveProjectBtn.Click();
    }

    public void AddProject(string projectName)
    {
        EnterProjectName(projectName);
        SaveProject();
    }
}
