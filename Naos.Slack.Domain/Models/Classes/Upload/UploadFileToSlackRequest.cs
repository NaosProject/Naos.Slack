// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UploadFileToSlackRequest.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using System.Collections.Generic;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// A request to upload a file to Slack.
    /// </summary>
    /// <remarks>
    /// - This object cannot be used as a reply (in a message thread).
    /// - There is no way to force "editable" mode.
    ///   Files will be stored either in hosted or editable mode,
    ///   based on certain heuristics (determined type, file size).
    /// </remarks>
    public partial class UploadFileToSlackRequest : IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFileToSlackRequest"/> class.
        /// </summary>
        /// <param name="fileBytes">The bytes of the file to upload.</param>
        /// <param name="channels">Channels to share the file with.  Can be public channels, private groups, or IM channels as long as the owner of the token used to upload the file is a member of these channels.  Can be an IDs (e.g. "C1234567890,C2345678901,C3456789012") or names (e.g. "@someone,#general").</param>
        /// <param name="fileType">OPTIONAL value that specifies the type of file being uploaded.  DEFAULT is to auto-detect the type of file (using <paramref name="fileName"/> if specified and the bytes in the file).</param>
        /// <param name="fileName">OPTIONAL name of the file, including the file extension if available (e.g. "my-image.jpg").  This will be used as the title of the file, unless <paramref name="title"/> is specified.  This file name will be used when downloading the file from Slack to disk.  Also, this helps Slack to identify the type file (unless <paramref name="fileType"/> is set to something other than <see cref="FileType.Auto"/>).  DEFAULT is to not specify a file name.</param>
        /// <param name="title">OPTIONAL title of the file (e.g. "My Image").  This will be the file name used when downloading the file from Slack to disk, unless <paramref name="fileName"/> is specified.</param>
        /// <param name="initialCommentText">The message text, in mrkdwn, introducing the file in the specified <paramref name="channels"/>.  No automating parsing of URLs nor names (e.g. channel name) is performed so linking should be done in mrkdwn link syntax.</param>
        public UploadFileToSlackRequest(
            byte[] fileBytes,
            IReadOnlyCollection<string> channels,
            FileType fileType = FileType.Auto,
            string fileName = null,
            string title = null,
            string initialCommentText = null)
        {
            new { fileBytes }.AsArg().Must().NotBeNullNorEmptyEnumerable();

            if (channels != null)
            {
                new { channels }.AsArg().Must().Each().NotBeNullNorWhiteSpace();
            }

            this.FileBytes = fileBytes;
            this.Channels = channels;
            this.FileType = fileType;
            this.FileName = fileName;
            this.Title = title;
            this.InitialCommentText = initialCommentText;
        }

        /// <summary>
        /// Gets the bytes of the file to upload.
        /// </summary>
        public byte[] FileBytes { get; private set; }

        /// <summary>
        /// Gets the channels to share the file with.
        /// </summary>
        public IReadOnlyCollection<string> Channels { get; private set; }

        /// <summary>
        /// Gets a value that specifies the type of file being uploaded.
        /// </summary>
        public FileType FileType { get; private set; }

        /// <summary>
        /// Gets the name of the file, including the file extension if available (e.g. "my-image.jpg").
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Gets the title of the file.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets the message text, in mrkdwn, introducing the file in the specified <see cref="Channels"/>.
        /// </summary>
        public string InitialCommentText { get; private set; }
    }
}
