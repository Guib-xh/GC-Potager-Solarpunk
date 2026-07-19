using System.Collections;
using UnityEngine;

namespace Gameplay
{
    public enum VegetableState
    {
        Growing,
        Ripe,
        Rotten
    }

    public class Vegetable : MonoBehaviour
    {

        //Data
        public VegetableState state = VegetableState.Growing;
        public float growingDuration = 7f;
        public float ripeDuration = 4f;
        public float rottenDuration = 4f;

        private Animator _animator;

        public Parcel parcel;


        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();

        }

        void Start()
        {
            StartCoroutine(GrowthCycle());
        }

        IEnumerator GrowthCycle()
        {
            yield return new WaitForSeconds(growingDuration);

            SetState(VegetableState.Ripe);
            yield return new WaitForSeconds(ripeDuration);

            SetState(VegetableState.Rotten);
            yield return new WaitForSeconds(rottenDuration);

            parcel.activeVegetableEntry.vegetableGameObject = null;
            Destroy(gameObject);
        }

        void SetState(VegetableState newState)
        {
            if (state == newState) return;
            state = newState;

            switch (newState)
            {
                case VegetableState.Growing:
                    _animator.SetTrigger("Grow");
                    break;
                case VegetableState.Ripe:
                    _animator.SetTrigger("Pulse");
                    break;
                case VegetableState.Rotten:
                    _animator.SetTrigger("Wilt");
                    break;
            }
        }
    }
}