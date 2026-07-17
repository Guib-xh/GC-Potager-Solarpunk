using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct VegetableEntry
{
    public GameObject prefab;
    public VegetableRarity rarity;
}

public class Parcel : MonoBehaviour
{
    public List<VegetableEntry> vegetablesPool;
    
    public float vegetableSpawnOffset = 0.7f;
    
    public GameObject activeVegetable;
    public GameObject floatingTextPrefab;
    public AudioClip seedOnSound;
    public ParticleSystem smokeRef;
    
    
    Renderer _renderer;
    Color _originalColor;
    AudioSource _audioSource;


    void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _originalColor = _renderer.material.color;
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Seed"))
        {
            _audioSource.PlayOneShot(seedOnSound);
            Destroy(other.gameObject);
            if (activeVegetable == null)
            {
                smokeRef.Play();
                StartGrowth();
            }
        }
    }
    
    void StartGrowth()
    {
        Vector3 vegetablePosition = new Vector3(transform.position.x, transform.position.y + vegetableSpawnOffset, transform.position.z);
        VegetableEntry chosenVegetable = GetRandomVegetable();
        
        activeVegetable = Instantiate(chosenVegetable.prefab, vegetablePosition, Quaternion.identity);
        Vegetable vegetable = activeVegetable.GetComponent<Vegetable>();
        vegetable.parcel = this;
    }

    VegetableEntry GetRandomVegetable()
    {
        float totalWeight = vegetablesPool.Sum(v => v.rarity.Weight());
        float roll = Random.Range(0f, totalWeight);
        float cumulativeWeight = 0f;
        
        foreach (var vegetableEntry in vegetablesPool)
        {
            cumulativeWeight += vegetableEntry.rarity.Weight();
            if (roll <= cumulativeWeight)
            {
                return vegetableEntry;
            }
        }

        return vegetablesPool[^1];
    }

    public int Harvest()
    {
        if (activeVegetable == null) return 0;

        int point = 100;
        VegetableState vegetableState = activeVegetable.GetComponent<Vegetable>().state;
        if (vegetableState == VegetableState.Ripe)
        {
            point = point * 2;
        } else if (vegetableState == VegetableState.Rotten)
        {
            point = point / 2;
        }
        Destroy(activeVegetable);
        
        //AddFloatingPoint
        if (floatingTextPrefab != null) ShowFloatingText(point);
        
        return point;
    }

    void ShowFloatingText(int point)
    {
        GameObject ft = Instantiate(floatingTextPrefab, transform.position, floatingTextPrefab.transform.rotation);
        ft.GetComponent<TextMesh>().text = point.ToString();
    }

    public void EnableGlow()
    {
        Color glow = Color.Lerp(_originalColor, Color.yellow,  0.5f);
        _renderer.material.color = glow;
    }

    public void DisableGlow()
    {
        _renderer.material.color = _originalColor;
    }
}
