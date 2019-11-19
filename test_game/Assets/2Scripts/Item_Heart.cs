using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Heart : MonoBehaviour {

    private GameObject player;
    private GameObject self;

    private bool isActive = false;

    void Start () {
        self = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

    }

    void IsTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player" && isActive == false)
        {
            player = coll.gameObject;
            StartCoroutine(Effect());
            isActive = true;

            self.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    public IEnumerator Effect()
    {
        player.transform.localScale = new Vector3(2, 2, 2);
        yield return new WaitForSecondsRealtime(3f);
        player.transform.localScale = new Vector3(1, 1, 1);
    }
}
