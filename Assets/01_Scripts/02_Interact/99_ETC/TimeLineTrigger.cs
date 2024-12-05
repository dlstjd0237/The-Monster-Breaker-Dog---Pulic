using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;
public class TimeLineTrigger : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector _playableDirector;
    [SerializeField] private UnityEvent _timeLineStartEvent,_timeLineEndEvent;

    public void TimeLineStart()
    {
        _timeLineStartEvent?.Invoke();
        _playableDirector.Play();
    }

   public void TimeLineEnd()
    {
        _timeLineEndEvent?.Invoke();
        InputReader.Instance.OnFloorEnable();
    }
}
