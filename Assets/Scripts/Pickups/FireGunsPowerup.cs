using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGunsPowerup : SpawnedPowerup
{
    public KartEntity owner;
    public override void Init(KartEntity spawner)
    {
        base.Init(spawner);
        owner = spawner;
        spawner.Controller.ActivateMachineGun();

        // Runner.Despawn(Object, true);
        // Destroy(gameObject);
    }


    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();

        //
        // We want to set this every frame because we dont want to accidentally enable this somewhere in code, because
        // that will mess up prediction somewhere.
        //
     
    }

    public override void Spawned()
    {
        base.Spawned();

        Runner.Despawn(Object, true);
    }

    public override void PredictedSpawnSpawned() { }
    public override void PredictedSpawnUpdate() { }
    public override void PredictedSpawnRender() { }
    public override void PredictedSpawnFailed() { }
    public override void PredictedSpawnSuccess() { }
}
