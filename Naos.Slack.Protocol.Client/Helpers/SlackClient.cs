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
        /// Posts to a API method.
        /// </summary>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="parameters">The method parameter name/value pairs.</param>
        /// <param name="httpContent">The HTTP request content to send.</param>
        /// <returns>
        /// The response message.
        /// </returns>
        public async Task<HttpResponseMessage> PostAsync(
            string methodName,
            IReadOnlyCollection<Tuple<string, string>> parameters,
            HttpContent httpContent)
        {
            new { methodName }.AsArg().Must().NotBeNullNorWhiteSpace();
            new { parameters }.AsArg().Must().NotBeNullNorEmptyEnumerableNorContainAnyNulls();
            new { httpContent }.AsArg().Must().NotBeNull();

            var methodUrl = new Uri(Path.Combine(ApiBaseUrl, methodName));

            var parametersWithToken = new Tuple<string, string>[0]
                .Concat(new[] { new Tuple<string, string>("token", this.authenticationToken) })
                .Concat(parameters)
                .ToList();

            var queryString = parametersWithToken
                .Select(_ => Invariant($"{WebUtility.UrlEncode(_.Item1)}={WebUtility.UrlEncode(_.Item2)}"))
                .ToDelimitedString("&");

            var requestUrl = Invariant($"{methodUrl}?{queryString}");

            var result = await this.httpClient.PostAsync(requestUrl, httpContent);

            return result;
        }
    }
}
