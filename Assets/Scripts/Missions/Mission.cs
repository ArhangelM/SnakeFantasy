using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mission : MonoBehaviour
{
    private GameObject _textObject;

    private string _missionData;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void InitMission(string missionData)
    {
        _textObject = gameObject.transform.Find("MissionData").gameObject;
        _missionData = missionData;
        _textObject.GetComponent<TextMeshProUGUI>().SetText(_missionData);
    }

    public void MissionCompleted()
    {
        gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
    }
}
