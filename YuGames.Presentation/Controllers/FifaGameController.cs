﻿// <copyright file="FifaGameController.cs" company="LeadOn's Corp'">
// Copyright (c) LeadOn's Corp'. All rights reserved.
// </copyright>

namespace YuGames.Presentation.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using YuGames.Application.FifaGamePlayed.Commands.DeleteFifaGamePlayed;
    using YuGames.Application.FifaGamePlayed.Queries.GetFifaGamePlayedById;
    using YuGames.Application.FifaGamePlayed.Queries.GetFifaGamePlayedByTournamentId;
    using YuGames.Application.FifaGamePlayed.Queries.GetLastFifaGamesPlayed;
    using YuGames.Application.FifaGamePlayed.Queries.GetLastFifaGamesPlayedByPlayerId;
    using YuGames.Application.FifaGamePlayed.Queries.SearchFifaGamesPlayed;
    using YuGames.Common.DTOs;

    /// <summary>
    /// FifaGame Controller.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class FifaGameController : ControllerBase
    {
        private readonly ISender mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="FifaGameController"/> class.
        /// </summary>
        /// <param name="mediator">MediatR interface, injected.</param>
        public FifaGameController(ISender mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets tournament games.
        /// </summary>
        /// <param name="tournamentId">Tournament ID.</param>
        /// <returns>IActionResult object.</returns>
        [HttpGet]
        [Route("tournament/{tournamentId:int}")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Get games played by tournament.")]
        [SwaggerResponse(200, "List of games played.", typeof(List<FifaGamePlayedDto>))]
        [SwaggerResponse(500, "Unknown error happened.")]
        public async Task<IActionResult> GetTournamentGames(int tournamentId)
        {
            return this.Ok(await this.mediator.Send(new GetFifaGamePlayedByTournamentIdQuery { TournamentId = tournamentId }));
        }

        /// <summary>
        /// Get game played by ID.
        /// </summary>
        /// <param name="gameId">Game ID.</param>
        /// <returns>IActionResult object.</returns>
        [HttpGet]
        [Route("{gameId:int}")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Get game played by ID.", Description = "Get game played by ID with its team players and highlights.")]
        [SwaggerResponse(200, "Game played.", typeof(FifaGamePlayedDto))]
        [SwaggerResponse(404, "Game not found.")]
        [SwaggerResponse(500, "Unknown error happened.")]
        public async Task<IActionResult> GetById(int gameId)
        {
            var gameInDb = await this.mediator.Send(new GetFifaGamePlayedByIdQuery { FifaGamePlayedId = gameId });

            if (gameInDb is null)
            {
                return this.NotFound();
            }

            return this.Ok(gameInDb);
        }

        /// <summary>
        /// Get last games played.
        /// </summary>
        /// <param name="number">Number of data to retrieve.</param>
        /// <returns>200 OK with Game list.</returns>
        [HttpGet]
        [Route("last/{number:int}")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Get last games played.", Description = "Get last games played with their players.")]
        [SwaggerResponse(200, "List of games played.", typeof(List<FifaGamePlayedDto>))]
        [SwaggerResponse(500, "Unknown error happened.")]
        public async Task<IActionResult> GetLastGamesPlayed(int number)
        {
            return this.Ok(await this.mediator.Send(new GetLastFifaGamesPlayedQuery { Limit = number }));
        }

        /// <summary>
        /// Gets last games played by player.
        /// </summary>
        /// <param name="number">Limit of results.</param>
        /// <param name="playerId">Player ID.</param>
        /// <returns>IActionResult object.</returns>
        [HttpGet]
        [Route("last/{number:int}/player/{playerId:int}")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Get last games played by player.", Description = "Get last games played by player with their team members.")]
        [SwaggerResponse(200, "List of games played.", typeof(List<FifaGamePlayedDto>))]
        [SwaggerResponse(500, "Unknown error happened.")]
        public async Task<IActionResult> GetLastGamesPlayedByPlayer(int number, int playerId)
        {
            return this.Ok(await this.mediator.Send(new GetLastFifaGamesPlayedByPlayerIdQuery { PlayerId = playerId, Limit = number }));
        }

        /// <summary>
        /// Delete game in database.
        /// </summary>
        /// <param name="gameId">Game ID.</param>
        /// <returns>IActionResult object.</returns>
        [HttpDelete]
        [Authorize(Roles = "yugames_admin")]
        [Route("{gameId:int}")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Delete game in database.", Description = "Delete game in database (including highlights / team-players). WARNING: it really deletes!")]
        [SwaggerResponse(204, "Deleted Game.")]
        [SwaggerResponse(401, "User is not logged in.")]
        [SwaggerResponse(403, "User isn't admin.")]
        [SwaggerResponse(500, "Unknown error.")]
        public async Task<IActionResult> Delete(int gameId)
        {
            var deleteStatus = await this.mediator.Send(new DeleteFifaGamePlayedCommand { GameId = gameId });

            if (deleteStatus)
            {
                return this.NoContent();
            }
            else
            {
                return this.Problem();
            }
        }

        /// <summary>
        /// Search game in database.
        /// </summary>
        /// <param name="limit">Limit (10 by default, 50 max).</param>
        /// <param name="platformId">Platform ID.</param>
        /// <param name="startDate">Start Date.</param>
        /// <param name="endDate">End date.</param>
        /// <returns>IActionResult object.</returns>
        [HttpGet]
        [Route("")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Search games played in database.")]
        [SwaggerResponse(200, "Games played.", typeof(List<FifaGamePlayedDto>))]
        [SwaggerResponse(500, "Something wrong happened.")]
        public async Task<IActionResult> Search(int? limit, int? platformId, DateTime? startDate, DateTime? endDate)
        {
            return this.Ok(await this.mediator.Send(new SearchFifaGamesPlayedQuery { Limit = limit, PlatformId = platformId, StartDate = startDate, EndDate = endDate }));
        }
    }
}
