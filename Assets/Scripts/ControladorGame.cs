using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorGame : MonoBehaviour
{
    [Tooltip("O quanto no Eixo Y a bola pode cair")]
    public int minY;
    public List<Bola> bolasEmCena;
    public GameObject gameOver;
    [SerializeField] GameObject bolaPrefab;
    [SerializeField] List<float> tracks;
    [Tooltip("Maior Posição no Eixo Y para Spawn das Bolas")]
    public float MaxY;

    public void PerdeBola(Bola obj)
    {
        bolasEmCena.Remove(obj);
        Destroy(obj.gameObject);

        if (bolasEmCena.Count.Equals(0))
        {
            gameOver.SetActive(true);
        }
    }

    public void SpawnBola()
    {
        Vector3 SpawnPos = new Vector3(tracks[Random.Range(0, tracks.Count)], MaxY);
        GameObject novaBola = Instantiate(bolaPrefab, SpawnPos,Quaternion.identity);
        if(novaBola.TryGetComponent(out Bola script))
        {
            bolasEmCena.Add(script);
            script.AtivaFisica();
        }

    }


    public void TentarNovamente()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
