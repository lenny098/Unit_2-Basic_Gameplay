using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ScoreManager.Instance.DecreaseLives();
    }
}
