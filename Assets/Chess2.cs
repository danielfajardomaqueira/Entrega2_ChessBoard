using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess2 : MonoBehaviour
{
    public GameObject piecePrefab;
    private int gridSize = 8;
    public float timer = 0.2f;
    private int piecesGenerated = 0;
    private int maxPieces = 64;
    private List<Vector2> occupiedPositions = new List<Vector2>();

    void Start()
    {
        StartCoroutine(GeneratePieces());
    }

    void Update()
    {

    }

    IEnumerator GeneratePieces()
    {
        while (piecesGenerated < maxPieces)
        {
            int width, height;
            Vector2 position;

            do
            {
                width = Random.Range(0, gridSize);
                height = Random.Range(0, gridSize);
                position = new Vector2(width, height);
            } while (occupiedPositions.Contains(position)); //.Contains se utiliza para saber si la pieza de ajedrez generada aleatoriamente se encuentra en alguna posición ya ocupada.

            occupiedPositions.Add(position);// registra la posicion de una pieza ya generada en la lista.

            float xoffset = width - gridSize / 2.0f + 0.5f;
            float yoffset = height - gridSize / 2.0f + 0.5f;
            Vector3 spawnPosition = new Vector3(xoffset, yoffset, 0);

            Instantiate(piecePrefab, spawnPosition, Quaternion.identity);//Quaternion.identity se utiliza para cancelar cualquier tipo de rotacion por si genera problemas.

            piecesGenerated++;

            yield return new WaitForSeconds(timer);
        }
    }



}
