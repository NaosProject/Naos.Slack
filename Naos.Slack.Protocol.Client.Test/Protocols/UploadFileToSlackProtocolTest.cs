// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UploadFileToSlackProtocolTest.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Protocol.Client.Test
{
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Naos.Slack.Domain;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.AutoFakeItEasy;

    using Xunit;

    public static partial class UploadFileToSlackProtocolTest
    {
        [Fact]
        public static async Task ExecuteAsync___Should_return_UploadFileToSlackResponse_with_UploadFileToSlackResult_FailedWithSlackReturningError___When_authorization_token_is_malformed()
        {
            // Arrange
            var uploadFileToSlackRequest = new UploadFileToSlackRequest(Some.ReadOnlyDummies<byte>().ToArray(), new[] { "@everyone" });

            var operation = new UploadFileToSlackOp(uploadFileToSlackRequest);

            var protocol = new UploadFileToSlackProtocol(new SlackAuthToken("bad"));

            // Act
            var actual = await protocol.ExecuteAsync(operation);

            // Assert
            actual.UploadFileToSlackResult.AsTest().Must().BeEqualTo(UploadFileToSlackResult.FailedWithSlackReturningError);
            actual.ResponseJson.AsTest().Must().ContainString("invalid_auth");
        }

        [Fact(Skip = "For local testing only.")]
        public static async Task ExecuteAsync___Should_return_UploadFileToSlackResult_with_Succeeded___When_inputs_are_all_well_formed()
        {
            // Arrange
            var uploadFileToSlackRequest = new UploadFileToSlackRequest(
                File.ReadAllBytes("TXT-FILE-PATH-HERE"),
                new[] { "CHANNEL-NAME-HERE" },
                FileType.Text,
                "my-file-name.txt",
                "My File Title",
                "This is my initial comment");

            var operation = new UploadFileToSlackOp(uploadFileToSlackRequest);

            var protocol = new UploadFileToSlackProtocol(new SlackAuthToken("AUTH-TOKEN-HERE"));

            // Act
            var actual = await protocol.ExecuteAsync(operation);

            // Assert
            actual.UploadFileToSlackResult.AsTest().Must().BeEqualTo(UploadFileToSlackResult.Succeeded);
        }
    }
}