using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalTests.StatePrinter;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;

namespace ImportTent.Lib.BLL.Tests
{
    [TestFixture()]
    public class GroupTests
    {
        [Test()]
        [UseReporter(typeof(DiffReporter))]
        public void ImportTest()
        {
            var sut = new Group();
            var csvData = "Abbreviation,Active,ActiveYears,Comment,FilingCount,Name,Years" + Environment.NewLine +
                          "JD,True,2,some comment,1,John Doe0,2" + Environment.NewLine +
                          "JD,True,2,some comment,0,John Doe1,2" + Environment.NewLine +
                          "JD,True,2,some comment,0,John Doe2,2" + Environment.NewLine +
                          "JD,True,2,some comment,0,John Doe3,2" + Environment.NewLine +
                          "JD,True,2,some comment,0,John Doe4,2" + Environment.NewLine +
                          "JD,True,2,some comment,0,John Doe5,2" + Environment.NewLine +
                          "JD,True,2,some comment,0,John Doe6,2" + Environment.NewLine +
                          "JD,True,2,some comment,0,John Doe7,2" + Environment.NewLine +
                          "JD,True,2,some comment,0,John Doe8,2" + Environment.NewLine +
                          "JD,True,2,some comment,0,John Doe9,2" + Environment.NewLine +
                          "JD,True,2,some comment,0,John Doe10,2";

            var result = sut.Import(csvData);

            // Assert
            StatePrinterApprovals.Verify(result);
        }
        [Test()]
        [UseReporter(typeof(DiffReporter))]
        public void ImportTest_ToManyColumns()
        {
            var sut = new Group();
            var csvData = "Abbreviation,Active,ActiveYears,Comment,FilingCount,Name,YearsAGO" + Environment.NewLine +
                          "JD,True,2,some comment,1,John Doe0, 2" + Environment.NewLine +
                          "JD,True,2,some comment,0,John Doe1,2" + Environment.NewLine +
                          "JD,True,2,some comment,0,John Doe2,2";

            var result = sut.Import(csvData);

            // Assert
            StatePrinterApprovals.Verify(result);
        }

        [Test()]
        [UseReporter(typeof(DiffReporter))]
        public void ExportTest()
        {
            var sut = new Group()
            {
                Name = "John Doe Combs",
                Abbreviation = "JDC",
                Comment = "some comment",
                Active = true,
                Years = 2,
                ActiveYears = 2,
                FilingCount = 123
            };

            var testGroups = new List<IGroup>() { sut };
            var result = sut.Export(testGroups);

            result.Length.ShouldBeGreaterThan(1);

            Approvals.Verify(result);
        }

        [Test()]
        [UseReporter(typeof(DiffReporter))]
        public void ExportTest_w_more_data()
        {
            var sut = new Group()
            {
                Name = "John Doe",
                Abbreviation = "JD",
                Comment = "some comment",
                Active = true,
                Years = 2,
                ActiveYears = 2,
                FilingCount = 123
            };

            var testGroups = new List<IGroup>() { sut };

            for (int n = 1; n <= 10; n++)
            {
                var item = new Group()
                {
                    Name = "John Doe" + n.ToString(),
                    Abbreviation = "JD",
                    Comment = "some comment",
                    Active = true,
                    Years = 2,
                    ActiveYears = 2,
                };

                    testGroups.Add(item);
            }

            var result = sut.Export(testGroups);

            result.Length.ShouldBeGreaterThan(1);

            Approvals.Verify(result);
        }
    }
}