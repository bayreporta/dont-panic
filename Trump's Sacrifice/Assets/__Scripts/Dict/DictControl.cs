using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class DictControl : MonoBehaviour {
    public static DictControl S;

    //VARIABLES______________________________________________

    void Awake() { S = this; }

    //REUSABLE JSON PARSER______________________________________________
    public JsonData RetreiveJSON(TextAsset j) {
        JsonData data;
        data = JsonMapper.ToObject(j.text);
        return data;
    }

    public void InitializeDictionaries() {
        DataDict.S.ParseData();
    }


}
