using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Builders;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using IdleRPG_JH.Channels;
using IdleRPG_JH.Bots;
using Newtonsoft.Json;
using System.IO;
using IdleRPG_JH.Bots.Items;

namespace IdleRPG_JH.Commands
{
    public class AdminCommands : BaseCommandModule
    {

        [Command("TestingMentions")]
        public async Task TestingMentions(CommandContext ctx, DiscordMember member = null)
        {
            if (member == null)
                await ctx.Channel.SendMessageAsync("No member @ed");
            else
                await ctx.Channel.SendMessageAsync("Member @ed" + member.DisplayName);
        }

        [Command("Start")]
        public async Task Start(CommandContext ctx)
        {

            ulong discordID = ctx.Message.Author.Id;
            string nickname = ctx.Message.Author.Username;

            if (ctx.Message.ChannelId == ChannelIDs.general_commands)
            {
                PlayerManager playerManager = await PlayerManager.FetchPlayerData();
                Player p = playerManager.GetPlayerByID(discordID);
                if (p != null)
                {
                    //profile exists!
                    await ctx.Channel.SendMessageAsync($"Player **{nickname}** already exists!");
                    return;
                }
                else
                {
                    //Make new profile
                    Player newPlayer = new Player(discordID, nickname);
                    newPlayer.InitializeProfile();
                    playerManager.AddPlayer(newPlayer);
                    playerManager.SavePlayerData();

                    await ctx.Channel.SendMessageAsync($"Player {newPlayer.Nickname}, has been added to the roster!");
                }
            }
            else
            {
                await ctx.Channel.SendMessageAsync("Visit " + ChannelIDs.GetChannelString(ChannelIDs.general_commands) + " to use this command!");
                return;
            }

            
        }

        [Command("Nickname")]
        public async Task Nickname(CommandContext ctx, string newName)
        {
            ulong discordID = ctx.Message.Author.Id;
            if (ctx.Message.ChannelId == ChannelIDs.general_commands)
            {
                PlayerManager playerManager = await PlayerManager.FetchPlayerData();
                Player p = playerManager.GetPlayerByID(discordID);
                if (p != null)
                {
                    //alter player
                    string prevNickname = p.Nickname;
                    p.SetNickname(newName);

                    //save player
                    playerManager.SavePlayerData();

                    await ctx.Channel.SendMessageAsync($"Renamed **{prevNickname}** to **{p.Nickname}**.");
                    return;
                }
                else
                {
                    await ctx.Channel.SendMessageAsync($"You must be playing to use this command.");
                }
            }
            else
            {
                await ctx.Channel.SendMessageAsync("Visit " + ChannelIDs.GetChannelString(ChannelIDs.general_commands) + " to use this command!");
                return;
            }


        }



        [Command("CreateRandomItem")]
        public async Task CreateRandomItem(CommandContext ctx, bool weapon)
        {
            if (ctx.Message.ChannelId == ChannelIDs.general_commands)
            {
                if (weapon)
                {
                    WeaponManager weaponManager = await WeaponManager.FetchItemData();
                    ulong newID = weaponManager.GetUnusedID();
                    Weapon randomWeapon = new Weapon(newID);
                    randomWeapon.RollWeapon(3);
                    weaponManager.AddItem(randomWeapon);
                    weaponManager.SaveItemData();
                    await ctx.Channel.SendMessageAsync($"ItemID: {randomWeapon.UniqueID} {randomWeapon.GetFormattedNameString()} Created!");
                    return;
                }
                else
                {
                    ArmourManager armourManager = await ArmourManager.FetchItemData();
                    ulong newID = armourManager.GetUnusedID();
                    Armour randomArmour = new Armour(newID);
                    randomArmour.RollArmour(3);
                    armourManager.AddItem(randomArmour);
                    armourManager.SaveItemData();
                    await ctx.Channel.SendMessageAsync($"ItemID: {randomArmour.UniqueID} {randomArmour.GetFormattedNameString()} Created!");
                    return;
                }
            }
            else
            {
                await ctx.Channel.SendMessageAsync("Visit " + ChannelIDs.GetChannelString(ChannelIDs.general_commands) + " to use this command!");
                return;
            }

        }

