using UnityEngine;

public class Environment {
    public static Environment Current = new Environment("DEMO");
        
    public string Name;

    public Environment(string name) {
        Name = name;
    }
}