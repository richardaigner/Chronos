using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemXp : MonoBehaviour
{
    public int value = 1;

    public GameObject destroyEffectPrefeb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RemoveObject();
            collision.gameObject.GetComponent<PlayerLevel>().GetXp(value);
        }
    }

    private void RemoveObject()
    {
        GetComponent<Collider2D>().enabled = false;
        Instantiate(destroyEffectPrefeb, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
