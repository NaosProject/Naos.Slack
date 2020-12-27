// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendSlackMessageResponseTest.cs" company="Naos Project">
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
    using OBeautifulCode.Equality.Recipes;
    using OBeautifulCode.Math.Recipes;

    using Xunit;

    using static System.FormattableString;

    [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
    public static partial class SendSlackMessageResponseTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static SendSlackMessageResponseTest()
        {
            ConstructorArgumentValidationTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SendSlackMessageResponse>
                    {
                        Name = "constructor should throw ArgumentOutOfRangeException when parameter 'sendSlackMessageResult' is SendSlackMessageResult.Unknown",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<SendSlackMessageResponse>();

                            var result = new SendSlackMessageResponse(
                                SendSlackMessageResult.Unknown,
                                referenceObject.ResponseJson,
                                referenceObject.ExceptionToString);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentOutOfRangeException),
                        ExpectedExceptionMessageContains = new[] { "sendSlackMessageResult", "Unknown" },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SendSlackMessageResponse>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'responseJson' is null and 'sendSlackMessageResult' is SendSlackMessageResult.Succeeded or SendSlackMessageResult.FailedWithSlackReturningError scenario",
                        ConstructionFunc = () =>
                        {
                            var sendSlackMessageResult = A.Dummy<SendSlackMessageResult>().ThatIs(_ => (_ == SendSlackMessageResult.Succeeded) || (_ == SendSlackMessageResult.FailedWithSlackReturningError));

                            var result = new SendSlackMessageResponse(
                                                 sendSlackMessageResult,
                                                 null,
                                                 null);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "responseJson", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SendSlackMessageResponse>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'responseJson' is white space and 'sendSlackMessageResult' is SendSlackMessageResult.Succeeded or SendSlackMessageResult.FailedWithSlackReturningError scenario",
                        ConstructionFunc = () =>
                        {
                            var sendSlackMessageResult = A.Dummy<SendSlackMessageResult>().ThatIs(_ => (_ == SendSlackMessageResult.Succeeded) || (_ == SendSlackMessageResult.FailedWithSlackReturningError));

                            var result = new SendSlackMessageResponse(
                                sendSlackMessageResult,
                                "  \r\n  ",
                                null);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "responseJson", "white space" },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SendSlackMessageResponse>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'responseJson' is not null and 'sendSlackMessageResult' is SendSlackMessageResult.FailedWithExceptionWhenSending scenario",
                        ConstructionFunc = () =>
                        {
                            var result = new SendSlackMessageResponse(
                                SendSlackMessageResult.FailedWithExceptionWhenSending,
                                A.Dummy<string>(),
                                A.Dummy<string>());

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "responseJson", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SendSlackMessageResponse>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'exceptionToString' is null and 'sendSlackMessageResult' is SendSlackMessageResult.FailedWithExceptionWhenSending scenario",
                        ConstructionFunc = () =>
                        {
                            var result = new SendSlackMessageResponse(
                                                 SendSlackMessageResult.FailedWithExceptionWhenSending,
                                                 null,
                                                 null);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "exceptionToString", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SendSlackMessageResponse>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'exceptionToString' is white space and 'sendSlackMessageResult' is SendSlackMessageResult.FailedWithExceptionWhenSending scenario",
                        ConstructionFunc = () =>
                        {
                            var result = new SendSlackMessageResponse(
                                SendSlackMessageResult.FailedWithExceptionWhenSending,
                                null,
                                "  \r\n  ");

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "exceptionToString", "white space" },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<SendSlackMessageResponse>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'exceptionToString' is not null and 'sendSlackMessageResult' is SendSlackMessageResult.Succeeded or SendSlackMessageResult.FailedWithSlackReturningError scenario",
                        ConstructionFunc = () =>
                        {
                            var sendSlackMessageResult = A.Dummy<SendSlackMessageResult>().ThatIs(_ => (_ == SendSlackMessageResult.Succeeded) || (_ == SendSlackMessageResult.FailedWithSlackReturningError));

                            var result = new SendSlackMessageResponse(
                                sendSlackMessageResult,
                                A.Dummy<string>(),
                                A.Dummy<string>());

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "exceptionToString", },
                    });

            DeepCloneWithTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new DeepCloneWithTestScenario<SendSlackMessageResponse>
                    {
                        Name = "DeepCloneWithSendSlackMessageResult should deep clone object and replace SendSlackMessageResult with the provided sendSlackMessageResult",
                        WithPropertyName = "SendSlackMessageResult",
                        SystemUnderTestDeepCloneWithValueFunc = () =>
                        {
                            var systemUnderTest = A.Dummy<SendSlackMessageResponse>().ThatIs(_ => (_.SendSlackMessageResult == SendSlackMessageResult.Succeeded) || (_.SendSlackMessageResult == SendSlackMessageResult.FailedWithSlackReturningError));

                            var referenceObject = A.Dummy<SendSlackMessageResponse>().ThatIs(_ => !systemUnderTest.SendSlackMessageResult.IsEqualTo(_.SendSlackMessageResult) && (_.SendSlackMessageResult != SendSlackMessageResult.FailedWithExceptionWhenSending));

                            var result = new SystemUnderTestDeepCloneWithValue<SendSlackMessageResponse>
                            {
                                SystemUnderTest = systemUnderTest,
                                DeepCloneWithValue = referenceObject.SendSlackMessageResult,
                            };

                            return result;
                        },
                    })
                .AddScenario(() =>
                    new DeepCloneWithTestScenario<SendSlackMessageResponse>
                    {
                        Name = "DeepCloneWithResponseJson should deep clone object and replace ResponseJson with the provided responseJson",
                        WithPropertyName = "ResponseJson",
                        SystemUnderTestDeepCloneWithValueFunc = () =>
                        {
                            var systemUnderTest = A.Dummy<SendSlackMessageResponse>().ThatIs(_ => (_.SendSlackMessageResult == SendSlackMessageResult.Succeeded) || (_.SendSlackMessageResult == SendSlackMessageResult.FailedWithSlackReturningError));

                            var referenceObject = A.Dummy<SendSlackMessageResponse>().ThatIs(_ => !systemUnderTest.ResponseJson.IsEqualTo(_.ResponseJson) && (_.SendSlackMessageResult != SendSlackMessageResult.FailedWithExceptionWhenSending));

                            var result = new SystemUnderTestDeepCloneWithValue<SendSlackMessageResponse>
                            {
                                SystemUnderTest = systemUnderTest,
                                DeepCloneWithValue = referenceObject.ResponseJson,
                            };

                            return result;
                        },
                    })
                .AddScenario(() =>
                    new DeepCloneWithTestScenario<SendSlackMessageResponse>
                    {
                        Name = "DeepCloneWithExceptionToString should deep clone object and replace ExceptionToString with the provided exceptionToString",
                        WithPropertyName = "ExceptionToString",
                        SystemUnderTestDeepCloneWithValueFunc = () =>
                        {
                            var systemUnderTest = A.Dummy<SendSlackMessageResponse>().ThatIs(_ => (_.SendSlackMessageResult == SendSlackMessageResult.FailedWithExceptionWhenSending));

                            var referenceObject = A.Dummy<SendSlackMessageResponse>().ThatIs(_ => !systemUnderTest.ExceptionToString.IsEqualTo(_.ExceptionToString) && (_.SendSlackMessageResult == SendSlackMessageResult.FailedWithExceptionWhenSending));

                            var result = new SystemUnderTestDeepCloneWithValue<SendSlackMessageResponse>
                            {
                                SystemUnderTest = systemUnderTest,
                                DeepCloneWithValue = referenceObject.ExceptionToString,
                            };

                            return result;
                        },
                    });

            var referenceObjectForEquatableTestScenarios1 = A.Dummy<SendSlackMessageResponse>().Whose(_ => (_.SendSlackMessageResult == SendSlackMessageResult.Succeeded) || (_.SendSlackMessageResult == SendSlackMessageResult.FailedWithSlackReturningError));
            var referenceObjectForEquatableTestScenarios2 = A.Dummy<SendSlackMessageResponse>().Whose(_ => _.SendSlackMessageResult == SendSlackMessageResult.FailedWithExceptionWhenSending);

            EquatableTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new EquatableTestScenario<SendSlackMessageResponse>
                    {
                        Name = "Default Code Generated Scenario",
                        ReferenceObject = referenceObjectForEquatableTestScenarios1,
                        ObjectsThatAreEqualToButNotTheSameAsReferenceObject = new SendSlackMessageResponse[]
                        {
                            new SendSlackMessageResponse(
                                referenceObjectForEquatableTestScenarios1.SendSlackMessageResult,
                                referenceObjectForEquatableTestScenarios1.ResponseJson,
                                referenceObjectForEquatableTestScenarios1.ExceptionToString),
                        },
                        ObjectsThatAreNotEqualToReferenceObject = new SendSlackMessageResponse[]
                        {
                            new SendSlackMessageResponse(
                                A.Dummy<SendSlackMessageResponse>().Whose(_ => !_.SendSlackMessageResult.IsEqualTo(referenceObjectForEquatableTestScenarios1.SendSlackMessageResult) && (_.SendSlackMessageResult != SendSlackMessageResult.FailedWithExceptionWhenSending)).SendSlackMessageResult,
                                referenceObjectForEquatableTestScenarios1.ResponseJson,
                                referenceObjectForEquatableTestScenarios1.ExceptionToString),
                            new SendSlackMessageResponse(
                                referenceObjectForEquatableTestScenarios1.SendSlackMessageResult,
                                A.Dummy<SendSlackMessageResponse>().Whose(_ => !_.ResponseJson.IsEqualTo(referenceObjectForEquatableTestScenarios1.ResponseJson) && (_.SendSlackMessageResult != SendSlackMessageResult.FailedWithExceptionWhenSending)).ResponseJson,
                                referenceObjectForEquatableTestScenarios1.ExceptionToString),
                        },
                        ObjectsThatAreNotOfTheSameTypeAsReferenceObject = new object[]
                        {
                            A.Dummy<object>(),
                            A.Dummy<string>(),
                            A.Dummy<int>(),
                            A.Dummy<int?>(),
                            A.Dummy<Guid>(),
                        },
                    })
                .AddScenario(() =>
                    new EquatableTestScenario<SendSlackMessageResponse>
                    {
                        Name = "Default Code Generated Scenario",
                        ReferenceObject = referenceObjectForEquatableTestScenarios2,
                        ObjectsThatAreEqualToButNotTheSameAsReferenceObject = new SendSlackMessageResponse[]
                        {
                            new SendSlackMessageResponse(
                                referenceObjectForEquatableTestScenarios2.SendSlackMessageResult,
                                referenceObjectForEquatableTestScenarios2.ResponseJson,
                                referenceObjectForEquatableTestScenarios2.ExceptionToString),
                        },
                        ObjectsThatAreNotEqualToReferenceObject = new SendSlackMessageResponse[]
                        {
                            new SendSlackMessageResponse(
                                referenceObjectForEquatableTestScenarios2.SendSlackMessageResult,
                                referenceObjectForEquatableTestScenarios2.ResponseJson,
                                A.Dummy<SendSlackMessageResponse>().Whose(_ => !_.ExceptionToString.IsEqualTo(referenceObjectForEquatableTestScenarios2.ExceptionToString) && (_.SendSlackMessageResult == SendSlackMessageResult.FailedWithExceptionWhenSending)).ExceptionToString),
                        },
                        ObjectsThatAreNotOfTheSameTypeAsReferenceObject = new object[]
                        {
                            A.Dummy<object>(),
                            A.Dummy<string>(),
                            A.Dummy<int>(),
                            A.Dummy<int?>(),
                            A.Dummy<Guid>(),
                        },
                    });
        }
    }
}