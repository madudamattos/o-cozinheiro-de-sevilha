using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToPosition : MonoBehaviour
{
    [SerializeField] private Transform target;

    // Chame este método para mover o objeto para a posição e rotação do alvo
    public void SnapToTarget()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.isKinematic = false;

        if (target != null)
        {
            transform.position = target.position;
            transform.rotation = target.rotation;
        }
    }
}
