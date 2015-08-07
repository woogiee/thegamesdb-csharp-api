using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;

namespace TheGamesDBAPI
{
	/// <summary>
	/// Contains the data for one game in the database.
	/// </summary>
	public class Game
	{
		/// <summary>
		/// Unique database ID
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// Title of the game.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Which platform the game is for.
		/// </summary>
		public string Platform { get; set; }

		/// <summary>
		/// Which date the game was first released on.
		/// </summary>
		public string ReleaseDate { get; set; }

		/// <summary>
		/// A general description of the game.
		/// </summary>
		public string Overview { get; set; }

		/// <summary>
		/// ESRB rating for the game.
		/// </summary>
		public string ESRB { get; set; }

		/// <summary>
		/// How many players the game supports. "1","2","3" or "4+".
		/// </summary>
		public string Players { get; set; }

		/// <summary>
		/// Does this game support co-op play? 
		/// </summary>
		public string CoOp { get; set; }

		/// <summary>
		/// Youtube link to related content.
		/// </summary>
		public string Youtube { get; set; }

		/// <summary>
		/// The publisher(s) of the game.
		/// </summary>
		public string Publisher { get; set; }

		/// <summary>
		/// The developer(s) of the game.
		/// </summary>
		public string Developer { get; set; }

		/// <summary>
		/// The overall rating of the game as rated by users on TheGamesDB.net.
		/// </summary>
		public string Rating { get; set; }

		/// <summary>
		/// A list of all the alternative titles of the game.
		/// </summary>
		public List<string> AlternateTitles { get; set; }

		/// <summary>
		/// A list of all the game's genres.
		/// </summary>
		public List<string> Genres { get; set; }

		/// <summary>
		/// A GameImages-object containing all the images for the game.
		/// </summary>
		public GameImages Images { get; set; }

		/// <summary>
		/// A list of similar titles.
		/// </summary>
		public List<SimilarTitle> SimilarTitles { get; set; }

		/// <summary>
		/// Creates a new Game without any content.
		/// </summary>
		public Game()
		{
			AlternateTitles = new List<string>();
			Genres = new List<string>();
			Images = new GameImages();
			SimilarTitles = new List<SimilarTitle>();
		}

		/// <summary>
		/// Represents the images for one game in the database.
		/// </summary>
		public class GameImages
		{
			/// <summary>
			/// The art on the back of the box.
			/// </summary>
			public GameImage BoxartBack { get; set; }

			/// <summary>
			/// The art on the front of the box.
			/// </summary>
			public GameImage BoxartFront { get; set; }

			/// <summary>
			/// The clear logo art.
			/// </summary>
			public GameImage ClearLogo { get; set; }

			/// <summary>
			/// A list of all the fanart for the game that have been uploaded to the database.
			/// </summary>
			public List<GameImage> Fanart { get; set; }

			/// <summary>
			/// A list of all the banners for the game that have been uploaded to the database.
			/// </summary>
			public List<GameImage> Banners { get; set; }

			/// <summary>
			/// A list of all the screenshots for the game that have been uploaded to the database.
			/// </summary>
			public List<GameImage> Screenshots { get; set; }

			/// <summary>
			/// Creates a new GameImages without any content.
			/// </summary>
			public GameImages()
			{
				Fanart = new List<GameImage>();
				Banners = new List<GameImage>();
				Screenshots = new List<GameImage>();
			}

			/// <summary>
			/// Adds all the images that can be found in the XmlNode
			/// </summary>
			/// <param name="node">the XmlNode to search through</param>
			public void FromXmlNode(XmlNode node)
			{
				IEnumerator ienumImages = node.GetEnumerator();
				while (ienumImages.MoveNext())
				{
					XmlNode imageNode = (XmlNode)ienumImages.Current;

					switch (imageNode.Name)
					{
						case "fanart":
							Fanart.Add(new GameImage(imageNode.FirstChild));
							break;
						case "banner":
							Banners.Add(new GameImage(imageNode));
							break;
						case "clearlogo":
							ClearLogo = new GameImage(imageNode);
							break;
						case "screenshot":
							Screenshots.Add(new GameImage(imageNode.FirstChild));
							break;
						case "boxart":
							if (imageNode.Attributes.GetNamedItem("side").InnerText == "front")
							{
								BoxartFront = new GameImage(imageNode);
							}
							else
							{
								BoxartBack = new GameImage(imageNode);
							}

							break;
					}
				}
			}

			/// <summary>
			/// Represents one image
			/// </summary>
			public class GameImage
			{
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
				public GameImage(XmlNode node)
				{
					Path = node.InnerText;

					int.TryParse(node.Attributes.GetNamedItem("width").InnerText, out width);
					int.TryParse(node.Attributes.GetNamedItem("height").InnerText, out height);
				}
			}
		}

		/// <summary>
		/// Similar title container.
		/// </summary>
		public class SimilarTitle
		{
			/// <summary>
			/// The gameid.
			/// </summary>
			public int GameId { get; set; }

			/// <summary>
			/// The platformId.
			/// </summary>
			public int PlatformId { get; set; }

			/// <summary>
			/// converts xmlnode into GameSimilar object.
			/// </summary>
			/// <param name="node"></param>
			public SimilarTitle(XmlNode node)
			{
				IEnumerator ienumImages = node.GetEnumerator();
				while (ienumImages.MoveNext())
				{
					XmlNode similarNode = (XmlNode)ienumImages.Current;

					switch (similarNode.Name)
					{
						case "id":
							int gameId;
							if (int.TryParse(similarNode.InnerText, out gameId))
							{
								GameId = gameId;
							}
							break;
						case "PlatformId":
							int platformId;
							if (int.TryParse(similarNode.InnerText, out platformId))
							{
								PlatformId = platformId;
							}
							break;
					}
				}
			}

		}
	}
}
