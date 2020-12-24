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
    public partial class SendSlackMessageOp : ReturningOperationBase<SendSlackMessageResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendSlackMessageOp"/> class.
        /// </summary>
        /// <param name="sendSlackMessageRequest">The request to send a Slack message.</param>
        public SendSlackMessageOp(
            SendSlackMessageRequestBase sendSlackMessageRequest)
        {
            new { sendSlackMessageRequest }.AsArg().Must().NotBeNull();

            this.SendSlackMessageRequest = sendSlackMessageRequest;
        }

        /// <summary>
        /// Gets the request to send a Slack message.
        /// </summary>
        public SendSlackMessageRequestBase SendSlackMessageRequest { get; private set; }
    }
}