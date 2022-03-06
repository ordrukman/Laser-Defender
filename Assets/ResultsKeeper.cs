using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsKeeper : MonoBehaviour
{
    List<string> allResults;
    static ResultsKeeper instance;

    void Awake() {
        ManageSingelton();
    }

    void ManageSingelton(){
        
        if(instance != null) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void addToList(string s) {
        allResults.Add(s);
        Debug.Log(s);
    }

    public string GetAllResults() {
        string all = "All Results: \n";
        foreach(string s in allResults) {
            all = all + s;
        }
        return all;
    }
}
