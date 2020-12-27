// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UploadFileToSlackRequestTest.cs" company="Naos Project">
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
    public static partial class UploadFileToSlackRequestTest
    {
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = ObcSuppressBecause.CA1505_AvoidUnmaintainableCode_DisagreeWithAssessment)]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = ObcSuppressBecause.CA1810_InitializeReferenceTypeStaticFieldsInline_FieldsDeclaredInCodeGeneratedPartialTestClass)]
        static UploadFileToSlackRequestTest()
        {
            ConstructorArgumentValidationTestScenarios
                .RemoveAllScenarios()
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<UploadFileToSlackRequest>
                    {
                        Name = "constructor should throw ArgumentNullException when parameter 'fileBytes' is null scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<UploadFileToSlackRequest>();

                            var result = new UploadFileToSlackRequest(
                                                 null,
                                                 referenceObject.Channels,
                                                 referenceObject.FileType,
                                                 referenceObject.FileName,
                                                 referenceObject.Title,
                                                 referenceObject.InitialCommentText);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentNullException),
                        ExpectedExceptionMessageContains = new[] { "fileBytes", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<UploadFileToSlackRequest>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'fileBytes' is an empty enumerable scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<UploadFileToSlackRequest>();

                            var result = new UploadFileToSlackRequest(
                                                 new byte[0],
                                                 referenceObject.Channels,
                                                 referenceObject.FileType,
                                                 referenceObject.FileName,
                                                 referenceObject.Title,
                                                 referenceObject.InitialCommentText);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "fileBytes", "is an empty enumerable", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<UploadFileToSlackRequest>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'channels' contains a null element scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<UploadFileToSlackRequest>();

                            var result = new UploadFileToSlackRequest(
                                                 referenceObject.FileBytes,
                                                 new string[0].Concat(referenceObject.Channels).Concat(new string[] { null }).Concat(referenceObject.Channels).ToList(),
                                                 referenceObject.FileType,
                                                 referenceObject.FileName,
                                                 referenceObject.Title,
                                                 referenceObject.InitialCommentText);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "channels", "contains an element that is null", },
                    })
                .AddScenario(() =>
                    new ConstructorArgumentValidationTestScenario<UploadFileToSlackRequest>
                    {
                        Name = "constructor should throw ArgumentException when parameter 'channels' contains a white space element scenario",
                        ConstructionFunc = () =>
                        {
                            var referenceObject = A.Dummy<UploadFileToSlackRequest>();

                            var result = new UploadFileToSlackRequest(
                                referenceObject.FileBytes,
                                new string[0].Concat(referenceObject.Channels).Concat(new string[] { "   \r\n  " }).Concat(referenceObject.Channels).ToList(),
                                referenceObject.FileType,
                                referenceObject.FileName,
                                referenceObject.Title,
                                referenceObject.InitialCommentText);

                            return result;
                        },
                        ExpectedExceptionType = typeof(ArgumentException),
                        ExpectedExceptionMessageContains = new[] { "channels", "contains an element that is white space", },
                    });
        }
    }
}