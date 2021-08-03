using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Sidekick.Common.Settings;
using Sidekick.Domain.Game.GameLogs.Queries;
using Sidekick.Domain.Keybinds;
using Sidekick.Domain.Platforms;

namespace Sidekick.Application.Keybinds
{
    public class ChatKeybindHandler : IChatKeybindHandler
    {
        private const string Token_Me_CharacterName = "{Me.CharacterName}";
        private const string Token_LastWhisper_CharacterName = "{LastWhisper.CharacterName}";

        private readonly ISettings settings;
        private readonly IClipboardProvider clipboard;
        private readonly IKeyboardProvider keyboard;
        private readonly ILogger<ChatKeybindHandler> logger;
        private readonly IMediator mediator;
        private readonly IProcessProvider processProvider;

        public ChatKeybindHandler(
            ISettings settings,
            IClipboardProvider clipboard,
            IKeyboardProvider keyboard,
            ILogger<ChatKeybindHandler> logger,
            IMediator mediator,
            IProcessProvider processProvider)
        {
            this.settings = settings;
            this.clipboard = clipboard;
            this.keyboard = keyboard;
            this.logger = logger;
            this.mediator = mediator;
            this.processProvider = processProvider;
        }

        public bool IsValid() => processProvider.IsPathOfExileInFocus;

        public async Task Execute(string command, bool submit)
        {
            if (string.IsNullOrEmpty(command)) return;

            string clipboardValue = null;
            if (settings.RetainClipboard)
            {
                clipboardValue = await clipboard.GetText();
            }

            if (command.Contains(Token_Me_CharacterName))
            {
                // This operation is only valid if the user has added their character name to the settings file.
                if (string.IsNullOrEmpty(settings.Character_Name))
                {
                    logger.LogWarning(@"This command requires a ""CharacterName"" to be specified in the settings menu.");
                    return;
                }

                command = command.Replace(Token_Me_CharacterName, settings.Character_Name);
            }

            if (command.Contains(Token_LastWhisper_CharacterName))
            {
                var characterName = await mediator.Send(new GetLatestWhisperCharacterNameQuery());
                if (string.IsNullOrEmpty(characterName))
                {
                    logger.LogWarning(@"No last whisper was found in the log file.");
                    return;
                }

                command = command.Replace(Token_LastWhisper_CharacterName, characterName);
            }

            await clipboard.SetText(command);

            if (submit)
            {
                keyboard.PressKey("Enter", "Ctrl+A", "Paste", "Enter", "Enter", "Up", "Up", "Esc");
            }
            else
            {
                keyboard.PressKey("Enter", "Ctrl+A", "Paste");
            }

            if (settings.RetainClipboard)
            {
                await Task.Delay(100);
                await clipboard.SetText(clipboardValue);
            }
        }
    }
}
