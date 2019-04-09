using UnityEngine;
namespace Ralenski
{
    public class TriggerSoundDetection : MonoBehaviour
    {
        public GameObject Guard;
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Throwable"))
            {
                Debug.Log("Sound detected");
            }
        }
        // Use this for initialization
        void Start()
        {

        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}