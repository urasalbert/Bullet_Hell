using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPFragmentCollector : MonoBehaviour
{
    //Magnet skill 
    private GameObject player;
    public float moveSpeed = 7f;
    private List<GameObject> xpFragments = new List<GameObject>();


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void CollectXPFragments()
    {
        GameObject[] fragments = GameObject.FindGameObjectsWithTag("XPFragment");

        foreach (GameObject fragment in fragments)
        {
            xpFragments.Add(fragment);
        }
    }

    void Update()
    {
        for (int i = 0; i < xpFragments.Count; i++)
        {
            if (xpFragments[i] != null)//Null check
            {
                Vector3 direction = (player.transform.position - xpFragments[i].transform.position).normalized;

                xpFragments[i].transform.position += direction * moveSpeed * Time.deltaTime;//Move fragment to the player

                //Remove fragment from list when player gets it
                if (Vector3.Distance(player.transform.position, xpFragments[i].transform.position) < 0.1f)
                {
                    xpFragments.RemoveAt(i);//Remove fragment from list here
                    i--; //Remove index for list correction
                }
            }
        }
    }
}
