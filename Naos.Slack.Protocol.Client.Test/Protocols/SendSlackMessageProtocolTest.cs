// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendSlackMessageProtocolTest.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Protocol.Client.Test
{
    using System.Threading.Tasks;

    using Naos.Slack.Domain;

    using OBeautifulCode.Assertion.Recipes;

    using Xunit;

    public static partial class SendSlackMessageProtocolTest
    {
        [Fact]
        public static async Task ExecuteAsync___Should_return_SendSlackMessageResponse_with_SendSlackMessageResult_FailedWithSlackReturningError___When_authorization_token_is_malformed()
        {
            // Arrange
            var sendSlackTextMessageRequest = new SendSlackTextMessageRequest("@everyone", "this is a test");

            var operation = new SendSlackMessageOp(sendSlackTextMessageRequest);

            var protocol = new SendSlackMessageProtocol("bad");

            // Act
            var actual = await protocol.ExecuteAsync(operation);

            // Assert
            actual.SendSlackMessageResult.AsTest().Must().BeEqualTo(SendSlackMessageResult.FailedWithSlackReturningError);
            actual.ResponseJson.AsTest().Must().ContainString("invalid_auth");
        }

        [Fact(Skip = "For local testing only.")]
        public static async Task ExecuteAsync___Should_return_SendSlackMessageResponse_with_Succeeded___When_inputs_are_all_well_formed()
        {
            // Arrange
            var sendSlackTextMessageRequest = new SendSlackTextMessageRequest("CHANNEL-HERE", "TEXT-HERE");

            var operation = new SendSlackMessageOp(sendSlackTextMessageRequest);

            var protocol = new SendSlackMessageProtocol("AUTH-TOKEN-HERE");

            // Act
            var actual = await protocol.ExecuteAsync(operation);

            // Assert
            actual.SendSlackMessageResult.AsTest().Must().BeEqualTo(SendSlackMessageResult.Succeeded);
        }
    }
}