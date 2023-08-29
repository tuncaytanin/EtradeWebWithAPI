﻿using System.Runtime.Serialization;
using System;

namespace WebCoreMvc.Exceptions
{
    [Serializable]
    internal class UnAuthorizedException : Exception
    {
        public UnAuthorizedException()
        {
        }

        public UnAuthorizedException(string message) : base(message)
        {
        }

        public UnAuthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnAuthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
