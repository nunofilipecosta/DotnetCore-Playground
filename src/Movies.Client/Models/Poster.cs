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
    public class Poster
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets MovieId
        /// </summary>
        [DataMember(Name = "movieId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "movieId")]
        public Guid? MovieId { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Bytes
        /// </summary>
        [DataMember(Name = "bytes", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "bytes")]
        public byte[] Bytes { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Poster {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  MovieId: ").Append(MovieId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Bytes: ").Append(Bytes).Append("\n");
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
