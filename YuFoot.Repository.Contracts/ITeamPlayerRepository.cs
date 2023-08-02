﻿// <copyright file="ITeamPlayerRepository.cs" company="LeadOn's Corp'">
// Copyright (c) LeadOn's Corp'. All rights reserved.
// </copyright>

namespace YuFoot.Repository.Contracts
{
    using YuFoot.Entities;

    /// <summary>
    /// Team Player repository.
    /// </summary>
    public interface ITeamPlayerRepository
    {
        /// <summary>
        /// Get Team players by game ID.
        /// </summary>
        /// <param name="gamePlayedId">GamePlayed ID.</param>
        /// <returns>List of Team Players.</returns>
        Task<IEnumerable<TeamPlayer>> GetTeamPlayersByGameId(int gamePlayedId);
    }
}