using UnityEngine;

public class Food : MonoBehaviour
{
    private FoodGeneration _foodGeneration;
    void Start()
    {
        _foodGeneration = GameObject.FindGameObjectWithTag("Spawner").GetComponent<FoodGeneration>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Character"))
        {
            if (other.GetComponent<CharacterProperties>().IsEat)
            {
                other.GetComponent<CharacterProperties>().Mass += 1;
                _foodGeneration.EatFood(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
