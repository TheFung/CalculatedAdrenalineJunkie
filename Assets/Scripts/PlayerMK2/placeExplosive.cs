using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerMK2
{
    public class placeExplosive : MonoBehaviour
    {
        public PlayerInput _input;
        private PlayerMK2 _player;
        public bool placing;
        private bool hasPlaced;
        private Vector3 posPreviusMove;
        [SerializeField] private GameObject explosive;
        [SerializeField] private GameObject wire;
        [SerializeField] private GameObject presurePlate;
        private bool firstPlace = true;

        private void Awake()
        {
            _input = GetComponent<PlayerInput>();
            _player = GetComponent<PlayerMK2>();
        }

        private void Update()
        {
            if (placing && !_player._moving) posPreviusMove = transform.position;
 
            
        }

        public void PlaceWhenMove()
        {
            if (placing && !hasPlaced && !_player._moving && firstPlace)
            {
                Instantiate(explosive, new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z)), new Quaternion(0,0,0,0));
                firstPlace = false;
            }
            if (placing && !hasPlaced && !_player._moving && !firstPlace)
            {
                
                //Instantiate(wire, new Vector3(Mathf.Round(transform.position.x) , Mathf.Round(transform.position.y), Mathf.Round(transform.position.z)), transform.rotation);
                Instantiate(wire, (transform.position + transform.forward * -0.5f), transform.rotation, null);
            } 
            if (!firstPlace && !_player._moving && !placing) 
            { 
                Instantiate(presurePlate, new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y) - 0.5f, Mathf.Round(transform.position.z)), new Quaternion(0, 0, 0, 0));
                firstPlace = true;
            }
        }
        private void OnPlaceStart()
        {
            placing = true;
        }

        private void OnPlaceEnd()
        {
            placing = false;
            
        }
    }
}
