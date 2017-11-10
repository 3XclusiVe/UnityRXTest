using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Inputs _inputs;
    [SerializeField]
    private CharacterController _character;
    [SerializeField]
    private float _walkSpeed;

    private void Awake()
    {
        var log = this.LateUpdateAsObservable()
            .Subscribe(_ =>
                {

                }
            );

    }

    private void Start()
    {
        _inputs.Movement
            .Where(v => v != Vector2.zero)
            .Subscribe(inputMovement =>
                {
                    var inputVelocity =
                        inputMovement * _walkSpeed;

                    var playerVelocity =
                        inputVelocity.x * transform.right +
                        inputVelocity.y * transform.forward;

                    var distance =
                        playerVelocity *
                        Time.fixedDeltaTime;

                    _character.Move(distance);
                }
            );
    }
}
