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
    public partial class FailedToSendSlackMessageEvent<TId> : SendSlackMessageResponseEventBase<TId>, IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailedToSendSlackMessageEvent{TId}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="timestampUtc">The timestamp in UTC.</param>
        /// <param name="sendSlackMessageResponse">The response to a request to send a Slack message.</param>
        public FailedToSendSlackMessageEvent(
            TId id,
            DateTime timestampUtc,
            SendSlackMessageResponse sendSlackMessageResponse)
            : base(id, timestampUtc, sendSlackMessageResponse)
        {
            new { sendSlackMessageResponse.SendSlackMessageResult }.AsArg(Invariant($"{nameof(sendSlackMessageResponse)}.{nameof(this.SendSlackMessageResponse.SendSlackMessageResult)}")).Must().NotBeEqualTo(SendSlackMessageResult.Succeeded);
        }
    }
}