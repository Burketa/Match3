using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] piecePrefabs;
    public GameObject holders, holderPrefab;

    public bool enableDrag;

    private void Start()
    {
        GeneratePool(); //Gera as peças possiveis
        ShuffleChildren(); //Embaralha as peças
        GrabPiece(); //Coloca a primeira peça no lugar
    }

    void Update ()
    {
        if (holders.transform.childCount == 0)
            SpawnHolder();
    }

    public void SpawnHolder()
    {
        Instantiate(holderPrefab, holders.transform);
        GenerateNewPieces();
    }

    public void SpawnPiece(int type)
    {
        Lean.Pool.LeanPool.Spawn(piecePrefabs[type]);
    }
    
    public void GeneratePool()
    {
        //Itera sobre cada child do spawner, que são onde devem ficar as peças spawnadas e
        //cria 3 peças para cada holder, uma peça de cada tipo.
        foreach(Transform holder in holders.transform)
        {
            for (int i = 0; i < 3; i++)
            {
                var newPiece = Lean.Pool.LeanPool.Spawn(piecePrefabs[i], new Vector2(0, 10), Quaternion.identity);
                newPiece.transform.SetParent(transform);
                newPiece.transform.localScale = piecePrefabs[i].transform.localScale;
            }
        }
    }

    public void ShuffleChildren()
    {
        List<int> intList = new List<int>();
        for(int i = 0; i < transform.childCount; i++)
            intList.Add(i);
        foreach (Transform child in transform)
        {
            int index = 0;
            index = Random.Range(0, intList.Count);
            child.SetSiblingIndex(intList.IndexOf(index));
            intList.RemoveAt(index);
         }
    }

    public void GrabPiece()
    {
        if(transform.childCount > 0)
            transform.GetChild(0).transform.position = transform.position;
    }

    public void GenerateNewPieces()
    {
        for (int i = 0; i < 3; i++)
        {
            var newPiece = Lean.Pool.LeanPool.Spawn(piecePrefabs[i], new Vector2(0, 10), Quaternion.identity);
            newPiece.transform.SetParent(transform);
            newPiece.transform.localScale = piecePrefabs[i].transform.localScale;
        }
        GrabPiece();
    }

    private void OnMouseDown()
    {
        enableDrag = true;
    }

    private void OnMouseDrag()
    {
        if (enableDrag)
        {
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            curPosition.z = 0;
            transform.GetChild(0).position = curPosition;
        }
    }

    private void OnMouseUp()
    {
        enableDrag = false;
        if(transform.childCount > 0)
            transform.GetChild(0).GetComponent<Piece>().Reset();
    }

}
