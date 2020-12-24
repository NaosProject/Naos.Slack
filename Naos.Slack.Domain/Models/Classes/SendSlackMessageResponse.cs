// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendSlackMessageResponse.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using System;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// The response to a request to send a Slack message.
    /// </summary>
    public partial class SendSlackMessageResponse : IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendSlackMessageResponse"/> class.
        /// </summary>
        /// <param name="sendSlackMessageResult">The result of sending the message.</param>
        /// <param name="timestampId">The timestamp identifier of the message.  Required when <paramref name="sendSlackMessageResult"/> is <see cref="Domain.SendSlackMessageResult.Succeeded"/>, otherwise should be null.</param>
        /// <param name="channelId">The identifier of the channel that the message was sent to.  Required when <paramref name="sendSlackMessageResult"/> is <see cref="Domain.SendSlackMessageResult.Succeeded"/>, otherwise should be null.</param>
        /// <param name="exceptionToString">The <see cref="object.ToString()"/> of the <see cref="Exception"/> that was thrown when sending the message.  Required when <paramref name="sendSlackMessageResult"/> is <see cref="Domain.SendSlackMessageResult.FailedWithExceptionWhenSending"/>, otherwise should be null.</param>
        /// <param name="slackErrorCode">The error code returned by Slack.  Required when <paramref name="sendSlackMessageResult"/> is <see cref="Domain.SendSlackMessageResult.FailedWithSlackReturningError"/>, otherwise should be null.</param>
        public SendSlackMessageResponse(
            SendSlackMessageResult sendSlackMessageResult,
            string timestampId,
            string channelId,
            string exceptionToString,
            string slackErrorCode)
        {
            new { sendSlackMessageResult }.AsArg().Must().NotBeEqualTo(SendSlackMessageResult.Unknown);

            if (sendSlackMessageResult == SendSlackMessageResult.Succeeded)
            {
                new { timestampId }.AsArg().Must().NotBeNullNorWhiteSpace();
                new { channelId }.AsArg().Must().NotBeNullNorWhiteSpace();
            }
            else
            {
                new { timestampId }.AsArg().Must().BeNull();
                new { channelId }.AsArg().Must().BeNull();
            }

            if (sendSlackMessageResult == SendSlackMessageResult.FailedWithExceptionWhenSending)
            {
                new { exceptionToString }.AsArg().Must().NotBeNullNorWhiteSpace();
            }
            else
            {
                new { exceptionToString }.AsArg().Must().BeNull();
            }

            if (sendSlackMessageResult == SendSlackMessageResult.FailedWithSlackReturningError)
            {
                new { slackErrorCode }.AsArg().Must().NotBeNullNorWhiteSpace();
            }
            else
            {
                new { slackErrorCode }.AsArg().Must().BeNull();
            }

            this.SendSlackMessageResult = sendSlackMessageResult;
            this.TimestampId = timestampId;
            this.ChannelId = channelId;
            this.ExceptionToString = exceptionToString;
            this.SlackErrorCode = slackErrorCode;
        }

        /// <summary>
        /// Gets the result of sending the message.
        /// </summary>
        public SendSlackMessageResult SendSlackMessageResult { get; private set; }

        /// <summary>
        /// Gets the timestamp identifier of the message.
        /// </summary>
        public string TimestampId { get; private set; }

        /// <summary>
        /// Gets the identifier of the channel that the message was sent to.
        /// </summary>
        public string ChannelId { get; private set; }

        /// <summary>
        /// Gets the <see cref="object.ToString()"/> of the <see cref="Exception"/> that was thrown when sending the message.
        /// </summary>
        public string ExceptionToString { get; private set; }

        /// <summary>
        /// Gets the error code returned by Slack.
        /// </summary>
        public string SlackErrorCode { get; private set; }
    }
}
