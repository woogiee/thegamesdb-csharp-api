using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;

namespace TheGamesDBAPI {
    public class Game {
        public int ID;
        public String Title, Platform, ReleaseDate, Overview, ESRB, Players, Publisher, Developer;
        public String Rating;

        public List<String> AlternateTitles, Genres;
        public GameImages Images;

        public Game() {
            AlternateTitles = new List<String>();
            Genres = new List<String>();
            Images = new GameImages();
        }

        public class GameImages {
            public GameImage BoxartBack, BoxartFront;
            public List<GameImage> Fanart;
            public List<GameImage> Banners;
            public List<GameImage> Screenshots;

            public GameImages() {
                Fanart = new List<GameImage>();
                Banners = new List<GameImage>();
                Screenshots = new List<GameImage>();
            }

            public void FromXmlNode(XmlNode node) {
                IEnumerator ienumImages = node.GetEnumerator();
                while (ienumImages.MoveNext()) {
                    XmlNode imageNode = (XmlNode)ienumImages.Current;

                    switch (imageNode.Name) {
                        case "fanart":
                            Fanart.Add(new GameImage(imageNode.FirstChild));
                            break;
                        case "banner":
                            Banners.Add(new GameImage(imageNode));
                            break;
                        case "screenshot":
                            Screenshots.Add(new GameImage(imageNode.FirstChild));
                            break;
                        case "boxart":
                            if (imageNode.Attributes.GetNamedItem("side").InnerText == "front") {
                                BoxartFront = new GameImage(imageNode);
                            }
                            else {
                                BoxartBack = new GameImage(imageNode);
                            }

                            break;
                    }
                }
            }

            public class GameImage {
                public int Width, Height;
                public String Path;

                public GameImage(XmlNode node) {
                    Path = node.InnerText;

                    int.TryParse(node.Attributes.GetNamedItem("width").InnerText, out Width);
                    int.TryParse(node.Attributes.GetNamedItem("height").InnerText, out Height);
                }
            }
        }
    }
}
