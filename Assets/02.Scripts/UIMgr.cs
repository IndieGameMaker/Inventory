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
        gameData.playerName = playerName.text;
        gameData.level      = int.Parse(level.text);
        gameData.hp         = float.Parse(hp.text);

        //아이템 생성
        for (int i=0; i<5; i++)
        {
            DataInfo.ItemInfo item = new ItemInfo();
            item.name = "Item " + i.ToString("00");
            item.desc = string.Format("Increase {0}% health up", (i+1)*Random.Range(10,30));
            item.damage = (i+1)*Random.Range(10,30);

            gameData.equipItems.Add(item);
        }

        DataMgr.instance.SaveData(gameData);

        playerName.text = "";
        level.text      = "";
        hp.text         = "";
    }

    public void OnLoadClick()
    {
        GameData loadData = DataMgr.instance.LoadData();

        playerName.text = loadData.playerName;
        level.text      = loadData.level.ToString();
        hp.text         = loadData.hp.ToString();

        string itemStr = "";
        for(int i=0;i<loadData.equipItems.Count;i++)
        {
            itemStr += string.Format("{0}  {1}  {2}\n", loadData.equipItems[i].name
                                                      , loadData.equipItems[i].desc
                                                      , loadData.equipItems[i].damage);
        }
        itemText.text = itemStr;
    }
}
