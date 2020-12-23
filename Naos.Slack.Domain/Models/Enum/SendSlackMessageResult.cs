// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendSlackMessageResult.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    /// <summary>
    /// Gets the result of sending a Slack message.
    /// </summary>
    public enum SendSlackMessageResult
    {
        /// <summary>
        /// Unknown (default).
        /// </summary>
        Unknown,

        /// <summary>
        /// The message was sent.
        /// </summary>
        Succeeded,

        /// <summary>
        /// The message was not sent.  An exception was thrown when sending.
        /// </summary>
        FailedWithExceptionWhenSending,

        /// <summary>
        /// The message was not sent.  Slack returned an error.
        /// </summary>
        FailedWithSlackReturningError,
    }
}
