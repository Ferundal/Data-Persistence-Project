using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameOptions : MonoBehaviour
{
    private const string scoreFileName = "score_file.json";
    private static GameOptions instance;
    // Start is called before the first frame update
    public class MaxScore
    {
        public string nick;
        public int score;
    }

    public string currentNick;
    public MaxScore maxScore;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        LoadMaxScore();
    }

    void LoadMaxScore()
    {
        string path = Application.persistentDataPath + "/" + scoreFileName;
        maxScore = new MaxScore();
        if (File.Exists(path))
        {
            Debug.Log("Loading file");
            string scoreInJsonString = File.ReadAllText(path);
            maxScore = JsonUtility.FromJson<MaxScore>(scoreInJsonString);
        } else
        {
            Debug.Log("NewFile");
        }
    }

    public void SaveMaxScore()
    {
        string path = Application.persistentDataPath + "/" + scoreFileName;
        string scoreInJsonString = JsonUtility.ToJson(maxScore);
        File.WriteAllText(path, scoreInJsonString);
    }

    public static GameOptions Instance()
    {
        return instance;
    }

    public bool AddNewScore(string nick, int score)
    {
        if (score > maxScore.score)
        {
            Debug.Log(this.maxScore.nick + " " + this.maxScore.score);
            maxScore.nick = nick;
            maxScore.score = score;
            Debug.Log(this.maxScore.nick + " " + this.maxScore.score);
            return true;
        }
        return false;
    }
}
