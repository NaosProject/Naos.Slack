// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendSlackTextMessageRequest.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// A request to send a Slack text-based (not Block Kit) message.
    /// </summary>
    /// <remarks>
    /// - This object cannot be used to compose a Block Kit (<a href="https://api.slack.com/block-kit" />) message.
    ///   In the future, we'll add a SlackBlockKitMessage class.
    /// - Here's the mrkdwn spec: <a href="https://api.slack.com/reference/surfaces/formatting" />.
    /// - This object cannot be used as a reply (in a message thread).
    /// </remarks>
    public partial class SendSlackTextMessageRequest : SendSlackMessageRequestBase, IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendSlackTextMessageRequest"/> class.
        /// </summary>
        /// <param name="channel">The channel to send the message to.  Can be a public channel, private group, or IM channel.  Can be an encoded ID, or a name (e.g. @someone, #general).</param>
        /// <param name="text">The text of the message.  If using mrkdwn then note that ampersand (&amp;), less-than sign (&lt;) and greater-than sign (&gt;) must be HTML-encoded.  No other characters need to be encoded.</param>
        /// <param name="textFormat">The format of <paramref name="text"/>.</param>
        /// <param name="options">OPTIONAL options/features to apply to the message.  DEFAULT is to apply all options/features.</param>
        /// <param name="messageAuthorIconOverride">OPTIONAL icon to use for the author of the message, overriding the app/bot icon.  DEFAULT is to use the app/bot icon.</param>
        /// <param name="messageAuthorUsernameOverride">OPTIONAL username to use for the author of the message, overriding the app/bot username.  DEFAULT is to use the app/bot username.</param>
        public SendSlackTextMessageRequest(
            string channel,
            string text,
            SlackTextFormat textFormat = SlackTextFormat.Mrkdwn,
            SlackTextMessageOptions options = SlackTextMessageOptions.All,
            MessageAuthorIcon messageAuthorIconOverride = null,
            string messageAuthorUsernameOverride = null)
            : base(channel, messageAuthorIconOverride, messageAuthorUsernameOverride)
        {
            new { text }.AsArg().Must().NotBeNullNorWhiteSpace();
            new { textFormat }.AsArg().Must().NotBeEqualTo(SlackTextFormat.Unknown);

            this.Text = text;
            this.TextFormat = textFormat;
            this.Options = options;
        }

        /// <summary>
        /// Gets the text of the message.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Gets the format of the <see cref="Text"/>.
        /// </summary>
        public SlackTextFormat TextFormat { get; private set; }

        /// <summary>
        /// Gets options/features to apply to the message.
        /// </summary>
        public SlackTextMessageOptions Options { get; private set; }
    }
}
