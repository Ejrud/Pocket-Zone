using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTarget : MonoBehaviour
{
    private StorageOfVisibleObjects _storage;

    public void Init(StorageOfVisibleObjects storage)
    {
        _storage = storage;
    }

    private void OnDestroy()
    {
        if (_storage != null)
            _storage.DeleteItem(this);
    }
}
