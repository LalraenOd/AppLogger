using Telegram.Bot;

namespace AppLogger.Helpers
{
    public class TelegramHelper
    {
        #region Init

        private readonly ITelegramBotClient _telegramBotClient;
        private readonly int _chatId;

        public TelegramHelper(int chatId, ITelegramBotClient telegramBotClient)
        {
            _chatId = chatId;
            _telegramBotClient = telegramBotClient;
        }

        #endregion

        #region PublicMethods

        /// <summary>
        /// Sends text message to chat
        /// </summary>
        /// <param name="logMessage">Message to be send</param>
        /// <param name="disableNotification">Disable notification to receiver</param>
        public void SendMessage(string logMessage, bool disableNotification)
        {
            _telegramBotClient.SendChatActionAsync(_chatId, Telegram.Bot.Types.Enums.ChatAction.Typing).Wait();
            _telegramBotClient.SendTextMessageAsync(_chatId, logMessage, disableNotification: disableNotification)
                .Wait();
        }

        /// <summary>
        /// Sends text message to chat
        /// </summary>
        /// <param name="logMessage">Message to be send</param>
        /// <param name="disableNotification">Disable notification to receiver</param>
        public async void SendMessageAsync(string logMessage, bool disableNotification)
        {
            await _telegramBotClient.SendChatActionAsync(_chatId, Telegram.Bot.Types.Enums.ChatAction.Typing);
            await _telegramBotClient.SendTextMessageAsync(_chatId, logMessage,
                disableNotification: disableNotification);
        }

        #endregion
    }
}