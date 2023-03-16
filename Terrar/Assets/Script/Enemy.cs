using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject CrushVFX;
    private void OnParticleCollision(GameObject other)
    {
        GameObject boom = Instantiate(CrushVFX, transform.position, transform.rotation);
        boom.GetComponent<ParticleSystem>().Play();
        Destroy(boom, 2f);
        Destroy(gameObject);
    }
}
