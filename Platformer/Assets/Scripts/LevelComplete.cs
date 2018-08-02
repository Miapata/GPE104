using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelComplete:MonoBehaviour  {
    public ParticleSystem ps;
    public GameObject canvas;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ps.Play();
            canvas.SetActive(true);
        }
    }

}
