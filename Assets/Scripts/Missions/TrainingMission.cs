using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TrainingMission : MonoBehaviour
{
    [SerializeField] private GameObject _missionObjectInfoCanvas;
    [SerializeField] private GameObject _missionPrefab;

    private CharacterMovement _character;
    private CharacterProperties _properties;
    private MissionCanvas _missionCanvas;
    private GameObject _door;
    
    private bool _firstTask = false;
    private bool _secondTask = false;
    private bool _thirdTask = false;
    private bool _fourthTask = false;
    private bool _fivethTask = false;

    private List<GameObject> _missions = new List<GameObject>();
    private string[] _tasks = new[]
    {
        "Рухайтесь ліворуч,  праворуч, вверх і вниз",
        "Маса персонажа має бути менше 5",
        "Маса персонажа має бути більше 30",
        "Розбийте двері",
        "Зберіть 4 монети. За них можна купити різні покращення",
        "Молодець! Тепер дійди до печери та закінчи навчальний рівень!"
    };

    private bool _moveLeft = false;
    private bool _moveRight = false;
    private bool _moveTop = false;
    private bool _moveDown = false;

    // Start is called before the first frame update
    void Start()
    {
        _character = GameObject.FindGameObjectWithTag("Character").GetComponent<CharacterMovement>();
        _properties = GameObject.FindGameObjectWithTag("Character").GetComponent<CharacterProperties>();
        _door = GameObject.FindGameObjectWithTag("Door");
        _missionCanvas = _missionObjectInfoCanvas.GetComponent<MissionCanvas>();
       
        InitMissions();
        StartCoroutine("CheckTasks");
    }

    private void InitMissions()
    {
        var panel = _missionCanvas.transform.GetChild(0).gameObject.transform.Find("PanelMissions");
        
        for (int i = 0; i < _tasks.Length; i++)
        {
            var mission = Instantiate(_missionPrefab, panel);
            _missions.Add(mission);
            mission.GetComponent<Mission>().InitMission(_tasks[i]);
        }
        _missionCanvas.ShowCanvas();
    }
    
    IEnumerator CheckTasks()
    {
        for (; ; )
        {
            if (!_firstTask)
            {
                CheckFirstTask();
            }
            if (!_secondTask)
            {
                CheckSecondTask();
            }
            if (!_thirdTask)
            {
                CheckThirdTask();
            }
            if (!_fourthTask)
            {
                CheckFourthTask();
            }
            if (!_fivethTask)
            {
                CheckFivethTask();
            }
            
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void CheckFirstTask()
    {
        if (!_moveLeft)
            _moveLeft = _character.Horizontal < 0;
        if (!_moveRight)
            _moveRight = _character.Horizontal > 0;
        if (!_moveDown)
            _moveDown = _character.Vertical < 0;
        if (!_moveTop)
            _moveTop = _character.Vertical > 0;

        if (_moveLeft && _moveRight && _moveDown && _moveTop)
        {
            _firstTask = true;
            _missions[0].GetComponent<Mission>().MissionCompleted();
        }
    }

    private void CheckSecondTask()
    {
        if (_properties.Mass < 5)
        {
            _secondTask = true;
            _missions[1].GetComponent<Mission>().MissionCompleted();
        }
    }
    
    private void CheckThirdTask()
    {
        if (_properties.Mass > 30)
        {
            _thirdTask = true;
            _missions[2].GetComponent<Mission>().MissionCompleted();
        }
    }
    
    private void CheckFourthTask()
    {
        if (_door == null)
        {
            _fourthTask = true;
            _missions[3].GetComponent<Mission>().MissionCompleted();
        }
    }
    
    private void CheckFivethTask()
    {
        if (_properties.Coins == 4)
        {
            _fivethTask = true;
            _missions[4].GetComponent<Mission>().MissionCompleted();
        }
    }
}
