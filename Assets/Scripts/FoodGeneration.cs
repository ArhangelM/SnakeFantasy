using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneration : MonoBehaviour
{
    [SerializeField] private GameObject _foodPrefab;
    [SerializeField] private GameObject _fantomFoodPrefab;

    private GameObject _currentFood;
    private Vector3 _currentPosFood;
    
    private List<GameObject> _foods = new List<GameObject>();
    
    private void RandomPos()
    { 
        _currentPosFood = new Vector3(Random.Range(-4f, 2f), Random.Range(-4f, 4f), -2); // fix
    }

    IEnumerator AddNewFood()
    {
        for (; ; )
        {
            if (_foods.Count < 50)
            {
                bool generate = false;
                while (!generate)
                {
                    RandomPos();
                    _currentFood = GameObject.Instantiate(_fantomFoodPrefab, _currentPosFood, Quaternion.identity);
                    var foodCollider2D = _currentFood.GetComponent<Collider2D>();
                    ContactFilter2D filter = new ContactFilter2D().NoFilter();
                    List<Collider2D> results = new List<Collider2D>();
                    generate = !(foodCollider2D.OverlapCollider(filter, results) > 0);
                    Destroy(_currentFood);
                }
                
                _currentFood = GameObject.Instantiate(_foodPrefab, _currentPosFood, Quaternion.identity);
                _foods.Add(_currentFood);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    void Start()
    {
        StartCoroutine("AddNewFood");
    }
    
    public void EatFood(GameObject food)
    {
        _foods.Remove(food);
    }
}
