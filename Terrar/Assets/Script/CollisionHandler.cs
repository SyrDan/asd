using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem CrushFX;
    [SerializeField] private float TimeReloadScene = 3f;
    private void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    void StartSequenceCrush()
    {
        GetComponent<MovementController>().enabled = false;
        GetComponent<MeshRenderer>().enabled= false;
        GetComponent<MeshCollider>().enabled= false;
        CrushFX.Play();
        Invoke(nameof(ReloadScene), TimeReloadScene);
        Debug.Log("Dead");
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
