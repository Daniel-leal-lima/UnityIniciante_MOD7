using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptMouse : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] Text score;
    [SerializeField] ControladorGame controlador;

    bool _input;
    int _points;

    private void Start()
    {
        score.text = "Score: " + _points.ToString();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _input = true;
        }
    }
    private void FixedUpdate()
    {
        if (_input)
        {
            Ray a = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Click
            RaycastHit hit;
            if (Physics.Raycast(a, out hit, Mathf.Infinity))
            {
                Rigidbody rb = hit.rigidbody;
                if (!rb.useGravity)
                {
                    rb.useGravity = true;
                }
                Pontuacao();
                rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            }
            _input = false;
        }
    }

    void Pontuacao()
    {
        _points++;
        score.text = "Score: " + _points.ToString();

        if (_points > 0 && _points % 10 == 0)
        {
            controlador.SpawnBola();
        }
    }

    public int GetPoints()
    {
        return _points;
    }
}
