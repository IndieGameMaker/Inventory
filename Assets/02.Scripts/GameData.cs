using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataInfo
{
    [Serializable]
    public class GameData
    {
        public string playerName = "";
        public int level = 1;
        public float hp = 100.0f;
        public List<ItemInfo> equipItems = new List<ItemInfo>();
    }

    [Serializable]
    public class ItemInfo
    {
        public string name;
        public string desc;
        public float damage;
    }
}
