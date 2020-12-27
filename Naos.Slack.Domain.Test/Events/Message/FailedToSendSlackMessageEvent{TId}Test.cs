﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FailedToSendSlackMessageEvent{TId}Test.cs" company="Naos Project">
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
    public static partial class FailedToSendSlackMessageEventTIdTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static FailedToSendSlackMessageEventTIdTest()
        {
            ConstructorArgumentValidationTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<FailedToSendSlackMessageEvent<Version>>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'sendSlackMessageResponse' is null scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<FailedToSendSlackMessageEvent<Version>>();

                            var result = new FailedToSendSlackMessageEvent<Version>(
                                referenceObject.Id,
                                referenceObject.TimestampUtc,
                                null);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "sendSlackMessageResponse", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<FailedToSendSlackMessageEvent<Version>>
                    {
                        Name = "constructor should throw ArgumentOutOfRangeException when sendSlackMessageResponse.SendSlackMessageResult is equal to SendSlackMessageResult.Succeeded scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<FailedToSendSlackMessageEvent<Version>>();

                            var sendSlackMessageResponse = A.Dummy<SendSlackMessageResponse>().ThatIs(_ => _.SendSlackMessageResult == SendSlackMessageResult.Succeeded);

                            var result = new FailedToSendSlackMessageEvent<Version>(
                                referenceObject.Id,
                                referenceObject.TimestampUtc,
                                sendSlackMessageResponse);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentOutOfRangeException),
                        ExpectedExceptionMessageContains = new[] { "sendSlackMessageResponse.SendSlackMessageResult", "Succeeded", "is equal to the comparison value" },
                    });
        }
    }
}