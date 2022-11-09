using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private int _mass;
    
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_mass < other.gameObject.GetComponent<CharacterProperties>().Mass)
        {
             Destroy(gameObject.GetComponent<Collider2D>());
            _animator.SetBool("isBreak", true);
        }
        else if (other.gameObject.CompareTag("Character"))
        {
            _animator.SetBool("isTouch", true);
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            _animator.SetBool("isTouch", false);
        }
    }

    public void Destroy()
    {
        Destroy(_animator.GetComponentInParent<Transform>().root.gameObject.GetComponentInParent<Transform>().root.gameObject);
    }
}
