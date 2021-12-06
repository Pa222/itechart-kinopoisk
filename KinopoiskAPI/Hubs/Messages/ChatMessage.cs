﻿namespace KinopoiskAPI.Hubs.Messages
{
    public class ChatMessage
    {
        public string Receiver { get; set; } = ChatDefaultValues.Empty;
        public string Sender { get; set; }
        public string Message { get; set; }
    }
}