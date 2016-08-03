using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class DataDefinition {
    public int id;
    public string title;
    public string flavor;
    public Object image;
    public bool sacrifice;
    public bool selfish;
}

public class DataDict : MonoBehaviour {
    public static DataDict S;
    void Awake() { S = this; }

    //VARIABLES_____________________________________
    public Dictionary<int, DataDefinition> DEFS;
    public TextAsset dataJSON;

    public DataDefinition GetDefinition(int i) {
        if (DEFS.ContainsKey(i)) {
            return DEFS[i];
        } else { return new DataDefinition(); }
    }

    public void ParseData() {
        DEFS = new Dictionary<int, DataDefinition>();
        JsonData data = DictControl.S.RetreiveJSON(dataJSON);

        //parse state data loop and build dictionary dynamically
        for (int i = 0; i < data[0].Count; i++) {
            DataDefinition d = new DataDefinition();                    
            d.id = int.Parse(data[0][i]["id"].ToString());
            d.title = data[0][i]["name"].ToString();
            d.flavor = data[0][i]["descript"].ToString();
            d.sacrifice = bool.Parse(data[0][i]["sacrifice"].ToString());
            d.selfish = bool.Parse(data[0][i]["selfishness"].ToString());
            
            DEFS.Add(i, d);
        }
    }
}
