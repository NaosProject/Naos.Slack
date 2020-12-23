// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SlackEventBase{TId}.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using System;

    using Naos.Protocol.Domain;

    using OBeautifulCode.Type;

    /// <summary>
    /// Base class for Slack events.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    public abstract partial class SlackEventBase<TId> : EventBase<TId>, IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SlackEventBase{TId}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="timestampUtc">The timestamp in UTC.</param>
        protected SlackEventBase(
            TId id,
            DateTime timestampUtc)
            : base(id, timestampUtc)
        {
        }
    }
}