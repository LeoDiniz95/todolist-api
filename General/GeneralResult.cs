﻿using System.Net;

namespace todolist_api.General
{
    public class GeneralResult
    {
        public Guid transactionId { get; set; }

        public bool failure { get; set; }

        public object data { get; set; }

        public List<string> errors { get; set; }

        public string date { get; set; }

        public List<string> message { get; set; }

        public GeneralResult()
        {
            transactionId = new Guid();
            failure = false;
            errors = new List<string>();
            date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        }

        public void AddError(Exception ex)
        {
            failure = true;
            data = new { };
            errors.Add(ex.Message);
        }

        public void AddError(string ex)
        {
            failure = true;
            data = new { };
            errors.Add(ex);
        }

        public void AddMessage(string _message)
        {
            message.Add(_message);
        }
    }
}
