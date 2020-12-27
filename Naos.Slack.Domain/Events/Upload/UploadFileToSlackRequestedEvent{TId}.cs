// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UploadFileToSlackRequestedEvent{TId}.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using System;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// A request has been made to upload a file to Slack.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class UploadFileToSlackRequestedEvent<TId> : SlackEventBase<TId>, IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFileToSlackRequestedEvent{TId}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="timestampUtc">The timestamp in UTC.</param>
        /// <param name="uploadFileToSlackRequest">The request to upload a file to Slack.</param>
        public UploadFileToSlackRequestedEvent(
            TId id,
            DateTime timestampUtc,
            UploadFileToSlackRequest uploadFileToSlackRequest)
            : base(id, timestampUtc)
        {
            new { uploadFileToSlackRequest }.AsArg().Must().NotBeNull();

            this.UploadFileToSlackRequest = uploadFileToSlackRequest;
        }

        /// <summary>
        /// Gets the request to upload a file to Slack.
        /// </summary>
        public UploadFileToSlackRequest UploadFileToSlackRequest { get; private set; }
    }
}