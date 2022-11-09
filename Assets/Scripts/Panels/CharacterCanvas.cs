using System.Collections;
using TMPro;
using UnityEngine;

public class CharacterCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _character;
    [SerializeField] private GameObject _missionCanvas;
    [SerializeField] private GameObject _textObjectInfo;
    [SerializeField] private GameObject _textObjectCoinsInfo;

    private CharacterProperties _properties;

    void Start()
    {
        _properties = _character.GetComponent<CharacterProperties>();
        StartCoroutine("UpdateInfo");
    }

    private IEnumerator UpdateInfo()
    {
        for (;;)
        {
            _textObjectInfo.GetComponent<TextMeshProUGUI>().SetText(_properties.Mass.ToString());
            _textObjectCoinsInfo.GetComponent<TextMeshProUGUI>().SetText(_properties.Coins.ToString());
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void ShowMissionInfoHandler()
    {
        _missionCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
}
