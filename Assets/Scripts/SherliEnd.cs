using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SherliEnd : MonoBehaviour
{
    [SerializeField] private InputOff inputOff;

    public void End()
    {
        inputOff.ReduceInput();
    }
}
