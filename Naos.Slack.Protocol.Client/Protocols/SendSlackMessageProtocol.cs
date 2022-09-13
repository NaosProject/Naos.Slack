// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendSlackMessageProtocol.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Protocol.Client
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Naos.Slack.Domain;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;
    using OBeautifulCode.Type.Recipes;

    using static System.FormattableString;

    /// <summary>
    /// Executes a <see cref="SendSlackMessageOp"/>.
    /// </summary>
    public class SendSlackMessageProtocol : AsyncSpecificReturningProtocolBase<SendSlackMessageOp, SendSlackMessageResponse>, ISendSlackMessageProtocol
    {
        private const string MethodName = "chat.postMessage";

        private readonly SlackClient slackClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="SendSlackMessageProtocol"/> class.
        /// </summary>
        /// <param name="slackAuthToken">A Slack authentication token bearing the required scopes.</param>
        public SendSlackMessageProtocol(
            SlackAuthToken slackAuthToken)
        {
            new { slackAuthToken }.AsArg().Must().NotBeNull();

            this.slackClient = new SlackClient(slackAuthToken);
        }

        /// <inheritdoc />
        public override async Task<SendSlackMessageResponse> ExecuteAsync(
            SendSlackMessageOp operation)
        {
            SendSlackMessageResponse result;

            try
            {
                var sendSlackMessageRequest = operation.SendSlackMessageRequest;

                if (sendSlackMessageRequest is SendSlackTextMessageRequest sendSlackTextMessageRequest)
                {
                    // HACK: should be using application/json instead of URI to communicate the message
                    // When that's fixed we no longer have to truncate.
                    // If the text is too long, .net throws:
                    // UriFormatException: Invalid URI: The Uri string is too long.
                    var textToSend = sendSlackTextMessageRequest.Text.Length > 1000
                        ? sendSlackTextMessageRequest.Text.Substring(0, 1000) + Environment.NewLine + "..."
                        : sendSlackTextMessageRequest.Text;

                    var parameters = new List<Tuple<string, string>>
                    {
                        new Tuple<string, string>("channel", sendSlackTextMessageRequest.Channel),
                        new Tuple<string, string>("text", textToSend),
                    };

                    if (!string.IsNullOrWhiteSpace(sendSlackTextMessageRequest.MessageAuthorUsernameOverride))
                    {
                        parameters.Add(new Tuple<string, string>("username", sendSlackTextMessageRequest.MessageAuthorUsernameOverride));
                    }

                    var messageAuthorIcon = sendSlackTextMessageRequest.MessageAuthorIconOverride;

                    if (messageAuthorIcon != null)
                    {
                        if (messageAuthorIcon.ResourceIdKind == IconResourceIdentifierKind.Emoji)
                        {
                            parameters.Add(new Tuple<string, string>("icon_emoji", messageAuthorIcon.ResourceId));
                        }
                        else if (messageAuthorIcon.ResourceIdKind == IconResourceIdentifierKind.ImageUrl)
                        {
                            parameters.Add(new Tuple<string, string>("icon_url", messageAuthorIcon.ResourceId));
                        }
                        else
                        {
                            throw new NotSupportedException(Invariant($"This {nameof(IconResourceIdentifierKind)} is not supported: {messageAuthorIcon.ResourceId}."));
                        }
                    }

                    if (sendSlackTextMessageRequest.TextFormat == SlackTextFormat.Mrkdwn)
                    {
                        // no-op
                    }
                    else if (sendSlackTextMessageRequest.TextFormat == SlackTextFormat.Plaintext)
                    {
                        parameters.Add(new Tuple<string, string>("mrkdwn", "false"));
                    }
                    else
                    {
                        throw new NotSupportedException(Invariant($"This {nameof(SlackTextFormat)} is not supported: {sendSlackTextMessageRequest.TextFormat}."));
                    }

                    if (sendSlackTextMessageRequest.Options.HasFlag(SlackTextMessageOptions.LinkNames))
                    {
                        parameters.Add(new Tuple<string, string>("link_names", "1"));
                    }
                    else
                    {
                        // no-op
                    }

                    parameters.Add(sendSlackTextMessageRequest.Options.HasFlag(SlackTextMessageOptions.LinkUrls)
                        ? new Tuple<string, string>("parse", "full")
                        : new Tuple<string, string>("parse", "none"));

                    parameters.Add(
                        sendSlackTextMessageRequest.Options.HasFlag(SlackTextMessageOptions.UnfurlMediaContent)
                            ? new Tuple<string, string>("unfurl_media", "true")
                            : new Tuple<string, string>("unfurl_media", "false"));

                    parameters.Add(
                        sendSlackTextMessageRequest.Options.HasFlag(SlackTextMessageOptions.UnfurlTextContent)
                            ? new Tuple<string, string>("unfurl_links", "true")
                            : new Tuple<string, string>("unfurl_links", "false"));

                    var responseJson = await this.slackClient.PostAsync(MethodName, parameters);

                    var sendSlackMessageResult = SlackClient.GetOperationResultFromResponseJson(responseJson, SendSlackMessageResult.Succeeded, SendSlackMessageResult.FailedWithSlackReturningError);

                    result = new SendSlackMessageResponse(sendSlackMessageResult, responseJson, null);
                }
                else
                {
                    throw new NotSupportedException(Invariant($"This kind of {nameof(SendSlackMessageRequestBase)} is not supported: {sendSlackMessageRequest.GetType().ToStringReadable()}."));
                }
            }
            catch (Exception ex)
            {
                result = new SendSlackMessageResponse(SendSlackMessageResult.FailedWithExceptionWhenSending, null, ex.ToString());
            }

            return result;
        }
    }
}