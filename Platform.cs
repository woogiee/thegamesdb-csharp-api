using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGamesDBAPI {
    /// <summary>
    /// Contains the data for one platform in the database.
    /// </summary>
    public class Platform {
        /// <summary>
        /// Unique database ID.
        /// </summary>
        public int ID;

        /// <summary>
        /// The name of the platform.
        /// </summary>
        public String Name;

        /// <summary>
        /// The max amount of controllers that can be connected to the device.
        /// </summary>
        public int MaxControllers;

        /// <summary>
        /// General overview of the platform.
        /// </summary>
        public String Overview;
        
        /// <summary>
        /// The developer(s) of the platform.
        /// </summary>
        public String Developer;

        /// <summary>
        /// The manufacturer(s) of the platform.
        /// </summary>
        public String Manufacturer;

        /// <summary>
        /// The CPU of the platform (for platforms which have one specific CPU).
        /// </summary>
        public String CPU;

        /// <summary>
        /// Information about the platform's memory.
        /// </summary>
        public String Memory;

        /// <summary>
        /// The platform's graphics card.
        /// </summary>
        public String Graphics;

        /// <summary>
        /// Information about the platform's sound capabilities.
        /// </summary>
        public String Sound;

        /// <summary>
        /// Display resolution (on the form: 'width'x'height')
        /// </summary>
        public String Display;

        /// <summary>
        /// The game media the platform reads (eg. 'Disc').
        /// </summary>
        public String Media;

        /// <summary>
        /// The average rating as rated by the users on TheGamesDB.net.
        /// </summary>
        public float Rating;

        public PlatformImages Images;

        public class PlatformImages {

        }
    }
}
