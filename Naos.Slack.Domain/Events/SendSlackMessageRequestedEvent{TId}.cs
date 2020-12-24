// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendSlackMessageRequestedEvent{TId}.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using System;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// A request has been made to send a Slack message.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class SendSlackMessageRequestedEvent<TId> : SlackEventBase<TId>, IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendSlackMessageRequestedEvent{TId}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="timestampUtc">The timestamp in UTC.</param>
        /// <param name="sendSlackMessageRequest">The request to send a Slack message.</param>
        public SendSlackMessageRequestedEvent(
            TId id,
            DateTime timestampUtc,
            SendSlackMessageRequestBase sendSlackMessageRequest)
            : base(id, timestampUtc)
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