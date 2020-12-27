// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FailedToUploadFileToSlackEvent{TId}Test.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using FakeItEasy;

    using OBeautifulCode.AutoFakeItEasy;
    using OBeautifulCode.CodeAnalysis.Recipes;
    using OBeautifulCode.CodeGen.ModelObject.Recipes;
    using OBeautifulCode.Math.Recipes;

    using Xunit;

    using static System.FormattableString;

    [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
    public static partial class FailedToUploadFileToSlackEventTIdTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static FailedToUploadFileToSlackEventTIdTest()
        {
            ConstructorArgumentValidationTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<FailedToUploadFileToSlackEvent<Version>>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'UploadFileToSlackResponse' is null scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<FailedToUploadFileToSlackEvent<Version>>();

                            var result = new FailedToUploadFileToSlackEvent<Version>(
                                referenceObject.Id,
                                referenceObject.TimestampUtc,
                                null);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "uploadFileToSlackResponse", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<FailedToUploadFileToSlackEvent<Version>>
                    {
                        Name = "constructor should throw ArgumentOutOfRangeException when uploadFileToSlackResponse.UploadFileToSlackResult is equal to UploadFileToSlackResult.Succeeded scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<FailedToUploadFileToSlackEvent<Version>>();

                            var uploadFileToSlackResponse = A.Dummy<UploadFileToSlackResponse>().ThatIs(_ => _.UploadFileToSlackResult == UploadFileToSlackResult.Succeeded);

                            var result = new FailedToUploadFileToSlackEvent<Version>(
                                referenceObject.Id,
                                referenceObject.TimestampUtc,
                                uploadFileToSlackResponse);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentOutOfRangeException),
                        ExpectedExceptionMessageContains = new[] { "uploadFileToSlackResponse.UploadFileToSlackResult", "Succeeded", "is equal to the comparison value" },
                    });
        }
    }
}