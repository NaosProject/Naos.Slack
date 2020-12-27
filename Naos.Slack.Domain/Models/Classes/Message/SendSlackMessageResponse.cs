// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendSlackMessageResponse.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Naos.CodeAnalysis.Recipes;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// The response to a request to send a Slack message.
    /// </summary>
    public partial class SendSlackMessageResponse : IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendSlackMessageResponse"/> class.
        /// </summary>
        /// <param name="sendSlackMessageResult">The result of sending the message.</param>
        /// <param name="responseJson">The response JSON returned by Slack.  Required when <paramref name="sendSlackMessageResult"/> is <see cref="SendSlackMessageResult.Succeeded"/> or <see cref="SendSlackMessageResult.FailedWithSlackReturningError"/>, otherwise should be null.</param>
        /// <param name="exceptionToString">The <see cref="object.ToString()"/> of the <see cref="Exception"/> that was thrown when sending the message.  Required when <paramref name="sendSlackMessageResult"/> is <see cref="SendSlackMessageResult.FailedWithExceptionWhenSending"/>, otherwise should be null.</param>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "string", Justification = NaosSuppressBecause.CA1720_IdentifiersShouldNotContainTypeNames_TypeNameAddsClarityToIdentifierAndAlternativesDegradeClarity)]
        public SendSlackMessageResponse(
            SendSlackMessageResult sendSlackMessageResult,
            string responseJson,
            string exceptionToString)
        {
            new { sendSlackMessageResult }.AsArg().Must().NotBeEqualTo(SendSlackMessageResult.Unknown);

            if ((sendSlackMessageResult == SendSlackMessageResult.Succeeded) || (sendSlackMessageResult == SendSlackMessageResult.FailedWithSlackReturningError))
            {
                new { responseJson }.AsArg().Must().NotBeNullNorWhiteSpace();
            }
            else
            {
                new { responseJson }.AsArg().Must().BeNull();
            }

            if (sendSlackMessageResult == SendSlackMessageResult.FailedWithExceptionWhenSending)
            {
                new { exceptionToString }.AsArg().Must().NotBeNullNorWhiteSpace();
            }
            else
            {
                new { exceptionToString }.AsArg().Must().BeNull();
            }

            this.SendSlackMessageResult = sendSlackMessageResult;
            this.ResponseJson = responseJson;
            this.ExceptionToString = exceptionToString;
        }

        /// <summary>
        /// Gets the result of sending the message.
        /// </summary>
        public SendSlackMessageResult SendSlackMessageResult { get; private set; }

        /// <summary>
        /// Gets the response JSON returned by Slack.
        /// </summary>
        public string ResponseJson { get; private set; }

        /// <summary>
        /// Gets the <see cref="object.ToString()"/> of the <see cref="Exception"/> that was thrown when sending the message.
        /// </summary>
        public string ExceptionToString { get; private set; }
    }
}
