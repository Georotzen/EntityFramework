﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.Extensions.CommandLineUtils
{
    internal static class CommandLineApplicationExtensions
    {
        public static CommandOption Option(this CommandLineApplication command, string template, string description)
            => command.Option(
                template,
                description,
                template.IndexOf('<') != -1
                    ? template.EndsWith(">...")
                        ? CommandOptionType.MultipleValue
                        : CommandOptionType.SingleValue
                    : CommandOptionType.NoValue);
    }
}