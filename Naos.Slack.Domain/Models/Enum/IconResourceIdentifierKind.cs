// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IconResourceIdentifierKind.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    /// <summary>
    /// The kind of icon resource identifier.
    /// </summary>
    public enum IconResourceIdentifierKind
    {
        /// <summary>
        /// Unknown (default).
        /// </summary>
        Unknown,

        /// <summary>
        /// The icon resource identifier is the name of an emoji (e.g.  ":chart_with_upwards_trend:").
        /// </summary>
        Emoji,

        /// <summary>
        /// The icon resource identifier is a URL to an image.
        /// </summary>
        ImageUrl,
    }
}
