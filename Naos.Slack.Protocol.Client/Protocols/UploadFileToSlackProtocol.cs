// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UploadFileToSlackProtocol.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Protocol.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Naos.Protocol.Domain;
    using Naos.Slack.Domain;

    using OBeautifulCode.Assertion.Recipes;

    /// <summary>
    /// Executes a <see cref="UploadFileToSlackOp"/>.
    /// </summary>
    public class UploadFileToSlackProtocol : AsyncSpecificReturningProtocolBase<UploadFileToSlackOp, UploadFileToSlackResponse>, IUploadFileToSlackProtocol
    {
        private const string MethodName = "files.upload";

        private readonly SlackClient slackClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFileToSlackProtocol"/> class.
        /// </summary>
        /// <param name="authenticationToken">A Slack authentication token bearing the required scopes.</param>
        public UploadFileToSlackProtocol(
            string authenticationToken)
        {
            new { authenticationToken }.AsArg().Must().NotBeNullNorWhiteSpace();

            this.slackClient = new SlackClient(authenticationToken);
        }

        /// <inheritdoc />
        public override async Task<UploadFileToSlackResponse> ExecuteAsync(
            UploadFileToSlackOp operation)
        {
            new { operation }.AsArg().Must().NotBeNull();

            UploadFileToSlackResponse result;

            try
            {
                var parameters = new List<Tuple<string, string>>();

                var uploadFileToSlackRequest = operation.UploadFileToSlackRequest;

                if ((uploadFileToSlackRequest.Channels != null) && uploadFileToSlackRequest.Channels.Any())
                {
                    parameters.Add(new Tuple<string, string>("channels", string.Join(",", uploadFileToSlackRequest.Channels)));
                }

                if (!string.IsNullOrWhiteSpace(uploadFileToSlackRequest.FileName))
                {
                    parameters.Add(new Tuple<string, string>("filename", uploadFileToSlackRequest.FileName));
                }

                // ReSharper disable once StringLiteralTypo
                parameters.Add(new Tuple<string, string>("filetype", uploadFileToSlackRequest.FileType.ToString().ToLower()));

                if (!string.IsNullOrWhiteSpace(uploadFileToSlackRequest.InitialCommentText))
                {
                    parameters.Add(new Tuple<string, string>("initial_comment", uploadFileToSlackRequest.InitialCommentText));
                }

                if (!string.IsNullOrWhiteSpace(uploadFileToSlackRequest.Title))
                {
                    parameters.Add(new Tuple<string, string>("title", uploadFileToSlackRequest.Title));
                }

                string responseJson;

                using (var multipartFormDataContent = new MultipartFormDataContent())
                {
                    // The fileName parameter is required here otherwise it causes an error.
                    string fileName;

                    if (!string.IsNullOrWhiteSpace(uploadFileToSlackRequest.FileName))
                    {
                        fileName = uploadFileToSlackRequest.FileName;
                    }
                    else if (!string.IsNullOrWhiteSpace(uploadFileToSlackRequest.Title))
                    {
                        fileName = uploadFileToSlackRequest.Title;
                    }
                    else
                    {
                        fileName = "Unspecified File Name";
                    }

                    multipartFormDataContent.Add(new ByteArrayContent(uploadFileToSlackRequest.FileBytes), "file", fileName);

                    responseJson = await this.slackClient.PostAsync(MethodName, parameters, multipartFormDataContent);
                }

                var uploadFileToSlackResult = SlackClient.GetOperationResultFromResponseJson(responseJson, UploadFileToSlackResult.Succeeded, UploadFileToSlackResult.FailedWithSlackReturningError);

                result = new UploadFileToSlackResponse(uploadFileToSlackResult, responseJson, null);
            }
            catch (Exception ex)
            {
                result = new UploadFileToSlackResponse(UploadFileToSlackResult.FailedWithExceptionWhenUploading, null, ex.ToString());
            }

            return result;
        }
    }
}