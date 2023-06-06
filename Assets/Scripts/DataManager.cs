using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public string playername;
    public float highscore;
    
    public MenuManager menuManager;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Trying to destroy myself");
            return;
        }
        Debug.Log("Not destroying myself");
        menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    [System.Serializable]
    class Data
    {
        public string name;
        public float score;
    }

    public void SaveData()
    {
        Data data = new Data();
        data.name = playername;
        data.score = highscore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);
            playername = data.name;
            highscore = data.score;
        }
    }
}
