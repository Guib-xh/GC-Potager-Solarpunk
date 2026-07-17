using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreEntry
{
    public int score;
    public string pseudo;
}

[System.Serializable]
public class ScoreList
{
    public List<ScoreEntry> entries = new List<ScoreEntry>();
}

public static class LeaderboardStorage
{
    
    private const int MaxEntries = 10;
    public static List<ScoreEntry> GetScores()
    {
        string json = PlayerPrefs.GetString("HighScores", "");
        if (string.IsNullOrEmpty(json)) return new List<ScoreEntry>();
        return JsonUtility.FromJson<ScoreList>(json).entries;
    }

    public static void SaveScore(int score, string pseudo)
    {
        List<ScoreEntry> scores = GetScores();
        scores.Add(new ScoreEntry { score = score, pseudo = pseudo });
        scores.Sort((a,b)=>a.score.CompareTo(b.score));

        if (scores.Count > MaxEntries)
        {
            scores = scores.GetRange(0, MaxEntries);
        }
        
        
        PlayerPrefs.SetString("HighScores", JsonUtility.ToJson(new ScoreList{entries = scores}));
        PlayerPrefs.Save();
    }
}
