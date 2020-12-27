// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UploadFileToSlackResult.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    /// <summary>
    /// Gets the result of upload a file to Slack.
    /// </summary>
    public enum UploadFileToSlackResult
    {
        /// <summary>
        /// Unknown (default).
        /// </summary>
        Unknown,

        /// <summary>
        /// The file was uploaded.
        /// </summary>
        Succeeded,

        /// <summary>
        /// The file was not uploaded.  An exception was thrown when uploading.
        /// </summary>
        FailedWithExceptionWhenUploading,

        /// <summary>
        /// The file was not uploaded.  Slack returned an error.
        /// </summary>
        FailedWithSlackReturningError,
    }
}
