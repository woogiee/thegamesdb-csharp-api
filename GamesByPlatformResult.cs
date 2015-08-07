using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGamesDBAPI {
    /// <summary>
    /// Represents a search result by platform.
    /// </summary>
	public class GamesByPlatformResult
	{
        /// <summary>
        /// Unique database ID.
        /// </summary>
        public int ID;

        /// <summary>
        /// Name of the platform.
        /// </summary>
        public String GameTitle;

		/// <summary>
		/// Date on which the game was released.
		/// </summary>
		public String ReleaseDate;
    }
}
