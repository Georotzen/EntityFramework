﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.EntityFrameworkCore.Tools.Commands;
using Microsoft.Extensions.CommandLineUtils;

namespace Microsoft.EntityFrameworkCore.Tools
{
    internal static class Program
    {
        private static int Main(string[] args)
        {
            var app = new CommandLineApplication()
            {
                Name = "ef"
            };

            new RootCommand().Configure(app);

            try
            {
                return app.Execute(args);
            }
            catch (Exception ex)
            {
                var wrappedException = ex as WrappedException;
                if (ex is CommandException
                    || ex is CommandParsingException
                    || (wrappedException != null
                        && wrappedException.Type == "Microsoft.EntityFrameworkCore.Design.OperationException"))
                {
                    Reporter.WriteVerbose(ex.ToString());
                }
                else
                {
                    Reporter.WriteInformation(ex.ToString());
                }

                Reporter.WriteError(ex.Message);

                return 1;
            }
        }
    }
}