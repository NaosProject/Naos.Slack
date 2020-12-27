// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UploadFileToSlackOp.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using Naos.Protocol.Domain;

    using OBeautifulCode.Assertion.Recipes;

    /// <summary>
    /// Uploads a file to Slack.
    /// </summary>
    public partial class UploadFileToSlackOp : ReturningOperationBase<UploadFileToSlackResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFileToSlackOp"/> class.
        /// </summary>
        /// <param name="uploadFileToSlackRequest">The request to upload a file to Slack.</param>
        public UploadFileToSlackOp(
            UploadFileToSlackRequest uploadFileToSlackRequest)
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