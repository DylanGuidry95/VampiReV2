using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStaticReferenceBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObjectVariable Variable;

    private void Start()
    {
        Variable.Value = gameObject;
    }
}
