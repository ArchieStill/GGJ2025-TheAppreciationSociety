using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orders : MonoBehaviour
{
    public List<List<string>> _orders = new List<List<string>>();

    private void Start()
    {
        List<string> one = new List<string>();

        one.Add("Customer: You want my order?");
        one.Add("Customer: I see. So you want this information from me ?");
        one.Add("Customer: One could say you were... persuing me");
        one.Add("Customer: ...");
        one.Add("Customer: Alas");
        one.Add("Customer: Tapioca and Milk please");

        _orders.Add(one);


        List<string> two = new List<string>();

        two.Add("Customer: Hey can I get a caramel macchiato");
        two.Add("Customer: You dont sell that? Oh");
        two.Add("Customer: Jelly milk tea then");

        _orders.Add(two);


        List<string> three = new List<string>();

        three.Add("Customer: Can I get a strawberry boba with raspberry jelly");

        _orders.Add(three);
            
    }
}
