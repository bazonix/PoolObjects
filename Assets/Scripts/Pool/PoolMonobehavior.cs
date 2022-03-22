using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolMonobehavior<T> where T : MonoBehaviour
{
    public T prefab { get; }
    public bool autoExpand { get; set; }
    public Transform contaniner { get; }
    public List<T> pool;

    public PoolMonobehavior(T prefab, int count)
    {
        this.prefab = prefab;
        this.contaniner = null;
        this.CreatePool(count);
    }

    public PoolMonobehavior(T prefab, int count, Transform contanier)
    {
        this.prefab = prefab;
        this.contaniner = contaniner;
        this.CreatePool(count);
    }

    private void CreatePool(int count)
    {
        this.pool = new List<T>();

        for (int i = 0; i < count; i++)
        {
            this.CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = GameObject.Instantiate(this.prefab, this.contaniner);
        createdObject.gameObject.SetActive(isActiveByDefault);
        this.pool.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var mono in pool)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {

        if (this.HasFreeElement(out var element))
            return element;

        if (this.autoExpand)
            return this.CreateObject(true);

        throw new Exception($"нет свободных элементов типа _  {typeof(T)}");
    }
}
