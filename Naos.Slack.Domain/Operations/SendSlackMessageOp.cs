// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendSlackMessageOp.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using Naos.Protocol.Domain;

    using OBeautifulCode.Assertion.Recipes;

    /// <summary>
    /// Sends a Slack message.
    /// </summary>
    public partial class SendSlackMessageOp : ReturningOperationBase<SlackMessageResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendSlackMessageOp"/> class.
        /// </summary>
        /// <param name="slackMessageRequest">The request to send a Slack message.</param>
        public SendSlackMessageOp(
            SlackMessageRequestBase slackMessageRequest)
        {
            new { slackMessageRequest }.AsArg().Must().NotBeNull();

            this.SlackMessageRequest = slackMessageRequest;
        }

        /// <summary>
        /// Gets the request to send a Slack message.
        /// </summary>
        public SlackMessageRequestBase SlackMessageRequest { get; private set; }
    }
}