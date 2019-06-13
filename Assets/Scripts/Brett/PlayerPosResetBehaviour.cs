using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosResetBehaviour : MonoBehaviour {

    public void ResetPlayerPosition()
    {
        transform.position = new Vector3(0, 0, 0);
    }
}
