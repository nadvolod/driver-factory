using System;
using System.Runtime.Serialization;

namespace DriverFactory.Tests.Core
{
    [Serializable]
    internal class SauceEnvironmentVariableNotSetException : Exception
    {
        public SauceEnvironmentVariableNotSetException()
        {
        }

        public SauceEnvironmentVariableNotSetException(string message) : base(message)
        {
        }

        public SauceEnvironmentVariableNotSetException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SauceEnvironmentVariableNotSetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}