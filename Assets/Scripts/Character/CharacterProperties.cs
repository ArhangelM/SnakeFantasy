using UnityEngine;

public class CharacterProperties : MonoBehaviour
{
    public int Mass { get; set; }
    public int Coins { get; set; }

    public bool IsEat { get; set; } = true;
    // Start is called before the first frame update
    void Start()
    {
        Mass = 50;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
