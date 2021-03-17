using System;
using System.Text.Json.Serialization;

namespace WebAPIClient
{
    public class Repository // ray: i'm curious why our filename and class name don't match. 
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("html_url")]
        public Uri GitHubHomeUrl { get; set; }

        [JsonPropertyName("homepage")]
        public Uri Homepage { get; set; }

        [JsonPropertyName("watchers")]
        public int Watchers { get; set; }

        [JsonPropertyName("pushed_at")]
        public DateTime LastPushUtc { get; set; }

        public DateTime LastPush => LastPushUtc.ToLocalTime();
       
    }
}


/* This version of the class represents the simplest path to process JSON data. 

*ding ding* The class name and the member name match the names used in the JSON packet, 
instead of following C# conventions. 

You'll fix that by providing some configuration attributes later. 

This class demonstrates another important feature of JSON serialization and deserialization: 
Not all the fields in the JSON packet are part of this class. *WOAH*

The JSON serializer will ignore information that is not included in the class type being used. 

This feature makes it easier to create types that work with only
a subset of the fields in the JSON packet. */

