using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using UnionReporting.Models;

namespace UnionReporting.Forms.Pages;

public class ProjectPage : Form
{
    private IList<ILabel> TestStartTimes => ElementFactory.FindElements<ILabel>(By.XPath("//table[@class='table']//td[4]"), nameof(TestStartTimes));

    private static ILabel TestRow(int testId)
    {
        return ElementFactory.GetLabel(By.XPath($"//a[@href='testInfo?testId={testId}']/parent::td/parent::tr"), nameof(TestRow));
    }

    public ProjectPage() : base(By.Id("allTests"), nameof(ProjectPage))
    {
    }

    public bool IsDisplayed => FormElement.State.WaitForDisplayed();

    public static bool TestRowIsDisplayed(int testId)
    {
        return TestRow(testId).State.WaitForDisplayed();
    }

    public List<UnionTest> GetTests()
    {
        const int firstRow = 2;
        const int lastRow = 21;
        List<UnionTest> tests = new();
        for (int rowNum = firstRow; rowNum <= lastRow; rowNum++)
        {
            TestRow testRow = new(rowNum);
            UnionTest test = new(testRow);
            tests.Add(test);
        }
        return tests;
    }

    public List<DateTime> GetTestDates(List<UnionTest> tests)
    {
        List<DateTime> dates = new();
        foreach (UnionTest test in tests)
        {
            DateTime date = DateTime.Parse(test.StartTime);
            dates.Add(date);
        }
        return dates;
    }
}
