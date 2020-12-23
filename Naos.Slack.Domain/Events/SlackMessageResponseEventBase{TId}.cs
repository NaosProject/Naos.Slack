// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SlackMessageResponseEventBase{TId}.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using System;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// Base class that tracks a <see cref="SlackMessageResponse"/>.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    public abstract partial class SlackMessageResponseEventBase<TId> : SlackEventBase<TId>, IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SlackMessageResponseEventBase{TId}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="timestampUtc">The timestamp in UTC.</param>
        /// <param name="slackMessageResponse">The response to a request to send a Slack message.</param>
        protected SlackMessageResponseEventBase(
            TId id,
            DateTime timestampUtc,
            SlackMessageResponse slackMessageResponse)
            : base(id, timestampUtc)
        {
            new { slackMessageResponse }.AsArg().Must().NotBeNull();

            this.SlackMessageResponse = slackMessageResponse;
        }

        /// <summary>
        /// Gets the response to a request to send a Slack message.
        /// </summary>
        public SlackMessageResponse SlackMessageResponse { get; private set; }
    }
}