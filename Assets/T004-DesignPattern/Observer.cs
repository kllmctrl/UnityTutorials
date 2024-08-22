using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    interface IObserver
    {
        void Update(string message);
    }

    class Subject
    {
        private ArrayList observers;

        public Subject()
        {
            observers = new ArrayList();
        }

        public void Register(IObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void Deregister(IObserver observer)
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }

        public void Notify(string message)
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(message);
            }
        }
    }
    
    // observer1
    class Observer1 : IObserver
    {
        public void Update(string message)
        {
            Debug.LogWarning("observer1: "+ message);
        }
    }
    
    // observer2
    class Observer2 : IObserver
    {
        public void Update(string message)
        {
            Debug.LogWarning("observer2: "+ message);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Subject mySubject = new Subject();
        IObserver myObserver1 = new Observer1();
        IObserver myObserver2 = new Observer2();
        
        //register observers
        mySubject.Register(myObserver1);
        mySubject.Register(myObserver2);
        
        mySubject.Notify("message 1");
    }
}
