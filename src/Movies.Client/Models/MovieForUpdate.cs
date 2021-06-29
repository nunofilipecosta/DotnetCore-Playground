using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Movies.Client.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class MovieForUpdate
    {
        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Genre
        /// </summary>
        [DataMember(Name = "genre", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "genre")]
        public string Genre { get; set; }

        /// <summary>
        /// Gets or Sets ReleaseDate
        /// </summary>
        [DataMember(Name = "releaseDate", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "releaseDate")]
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or Sets DirectorId
        /// </summary>
        [DataMember(Name = "directorId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "directorId")]
        public Guid? DirectorId { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MovieForUpdate {\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Genre: ").Append(Genre).Append("\n");
            sb.Append("  ReleaseDate: ").Append(ReleaseDate).Append("\n");
            sb.Append("  DirectorId: ").Append(DirectorId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}
