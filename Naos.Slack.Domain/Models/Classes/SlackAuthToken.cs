// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SlackAuthToken.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// A Slack authentication token bearing the required scopes.
    /// </summary>
    public partial class SlackAuthToken : IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SlackAuthToken"/> class.
        /// </summary>
        /// <param name="value">The token value.</param>
        public SlackAuthToken(
            string value)
        {
            new { value }.AsArg().Must().NotBeNullNorWhiteSpace();

            this.Value = value;
        }

        /// <summary>
        /// Gets the token value.
        /// </summary>
        public string Value { get; private set; }
    }
}
