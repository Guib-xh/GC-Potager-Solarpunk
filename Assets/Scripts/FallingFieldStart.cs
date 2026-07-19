using LitMotion;
using LitMotion.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

public class FallingFieldStart : MonoBehaviour
{
    public float height = 20f;
    public float fallingTime = 0.5f;
    public float randomDelta = 1f;
    public Ease currentEase =  Ease.InOutBounce;
    private void Start()
    {
        Vector3 destination = transform.position;
        LMotion.Create(destination + Vector3.up * height, destination, fallingTime)
            .WithEase(currentEase)
            .WithDelay(Random.value * randomDelta)
            .BindToPosition(transform);
    }
}