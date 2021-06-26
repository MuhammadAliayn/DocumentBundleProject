using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InPlace4.Models
{
    class __mError
    {
        public __mError(bool State, string Message)
        {
            this.State = State;
            this.Message = Message;
        }

        public bool State;

        public string Message;
    }
}