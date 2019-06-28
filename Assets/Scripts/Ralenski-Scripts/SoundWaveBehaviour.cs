using UnityEngine;

public class SoundWaveBehaviour : MonoBehaviour
{
    public float particleLifetime = 2.0f;
    public GameObject prefab;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Ground"))
        {
            var go = Instantiate(prefab, transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(go, particleLifetime);
        }
    } 
}
