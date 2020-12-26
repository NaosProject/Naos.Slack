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

    using Naos.Protocol.Domain;
    using Naos.Slack.Domain;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type.Recipes;

    using SlackAPI;

    using static System.FormattableString;

    /// <summary>
    /// Executes a <see cref="SendSlackMessageOp"/>.
    /// </summary>
    public class SendSlackMessageProtocol : AsyncSpecificReturningProtocolBase<SendSlackMessageOp, SendSlackMessageResponse>, ISendSlackMessageProtocol
    {
        private readonly string authenticationToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="SendSlackMessageProtocol"/> class.
        /// </summary>
        /// <param name="authenticationToken">A Slack authentication token bearing the required scopes.</param>
        public SendSlackMessageProtocol(
            string authenticationToken)
        {
            new { authenticationToken }.AsArg().Must().NotBeNullNorWhiteSpace();

            this.authenticationToken = authenticationToken;
        }

        /// <inheritdoc />
        public override async Task<SendSlackMessageResponse> ExecuteAsync(
            SendSlackMessageOp operation)
        {
            SendSlackMessageResponse result;

            try
            {
                var slackClient = new SlackTaskClient(this.authenticationToken);

                var sendSlackMessageRequest = operation.SendSlackMessageRequest;

                if (sendSlackMessageRequest is SendSlackTextMessageRequest sendSlackTextMessageRequest)
                {
                    var postParameters = new List<Tuple<string, string>>
                    {
                        new Tuple<string, string>("channel", sendSlackTextMessageRequest.Channel),
                        new Tuple<string, string>("text", sendSlackTextMessageRequest.Text),
                    };

                    if (!string.IsNullOrWhiteSpace(sendSlackTextMessageRequest.MessageAuthorUsernameOverride))
                    {
                        postParameters.Add(new Tuple<string, string>("username", sendSlackTextMessageRequest.MessageAuthorUsernameOverride));
                    }

                    var messageAuthorIcon = sendSlackTextMessageRequest.MessageAuthorIconOverride;

                    if (messageAuthorIcon != null)
                    {
                        if (messageAuthorIcon.ResourceIdKind == IconResourceIdentifierKind.Emoji)
                        {
                            postParameters.Add(new Tuple<string, string>("icon_emoji", messageAuthorIcon.ResourceId));
                        }
                        else if (messageAuthorIcon.ResourceIdKind == IconResourceIdentifierKind.ImageUrl)
                        {
                            postParameters.Add(new Tuple<string, string>("icon_url", messageAuthorIcon.ResourceId));
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
                        postParameters.Add(new Tuple<string, string>("mrkdwn", "false"));
                    }
                    else
                    {
                        throw new NotSupportedException(Invariant($"This {nameof(SlackTextFormat)} is not supported: {sendSlackTextMessageRequest.TextFormat}."));
                    }

                    if (sendSlackTextMessageRequest.Options.HasFlag(SlackTextMessageOptions.LinkNames))
                    {
                        postParameters.Add(new Tuple<string, string>("link_names", "1"));
                    }
                    else
                    {
                        // no-op
                    }

                    postParameters.Add(sendSlackTextMessageRequest.Options.HasFlag(SlackTextMessageOptions.LinkUrls)
                        ? new Tuple<string, string>("parse", "full")
                        : new Tuple<string, string>("parse", "none"));

                    postParameters.Add(
                        sendSlackTextMessageRequest.Options.HasFlag(SlackTextMessageOptions.UnfurlMediaContent)
                            ? new Tuple<string, string>("unfurl_media", "true")
                            : new Tuple<string, string>("unfurl_media", "false"));

                    postParameters.Add(
                        sendSlackTextMessageRequest.Options.HasFlag(SlackTextMessageOptions.UnfurlTextContent)
                            ? new Tuple<string, string>("unfurl_links", "true")
                            : new Tuple<string, string>("unfurl_links", "false"));

                    var response = await slackClient.APIRequestWithTokenAsync<PostMessageResponse>(postParameters.ToArray());

                    result = response.ok
                        ? new SendSlackMessageResponse(SendSlackMessageResult.Succeeded, response.ts, response.channel, null, null)
                        : new SendSlackMessageResponse(SendSlackMessageResult.FailedWithSlackReturningError, null, null, null, response.error);
                }
                else
                {
                    throw new NotSupportedException(Invariant($"This kind of {nameof(SendSlackMessageRequestBase)} is not supported: {sendSlackMessageRequest.GetType().ToStringReadable()}."));
                }
            }
            catch (Exception ex)
            {
                result = new SendSlackMessageResponse(SendSlackMessageResult.FailedWithExceptionWhenSending, null, null, ex.ToString(), null);
            }

            return result;
        }
    }
}