
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

namespace LP.SpawnMenNewInput
{
    public class SpawnMen : MonoBehaviour
               
    {
        
        List<GameObject> prefabList = new List<GameObject>();
        [SerializeField] GameObject Prefab1 = null;
        [SerializeField] GameObject Prefab2 = null;
        [SerializeField] GameObject Prefab3 = null;
        [SerializeField] GameObject Prefab4 = null;
        [SerializeField] GameObject Prefab5 = null;
        public GameObject player;

        private Camera cam = null;
        public InputAction button;
        private void Start()
        {
            cam = Camera.main;

        }

        private void Update()
        {
            prefabList.Add(Prefab1);
            prefabList.Add(Prefab2);
            prefabList.Add(Prefab3);
            prefabList.Add(Prefab4);
            prefabList.Add(Prefab5);

            button.Enable();
            SpawnAtMousePos();
        }

        private void SpawnAtMousePos()
        {
            // Debug.Log(-button.ReadValue<float>() * .05f); || Mouse.current.leftButton.wasPressedThisFrame
            if (button.WasPerformedThisFrame() )
            {

                Ray ray;

                if (Application.isEditor)
                    ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                else
                    ray = cam.ViewportPointToRay(new Vector2(0.5f, 0.5f));

                RaycastHit hit;

                int prefabIndex = UnityEngine.Random.Range(0, 5);

                if (Physics.Raycast(ray, out hit))
                {
                    var startPos = hit.point;
                    var startRot = Quaternion.Euler(0f, 180f, 0f);
                    GameObject obj = Instantiate(prefabList[prefabIndex], startPos, Quaternion.FromToRotation(transform.up, hit.normal));

                    obj.GetComponent<LookAtPlayer>().target = player.transform;
                    obj.GetComponent<ActiveInBack>().target = player.transform;
                }
            }
        }
    }
}

