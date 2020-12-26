// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SlackTextMessageOptions.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using System;

    /// <summary>
    /// Some options to apply to a Slack text-based message.
    /// </summary>
    [Flags]
    public enum SlackTextMessageOptions
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,

        /// <summary>
        /// Instructs Slack to find and link channel names and usernames that appear in the text.
        /// </summary>
        /// <remarks>
        /// If this flag is not set, it's still possible to link channel names and usernames using mrkdwn link syntax.
        /// </remarks>
        LinkNames = 1,

        /// <summary>
        /// Instructs Slack to find and link URLs that appear in the text.
        /// </summary>
        /// <remarks>
        /// If this flag is not set, it's still possible to link URLs using mrkdwn link syntax.
        /// </remarks>
        LinkUrls = 2,

        /// <summary>
        /// Instructs Slack to unfurl any linked text content (e.g. website URL),
        /// either linked manually in mrkdwn or via <see cref="LinkUrls"/>.
        /// </summary>
        UnfurlTextContent = 4,

        /// <summary>
        /// Instructs Slack to unfurl any linked media content,
        /// either linked manually in mrkdwn or via <see cref="LinkUrls"/>.
        /// </summary>
        UnfurlMediaContent = 8,

        /// <summary>
        /// Use all options.
        /// </summary>
        All = LinkNames | LinkUrls | UnfurlTextContent | UnfurlMediaContent,
    }
}
