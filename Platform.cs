using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGamesDBAPI {
    public class Platform {
        public int ID, MaxControllers;
        public String Overview, Developer, Manufacturer, CPU, Memory, Graphics, Sound, Display, Media;
        public float Rating;

        public PlatformImages Images;

        public class PlatformImages {

        }
    }
}
