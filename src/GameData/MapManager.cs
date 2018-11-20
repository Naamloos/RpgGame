using RpgGame.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RpgGame.GameData
{
    public class MapManager
    {
        List<Map> Maps;

        public MapManager()
        {
            Maps = new List<Map>();
        }

        public void LoadMaps()
        {

        }
    }

    public class Map
    {
        [JsonProperty("mapid")]
        public string MapId;

        [JsonProperty("width")]
        public int Width;

        [JsonProperty("height")]
        public int Height;

        [JsonProperty("tilewidth")]
        public int TileWidth;

        [JsonProperty("tileheight")]
        public int TileHeight;

        [JsonProperty("maptiles")]
        public List<MapTile> MapTiles;

        [JsonProperty("mapcolissions")]
        public List<MapColission> MapColissions;

        [JsonProperty("mapevents")]
        public List<MapEvent> MapEvents;
    }

    public class MapTile
    {
        [JsonProperty("x")]
        public int X;

        [JsonProperty("y")]
        public int Y;

        [JsonProperty("tileid")]
        public string TileId;
    }

    public class MapColission
    {
        [JsonProperty("x")]
        public int X;

        [JsonProperty("x")]
        public int Y;

        [JsonProperty("colission")]
        public ColissionLevel Colission;
    }

    public class MapEvent
    {
        [JsonProperty("x")]
        public int X;

        [JsonProperty("y")]
        public int Y;

        [JsonProperty("eventid")]
        public string EventId;
    }

    public enum ColissionLevel
    {
        Pass,
        NoPass,
        Event
    }
}
