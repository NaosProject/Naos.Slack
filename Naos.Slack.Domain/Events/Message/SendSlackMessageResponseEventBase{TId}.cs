// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendSlackMessageResponseEventBase{TId}.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using System;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// Base class that tracks a <see cref="SendSlackMessageResponse"/>.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    public abstract partial class SendSlackMessageResponseEventBase<TId> : SlackEventBase<TId>, IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendSlackMessageResponseEventBase{TId}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="timestampUtc">The timestamp in UTC.</param>
        /// <param name="sendSlackMessageResponse">The response to a request to send a Slack message.</param>
        protected SendSlackMessageResponseEventBase(
            TId id,
            DateTime timestampUtc,
            SendSlackMessageResponse sendSlackMessageResponse)
            : base(id, timestampUtc)
        {
            new { sendSlackMessageResponse }.AsArg().Must().NotBeNull();

            this.SendSlackMessageResponse = sendSlackMessageResponse;
        }

        /// <summary>
        /// Gets the response to a request to send a Slack message.
        /// </summary>
        public SendSlackMessageResponse SendSlackMessageResponse { get; private set; }
    }
}