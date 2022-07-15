using System.Collections;
using UnityEngine;

public class CameraObject : MonoBehaviour, IStateMachine
{
    // TODO: поменять тут все
    [SerializeField] private float moveSpeed;
    
    private StateMachine statusMachine = new StateMachine();
    private Coroutine coroutine;
    
    public StateMachine StateMachine => statusMachine;

    private void Start()
    {
        //Screen.SetResolution(1068, 488, false);
    }

    public void LerpMove(Vector3 targetPosition)
    {
        if (coroutine != null)
        {
            CoroutineManager.Stop(coroutine);
            coroutine = null;
        }
        coroutine = CoroutineManager.Start(LerpMoveCoroutine(targetPosition));
    }
    
    private IEnumerator LerpMoveCoroutine(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            if (gameObject)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
