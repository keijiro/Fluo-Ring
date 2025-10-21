using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;
using Unity.Mathematics;
using Random = Unity.Mathematics.Random;

sealed public class RandomWalk : MonoBehaviour
{
    [SerializeField] UnityEvent<float> _target = null;
    [SerializeField] VisualEffect _targetVFX = null;
    [SerializeField] string _vfxProperty = "Throttle";
    [SerializeField] AnimationCurve _curve = AnimationCurve.Linear(0, 0, 1, 1);
    [SerializeField] float2 _duration = math.float2(1, 5);
    [SerializeField] UnityEvent _intervalEvent = null;
    [SerializeField] uint _seed = 1;

    void ApplyParameter(float value)
    {
        if (_target != null) _target.Invoke(value);
        if (_targetVFX != null) _targetVFX.SetFloat(_vfxProperty, value);
    }

    async void Start()
    {
        var rng = new Random(_seed++);
        rng.NextUInt4(); // Warm up

        while (true)
        {
            ApplyParameter(_curve.Evaluate(rng.NextFloat()));
            await Awaitable.WaitForSecondsAsync(rng.NextFloat(_duration.x, _duration.y));
            if (_intervalEvent != null) _intervalEvent.Invoke();
        }
    }
}
