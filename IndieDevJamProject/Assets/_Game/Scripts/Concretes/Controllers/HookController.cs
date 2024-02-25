using System;
using System.Collections;
using System.Numerics;
using SnaileyGame.Animations;
using SnaileyGame.Movements;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace SnaileyGame.Controllers
{
    public class HookController : MonoBehaviour
    {
        [SerializeField] private Transform hookPivot;
        [SerializeField] private HookEndPointController hookEndPivot;
        [SerializeField] private float maxScale = 3;
        [SerializeField] private float currentScale = 0;
        [SerializeField] private float hookScaleSpeed = 0;
        
        private BaseCharacterController _characterController;
        private PlayerAnimation _playerAnimation;
        private IFlip _flip;
        
        private bool _isHooking = false;

        private void Awake()
        {
            _characterController = GetComponentInParent<BaseCharacterController>();
            _playerAnimation = _characterController.GetComponent<PlayerAnimation>();
            _flip = new FlipWithTransform(_characterController);
        }

        void Update()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));
            AimToPosition(worldPosition);
            LeftClickScale();
        }

        void AimToPosition(Vector3 targetPosition)
        {
            Vector3 aimDir = (targetPosition - hookPivot.transform.position);
            float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;

            
            if (Input.mousePosition.x < Screen.width / 2)
            {
                if (Input.GetMouseButtonUp(0) && hookEndPivot.TileController == null)
                {
                    StartCoroutine(MovePlayerToOppositePosition(1));
                }
            }
            else
            {
                if (Input.GetMouseButtonUp(0) && hookEndPivot.TileController == null)
                {
                    StartCoroutine(MovePlayerToOppositePosition(-1));
                }
            }
            
            if ((angle >= 90f && angle <= 180f) || (angle >= -180f && angle <= -90f))
            {
                // _flip.Flip(-1, 0);
            }
            else
            {
                // _flip.Flip(1, 0);
            }

            hookPivot.transform.eulerAngles = Vector3.forward * angle;
        }

        private IEnumerator MovePlayerToOppositePosition(int side)
        {
             _characterController.transform.Translate((currentScale / 10) * side * Vector3.right * Time.deltaTime * 400f);
            // _characterController.transform.GetComponent<Rigidbody2D>().AddForce((currentScale / 10) * side * Vector3.right * Time.deltaTime * 5000f);
            
            yield return new WaitForSeconds(1.0F);
        }

        private void AdjustAngleFromHookDirection()
        {
            
        }

        private void LeftClickScale()
        {
            if (Input.GetMouseButton(0) && _characterController.OnGround)
            {
                currentScale += Time.deltaTime * hookScaleSpeed;

                if (currentScale >= maxScale)
                {
                    currentScale = maxScale;
                }
                
                _isHooking = true;

                Vector3 newScale = new Vector3(currentScale, 0.4f, 0.4f);
                hookPivot.transform.localScale = newScale;
            }

            PointReached();
            CantReachedPoint();
        }

        private void PointReached()
        {
            if(Input.GetMouseButtonUp(0) && _isHooking && hookEndPivot.TileController != null)
            {
                _characterController.transform.localPosition = hookEndPivot.transform.position;
                _playerAnimation.PlayShieldInAnimation();
                hookEndPivot.TileController = null;
                SetCurrentScaleToMinimum();
                Vector3 resetScale = new Vector3(0.4f, 0.4f, 0.4f);
                hookPivot.transform.localScale = resetScale;
                _isHooking = false;
            }
        }

        private void CantReachedPoint()
        {
            if(Input.GetMouseButtonUp(0) && _isHooking && hookEndPivot.TileController == null)
            {
                SetCurrentScaleToMinimum();
                _playerAnimation.PlayPlayerAirAnimation();
                Vector3 resetScale = new Vector3(0.4f, 0.4f, 0.4f);
                hookPivot.transform.localScale = resetScale;
            }
        }

        private void SetCurrentScaleToMinimum()
        {
            var minScale = 0.4f;
            currentScale = minScale;
        }
        
        private void FixedUpdate()
        {
            
        }
    }
}