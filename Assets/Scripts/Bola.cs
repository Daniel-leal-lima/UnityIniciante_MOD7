using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    ControladorGame controlador;
    private void Start()
    {
        controlador = GameObject.FindObjectOfType<ControladorGame>();
    }
    void Update()
    {
        if (this.transform.position.y < controlador.minY)
        {
            controlador.PerdeBola(this);
        }
    }
    public void AtivaFisica()
    {
        if(TryGetComponent(out Rigidbody rb))
        {
            rb.useGravity = true;
        }
    }
}
