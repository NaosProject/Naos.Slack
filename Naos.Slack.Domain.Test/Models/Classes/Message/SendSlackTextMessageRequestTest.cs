// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendSlackTextMessageRequestTest.cs" company="Naos Project">
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
    public static partial class SendSlackTextMessageRequestTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static SendSlackTextMessageRequestTest()
        {
            ConstructorArgumentValidationTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SendSlackTextMessageRequest>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'channel' is null scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<SendSlackTextMessageRequest>();

                            var result = new SendSlackTextMessageRequest(
                                                 null,
                                                 referenceObject.Text,
                                                 referenceObject.TextFormat,
                                                 referenceObject.Options,
                                                 referenceObject.MessageAuthorIconOverride,
                                                 referenceObject.MessageAuthorUsernameOverride);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "channel", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SendSlackTextMessageRequest>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'channel' is white space scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<SendSlackTextMessageRequest>();

                            var result = new SendSlackTextMessageRequest(
                                                 Invariant($"  {Environment.NewLine}  "),
                                                 referenceObject.Text,
                                                 referenceObject.TextFormat,
                                                 referenceObject.Options,
                                                 referenceObject.MessageAuthorIconOverride,
                                                 referenceObject.MessageAuthorUsernameOverride);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "channel", "white space", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SendSlackTextMessageRequest>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'text' is null scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<SendSlackTextMessageRequest>();

                            var result = new SendSlackTextMessageRequest(
                                                 referenceObject.Channel,
                                                 null,
                                                 referenceObject.TextFormat,
                                                 referenceObject.Options,
                                                 referenceObject.MessageAuthorIconOverride,
                                                 referenceObject.MessageAuthorUsernameOverride);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "text", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SendSlackTextMessageRequest>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'text' is white space scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<SendSlackTextMessageRequest>();

                            var result = new SendSlackTextMessageRequest(
                                                 referenceObject.Channel,
                                                 Invariant($"  {Environment.NewLine}  "),
                                                 referenceObject.TextFormat,
                                                 referenceObject.Options,
                                                 referenceObject.MessageAuthorIconOverride,
                                                 referenceObject.MessageAuthorUsernameOverride);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "text", "white space", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SendSlackTextMessageRequest>
                    {
                        Name = "constructor should throw ArgumentOutOfRangeException when parameter 'textFormat' is SlackTextFormat.Unknown scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<SendSlackTextMessageRequest>();

                            var result = new SendSlackTextMessageRequest(
                                referenceObject.Channel,
                                referenceObject.Text,
                                SlackTextFormat.Unknown,
                                referenceObject.Options,
                                referenceObject.MessageAuthorIconOverride,
                                referenceObject.MessageAuthorUsernameOverride);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentOutOfRangeException),
                        ExpectedExceptionMessageContains = new[] { "textFormat", "Unknown", },
                    });
        }
    }
}