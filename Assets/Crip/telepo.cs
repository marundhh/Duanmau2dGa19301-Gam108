using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telepo : MonoBehaviour
{
    [SerializeField] private Transform detination;
    public Transform GetDestination()
    {
        return detination;
    }
}
