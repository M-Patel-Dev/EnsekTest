using Microsoft.Extensions.Logging;
using Moq;
using MP.EnsekTest.Api.Business.MeterReads;
using MP.EnsekTest.Api.Controllers;
using MP.EnsekTest.Api.Dtos;
using MP.EnsekTest.Api.ModelBinders;
using MP.EnsekTest.Utilities.Helpers;

namespace MP.EnsekTest.Api.Tests
{
    public static class TestCases
    {

        public static IEnumerable<TestCaseData> MeterReadingsValidatorValidDataTestCase
        {
            get
            {
                var data = new List<MeterReadingDto>
                {
                    new MeterReadingDto { AccountId = 1234, MeterReadingDateTime = DateTime.Now, MeterReadValue = "12345" },
                    new MeterReadingDto { AccountId = 1235, MeterReadingDateTime = DateTime.Now.AddYears(-1), MeterReadValue = "78945" },
                    new MeterReadingDto { AccountId = 1235, MeterReadingDateTime = DateTime.Now, MeterReadValue = "79445" },
                };

                yield return new TestCaseData(data);
            }
        }

        public static IEnumerable<TestCaseData> MeterReadingsValidatorInvalidDataTestCase
        {
            get
            {
                var data = new List<MeterReadingDto>
                {
                    new MeterReadingDto { AccountId = -1, MeterReadingDateTime = DateTime.Now, MeterReadValue = "123" },
                    new MeterReadingDto { AccountId = 1234, MeterReadingDateTime = DateTime.Now, MeterReadValue = "123" },
                    new MeterReadingDto { AccountId = 1235, MeterReadingDateTime = DateTime.Now, MeterReadValue = "abc" },
                    new MeterReadingDto { AccountId = 1235, MeterReadingDateTime = DateTime.Now, MeterReadValue = "123456" },
                };

                yield return new TestCaseData(data);
            }
        }

        public static IEnumerable<TestCaseData> MeterReadingCsvModelBinderConstructorTestCases
        {
            get
            {
                yield return new TestCaseData(null, null);
                yield return new TestCaseData(new Mock<ICsvParser<MeterReadingDto>>().Object, null);
                yield return new TestCaseData(null, new Mock<ILogger<MeterReadingCsvModelBinder>>().Object);
            }
        }

        public static IEnumerable<TestCaseData> MeterReadingsControllerConstructorTestCases
        {
            get
            {
                yield return new TestCaseData(null, null);
                yield return new TestCaseData(new Mock<IMeterReadingsService>().Object, null);
                yield return new TestCaseData(null, new Mock<ILogger<MeterReadingsController>>().Object);
            }
        }

        public static IEnumerable<TestCaseData> MeterReadingsServiceConstructorTestCases
        {
            get
            {
                yield return new TestCaseData(null, null, null);

                yield return new TestCaseData(new Mock<IMeterReadingsValidator>().Object, null, null);
                yield return new TestCaseData(new Mock<IMeterReadingsValidator>().Object, new Mock<IMeterReadingsPersistor>().Object, null);

                yield return new TestCaseData(new Mock<IMeterReadingsValidator>().Object, null, new Mock<ILogger<MeterReadingsService>>().Object);
                yield return new TestCaseData(new Mock<IMeterReadingsValidator>().Object, new Mock<IMeterReadingsPersistor>().Object, null);

                yield return new TestCaseData(null, new Mock<IMeterReadingsPersistor>().Object, new Mock<ILogger<MeterReadingsService>>().Object);
                yield return new TestCaseData(null, new Mock<IMeterReadingsPersistor>().Object, null);
            }
        }
    }
}
