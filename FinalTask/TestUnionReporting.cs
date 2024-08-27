using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using UnionReporting.Configurations;
using UnionReporting.Forms.Pages;
using UnionReporting.Models;
using UnionReporting.Steps;
using UnionReporting.Utils;

namespace UnionReporting;

public class UnionTests: BaseTest
{
    private static readonly TestData _testData = TestData.GetTestData();

    [Test]
    public void TestUnionReporting()
    {
        _testData.Browser = DriverUtil.GetBrowserName();
        _testData.SID = Guid.NewGuid().ToString();
        string variant = _testData.Variant;
        string token = UnionApiUtil.GetToken(variant);
        Assert.That(token, Is.Not.Empty, $"Access token was not received. Token: {token}");

        DriverUtil.GoTo(Configuration.StartUrl);
        MainPage mainPage = new();
        Assert.That(mainPage.IsDisplayed, $"{mainPage.Name} is not displayed.");
        DriverUtil.AddCookie("token", token);
        DriverUtil.Refresh();
        string actualVariant = mainPage.GetVariant();
        string expectedVariant = variant;
        Assert.That(actualVariant, Is.EqualTo(expectedVariant), $"Actual variant: {actualVariant}, is different from expected: {expectedVariant}.");
        string nexageProjectName = _testData.TestProjectName;
        string nexageProjectId = mainPage.GetProjectId(nexageProjectName);
        mainPage.GoToProjectPage(nexageProjectName);

        ProjectPage nexagePage = new();
        Assert.That(nexagePage.IsDisplayed, $"Project '{nexageProjectName}' page is not displayed");
        List<UnionTest> apiNexageTests = TestSteps.GetApiTestsOrderedByStartTime(nexageProjectId, 20);
        List<UnionTest> webNexageTests = nexagePage.GetTests();
        List<DateTime> testDates = nexagePage.GetTestDates(webNexageTests);
        Assert.Multiple(() =>
        {
            Assert.That(apiNexageTests, Is.EqualTo(webNexageTests), "Tests from API-request are different from tests on web page.");
            Assert.That(SortingUtil.AreTestDatesInDescendingOrder(testDates), Is.True, "Test dates are not sorted in descending order.");
        });
        DriverUtil.GoBack();
        mainPage.ClickAddProjectBtn();

        string mainWindow = DriverUtil.GetCurrentWindowHandle();
        DriverUtil.SwitchToWindow(DriverUtil.GetWindowHandle(1));
        AddProjectPage addProjectPage = new();
        _testData.ProjectName = Utils.Randomizer.GetText();
        addProjectPage.AddProject(_testData.ProjectName);
        Assert.That(addProjectPage.IsProjectSavedSuccesfully, Is.True, "Project is not saved succesfully");
        DriverUtil.CloseTab();
        DriverUtil.SwitchToWindow(mainWindow);
        Assert.That(addProjectPage.IsClosed, $"{addProjectPage.Name} is still displayed");
        DriverUtil.Refresh();
        Assert.That(mainPage.IsProjectDisplayed(_testData.ProjectName));

        mainPage.GoToProjectPage(_testData.ProjectName);
        int testId = TestSteps.PutTest(_testData);
        Assert.That(ProjectPage.TestRowIsDisplayed(testId), $"Test with id: {testId} is not displayed");
    }
}
