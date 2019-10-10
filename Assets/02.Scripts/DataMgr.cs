using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using DataInfo;

public class DataMgr : MonoBehaviour
{
    public static DataMgr instance = null;
    public string dataPath;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
            dataPath = Application.persistentDataPath + "/gameInfo.dat";
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public void SaveData(DataInfo.GameData gameData)
    {
        try
        {
            //2진 파일 포맷터를 생성
            BinaryFormatter bf = new BinaryFormatter();
            //파일 생성
            FileStream file = File.Create(dataPath);

            //파일에 데이터를 기록
            GameData data = new GameData();
            data.playerName = gameData.playerName;
            data.hp         = gameData.hp;
            data.level      = gameData.level;
            data.equipItems = gameData.equipItems;

            bf.Serialize(file, data);
            file.Close();
        }
        catch(Exception e)
        {
            Debug.Log("Error " + e.Message.ToString());
        }
    }

    public GameData LoadData()
    {
        if (File.Exists(dataPath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(dataPath, FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file);
            file.Close();
            return data;
        }
        else
        {
            return null;
        }
    }

}
