using UnityEngine;

public class Package : MonoBehaviour
{
    public int index;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.PickPackage(index, gameObject);
        }
    }
}