using BrawlHelper.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrawlHelper
{
    public class DataBase
    {
        private readonly string _connectionString;

        public DataBase()
        {
            _connectionString = Constants.Connect;
        }

        public async Task InsertPlayer(Player player)
        {
            var sql = "INSERT INTO public.\"player\" (\"Tag\", \"Name\", \"Trophies\", \"ExpLevel\", \"ExpPoints\", \"HighestTrophies\", \"PowerPlayPoints\", \"HighestPowerPlayPoints\", \"SoloVictories\", \"DuoVictories\", \"BestRoboRumbleTime\", \"BestTimeAsBigBrawler\") " +
                      "VALUES (@Tag, @Name, @Trophies, @ExpLevel, @ExpPoints, @HighestTrophies, @PowerPlayPoints, @HighestPowerPlayPoints, @SoloVictories, @DuoVictories, @BestRoboRumbleTime, @BestTimeAsBigBrawler)";

            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            await using var comm = new NpgsqlCommand(sql, conn);
            comm.Parameters.AddWithValue("Tag", player.Tag);
            comm.Parameters.AddWithValue("Name", player.Name);
            comm.Parameters.AddWithValue("Trophies", player.Trophies);
            comm.Parameters.AddWithValue("ExpLevel", player.ExpLevel);
            comm.Parameters.AddWithValue("ExpPoints", player.ExpPoints);
            comm.Parameters.AddWithValue("HighestTrophies", player.HighestTrophies);
            comm.Parameters.AddWithValue("PowerPlayPoints", player.PowerPlayPoints);
            comm.Parameters.AddWithValue("HighestPowerPlayPoints", player.HighestPowerPlayPoints);
            comm.Parameters.AddWithValue("SoloVictories", player.SoloVictories);
            comm.Parameters.AddWithValue("DuoVictories", player.DuoVictories);
            comm.Parameters.AddWithValue("BestRoboRumbleTime", player.BestRoboRumbleTime);
            comm.Parameters.AddWithValue("BestTimeAsBigBrawler", player.BestTimeAsBigBrawler);

            await comm.ExecuteNonQueryAsync();
        }

        public async Task<List<Player>> GetAllPlayers()
        {
            var players = new List<Player>();
            var sql = "SELECT \"Tag\", \"Name\", \"Trophies\", \"ExpLevel\", \"ExpPoints\", \"HighestTrophies\", \"PowerPlayPoints\", \"HighestPowerPlayPoints\", \"SoloVictories\", \"DuoVictories\", \"BestRoboRumbleTime\", \"BestTimeAsBigBrawler\" FROM public.\"player\"";

            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            await using var comm = new NpgsqlCommand(sql, conn);
            await using var reader = await comm.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var player = new Player
                {
                    Tag = reader.GetString(0),
                    Name = reader.GetString(1),
                    Trophies = reader.GetInt32(2),
                    ExpLevel = reader.GetInt32(3),
                    ExpPoints = reader.GetInt32(4),
                    HighestTrophies = reader.GetInt32(5),
                    PowerPlayPoints = reader.GetInt32(6),
                    HighestPowerPlayPoints = reader.GetInt32(7),
                    SoloVictories = reader.GetInt32(8),
                    DuoVictories = reader.GetInt32(9),
                    BestRoboRumbleTime = reader.GetInt32(10),
                    BestTimeAsBigBrawler = reader.GetInt32(11)
                };
                players.Add(player);
            }

            return players;
        }

        public async Task DeletePlayer(string playerId)
        {
            var sql = "DELETE FROM public.\"player\" WHERE \"Tag\" = @Tag";

            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            await using var comm = new NpgsqlCommand(sql, conn);
            comm.Parameters.AddWithValue("Tag", playerId);

            await comm.ExecuteNonQueryAsync();
        }

        public async Task<bool> PlayerExists(string playerId)
        {
            var sql = "SELECT 1 FROM public.\"player\" WHERE \"Tag\" = @Tag";

            await using var conn = new NpgsqlConnection(_connectionString);


                        await conn.OpenAsync();

            await using var comm = new NpgsqlCommand(sql, conn);
            comm.Parameters.AddWithValue("Tag", playerId);

            await using var reader = await comm.ExecuteReaderAsync();
            return await reader.ReadAsync();
        }

        public async Task UpdatePlayer(Player player)
        {
            var sql = "UPDATE public.\"player\" SET " +
                      "\"Name\" = @Name, " +
                      "\"Trophies\" = @Trophies, " +
                      "\"ExpLevel\" = @ExpLevel, " +
                      "\"ExpPoints\" = @ExpPoints, " +
                      "\"HighestTrophies\" = @HighestTrophies, " +
                      "\"PowerPlayPoints\" = @PowerPlayPoints, " +
                      "\"HighestPowerPlayPoints\" = @HighestPowerPlayPoints, " +
                      "\"SoloVictories\" = @SoloVictories, " +
                      "\"DuoVictories\" = @DuoVictories, " +
                      "\"BestRoboRumbleTime\" = @BestRoboRumbleTime, " +
                      "\"BestTimeAsBigBrawler\" = @BestTimeAsBigBrawler " +
                      "WHERE \"Tag\" = @Tag";

            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            await using var comm = new NpgsqlCommand(sql, conn);
            comm.Parameters.AddWithValue("Tag", player.Tag);
            comm.Parameters.AddWithValue("Name", player.Name);
            comm.Parameters.AddWithValue("Trophies", player.Trophies);
            comm.Parameters.AddWithValue("ExpLevel", player.ExpLevel);
            comm.Parameters.AddWithValue("ExpPoints", player.ExpPoints);
            comm.Parameters.AddWithValue("HighestTrophies", player.HighestTrophies);
            comm.Parameters.AddWithValue("PowerPlayPoints", player.PowerPlayPoints);
            comm.Parameters.AddWithValue("HighestPowerPlayPoints", player.HighestPowerPlayPoints);
            comm.Parameters.AddWithValue("SoloVictories", player.SoloVictories);
            comm.Parameters.AddWithValue("DuoVictories", player.DuoVictories);
            comm.Parameters.AddWithValue("BestRoboRumbleTime", player.BestRoboRumbleTime);
            comm.Parameters.AddWithValue("BestTimeAsBigBrawler", player.BestTimeAsBigBrawler);

            await comm.ExecuteNonQueryAsync();
        }
    }
}