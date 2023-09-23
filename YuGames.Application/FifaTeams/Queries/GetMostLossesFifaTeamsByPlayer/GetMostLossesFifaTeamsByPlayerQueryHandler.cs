﻿// <copyright file="GetMostLossesFifaTeamsByPlayerQueryHandler.cs" company="LeadOn's Corp'">
// Copyright (c) LeadOn's Corp'. All rights reserved.
// </copyright>

namespace YuGames.Application.FifaTeams.Queries.GetMostLossesFifaTeamsByPlayer
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using YuGames.Application.Common.Interfaces;
    using YuGames.Common.DTOs;

    /// <summary>
    /// GetMostLossesFifaTeamsByPlayerQueryHandler class.
    /// </summary>
    public class GetMostLossesFifaTeamsByPlayerQueryHandler : IRequestHandler<GetMostLossesFifaTeamsByPlayerQuery, List<TopTeamStatDto>>
    {
        private readonly IApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMostLossesFifaTeamsByPlayerQueryHandler"/> class.
        /// </summary>
        /// <param name="context">DbContext, injected.</param>
        public GetMostLossesFifaTeamsByPlayerQueryHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc />
        public async Task<List<TopTeamStatDto>> Handle(GetMostLossesFifaTeamsByPlayerQuery request, CancellationToken cancellationToken)
        {
            // Getting games played by user
            var gamePlayedInTeam1 = await this.context.FifaTeamPlayers.Include(x => x.FifaGamePlayed).Where(x => x.PlayerId == request.PlayerId && x.Team == 0 && x.FifaGamePlayed.TeamScore1 < x.FifaGamePlayed.TeamScore2 && x.FifaGamePlayed.SeasonId == request.SeasonId && x.FifaGamePlayed.IsPlayed == true).Select(x => x.FifaGamePlayed).ToListAsync();
            var gamePlayedInTeam2 = await this.context.FifaTeamPlayers.Include(x => x.FifaGamePlayed).Where(x => x.PlayerId == request.PlayerId && x.Team == 1 && x.FifaGamePlayed.TeamScore1 > x.FifaGamePlayed.TeamScore2 && x.FifaGamePlayed.SeasonId == request.SeasonId && x.FifaGamePlayed.IsPlayed == true).Select(x => x.FifaGamePlayed).ToListAsync();

            if (gamePlayedInTeam1.Count == 0 && gamePlayedInTeam2.Count == 0)
            {
                return new List<TopTeamStatDto>();
            }
            else
            {
                var topTeamStats = new List<TopTeamStatDto>();

                // Getting all of the Team IDs, with their game count
                var teamIdsCount = new Dictionary<int, int>();

                var team1IdsCount = gamePlayedInTeam1.GroupBy(x => x.Team1Id).Select(x => new { TeamId = x.Key, GamesPlayed = x.Count() }).ToList();
                var team2IdsCount = gamePlayedInTeam2.GroupBy(x => x.Team2Id).Select(x => new { TeamId = x.Key, GamesPlayed = x.Count() }).ToList();

                team1IdsCount.ForEach(x =>
                {
                    var id = x.TeamId;

                    if (id is null)
                    {
                        id = 0;
                    }

                    if (teamIdsCount.ContainsKey((int)id))
                    {
                        teamIdsCount[(int)id] = teamIdsCount[(int)id] + x.GamesPlayed;
                    }
                    else
                    {
                        teamIdsCount.Add((int)id, (int)x.GamesPlayed);
                    }
                });
                team2IdsCount.ForEach(x =>
                {
                    var id = x.TeamId;

                    if (id is null)
                    {
                        id = 0;
                    }

                    if (teamIdsCount.ContainsKey((int)id))
                    {
                        teamIdsCount[(int)id] = teamIdsCount[(int)id] + x.GamesPlayed;
                    }
                    else
                    {
                        teamIdsCount.Add((int)id, (int)x.GamesPlayed);
                    }
                });

                // Now that we have all of team IDs + their count, building returned object
                var wantedTeam = teamIdsCount.OrderByDescending(x => x.Value).Take(request.NumberOfTeams).ToList();

                foreach (var team in wantedTeam)
                {
                    if (team.Key == 0)
                    {
                        topTeamStats.Add(new TopTeamStatDto { NumberOfGames = team.Value });
                    }
                    else
                    {
                        var teamInDb = await this.context.FifaTeams.FirstOrDefaultAsync(x => x.Id == team.Key);
                        topTeamStats.Add(new TopTeamStatDto { NumberOfGames = team.Value, FifaTeam = teamInDb });
                    }
                }

                return topTeamStats;
            }
        }
    }
}
