﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using MessagesSenders.SendersImplementations;
using MessagesSenders.SMS.SendersImplementations;
using Microsoft.Extensions.Configuration;

namespace MessagesSenders
{
    public class SendersProvider
    {
        private readonly IConfiguration _config;
        public SendersProvider()
        {
            _config = new ConfigurationBuilder().AddInMemoryCollection().Build();
        }

        public SendersProvider(IConfiguration configuration)
        {
            _config = configuration;
        }

        public SendersProvider(IConfiguration configuration, string section)
        {
            _config = configuration.GetSection(section);
        }

        public IMessageSender GetSender(SenderTypes type)
        {
            switch(type)
            {
                case SenderTypes.SMS:
                    return new SMSMessageSender(_config);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
