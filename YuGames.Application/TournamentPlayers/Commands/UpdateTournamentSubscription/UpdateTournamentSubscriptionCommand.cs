﻿// <copyright file="UpdateTournamentSubscriptionCommand.cs" company="LeadOn's Corp'">
// Copyright (c) LeadOn's Corp'. All rights reserved.
// </copyright>

namespace YuGames.Application.TournamentPlayers.Commands.UpdateTournamentSubscription
{
    using MediatR;
    using YuGames.Common.DTOs;
    using YuGames.Domain;

    /// <summary>
    /// UpdateTournamentSubscriptionCommand class.
    /// </summary>
    public class UpdateTournamentSubscriptionCommand : IRequest<TournamentPlayer?>
    {
        /// <summary>
        /// Gets or sets Tournament ID.
        /// </summary>
        public int TournamentId { get; set; }

        /// <summary>
        /// Gets or sets ConnectedPlayer.
        /// </summary>
        public ConnectedPlayerDto Player { get; set; } = new ConnectedPlayerDto();

        /// <summary>
        /// Gets or sets Fifa Team ID.
        /// </summary>
        public int FifaTeamId { get; set; }
    }
}
