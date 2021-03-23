using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace PlayerMK2
{
    public class knockBack : MonoBehaviour
    {
        [SerializeField] private float airTime;
        [SerializeField] private float blastDistance;
        [SerializeField] private AnimationCurve airMove1;
        [SerializeField] private AnimationCurve airMove2;
        [SerializeField] private AnimationCurve airMove3;
        private List<float> _times;
        private List<AnimationCurve> _curves;
        private Vector3 rotation;
        private Vector3 blastDirection;
        private Vector3 posAtBlast;
        private bool blasting;
        public bool blastingAway;
        private float timer;
        private float distanceFromExplotion;
        private Vector3 velocity = Vector3.one;
        private Vector3 lenghtSmoothDamp;
        private Vector3 landingLocation;
        private PlayerMK2 _playerMk2;
        private Vector3 closestBlock;
        private int IntAway;

        [SerializeField] float maxDistance;
        private bool collided;
        
        void Start()
        {
            _times = new List<float>() {1f, 5f / 6f, 4f / 6f};
            _curves = new List<AnimationCurve>() {airMove1, airMove2, airMove3};
            _playerMk2 = GetComponent<PlayerMK2>();

        }

        public void KnockBack(Transform exposition)
        {
            if (blasting) return;
            distanceFromExplotion = Vector3.Distance(transform.position, exposition.position);
            print("distance from explotion" + distanceFromExplotion);
            if (distanceFromExplotion > maxDistance) return;
            if (distanceFromExplotion > 2.9f) IntAway = 2;
            else if (distanceFromExplotion > 1.9f) IntAway = 1;
            else IntAway = 0;
            posAtBlast = transform.position;
            
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y),
                Mathf.Round(transform.position.z));
            rotation = transform.eulerAngles;
            transform.LookAt(exposition);
            blastDirection = Vector3.Normalize(transform.position + exposition.position);
            blasting = true;
            var expos = exposition.position;
            landingLocation = new Vector3(Mathf.Round(expos.x - transform.forward.x * blastDistance), Mathf.Round(expos.y - transform.forward.y * blastDistance), Mathf.Round(expos.z - transform.forward.z * blastDistance));
            print(landingLocation);
        }
        private void Update()
        {
            

            if (!_playerMk2._moving && blasting)
            {
                blastingAway = true;
                _playerMk2._moving = true;
                timer = 0;
                blasting = false;
            }

            closestBlock = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
            if (blastingAway)
            {
                collided = Physics.CapsuleCast(transform.position, transform.position, 0.6f, Vector3.one) && timer >= 0.25f;
                if(collided) print("I collided with circle cast");
                print(_playerMk2._moving);
                if(!collided) timer += Time.deltaTime * 6;
                lenghtSmoothDamp = Vector3.SmoothDamp(transform.position, new Vector3(landingLocation.x, transform.position.y, landingLocation.z), ref velocity, airTime * _times[IntAway]);
                var move = new Vector3(lenghtSmoothDamp.x, posAtBlast.y + _curves[IntAway].Evaluate(timer), lenghtSmoothDamp.z);
                transform.position = move;
            
            
                if (collided || closestBlock.x == landingLocation.x && closestBlock.z == landingLocation.z)
                {
                    print("i collided");
                    transform.LookAt(null);
                    transform.eulerAngles = _playerMk2.eularAgnleBeforeLookAt;
                    transform.position = landingLocation;
                    //_playerMk2._moving = false;
                    blastingAway = false;
                }
            }
        }
    }
}
