using Microsoft.EntityFrameworkCore.Migrations;
using Shared.Utils;

#nullable disable

namespace Voting_API.Database.Migrations
{
    /// <inheritdoc />
    public partial class CandidatesDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(SqlExecuter.GetSql(nameof(CandidatesDataSeed)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
