using UnityEngine;

public class DeliveryPoint : MonoBehaviour
{
    public int index;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.TryDelivery(index);
        }
    }
}