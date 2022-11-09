using UnityEngine;

public class LimitMass : MonoBehaviour
{
    [SerializeField] private int _limitMass;

    private CharacterProperties _properties;

    void Start()
    {
        // _properties = GameObject.FindGameObjectWithTag("Character").GetComponent<CharacterProperties>();
    }

    /*
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Character"))
        {
            if (other.gameObject.GetComponent<CharacterProperties>().Mass >= _limitMass)
            {
                other.GetComponent<CharacterProperties>().IsEat = false;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Character"))
        {
            if (other.gameObject.GetComponent<CharacterProperties>().Mass >= _limitMass)
            {
                other.GetComponent<CharacterProperties>().IsEat = false;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Character"))
        {
            other.GetComponent<CharacterProperties>().IsEat = true;
        }
    }
    */
}
