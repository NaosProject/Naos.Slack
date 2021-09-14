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
    using global::OBeautifulCode.Cloning.Recipes;

    using global::OBeautifulCode.Equality.Recipes;
    using global::OBeautifulCode.Type;
    using global::OBeautifulCode.Type.Recipes;

    using static global::System.FormattableString;

    [Serializable]
    public partial class SendSlackMessageResponse : IModel<SendSlackMessageResponse>
    {
        /// <summary>
        /// Determines whether two objects of type <see cref="SendSlackMessageResponse"/> are equal.
        /// </summary>
        /// <param name="left">The object to the left of the equality operator.</param>
        /// <param name="right">The object to the right of the equality operator.</param>
        /// <returns>true if the two items are equal; otherwise false.</returns>
        public static bool operator ==(SendSlackMessageResponse left, SendSlackMessageResponse right)
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
        /// Determines whether two objects of type <see cref="SendSlackMessageResponse"/> are not equal.
        /// </summary>
        /// <param name="left">The object to the left of the equality operator.</param>
        /// <param name="right">The object to the right of the equality operator.</param>
        /// <returns>true if the two items are not equal; otherwise false.</returns>
        public static bool operator !=(SendSlackMessageResponse left, SendSlackMessageResponse right) => !(left == right);

        /// <inheritdoc />
        public bool Equals(SendSlackMessageResponse other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (ReferenceEquals(other, null))
            {
                return false;
            }

            var result = this.SendSlackMessageResult.IsEqualTo(other.SendSlackMessageResult)
                      && this.ResponseJson.IsEqualTo(other.ResponseJson, StringComparer.Ordinal)
                      && this.ExceptionToString.IsEqualTo(other.ExceptionToString, StringComparer.Ordinal);

            return result;
        }

        /// <inheritdoc />
        public override bool Equals(object obj) => this == (obj as SendSlackMessageResponse);

        /// <inheritdoc />
        public override int GetHashCode() => HashCodeHelper.Initialize()
            .Hash(this.SendSlackMessageResult)
            .Hash(this.ResponseJson)
            .Hash(this.ExceptionToString)
            .Value;

        /// <inheritdoc />
        public object Clone() => this.DeepClone();

        /// <inheritdoc />
        public SendSlackMessageResponse DeepClone()
        {
            var result = new SendSlackMessageResponse(
                                 this.SendSlackMessageResult,
                                 this.ResponseJson?.DeepClone(),
                                 this.ExceptionToString?.DeepClone());

            return result;
        }

        /// <summary>
        /// Deep clones this object with a new <see cref="SendSlackMessageResult" />.
        /// </summary>
        /// <param name="sendSlackMessageResult">The new <see cref="SendSlackMessageResult" />.  This object will NOT be deep cloned; it is used as-is.</param>
        /// <returns>New <see cref="SendSlackMessageResponse" /> using the specified <paramref name="sendSlackMessageResult" /> for <see cref="SendSlackMessageResult" /> and a deep clone of every other property.</returns>
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
        public SendSlackMessageResponse DeepCloneWithSendSlackMessageResult(SendSlackMessageResult sendSlackMessageResult)
        {
            var result = new SendSlackMessageResponse(
                                 sendSlackMessageResult,
                                 this.ResponseJson?.DeepClone(),
                                 this.ExceptionToString?.DeepClone());

            return result;
        }

        /// <summary>
        /// Deep clones this object with a new <see cref="ResponseJson" />.
        /// </summary>
        /// <param name="responseJson">The new <see cref="ResponseJson" />.  This object will NOT be deep cloned; it is used as-is.</param>
        /// <returns>New <see cref="SendSlackMessageResponse" /> using the specified <paramref name="responseJson" /> for <see cref="ResponseJson" /> and a deep clone of every other property.</returns>
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
        public SendSlackMessageResponse DeepCloneWithResponseJson(string responseJson)
        {
            var result = new SendSlackMessageResponse(
                                 this.SendSlackMessageResult,
                                 responseJson,
                                 this.ExceptionToString?.DeepClone());

            return result;
        }

        /// <summary>
        /// Deep clones this object with a new <see cref="ExceptionToString" />.
        /// </summary>
        /// <param name="exceptionToString">The new <see cref="ExceptionToString" />.  This object will NOT be deep cloned; it is used as-is.</param>
        /// <returns>New <see cref="SendSlackMessageResponse" /> using the specified <paramref name="exceptionToString" /> for <see cref="ExceptionToString" /> and a deep clone of every other property.</returns>
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
        public SendSlackMessageResponse DeepCloneWithExceptionToString(string exceptionToString)
        {
            var result = new SendSlackMessageResponse(
                                 this.SendSlackMessageResult,
                                 this.ResponseJson?.DeepClone(),
                                 exceptionToString);

            return result;
        }

        /// <inheritdoc />
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public override string ToString()
        {
            var result = Invariant($"Naos.Slack.Domain.SendSlackMessageResponse: SendSlackMessageResult = {this.SendSlackMessageResult.ToString() ?? "<null>"}, ResponseJson = {this.ResponseJson?.ToString(CultureInfo.InvariantCulture) ?? "<null>"}, ExceptionToString = {this.ExceptionToString?.ToString(CultureInfo.InvariantCulture) ?? "<null>"}.");

            return result;
        }
    }
}