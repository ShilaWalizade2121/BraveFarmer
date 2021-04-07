using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class GameCtrl : MonoBehaviour
{
    public static GameCtrl Instance;
    public GameData data;
    BinaryFormatter bf;
    string dataFilePath;
    public UI ui;

    
    public int coinValue;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        bf = new BinaryFormatter();
        dataFilePath = Application.persistentDataPath + "/game.dot";
        print(dataFilePath);
        
    }

   public void PlayerDied(GameObject player)
    {
        player.SetActive(false);
        Invoke("RestartLevel",1f);
    }


    void RestartLevel()
    {
        SceneManager.LoadScene("Level_01");
    }

    public void Save()
    {
        FileStream fs = new FileStream(dataFilePath, FileMode.Create);
        bf.Serialize(fs, data);

        fs.Close();
    }
    void Load()
    {
        if (File.Exists(dataFilePath))
        {
            FileStream fs = new FileStream(dataFilePath, FileMode.Open);
            data = (GameData)bf.Deserialize(fs);
            ui.coinCountText.text = "X" + data.coinCount;
            ui.scoreCountText.text = "Score : " + data.scoreCount;

            fs.Close();
        }
    }


    void ResetAll()
    {
        FileStream fs = new FileStream(dataFilePath, FileMode.Create);
        data.coinCount = 0;
        data.scoreCount = 0;
        ui.coinCountText.text = "X0";
        ui.scoreCountText.text = "Score : 0" ;
        bf.Serialize(fs, data);
        fs.Close();
    }


    private void OnEnable()
    {
        Load();
    }
    private void OnDisable()
    {
        Save();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetAll();
        }
    }



    public void UpdateCoinCount()
    {
        data.coinCount++;
        ui.coinCountText.text = "X" + data.coinCount;
        UpdateScoreCount(coinValue);
    }

    public void UpdateScoreCount(int value)
    {
        data.scoreCount += value;
        ui.scoreCountText.text = "Score : " + data.scoreCount;
    }
}
