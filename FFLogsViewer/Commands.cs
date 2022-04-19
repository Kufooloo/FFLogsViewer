﻿using System;
using Dalamud.Game.Command;

namespace FFLogsViewer;

public class Commands
{
    private const string CommandName = "/fflogs";
    private const string SettingsCommandName = "/fflogsconfig";

    public Commands()
    {
        Service.CommandManager.AddHandler(CommandName, new CommandInfo(OnCommand)
        {
            HelpMessage = "Open config",
            ShowInHelp = true,
        });

        Service.CommandManager.AddHandler(SettingsCommandName, new CommandInfo(OnCommand)
        {
            HelpMessage = "Open the FF Logs Viewer config window.",
            ShowInHelp = true,
        });
    }

    public static void Dispose()
    {
        Service.CommandManager.RemoveHandler(CommandName);
        Service.CommandManager.RemoveHandler(SettingsCommandName);
    }

    private static void OnCommand(string command, string args)
    {
        switch (command)
        {
            case CommandName when args.Equals("config", StringComparison.OrdinalIgnoreCase):
            case SettingsCommandName:
                Service.ConfigWindow.Toggle();
                break;
            case CommandName when string.IsNullOrEmpty(args):
                Service.MainWindow.Toggle();
                break;
            case CommandName:
                Service.CharDataManager.DisplayedChar.FetchTextCharacter(args);
                break;
        }
    }
}
