// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FailedToUploadFileToSlackEvent{TId}.cs" company="Naos Project">
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
    /// Failed to upload a file to Slack.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class FailedToUploadFileToSlackEvent<TId> : UploadFileToSlackResponseEventBase<TId>, IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailedToUploadFileToSlackEvent{TId}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="timestampUtc">The timestamp in UTC.</param>
        /// <param name="uploadFileToSlackResponse">The response to a request to upload a file to Slack.</param>
        public FailedToUploadFileToSlackEvent(
            TId id,
            DateTime timestampUtc,
            UploadFileToSlackResponse uploadFileToSlackResponse)
            : base(id, timestampUtc, uploadFileToSlackResponse)
        {
            new { uploadFileToSlackResponse.UploadFileToSlackResult }.AsArg(Invariant($"{nameof(uploadFileToSlackResponse)}.{nameof(this.UploadFileToSlackResponse.UploadFileToSlackResult)}")).Must().NotBeEqualTo(UploadFileToSlackResult.Succeeded);
        }
    }
}