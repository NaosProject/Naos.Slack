// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageAuthorIcon.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.Type;

    /// <summary>
    /// The icon to use for the author of a message.
    /// </summary>
    public partial class MessageAuthorIcon : IModelViaCodeGen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageAuthorIcon"/> class.
        /// </summary>
        /// <param name="resourceId">The icon resource identifier (e.g. URL, emoji name).</param>
        /// <param name="resourceIdKind">The kind of the <paramref name="resourceId"/>.</param>
        public MessageAuthorIcon(
            string resourceId,
            IconResourceIdentifierKind resourceIdKind)
        {
            new { resourceId }.AsArg().Must().NotBeNullNorWhiteSpace();
            new { resourceIdKind }.AsArg().Must().NotBeEqualTo(IconResourceIdentifierKind.Unknown);

            this.ResourceId = resourceId;
            this.ResourceIdKind = resourceIdKind;
        }

        /// <summary>
        /// Gets the icon resource identifier (e.g. URL, emoji name).
        /// </summary>
        public string ResourceId { get; private set; }

        /// <summary>
        /// Gets the kind of the <see cref="ResourceId"/>.
        /// </summary>
        public IconResourceIdentifierKind ResourceIdKind { get; private set; }
    }
}
