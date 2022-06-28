using Newtonsoft.Json;

namespace Captura.Imgur
{
    class ImgurData
    {
        [JsonProperty("id")]
        public string Id { get; set; } = default!;

        [JsonProperty("title")]
        public string Title { get; set; } = default!;

        [JsonProperty("description")]
        public string Description { get; set; } = default!;

        [JsonProperty("datetime")]
        public int DateTime { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; } = default!;

        [JsonProperty("animated")]
        public bool Animated { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("views")]
        public int Views { get; set; }

        [JsonProperty("deletehash")]
        public string DeleteHash { get; set; } = default!;

        [JsonProperty("name")]
        public string Name { get; set; } = default!;

        [JsonProperty("link")]
        public string Link { get; set; } = default!;

        [JsonProperty("favorite")]
        public bool Favorite { get; set; }
    }
}
