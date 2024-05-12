using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public static class RandomUtils
{
    public static T SelectRandom<T>(List<T> elements)
    {
        System.Random rand = new();
        int randomIndex = rand.Next(0, elements.Count);
        return elements[randomIndex];
    }

    public static List<T> SelectNRandom<T>(List<T> elements, int count)
    {
        System.Random rand = new();
        return elements.OrderBy(x => rand.Next()).Take(count).ToList();
    }

    public static T WeightedSelectRandom<T>(List<WeightedElement<T>> weightedElements)
    {
        var totalWeight = weightedElements.Sum(x => x.Weight);
        double randomValue = new System.Random().NextDouble() * totalWeight;
        foreach (var weightedElement in weightedElements)
        {
            randomValue -= weightedElement.Weight;
            if (randomValue <= 0)
            {
                var element = weightedElement.Element;
                return element;
            }
        }
        // Should not reach this point if weights added up to 1
        return weightedElements[0].Element;
    }

    public static bool WeightedRandomBoolean(float trueProbability)
    {
        return new System.Random().NextDouble() < trueProbability;
    }
}

[Serializable]
public class WeightedElement<T>
{
    [field: SerializeField] public T Element { get; private set; }
    [field: SerializeField] public float Weight { get; private set; }

    public WeightedElement(T element, float weight)
    {
        Element = element;
        Weight = weight;
    }
}