using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzySet : MonoBehaviour
{
    public float DOM { get; private set; }
    public string setName { get; private set; }
    public AnimationCurve membershipFunction { get; private set; }

    public FuzzySet(string name, AnimationCurve curve)
    {
        setName = name;
        membershipFunction = curve;
    }

    public float GetDOM(float value)
    {
        DOM = membershipFunction.Evaluate(value);
        return DOM; 
    }

    // Potential function to create fuzzy set curves via code parameters? 
    // void SetTriangle(float left, float peak, float right); 

    /* void Set(T linguisticVariable)
     * this.Set(
     */
    
}
