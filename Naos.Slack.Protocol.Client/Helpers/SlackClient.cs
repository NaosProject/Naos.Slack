// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SlackClient.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Collection.Recipes;

    using static System.FormattableString;

    /// <summary>
    /// A Slack client.
    /// </summary>
    public class SlackClient
    {
        private const string ApiBaseUrl = "https://slack.com/api/";

        private readonly string authenticationToken;

        private readonly HttpClient httpClient;

        static SlackClient()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SlackClient"/> class.
        /// </summary>
        /// <param name="authenticationToken">A Slack authentication token bearing the required scopes.</param>
        public SlackClient(
            string authenticationToken)
        {
            new { authenticationToken }.AsArg().Must().NotBeNullNorWhiteSpace();

            this.authenticationToken = authenticationToken;
            this.httpClient = new HttpClient();
        }

        /// <summary>
        /// Gets the result of an operation from the response JSON.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="responseJson">The response JSON.</param>
        /// <param name="successResult">The result to return if the operation was successful.</param>
        /// <param name="failureResult">The result to return if the operation failed.</param>
        /// <returns>
        /// The result of the operation.
        /// </returns>
        public static T GetOperationResultFromResponseJson<T>(
            string responseJson,
            T successResult,
            T failureResult)
            where T : struct
        {
            T result;

            if (responseJson.StartsWith(@"{""ok"":true"))
            {
                result = successResult;
            }
            else if (responseJson.StartsWith(@"{""ok"":false"))
            {
                result = failureResult;
            }
            else
            {
                throw new InvalidOperationException(Invariant($"The response JSON was expected to start with an 'ok' property having a value of either 'true' or 'false', but found neither: {responseJson}."));
            }

            return result;
        }

        /// <summary>
        /// Posts to a API method.
        /// </summary>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="parameters">The method parameter name/value pairs.</param>
        /// <param name="httpContent">OPTIONAL HTTP request content to send.  DEFAULT is to specify none.</param>
        /// <returns>
        /// The response JSON.
        /// </returns>
        public async Task<string> PostAsync(
            string methodName,
            IReadOnlyCollection<Tuple<string, string>> parameters,
            HttpContent httpContent = null)
        {
            new { methodName }.AsArg().Must().NotBeNullNorWhiteSpace();
            new { parameters }.AsArg().Must().NotBeNullNorEmptyEnumerableNorContainAnyNulls();

            var methodUrl = new Uri(Path.Combine(ApiBaseUrl, methodName));

            var parametersWithToken = new Tuple<string, string>[0]
                .Concat(new[] { new Tuple<string, string>("token", this.authenticationToken) })
                .Concat(parameters)
                .ToList();

            var queryString = parametersWithToken
                .Select(_ => Invariant($"{Uri.EscapeDataString(_.Item1)}={Uri.EscapeDataString(_.Item2)}"))
                .ToDelimitedString("&");

            var requestUrl = Invariant($"{methodUrl}?{queryString}");

            var httpResponseMessage = await this.httpClient.PostAsync(requestUrl, httpContent);

            var result = await httpResponseMessage.Content.ReadAsStringAsync();

            return result;
        }
    }
}
