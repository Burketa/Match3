using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Piece : MonoBehaviour
{
    #region Public Variables

    public int type;
    #endregion

    #region Private Variables

    private bool enableDrag;
    private Holder holder;
    private Spawner spawner;

    #endregion

    #region Private Methods

    private void Start()
    {
        spawner = FindObjectOfType<Spawner>();
    }

    #endregion

    #region public Methods

    public void OnTriggerEnter2D(Collider2D collided)
    {
        if (collided.tag == "Holder")
        {
            spawner.enableDrag = false;
            holder = collided.GetComponent<Holder>();
            holder.AddPiece(this);
        }
    }

    public void Reset()
    {
        transform.position = Vector2.zero;
        spawner.enableDrag = false;
    }

    #endregion
}
