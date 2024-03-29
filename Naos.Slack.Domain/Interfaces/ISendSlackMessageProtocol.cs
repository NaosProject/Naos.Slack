﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISendSlackMessageProtocol.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Slack.Domain
{
    using OBeautifulCode.Type;

    /// <summary>
    /// Executes a <see cref="SendSlackMessageOp"/>.
    /// </summary>
    public interface ISendSlackMessageProtocol : IAsyncReturningProtocol<SendSlackMessageOp, SendSlackMessageResponse>
    {
    }
}