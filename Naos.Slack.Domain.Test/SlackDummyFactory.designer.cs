﻿// --------------------------------------------------------------------------------------------------------------------
// <auto-generated>
//   Generated using OBeautifulCode.CodeGen.ModelObject (1.0.178.0)
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain.Test
{
    using global::System;
    using global::System.CodeDom.Compiler;
    using global::System.Collections.Concurrent;
    using global::System.Collections.Generic;
    using global::System.Collections.ObjectModel;
    using global::System.Diagnostics.CodeAnalysis;

    using global::FakeItEasy;

    using global::Naos.Slack.Domain;

    using global::OBeautifulCode.AutoFakeItEasy;
    using global::OBeautifulCode.Math.Recipes;
    using global::OBeautifulCode.Type;

    /// <summary>
    /// The default (code generated) Dummy Factory.
    /// Derive from this class to add any overriding or custom registrations.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [GeneratedCode("OBeautifulCode.CodeGen.ModelObject", "1.0.178.0")]
#if !NaosSlackSolution
    internal
#else
    public
#endif
    abstract class DefaultSlackDummyFactory : IDummyFactory
    {
        public DefaultSlackDummyFactory()
        {
            AutoFixtureBackedDummyFactory.AddDummyCreator(
                () => new FailedToSendSlackMessageEvent<Version>(
                                 A.Dummy<Version>(),
                                 A.Dummy<DateTime>(),
                                 A.Dummy<SendSlackMessageResponse>()));

            AutoFixtureBackedDummyFactory.AddDummyCreator(
                () => new FailedToUploadFileToSlackEvent<Version>(
                                 A.Dummy<Version>(),
                                 A.Dummy<DateTime>(),
                                 A.Dummy<UploadFileToSlackResponse>()));

            AutoFixtureBackedDummyFactory.AddDummyCreator(
                () => new MessageAuthorIcon(
                                 A.Dummy<string>(),
                                 A.Dummy<IconResourceIdentifierKind>()));

            AutoFixtureBackedDummyFactory.AddDummyCreator(
                () => new SendSlackMessageOp(
                                 A.Dummy<SendSlackMessageRequestBase>()));

            AutoFixtureBackedDummyFactory.AddDummyCreator(
                () =>
                {
                    var availableTypes = new[]
                    {
                        typeof(SendSlackTextMessageRequest)
                    };

                    var randomIndex = ThreadSafeRandom.Next(0, availableTypes.Length);

                    var randomType = availableTypes[randomIndex];

                    var result = (SendSlackMessageRequestBase)AD.ummy(randomType);

                    return result;
                });

            AutoFixtureBackedDummyFactory.AddDummyCreator(
                () => new SendSlackMessageRequestedEvent<Version>(
                                 A.Dummy<Version>(),
                                 A.Dummy<DateTime>(),
                                 A.Dummy<SendSlackMessageRequestBase>()));

            AutoFixtureBackedDummyFactory.AddDummyCreator(
                () => new SendSlackMessageResponse(
                                 A.Dummy<SendSlackMessageResult>(),
                                 A.Dummy<string>(),
                                 A.Dummy<string>()));

            AutoFixtureBackedDummyFactory.AddDummyCreator(
                () =>
                {
                    var availableTypes = new[]
                    {
                        typeof(FailedToSendSlackMessageEvent<Version>),
                        typeof(SucceededInSendingSlackMessageEvent<Version>)
                    };

                    var randomIndex = ThreadSafeRandom.Next(0, availableTypes.Length);

                    var randomType = availableTypes[randomIndex];

                    var result = (SendSlackMessageResponseEventBase<Version>)AD.ummy(randomType);

                    return result;
                });

            AutoFixtureBackedDummyFactory.AddDummyCreator(
                () => new SendSlackTextMessageRequest(
                                 A.Dummy<string>(),
                                 A.Dummy<string>(),
                                 A.Dummy<SlackTextFormat>(),
                                 A.Dummy<SlackTextMessageOptions>(),
                                 A.Dummy<MessageAuthorIcon>(),
                                 A.Dummy<string>()));

            AutoFixtureBackedDummyFactory.AddDummyCreator(
                () => new SlackAuthToken(
                                 A.Dummy<string>()));

            AutoFixtureBackedDummyFactory.AddDummyCreator(
                () =>
                {
                    var availableTypes = new[]
                    {
                        typeof(FailedToSendSlackMessageEvent<Version>),
                        typeof(FailedToUploadFileToSlackEvent<Version>),
                        typeof(SendSlackMessageRequestedEvent<Version>),
                        typeof(SucceededInSendingSlackMessageEvent<Version>),
                        typeof(SucceededInUploadingFileToSlackEvent<Version>),
                        typeof(UploadFileToSlackRequestedEvent<Version>)
                    };

                    var randomIndex = ThreadSafeRandom.Next(0, availableTypes.Length);

                    var randomType = availableTypes[randomIndex];

                    var result = (SlackEventBase<Version>)AD.ummy(randomType);

                    return result;
                });

            AutoFixtureBackedDummyFactory.AddDummyCreator(
                () => new SucceededInSendingSlackMessageEvent<Version>(
                                 A.Dummy<Version>(),
                                 A.Dummy<DateTime>(),
                                 A.Dummy<SendSlackMessageResponse>()));

            AutoFixtureBackedDummyFactory.AddDummyCreator(
                () => new SucceededInUploadingFileToSlackEvent<Version>(
                                 A.Dummy<Version>(),
                                 A.Dummy<DateTime>(),
                                 A.Dummy<UploadFileToSlackResponse>()));

            AutoFixtureBackedDummyFactory.AddDummyCreator(
                () => new UploadFileToSlackOp(
                                 A.Dummy<UploadFileToSlackRequest>()));

            AutoFixtureBackedDummyFactory.AddDummyCreator(
                () => new UploadFileToSlackRequest(
                                 A.Dummy<byte[]>(),
                                 A.Dummy<IReadOnlyCollection<string>>(),
                                 A.Dummy<FileType>(),
                                 A.Dummy<string>(),
                                 A.Dummy<string>(),
                                 A.Dummy<string>()));

            AutoFixtureBackedDummyFactory.AddDummyCreator(
                () => new UploadFileToSlackRequestedEvent<Version>(
                                 A.Dummy<Version>(),
                                 A.Dummy<DateTime>(),
                                 A.Dummy<UploadFileToSlackRequest>()));

            AutoFixtureBackedDummyFactory.AddDummyCreator(
                () => new UploadFileToSlackResponse(
                                 A.Dummy<UploadFileToSlackResult>(),
                                 A.Dummy<string>(),
                                 A.Dummy<string>()));

            AutoFixtureBackedDummyFactory.AddDummyCreator(
                () =>
                {
                    var availableTypes = new[]
                    {
                        typeof(FailedToUploadFileToSlackEvent<Version>),
                        typeof(SucceededInUploadingFileToSlackEvent<Version>)
                    };

                    var randomIndex = ThreadSafeRandom.Next(0, availableTypes.Length);

                    var randomType = availableTypes[randomIndex];

                    var result = (UploadFileToSlackResponseEventBase<Version>)AD.ummy(randomType);

                    return result;
                });
        }

        /// <inheritdoc />
        public Priority Priority => new FakeItEasy.Priority(1);

        /// <inheritdoc />
        public bool CanCreate(Type type)
        {
            return false;
        }

        /// <inheritdoc />
        public object Create(Type type)
        {
            return null;
        }
    }
}