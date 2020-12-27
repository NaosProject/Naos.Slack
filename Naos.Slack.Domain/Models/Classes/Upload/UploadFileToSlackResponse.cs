// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UploadFileToSlackResponse.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Naos.CodeAnalysis.Recipes;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// The response to a request to upload a file to Slack.
    /// </summary>
    public partial class UploadFileToSlackResponse : IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFileToSlackResponse"/> class.
        /// </summary>
        /// <param name="uploadFileToSlackResult">The result of uploading the file.</param>
        /// <param name="responseJson">The response JSON returned by Slack.  Required when <paramref name="uploadFileToSlackResult"/> is <see cref="UploadFileToSlackResult.Succeeded"/> or <see cref="UploadFileToSlackResult.FailedWithSlackReturningError"/>, otherwise should be null.</param>
        /// <param name="exceptionToString">The <see cref="object.ToString()"/> of the <see cref="Exception"/> that was thrown when uploading the file.  Required when <paramref name="uploadFileToSlackResult"/> is <see cref="UploadFileToSlackResult.FailedWithExceptionWhenUploading"/>, otherwise should be null.</param>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "string", Justification = NaosSuppressBecause.CA1720_IdentifiersShouldNotContainTypeNames_TypeNameAddsClarityToIdentifierAndAlternativesDegradeClarity)]
        public UploadFileToSlackResponse(
            UploadFileToSlackResult uploadFileToSlackResult,
            string responseJson,
            string exceptionToString)
        {
            new { uploadFileToSlackResult }.AsArg().Must().NotBeEqualTo(UploadFileToSlackResult.Unknown);

            if ((uploadFileToSlackResult == UploadFileToSlackResult.Succeeded) || (uploadFileToSlackResult == UploadFileToSlackResult.FailedWithSlackReturningError))
            {
                new { responseJson }.AsArg().Must().NotBeNullNorWhiteSpace();
            }
            else
            {
                new { responseJson }.AsArg().Must().BeNull();
            }

            if (uploadFileToSlackResult == UploadFileToSlackResult.FailedWithExceptionWhenUploading)
            {
                new { exceptionToString }.AsArg().Must().NotBeNullNorWhiteSpace();
            }
            else
            {
                new { exceptionToString }.AsArg().Must().BeNull();
            }

            this.UploadFileToSlackResult = uploadFileToSlackResult;
            this.ResponseJson = responseJson;
            this.ExceptionToString = exceptionToString;
        }

        /// <summary>
        /// Gets the result of uploading the file.
        /// </summary>
        public UploadFileToSlackResult UploadFileToSlackResult { get; private set; }

        /// <summary>
        /// Gets the response JSON returned by Slack.
        /// </summary>
        public string ResponseJson { get; private set; }

        /// <summary>
        /// Gets the <see cref="object.ToString()"/> of the <see cref="Exception"/> that was thrown when uploading the file.
        /// </summary>
        public string ExceptionToString { get; private set; }
    }
}
