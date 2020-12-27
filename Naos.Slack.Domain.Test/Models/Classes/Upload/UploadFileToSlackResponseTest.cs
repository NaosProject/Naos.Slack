// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UploadFileToSlackResponseTest.cs" company="Naos Project">
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
    public static partial class UploadFileToSlackResponseTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static UploadFileToSlackResponseTest()
        {
            ConstructorArgumentValidationTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<UploadFileToSlackResponse>
                    {
                        Name = "constructor should throw ArgumentOutOfRangeException when parameter 'uploadFileToSlackResult' is UploadFileToSlackResult.Unknown",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<UploadFileToSlackResponse>();

                            var result = new UploadFileToSlackResponse(
                                UploadFileToSlackResult.Unknown,
                                referenceObject.ResponseJson,
                                referenceObject.ExceptionToString);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentOutOfRangeException),
                        ExpectedExceptionMessageContains = new[] { "uploadFileToSlackResult", "Unknown" },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<UploadFileToSlackResponse>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'responseJson' is null and 'uploadFileToSlackResult' is UploadFileToSlackResult.Succeeded or UploadFileToSlackResult.FailedWithSlackReturningError scenario",
                        ConstructionFunc = () =>
                        {
                            var uploadFileToSlackResult = A.Dummy<UploadFileToSlackResult>().ThatIs(_ => (_ == UploadFileToSlackResult.Succeeded) || (_ == UploadFileToSlackResult.FailedWithSlackReturningError));

                            var result = new UploadFileToSlackResponse(
                                                 uploadFileToSlackResult,
                                                 null,
                                                 null);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "responseJson", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<UploadFileToSlackResponse>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'responseJson' is white space and 'uploadFileToSlackResult' is UploadFileToSlackResult.Succeeded or UploadFileToSlackResult.FailedWithSlackReturningError scenario",
                        ConstructionFunc = () =>
                        {
                            var uploadFileToSlackResult = A.Dummy<UploadFileToSlackResult>().ThatIs(_ => (_ == UploadFileToSlackResult.Succeeded) || (_ == UploadFileToSlackResult.FailedWithSlackReturningError));

                            var result = new UploadFileToSlackResponse(
                                uploadFileToSlackResult,
                                "  \r\n  ",
                                null);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "responseJson", "white space" },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<UploadFileToSlackResponse>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'responseJson' is not null and 'uploadFileToSlackResult' is UploadFileToSlackResult.FailedWithExceptionWhenUploading scenario",
                        ConstructionFunc = () =>
                        {
                            var result = new UploadFileToSlackResponse(
                                UploadFileToSlackResult.FailedWithExceptionWhenUploading,
                                A.Dummy<string>(),
                                A.Dummy<string>());

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "responseJson", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<UploadFileToSlackResponse>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'exceptionToString' is null and 'uploadFileToSlackResult' is UploadFileToSlackResult.FailedWithExceptionWhenUploading scenario",
                        ConstructionFunc = () =>
                        {
                            var result = new UploadFileToSlackResponse(
                                                 UploadFileToSlackResult.FailedWithExceptionWhenUploading,
                                                 null,
                                                 null);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "exceptionToString", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<UploadFileToSlackResponse>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'exceptionToString' is white space and 'uploadFileToSlackResult' is UploadFileToSlackResult.FailedWithExceptionWhenUploading scenario",
                        ConstructionFunc = () =>
                        {
                            var result = new UploadFileToSlackResponse(
                                UploadFileToSlackResult.FailedWithExceptionWhenUploading,
                                null,
                                "  \r\n  ");

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "exceptionToString", "white space" },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<UploadFileToSlackResponse>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'exceptionToString' is not null and 'uploadFileToSlackResult' is UploadFileToSlackResult.Succeeded or UploadFileToSlackResult.FailedWithSlackReturningError scenario",
                        ConstructionFunc = () =>
                        {
                            var uploadFileToSlackResult = A.Dummy<UploadFileToSlackResult>().ThatIs(_ => (_ == UploadFileToSlackResult.Succeeded) || (_ == UploadFileToSlackResult.FailedWithSlackReturningError));

                            var result = new UploadFileToSlackResponse(
                                uploadFileToSlackResult,
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
                    new DeepCloneWithTestScenario<UploadFileToSlackResponse>
                    {
                        Name = "DeepCloneWithUploadFileToSlackResult should deep clone object and replace UploadFileToSlackResult with the provided sendSlackMessageResult",
                        WithPropertyName = "UploadFileToSlackResult",
                        SystemUnderTestDeepCloneWithValueFunc = () =>
                        {
                            var systemUnderTest = A.Dummy<UploadFileToSlackResponse>().ThatIs(_ => (_.UploadFileToSlackResult == UploadFileToSlackResult.Succeeded) || (_.UploadFileToSlackResult == UploadFileToSlackResult.FailedWithSlackReturningError));

                            var referenceObject = A.Dummy<UploadFileToSlackResponse>().ThatIs(_ => !systemUnderTest.UploadFileToSlackResult.IsEqualTo(_.UploadFileToSlackResult) && (_.UploadFileToSlackResult != UploadFileToSlackResult.FailedWithExceptionWhenUploading));

                            var result = new SystemUnderTestDeepCloneWithValue<UploadFileToSlackResponse>
                            {
                                SystemUnderTest = systemUnderTest,
                                DeepCloneWithValue = referenceObject.UploadFileToSlackResult,
                            };

                            return result;
                        },
                    })
                .AddScenario(() =>
                    new DeepCloneWithTestScenario<UploadFileToSlackResponse>
                    {
                        Name = "DeepCloneWithResponseJson should deep clone object and replace ResponseJson with the provided responseJson",
                        WithPropertyName = "ResponseJson",
                        SystemUnderTestDeepCloneWithValueFunc = () =>
                        {
                            var systemUnderTest = A.Dummy<UploadFileToSlackResponse>().ThatIs(_ => (_.UploadFileToSlackResult == UploadFileToSlackResult.Succeeded) || (_.UploadFileToSlackResult == UploadFileToSlackResult.FailedWithSlackReturningError));

                            var referenceObject = A.Dummy<UploadFileToSlackResponse>().ThatIs(_ => !systemUnderTest.ResponseJson.IsEqualTo(_.ResponseJson) && (_.UploadFileToSlackResult != UploadFileToSlackResult.FailedWithExceptionWhenUploading));

                            var result = new SystemUnderTestDeepCloneWithValue<UploadFileToSlackResponse>
                            {
                                SystemUnderTest = systemUnderTest,
                                DeepCloneWithValue = referenceObject.ResponseJson,
                            };

                            return result;
                        },
                    })
                .AddScenario(() =>
                    new DeepCloneWithTestScenario<UploadFileToSlackResponse>
                    {
                        Name = "DeepCloneWithExceptionToString should deep clone object and replace ExceptionToString with the provided exceptionToString",
                        WithPropertyName = "ExceptionToString",
                        SystemUnderTestDeepCloneWithValueFunc = () =>
                        {
                            var systemUnderTest = A.Dummy<UploadFileToSlackResponse>().ThatIs(_ => (_.UploadFileToSlackResult == UploadFileToSlackResult.FailedWithExceptionWhenUploading));

                            var referenceObject = A.Dummy<UploadFileToSlackResponse>().ThatIs(_ => !systemUnderTest.ExceptionToString.IsEqualTo(_.ExceptionToString) && (_.UploadFileToSlackResult == UploadFileToSlackResult.FailedWithExceptionWhenUploading));

                            var result = new SystemUnderTestDeepCloneWithValue<UploadFileToSlackResponse>
                            {
                                SystemUnderTest = systemUnderTest,
                                DeepCloneWithValue = referenceObject.ExceptionToString,
                            };

                            return result;
                        },
                    });

            var referenceObjectForEquatableTestScenarios1 = A.Dummy<UploadFileToSlackResponse>().Whose(_ => (_.UploadFileToSlackResult == UploadFileToSlackResult.Succeeded) || (_.UploadFileToSlackResult == UploadFileToSlackResult.FailedWithSlackReturningError));
            var referenceObjectForEquatableTestScenarios2 = A.Dummy<UploadFileToSlackResponse>().Whose(_ => _.UploadFileToSlackResult == UploadFileToSlackResult.FailedWithExceptionWhenUploading);

            EquatableTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new EquatableTestScenario<UploadFileToSlackResponse>
                    {
                        Name = "Default Code Generated Scenario",
                        ReferenceObject = referenceObjectForEquatableTestScenarios1,
                        ObjectsThatAreEqualToButNotTheSameAsReferenceObject = new UploadFileToSlackResponse[]
                        {
                            new UploadFileToSlackResponse(
                                referenceObjectForEquatableTestScenarios1.UploadFileToSlackResult,
                                referenceObjectForEquatableTestScenarios1.ResponseJson,
                                referenceObjectForEquatableTestScenarios1.ExceptionToString),
                        },
                        ObjectsThatAreNotEqualToReferenceObject = new UploadFileToSlackResponse[]
                        {
                            new UploadFileToSlackResponse(
                                A.Dummy<UploadFileToSlackResponse>().Whose(_ => !_.UploadFileToSlackResult.IsEqualTo(referenceObjectForEquatableTestScenarios1.UploadFileToSlackResult) && (_.UploadFileToSlackResult != UploadFileToSlackResult.FailedWithExceptionWhenUploading)).UploadFileToSlackResult,
                                referenceObjectForEquatableTestScenarios1.ResponseJson,
                                referenceObjectForEquatableTestScenarios1.ExceptionToString),
                            new UploadFileToSlackResponse(
                                referenceObjectForEquatableTestScenarios1.UploadFileToSlackResult,
                                A.Dummy<UploadFileToSlackResponse>().Whose(_ => !_.ResponseJson.IsEqualTo(referenceObjectForEquatableTestScenarios1.ResponseJson) && (_.UploadFileToSlackResult != UploadFileToSlackResult.FailedWithExceptionWhenUploading)).ResponseJson,
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
                    new EquatableTestScenario<UploadFileToSlackResponse>
                    {
                        Name = "Default Code Generated Scenario",
                        ReferenceObject = referenceObjectForEquatableTestScenarios2,
                        ObjectsThatAreEqualToButNotTheSameAsReferenceObject = new UploadFileToSlackResponse[]
                        {
                            new UploadFileToSlackResponse(
                                referenceObjectForEquatableTestScenarios2.UploadFileToSlackResult,
                                referenceObjectForEquatableTestScenarios2.ResponseJson,
                                referenceObjectForEquatableTestScenarios2.ExceptionToString),
                        },
                        ObjectsThatAreNotEqualToReferenceObject = new UploadFileToSlackResponse[]
                        {
                            new UploadFileToSlackResponse(
                                referenceObjectForEquatableTestScenarios2.UploadFileToSlackResult,
                                referenceObjectForEquatableTestScenarios2.ResponseJson,
                                A.Dummy<UploadFileToSlackResponse>().Whose(_ => !_.ExceptionToString.IsEqualTo(referenceObjectForEquatableTestScenarios2.ExceptionToString) && (_.UploadFileToSlackResult == UploadFileToSlackResult.FailedWithExceptionWhenUploading)).ExceptionToString),
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