using UnityEngine;

namespace CrawfisSoftware
{
    class FollowWithOffset : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;

        private void Awake()
        {
            GameplayEvents.CharacterChanged += GameplayEvents_CharacterChanged;
        }

        private void GameplayEvents_CharacterChanged(GameObject player)
        {
            this.target = player.transform;
        }

        private void Update()
        {
            transform.position = target.position + offset;
        }
    }
}