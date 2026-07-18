using System;
using UnityEngine;

namespace Gameplay
{
    public class HoverArea : MonoBehaviour

    {
        private Parcel _parcel;

        private void Awake()
        {
            _parcel = GetComponentInParent<Parcel>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _parcel.EnableGlow();
                other.GetComponent<Player>().hoveredParcel = _parcel;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _parcel.DisableGlow();
                if (_parcel == other.GetComponent<Player>().hoveredParcel)
                {
                    other.GetComponent<Player>().hoveredParcel = null;
                }
            }
        }
    }
}