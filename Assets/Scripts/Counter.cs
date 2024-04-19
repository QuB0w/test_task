using Structs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private Text myText;
    public Text levelText;
    [HideInInspector]
    public int inStock;
    public int myNumber;
    public GameObject myImage;
    public Timer timer;

    public int level = 1;

    public AdManager adManager;

    [Header("Save Config")]
    [SerializeField] private string savePath;
    [SerializeField] private string saveFileName = "data.json";

    public void SaveToFile()
    {
        GameStruct gameCore = new GameStruct()
        {
            level = level
        };

        string json = JsonUtility.ToJson(gameCore);

        try
        {
            File.WriteAllText(savePath, json);
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public void LoadFromFile()
    {
        if (!File.Exists(savePath))
        {
            Debug.Log("File not found!");
            return;
        }

        try
        {
            string json = File.ReadAllText(savePath);

            GameStruct gameCoreFromJson = JsonUtility.FromJson<GameStruct>(json);
            level = gameCoreFromJson.level;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        savePath = Path.Combine(Application.persistentDataPath, saveFileName);
#else
        savePath = Path.Combine(Application.dataPath, saveFileName);
#endif
        LoadFromFile();
    }

    private void OnApplicationPause(bool pause)
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            SaveToFile();
        }
    }

    private void OnApplicationQuit()
    {
        SaveToFile();
    }


    void Start()
    {
        myText = GetComponent<Text>();
    }

    
    void Update()
    {
        levelText.text = "Level: " + level.ToString();
        myText.text = inStock.ToString() + "/" + myNumber;
        if(inStock == myNumber)
        {
            myImage.SetActive(true);
            var obj = myImage.transform.GetChild(0);
            obj.GetComponent<Text>().enabled = true;
            obj.GetComponent<Text>().color = Color.green;
            obj.GetComponent<Text>().text = "You win";
            timer.enabled = false;
        }

        if (inStock != myNumber && timer.gameTime <= 0)
        {
            myImage.SetActive(true);
            var obj = myImage.transform.GetChild(0);
            obj.GetComponent<Text>().enabled = true;
            obj.GetComponent<Text>().color = Color.red;
            obj.GetComponent<Text>().text = "You lose";
            timer.enabled = false;
        }
    }

    public void OnClickRestart()
    {
        level++;
        SaveToFile();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        adManager.ShowInterAds();
    }
}
