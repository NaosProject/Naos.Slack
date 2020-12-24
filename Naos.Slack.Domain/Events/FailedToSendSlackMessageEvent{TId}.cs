// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FailedToSendSlackMessageEvent{TId}.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using System;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    using static System.FormattableString;

    /// <summary>
    /// Failed to send a Slack message.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class FailedToSendSlackMessageEvent<TId> : SlackMessageResponseEventBase<TId>, IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailedToSendSlackMessageEvent{TId}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="timestampUtc">The timestamp in UTC.</param>
        /// <param name="slackMessageResponse">The response to a request to send a Slack message.</param>
        public FailedToSendSlackMessageEvent(
            TId id,
            DateTime timestampUtc,
            SlackMessageResponse slackMessageResponse)
            : base(id, timestampUtc, slackMessageResponse)
        {
            new { slackMessageResponse.SendSlackMessageResult }.AsArg(Invariant($"{nameof(slackMessageResponse)}.{nameof(this.SlackMessageResponse.SendSlackMessageResult)}")).Must().NotBeEqualTo(SendSlackMessageResult.Succeeded);
        }
    }
}