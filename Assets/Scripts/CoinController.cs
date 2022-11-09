using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Character"))
        {
            other.GetComponent<CharacterProperties>().Coins += 1;
            Destroy(gameObject);
        }
    }
}
