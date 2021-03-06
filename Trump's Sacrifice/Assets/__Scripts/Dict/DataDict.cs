﻿using UnityEngine;
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
    public List<string> trumpisms;

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

        ConfigureTrumpisms();

    }

    public void ConfigureTrumpisms() {
        trumpisms = new List<string>();

        //I know I know lazy
        trumpisms.Add("THREATEN VIOLENCE AGAINST PROTESTERS");
        trumpisms.Add("BAN MUSLIMS FROM ENTERING US");
        trumpisms.Add("CALL MEXICAN IMMIGRANTS RAPISTS");
        trumpisms.Add("ATTACK JUDGE OVER HIS RACE");
        trumpisms.Add("ASK RUSSIA TO HACK USA");
        trumpisms.Add("ATTACK FAMILIES OF VETERANS");
        trumpisms.Add("ALTER LIBEL LAWS TO PROTECT SELF");
        trumpisms.Add("RESTRICT PRESS ACCESS TO EVENTS");
        trumpisms.Add("PEDDLE CONSPIRACY THEORIES");
        trumpisms.Add("STROKE BIGOTRY FOR VOTES");
        trumpisms.Add("DEMEAN AND DEVALUE WOMEN");
        trumpisms.Add("ELUDE TO SECOND AMENDMENT SOLUTIONS");
        trumpisms.Add("CLAIM ELECTION IS RIGGED");
		trumpisms.Add("USE ELECTION TO MARKET OWN BRAND");
    }


}
