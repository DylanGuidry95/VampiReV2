using Assets.Scripts.Brett;
using UnityEngine;
namespace Ralenski
{
    [RequireComponent(typeof(Collider))]
public class OnTriggerEventSystem : MonoBehaviour
{
    public string playerTag;
    public GameEvent playerTriggerEnter;
    public GameEvent playerTriggerExit;
    public GameEvent playerTriggerStay;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag)==true)
        {
            playerTriggerEnter.Raise();
            Debug.Log("Trigger Beginning.");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag)==true)
        {
            playerTriggerExit.Raise();
            Debug.Log("Trigger Stop.");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(playerTag)== true)
        {
            playerTriggerStay.Raise();
            Debug.Log("Trigger Stay.");
        }
    }
    
}
}