// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUploadFileToSlackProtocol.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using Naos.Protocol.Domain;

    /// <summary>
    /// Executes a <see cref="UploadFileToSlackOp"/>.
    /// </summary>
    public interface IUploadFileToSlackProtocol : IAsyncReturningProtocol<UploadFileToSlackOp, UploadFileToSlackResponse>
    {
    }
}