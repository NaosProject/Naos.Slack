// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SlackTextFormat.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    /// <summary>
    /// The format of a Slack text object.
    /// </summary>
    public enum SlackTextFormat
    {
        /// <summary>
        /// Unknown (default).
        /// </summary>
        Unknown,

        /// <summary>
        /// Plaintext.
        /// </summary>
        Plaintext,

        /// <summary>
        /// Slack's markup language, see: <a href="https://api.slack.com/reference/surfaces/formatting" />.
        /// </summary>
        Mrkdwn,
    }
}
