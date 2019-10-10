using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataInfo;

public class UIMgr : MonoBehaviour
{
    public InputField playerName;
    public InputField level;
    public InputField hp;
    public Text itemText;


    public void OnSaveClick()
    {
        //게임데이터를 저장하기 위한 클래스 생성
        GameData gameData = new GameData();
        gameData.playerName = "Zackiller";
        gameData.level      = 70;
        gameData.hp         = 1000.0f;

        //아이템 생성
        for (int i=0; i<5; i++)
        {
            DataInfo.ItemInfo item = new ItemInfo();
            item.name = "Item " + i.ToString("00");
            item.desc = string.Format("Increase {0}% health up", (i+1)*10.0f);
            item.damage = (i+1)*10.0f;

            gameData.equipItems.Add(item);
        }

        DataMgr.instance.SaveData(gameData);
    }
}
