using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    public float translateSpeed = 1, rotateSpeed = 1;

    private List<int> types = new List<int>();
    private void Start()
    {
        if (Random.value < 0.7f)
            rotateSpeed = -rotateSpeed;
    }
    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, -translateSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
    }

    public void AddPiece(Piece piece)
    {
        foreach (Transform child in transform)
        {
            if (child.childCount > 0)
            {
                if (piece.type == child.GetChild(0).GetComponent<Piece>().type)
                {
                    piece.Reset();
                    FindObjectOfType<Controller>().TakeLife();
                    break;
                }
            }
            else
            {
                types.Add(piece.type);

                piece.transform.SetParent(child.transform);
                piece.transform.position = child.position;

                FindObjectOfType<Spawner>().GrabPiece();

                var timer = FindObjectOfType<Spawner>();
                FindObjectOfType<Controller>().AddTime(1);
                break;
            }
        }
        if (types.Contains(1) && types.Contains(2) && types.Contains(3))
            Destroy(gameObject);
    }
}
