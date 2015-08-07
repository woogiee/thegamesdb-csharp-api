using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;

namespace TheGamesDBAPI {
    /// <summary>
    /// Contains the data for one platform in the database.
    /// </summary>
    public class Platform {
        /// <summary>
        /// Unique database ID.
        /// </summary>
		public int ID { get; set; }

        /// <summary>
        /// The name of the platform.
        /// </summary>
		public string Name { get; set; }

        /// <summary>
        /// The max amount of controllers that can be connected to the device.
        /// </summary>
		public int MaxControllers { get; set; }

        /// <summary>
        /// General overview of the platform.
        /// </summary>
		public string Overview { get; set; }
        
        /// <summary>
        /// The developer(s) of the platform.
        /// </summary>
		public string Developer { get; set; }

        /// <summary>
        /// The manufacturer(s) of the platform.
        /// </summary>
		public string Manufacturer { get; set; }

        /// <summary>
        /// The CPU of the platform (for platforms which have one specific CPU).
        /// </summary>
		public string CPU { get; set; }

        /// <summary>
        /// Information about the platform's memory.
        /// </summary>
		public string Memory { get; set; }

        /// <summary>
        /// The platform's graphics card.
        /// </summary>
		public string Graphics { get; set; }

        /// <summary>
        /// Information about the platform's sound capabilities.
        /// </summary>
		public string Sound { get; set; }

        /// <summary>
        /// Display resolution (on the form: 'width'x'height')
        /// </summary>
		public string Display { get; set; }

        /// <summary>
        /// The game media the platform reads (eg. 'Disc').
        /// </summary>
		public string Media { get; set; }

        /// <summary>
        /// The average rating as rated by the users on TheGamesDB.net.
        /// </summary>
		public float Rating { get; set; }

        /// <summary>
        /// A PlatformImages-object containing all the images for the platform.
        /// </summary>
		public PlatformImages Images { get; set; }

        /// <summary>
        /// Creates a new Platform without any content.
        /// </summary>
        public Platform() {
            Images = new PlatformImages();
        }

        /// <summary>
        /// Represents the images for one platform in the database.
        /// </summary>
        public class PlatformImages {
            /// <summary>
            /// Path to the image of the console.
            /// </summary>
			public string ConsoleArt { get; set; }

            /// <summary>
            /// Path to the image of the controller.
            /// </summary>
			public string ControllerArt { get; set; }

            /// <summary>
            /// Boxart for the platform
            /// </summary>
			public PlatformImage Boxart { get; set; }

            /// <summary>
            /// A list of all the fanart for the platform that have been uploaded to the database.
            /// </summary>
			public List<PlatformImage> Fanart { get; set; }

            /// <summary>
            /// A list of all the banners for the platform that have been uploaded to the database.
            /// </summary>
			public List<PlatformImage> Banners { get; set; }

            /// <summary>
            /// Creates a new PlatformImages without any content.
            /// </summary>
            public PlatformImages() {
                Fanart = new List<PlatformImage>();
                Banners = new List<PlatformImage>();
            }

            /// <summary>
            /// Adds all the images that can be found in the XmlNode
            /// </summary>
            /// <param name="node">the XmlNode to search through</param>
            public void FromXmlNode(XmlNode node) {
                IEnumerator ienumImages = node.GetEnumerator();
                while (ienumImages.MoveNext()) {
                    XmlNode imageNode = (XmlNode)ienumImages.Current;

                    switch (imageNode.Name) {
                        case "fanart":
                            Fanart.Add(new PlatformImage(imageNode.FirstChild));
                            break;
                        case "banner":
                            Banners.Add(new PlatformImage(imageNode));
                            break;
                        case "boxart":
                            Boxart = new PlatformImage(imageNode);
                            break;
                        case "consoleart":
                            ConsoleArt = imageNode.InnerText;
                            break;
                        case "controllerart":
                            ControllerArt = imageNode.InnerText;
                            break;
                    }
                }
            }

            /// <summary>
            /// Represents one image
            /// </summary>
            public class PlatformImage {
	            private int width;

	            private int height;

	            /// <summary>
	            /// The width of the image in pixels.
	            /// </summary>
	            public int Width
	            {
		            get
		            {
			            return this.width;
		            }
		            set
		            {
			            this.width = value;
		            }
	            }

	            /// <summary>
	            /// The height of the image in pixels.
	            /// </summary>
	            public int Height
	            {
		            get
		            {
			            return this.height;
		            }
		            set
		            {
			            this.height = value;
		            }
	            }

	            /// <summary>
	            /// The relative path to the image.
	            /// </summary>
	            /// <seealso cref="GamesDB.BaseImgURL"/>
	            public string Path { get; set; }

                /// <summary>
                /// Creates an image from an XmlNode.
                /// </summary>
                /// <param name="node">XmlNode to get data from</param>
                public PlatformImage(XmlNode node) {
                    Path = node.InnerText;

                    int.TryParse(node.Attributes.GetNamedItem("width").InnerText, out width);
                    int.TryParse(node.Attributes.GetNamedItem("height").InnerText, out height);
                }

	            public PlatformImage(string path)
	            {
		            Path = path;
	            }
            }
        }
    }
}
