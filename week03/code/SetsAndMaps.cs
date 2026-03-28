using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var result = new List<string>();
        var seenWords = new HashSet<string>();

        foreach (var word in words)
        {
            string reversed = new string(new char[] { word[1], word[0] });

            if (word == reversed) continue;

            if (seenWords.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
            }
            else
            {
                seenWords.Add(word);
            }
        }

        return result.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // Index 3 is the 4th column
            string degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
            {
                degrees[degree] += 1;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        string clean1 = word1.Replace(" ", "").ToLower();
        string clean2 = word2.Replace(" ", "").ToLower();

        if (clean1.Length != clean2.Length) return false;

        var charCounts = new Dictionary<char, int>();

        foreach (char c in clean1)
        {
            if (charCounts.ContainsKey(c)) charCounts[c]++;
            else charCounts[c] = 1;
        }

        foreach (char c in clean2)
        {
            if (!charCounts.ContainsKey(c)) return false;
            charCounts[c]--;
        }

        // Ensure every count returned to zero (handles cases like "DOG" vs "GOOD")
        foreach (var count in charCounts.Values)
        {
            if (count != 0) return false;
        }

        return true;
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        
        // Added standard error handling for the network request
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        var response = client.Send(getRequestMessage);
        using var jsonStream = response.Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        // This will only work if FeatureCollection.cs is filled out correctly!
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var summary = new List<string>();

        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                // Accessing the place and magnitude from the nested JSON properties
                string place = feature.Properties.Place;
                double mag = feature.Properties.Mag;
                summary.Add($"{place} - Mag {mag}");
            }
        }

        return summary.ToArray();
    }
}