using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float destroyTime = 1f;
    public Vector3 offset = new Vector3(0f, 2f, 0f);

    void Start()
    {
        Destroy(gameObject, destroyTime);
        
        transform.localPosition += offset;
    }
}
