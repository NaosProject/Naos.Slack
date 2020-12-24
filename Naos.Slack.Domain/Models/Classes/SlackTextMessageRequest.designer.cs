﻿// --------------------------------------------------------------------------------------------------------------------
// <auto-generated>
//   Generated using OBeautifulCode.CodeGen.ModelObject (1.0.139.0)
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using global::System;
    using global::System.CodeDom.Compiler;
    using global::System.Collections.Concurrent;
    using global::System.Collections.Generic;
    using global::System.Collections.ObjectModel;
    using global::System.Diagnostics.CodeAnalysis;
    using global::System.Globalization;
    using global::System.Linq;

    using global::OBeautifulCode.Equality.Recipes;
    using global::OBeautifulCode.Type;
    using global::OBeautifulCode.Type.Recipes;

    using static global::System.FormattableString;

    [Serializable]
    public partial class SlackTextMessageRequest : IModel<SlackTextMessageRequest>
    {
        /// <summary>
        /// Determines whether two objects of type <see cref="SlackTextMessageRequest"/> are equal.
        /// </summary>
        /// <param name="left">The object to the left of the equality operator.</param>
        /// <param name="right">The object to the right of the equality operator.</param>
        /// <returns>true if the two items are equal; otherwise false.</returns>
        public static bool operator ==(SlackTextMessageRequest left, SlackTextMessageRequest right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }

            var result = left.Equals(right);

            return result;
        }

        /// <summary>
        /// Determines whether two objects of type <see cref="SlackTextMessageRequest"/> are not equal.
        /// </summary>
        /// <param name="left">The object to the left of the equality operator.</param>
        /// <param name="right">The object to the right of the equality operator.</param>
        /// <returns>true if the two items are not equal; otherwise false.</returns>
        public static bool operator !=(SlackTextMessageRequest left, SlackTextMessageRequest right) => !(left == right);

        /// <inheritdoc />
        public bool Equals(SlackTextMessageRequest other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (ReferenceEquals(other, null))
            {
                return false;
            }

            var result = this.Channel.IsEqualTo(other.Channel, StringComparer.Ordinal)
                      && this.MessageAuthorIconOverride.IsEqualTo(other.MessageAuthorIconOverride)
                      && this.MessageAuthorUsernameOverride.IsEqualTo(other.MessageAuthorUsernameOverride, StringComparer.Ordinal)
                      && this.Text.IsEqualTo(other.Text, StringComparer.Ordinal)
                      && this.TextFormat.IsEqualTo(other.TextFormat)
                      && this.Options.IsEqualTo(other.Options);

            return result;
        }

        /// <inheritdoc />
        public override bool Equals(object obj) => this == (obj as SlackTextMessageRequest);

        /// <inheritdoc />
        public override int GetHashCode() => HashCodeHelper.Initialize()
            .Hash(this.Channel)
            .Hash(this.MessageAuthorIconOverride)
            .Hash(this.MessageAuthorUsernameOverride)
            .Hash(this.Text)
            .Hash(this.TextFormat)
            .Hash(this.Options)
            .Value;

        /// <inheritdoc />
        public new SlackTextMessageRequest DeepClone() => (SlackTextMessageRequest)this.DeepCloneInternal();

        /// <inheritdoc />
        [SuppressMessage("Microsoft.Design", "CA1002: DoNotExposeGenericLists")]
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
        [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
        [SuppressMessage("Microsoft.Naming", "CA1715:IdentifiersShouldHaveCorrectPrefix")]
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords")]
        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames")]
        [SuppressMessage("Microsoft.Naming", "CA1722:IdentifiersShouldNotHaveIncorrectPrefix")]
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public override SlackMessageRequestBase DeepCloneWithChannel(string channel)
        {
            var result = new SlackTextMessageRequest(
                                 channel,
                                 this.Text?.DeepClone(),
                                 this.TextFormat,
                                 this.Options,
                                 this.MessageAuthorIconOverride?.DeepClone(),
                                 this.MessageAuthorUsernameOverride?.DeepClone());

            return result;
        }

        /// <inheritdoc />
        [SuppressMessage("Microsoft.Design", "CA1002: DoNotExposeGenericLists")]
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
        [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
        [SuppressMessage("Microsoft.Naming", "CA1715:IdentifiersShouldHaveCorrectPrefix")]
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords")]
        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames")]
        [SuppressMessage("Microsoft.Naming", "CA1722:IdentifiersShouldNotHaveIncorrectPrefix")]
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public override SlackMessageRequestBase DeepCloneWithMessageAuthorIconOverride(MessageAuthorIcon messageAuthorIconOverride)
        {
            var result = new SlackTextMessageRequest(
                                 this.Channel?.DeepClone(),
                                 this.Text?.DeepClone(),
                                 this.TextFormat,
                                 this.Options,
                                 messageAuthorIconOverride,
                                 this.MessageAuthorUsernameOverride?.DeepClone());

            return result;
        }

        /// <inheritdoc />
        [SuppressMessage("Microsoft.Design", "CA1002: DoNotExposeGenericLists")]
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
        [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
        [SuppressMessage("Microsoft.Naming", "CA1715:IdentifiersShouldHaveCorrectPrefix")]
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords")]
        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames")]
        [SuppressMessage("Microsoft.Naming", "CA1722:IdentifiersShouldNotHaveIncorrectPrefix")]
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public override SlackMessageRequestBase DeepCloneWithMessageAuthorUsernameOverride(string messageAuthorUsernameOverride)
        {
            var result = new SlackTextMessageRequest(
                                 this.Channel?.DeepClone(),
                                 this.Text?.DeepClone(),
                                 this.TextFormat,
                                 this.Options,
                                 this.MessageAuthorIconOverride?.DeepClone(),
                                 messageAuthorUsernameOverride);

            return result;
        }

        /// <summary>
        /// Deep clones this object with a new <see cref="Text" />.
        /// </summary>
        /// <param name="text">The new <see cref="Text" />.  This object will NOT be deep cloned; it is used as-is.</param>
        /// <returns>New <see cref="SlackTextMessageRequest" /> using the specified <paramref name="text" /> for <see cref="Text" /> and a deep clone of every other property.</returns>
        [SuppressMessage("Microsoft.Design", "CA1002: DoNotExposeGenericLists")]
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
        [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
        [SuppressMessage("Microsoft.Naming", "CA1715:IdentifiersShouldHaveCorrectPrefix")]
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords")]
        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames")]
        [SuppressMessage("Microsoft.Naming", "CA1722:IdentifiersShouldNotHaveIncorrectPrefix")]
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public SlackTextMessageRequest DeepCloneWithText(string text)
        {
            var result = new SlackTextMessageRequest(
                                 this.Channel?.DeepClone(),
                                 text,
                                 this.TextFormat,
                                 this.Options,
                                 this.MessageAuthorIconOverride?.DeepClone(),
                                 this.MessageAuthorUsernameOverride?.DeepClone());

            return result;
        }

        /// <summary>
        /// Deep clones this object with a new <see cref="TextFormat" />.
        /// </summary>
        /// <param name="textFormat">The new <see cref="TextFormat" />.  This object will NOT be deep cloned; it is used as-is.</param>
        /// <returns>New <see cref="SlackTextMessageRequest" /> using the specified <paramref name="textFormat" /> for <see cref="TextFormat" /> and a deep clone of every other property.</returns>
        [SuppressMessage("Microsoft.Design", "CA1002: DoNotExposeGenericLists")]
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
        [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
        [SuppressMessage("Microsoft.Naming", "CA1715:IdentifiersShouldHaveCorrectPrefix")]
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords")]
        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames")]
        [SuppressMessage("Microsoft.Naming", "CA1722:IdentifiersShouldNotHaveIncorrectPrefix")]
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public SlackTextMessageRequest DeepCloneWithTextFormat(SlackTextFormat textFormat)
        {
            var result = new SlackTextMessageRequest(
                                 this.Channel?.DeepClone(),
                                 this.Text?.DeepClone(),
                                 textFormat,
                                 this.Options,
                                 this.MessageAuthorIconOverride?.DeepClone(),
                                 this.MessageAuthorUsernameOverride?.DeepClone());

            return result;
        }

        /// <summary>
        /// Deep clones this object with a new <see cref="Options" />.
        /// </summary>
        /// <param name="options">The new <see cref="Options" />.  This object will NOT be deep cloned; it is used as-is.</param>
        /// <returns>New <see cref="SlackTextMessageRequest" /> using the specified <paramref name="options" /> for <see cref="Options" /> and a deep clone of every other property.</returns>
        [SuppressMessage("Microsoft.Design", "CA1002: DoNotExposeGenericLists")]
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
        [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
        [SuppressMessage("Microsoft.Naming", "CA1715:IdentifiersShouldHaveCorrectPrefix")]
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords")]
        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames")]
        [SuppressMessage("Microsoft.Naming", "CA1722:IdentifiersShouldNotHaveIncorrectPrefix")]
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public SlackTextMessageRequest DeepCloneWithOptions(SlackTextMessageOptions options)
        {
            var result = new SlackTextMessageRequest(
                                 this.Channel?.DeepClone(),
                                 this.Text?.DeepClone(),
                                 this.TextFormat,
                                 options,
                                 this.MessageAuthorIconOverride?.DeepClone(),
                                 this.MessageAuthorUsernameOverride?.DeepClone());

            return result;
        }

        /// <inheritdoc />
        protected override SlackMessageRequestBase DeepCloneInternal()
        {
            var result = new SlackTextMessageRequest(
                                 this.Channel?.DeepClone(),
                                 this.Text?.DeepClone(),
                                 this.TextFormat,
                                 this.Options,
                                 this.MessageAuthorIconOverride?.DeepClone(),
                                 this.MessageAuthorUsernameOverride?.DeepClone());

            return result;
        }

        /// <inheritdoc />
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public override string ToString()
        {
            var result = Invariant($"Naos.Slack.Domain.SlackTextMessageRequest: Channel = {this.Channel?.ToString(CultureInfo.InvariantCulture) ?? "<null>"}, MessageAuthorIconOverride = {this.MessageAuthorIconOverride?.ToString() ?? "<null>"}, MessageAuthorUsernameOverride = {this.MessageAuthorUsernameOverride?.ToString(CultureInfo.InvariantCulture) ?? "<null>"}, Text = {this.Text?.ToString(CultureInfo.InvariantCulture) ?? "<null>"}, TextFormat = {this.TextFormat.ToString() ?? "<null>"}, Options = {this.Options.ToString() ?? "<null>"}.");

            return result;
        }
    }
}