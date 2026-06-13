// /*
//     Copyright (C) 2026 0x90d
//     This file is part of VideoDuplicateFinder
//     VideoDuplicateFinder is free software: you can redistribute it and/or modify
//     it under the terms of the GNU Affero General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
//     VideoDuplicateFinder is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU Affero General Public License for more details.
//     You should have received a copy of the GNU Affero General Public License
//     along with VideoDuplicateFinder.  If not, see <http://www.gnu.org/licenses/>.
// */

using System.CommandLine;
using VDF.CLI.Commands;

namespace VDF.CLI.Tests.Commands;

public class DatabaseCommandTests {
	[Fact]
	public void DbCommand_Registers_Export_Subcommand() {
		var cmd = DatabaseCommand.Build();
		var export = cmd.Subcommands.FirstOrDefault(c => c.Name == "export");
		Assert.NotNull(export);
		Assert.Equal("Export the scan database to a JSON file (includes fingerprints, media info, and perceptual hashes).",
			export.Description);
	}

	[Fact]
	public void DbExport_Has_Output_Option() {
		var cmd = DatabaseCommand.Build();
		var export = cmd.Subcommands.First(c => c.Name == "export");
		var outputOpt = export.Options.FirstOrDefault(o => o.Name == "output");
		Assert.NotNull(outputOpt);
		Assert.Equal("Path for the exported JSON file.", outputOpt.Description);
	}

	[Fact]
	public void DbExport_Has_Pretty_Option() {
		var cmd = DatabaseCommand.Build();
		var export = cmd.Subcommands.First(c => c.Name == "export");
		var prettyOpt = export.Options.FirstOrDefault(o => o.Name == "pretty");
		Assert.NotNull(prettyOpt);
	}

	[Fact]
	public void DbExport_Has_Db_Option() {
		var cmd = DatabaseCommand.Build();
		var export = cmd.Subcommands.First(c => c.Name == "export");
		var dbOpt = export.Options.FirstOrDefault(o => o.Name == "db");
		Assert.NotNull(dbOpt);
	}
}