        [Command("Give")]
        public async Task GivePlayerItemWithID(CommandContext ctx, DiscordMember reciever, ulong identifier)
        {
            if (ctx.Message.ChannelId == ChannelIDs.general_commands)
            {
                PlayerManager playerManager = await PlayerManager.FetchPlayerData();

                Player recievingPlayer = playerManager.GetPlayerByID(reciever.Id);
                if (recievingPlayer != null)
                {
                    ulong identifierFirstDigit = identifier / 10000;
                    Item itemToGive = null;
                    if (identifierFirstDigit == 1)
                    {
                        ArmourManager armourManager = await ArmourManager.FetchItemData();
                        itemToGive = armourManager.GetItemByID(identifier);
                    }
                    else if (identifierFirstDigit == 2)
                    {
                        WeaponManager weaponManager = await WeaponManager.FetchItemData();
                        itemToGive = weaponManager.GetItemByID(identifier);
                    }
                    
                    if (itemToGive != null)
                    {
                        if (!recievingPlayer.Inventory.Exists(x => x == itemToGive.UniqueID))
                        {
                            recievingPlayer.AddItemToBag(itemToGive);
                            playerManager.SavePlayerData();
                            return;
                        }
                        else
                        {
                            await ctx.Channel.SendMessageAsync($"{recievingPlayer.Nickname} already has item with ID {itemToGive.UniqueID}!");
                            return;
                        }
                    }
                    else
                    {
                        await ctx.Channel.SendMessageAsync($"ID: {identifier} does not exist in the database.");
                        return;
                    }
                }
                else
                {
                    await ctx.Channel.SendMessageAsync($"{reciever.DisplayName} has no profile!");
                    return;
                }
            }
            else
            {
                await ctx.Channel.SendMessageAsync("Visit " + ChannelIDs.GetChannelString(ChannelIDs.general_commands) + " to use this command!");
                return;
            }
            //gives a player an item from the item table
        }

        [Command("Inventory")]
        public async Task Inventory(CommandContext ctx, DiscordMember reciever)
        {
            if (ctx.Message.ChannelId == ChannelIDs.general_commands)
            {
                PlayerManager playerManager = await PlayerManager.FetchPlayerData();
                Player recieverPlayer = playerManager.GetPlayerByID(reciever.Id);
                if (recieverPlayer != null)
                {
                    //Fetch recent data
                    ArmourManager armourManager = await ArmourManager.FetchItemData();
                    WeaponManager weaponManager = await WeaponManager.FetchItemData();

                    string output = $"```**{recieverPlayer.Nickname}**'s Inventory: \n";
                    foreach (ulong identifier in recieverPlayer.Inventory)
                    {
                        ulong identifierFirstDigit = identifier / 10000;
                        Item itemToGive = null;
                        if (identifierFirstDigit == 1)
                        {
                            itemToGive = armourManager.GetItemByID(identifier);
                        }
                        else if (identifierFirstDigit == 2)
                        {
                            itemToGive = weaponManager.GetItemByID(identifier);
                        }

                        if (itemToGive != null)
                        {
                            output += $"[ ID:{itemToGive.UniqueID} ] [ {itemToGive.GetRarityString()} ] [ {itemToGive.GetFormattedNameString()} ]\n";
                        }
                    }

                    output += "```";
                    await ctx.Channel.SendMessageAsync(output);
                    return;
                }
                else
                {
                    await ctx.Channel.SendMessageAsync($"{reciever.DisplayName} has no profile!");
                    return;
                }
            }
            else
            {
                await ctx.Channel.SendMessageAsync("Visit " + ChannelIDs.GetChannelString(ChannelIDs.general_commands) + " to use this command!");
                return;
            }
            //gives a player an item from the item table
        }
    }
}
