using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public int id;
    private int score=0;
    public List<GameObject> collectedStar;
    public Transform Bag;
    // Start is called before the first frame update
    RockDragMove rockDragMove;
    void Start()
    {
        collectedStar = new List<GameObject>();
        rockDragMove = GetComponent<RockDragMove>();
        GameManager.instance.gameStart += Instance_gameStart;
        GameManager.instance.gameEnd += Instance_gameEnd;
        id = IDGenerator.instance.GetRockId();
    }

    private void Instance_gameEnd()
    {
        rockDragMove.enabled = false;
    }

    private void OnDestroy()
    {
        GameManager.instance.gameStart -= Instance_gameStart;
        GameManager.instance.gameEnd -= Instance_gameEnd;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject);
        if ( other.GetComponent<Star>() )
        {
            other.gameObject.SetActive(false);
            other.gameObject.transform.parent = Bag.transform;
            collectedStar.Add(other.gameObject);
        }
        score += 1;
        GameManager.instance.UpdateScore(score);

    }

    private void Instance_gameStart()
    {

        GameManager.instance.UpdateScore(score);
    }


}
