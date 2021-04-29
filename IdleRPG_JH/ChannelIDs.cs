using System;
using System.Collections.Generic;
using System.Text;

namespace IdleRPG_JH.Channels
{
    public static class ChannelIDs
    {
        //Event log
        public static ulong event_log = 614465031450525746;
        public static string GetEventLogLink() { return GetChannelString(event_log); }

        //General
        public static ulong general_commands = 614519679641190414;
        public static string GetGeneralCommandsLink() { return GetChannelString(general_commands); }

        //Trade
        public static ulong trade_commands = 614466797353173022;
        public static string GetTradeCommandsLink() { return GetChannelString(trade_commands); }

        //Market
        public static ulong market = 614468314004979721;
        public static string GetMarketLink() { return GetChannelString(market); }

        //Part bits
        public static ulong party_commands = 741625361397448816;
        public static string GetPartyCommandsLink() { return GetChannelString(event_log); }

        public static string GetChannelString(ulong id)
        {
            return "<#" + id + ">";
        }
    }
}
