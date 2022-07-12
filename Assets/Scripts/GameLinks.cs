using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameLinks
{
    private static Dictionary<Type, object> links = new Dictionary<Type, object>();

    public static void AddLink<T>(T newLink)
    {
        if (links.ContainsKey(typeof(T)) == false)
        {
            links[typeof(T)] = newLink;
        }
        else
        {
            Debug.LogError($"You are trying to add a property {typeof(T)} which has already been added!");
        }
    }

    public static T GetLink<T>() where T : new()
    {
        if (links.ContainsKey(typeof(T)))
        {
            return (T)links[typeof(T)];
        }
        else
        {
            //Debug.LogError($"Could not find object by key {typeof(T)}!");
            return new T();
        }
    }
    
    public static void DeleteLink<T>()
    {
        if (links.ContainsKey(typeof(T)) == true)
        {
            links.Remove(typeof(T));
        }
        else
        {
            Debug.LogError($"You are trying to delete a property {typeof(T)} which hasn't been added!");
        }
    }

    public static void DeleteAll()
    {
        links.Clear();
    }
}