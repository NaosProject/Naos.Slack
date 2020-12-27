// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UploadFileToSlackResponseEventBase{TId}.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using System;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// Base class that tracks a <see cref="UploadFileToSlackResponse"/>.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    public abstract partial class UploadFileToSlackResponseEventBase<TId> : SlackEventBase<TId>, IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFileToSlackResponseEventBase{TId}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="timestampUtc">The timestamp in UTC.</param>
        /// <param name="uploadFileToSlackResponse">The response to a request to upload a file to slack.</param>
        protected UploadFileToSlackResponseEventBase(
            TId id,
            DateTime timestampUtc,
            UploadFileToSlackResponse uploadFileToSlackResponse)
            : base(id, timestampUtc)
        {
            new { uploadFileToSlackResponse }.AsArg().Must().NotBeNull();

            this.UploadFileToSlackResponse = uploadFileToSlackResponse;
        }

        /// <summary>
        /// Gets the response to a request to upload a file to Slack.
        /// </summary>
        public UploadFileToSlackResponse UploadFileToSlackResponse { get; private set; }
    }
}