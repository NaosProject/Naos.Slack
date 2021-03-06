﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SucceededInUploadingFileToSlackEvent{TId}Test.cs" company="Naos Project">
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
    public static partial class SucceededInUploadingFileToSlackEventTIdTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static SucceededInUploadingFileToSlackEventTIdTest()
        {
            ConstructorArgumentValidationTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SucceededInUploadingFileToSlackEvent<Version>>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'UploadFileToSlackResponse' is null scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<SucceededInUploadingFileToSlackEvent<Version>>();

                            var result = new SucceededInUploadingFileToSlackEvent<Version>(
                                referenceObject.Id,
                                referenceObject.TimestampUtc,
                                null);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "uploadFileToSlackResponse", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SucceededInUploadingFileToSlackEvent<Version>>
                    {
                        Name = "constructor should throw ArgumentOutOfRangeException when uploadFileToSlackResponse.UploadFileToSlackResult is not equal to UploadFileToSlackResult.Succeeded scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<SucceededInUploadingFileToSlackEvent<Version>>();

                            var uploadFileToSlackResponse = A.Dummy<UploadFileToSlackResponse>().ThatIs(_ => _.UploadFileToSlackResult != UploadFileToSlackResult.Succeeded);

                            var result = new SucceededInUploadingFileToSlackEvent<Version>(
                                referenceObject.Id,
                                referenceObject.TimestampUtc,
                                uploadFileToSlackResponse);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentOutOfRangeException),
                        ExpectedExceptionMessageContains = new[] { "uploadFileToSlackResponse.UploadFileToSlackResult", "Succeeded", "is not equal to the comparison value" },
                    });
        }
    }
}