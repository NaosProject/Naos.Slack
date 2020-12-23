// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SlackMessageRequestBase.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// Base class for a request to send a Slack message.
    /// </summary>
    public abstract partial class SlackMessageRequestBase : IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SlackMessageRequestBase"/> class.
        /// </summary>
        /// <param name="channel">The channel to send the message to.  Can be a public channel, private group, or IM channel.  Can be an encoded ID, or a name (e.g. @someone, #general).</param>
        /// <param name="messageAuthorIconOverride">OPTIONAL icon to use for the author of the message, overriding the app/bot icon.  DEFAULT is to use the app/bot icon.</param>
        /// <param name="messageAuthorUsernameOverride">OPTIONAL username to use for the author of the message, overriding the app/bot username.  DEFAULT is to use the app/bot username.</param>
        protected SlackMessageRequestBase(
            string channel,
            MessageAuthorIcon messageAuthorIconOverride = null,
            string messageAuthorUsernameOverride = null)
        {
            new { channel }.AsArg().Must().NotBeNullNorWhiteSpace();

            this.Channel = channel;
            this.MessageAuthorIconOverride = messageAuthorIconOverride;
            this.MessageAuthorUsernameOverride = messageAuthorUsernameOverride;
        }

        /// <summary>
        /// Gets the channel to send the message to.
        /// </summary>
        public string Channel { get; private set; }

        /// <summary>
        /// Gets the icon to use for the author of the message, overriding the app/bot icon.
        /// </summary>
        public MessageAuthorIcon MessageAuthorIconOverride { get; private set; }

        /// <summary>
        /// Gets the username to use for the author of the message, overriding the app/bot username.
        /// </summary>
        public string MessageAuthorUsernameOverride { get; private set; }
    }
}
