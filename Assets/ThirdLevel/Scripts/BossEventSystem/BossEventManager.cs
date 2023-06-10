using UnityEngine;
using UnityEngine.Events;

public class BossEventManager : MonoBehaviour
{
    public UnityEvent bossEvent1;
    public UnityEvent bossEvent2;
    public UnityEvent bossEvent3;
    public UnityEvent krakenup;
    public UnityEvent krakenDown;
    public UnityEvent krakenEneySpawner;

    public void TriggerBossEvent1()
    {
        bossEvent1.Invoke();    
    }

    public void TriggerBossEvent2()
    {
        bossEvent2.Invoke();
    }

    public void TriggerBossEvent3()
    {
        bossEvent3.Invoke();
    }
    public void KrakenUpEvent()
    {
        krakenup.Invoke();
    }
    public void KrakenDownEvent()
    {
        krakenDown.Invoke();
    }
    public void KrakenEnemySpawnerEvent()
    {
        krakenEneySpawner.Invoke();
    }
}
