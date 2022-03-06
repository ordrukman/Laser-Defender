using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsKeeper2 : MonoBehaviour
{
    List<string> allResults;
    static ResultsKeeper2 instance;

    void Awake() {
        ManageSingelton();
        allResults = new List<string>();
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
        if (allResults.Count < 1) {
            return "No Results Yet.";
        }
        return all;
    }
}
