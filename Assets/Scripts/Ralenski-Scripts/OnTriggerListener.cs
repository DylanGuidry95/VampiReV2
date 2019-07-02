using Assets.Scripts.Brett;
namespace Ralenski { 
public class OnTriggerListener : GameEventListener
{
    // Use this for initialization
    private void OnEnable()
    {
        Event.Subscribe(this);
    }
    private void OnDisable()
    {
        Event.UnSubscribe(this);
    }
}
}