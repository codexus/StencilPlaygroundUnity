using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}
