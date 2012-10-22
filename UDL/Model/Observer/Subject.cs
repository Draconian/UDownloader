using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDL.Model.Observer
{
    public abstract class Subject
    {
        private List<IObserver> _observers = new List<IObserver>(2);

        public IObserver[] Observers
        {
            get { return this._observers.ToArray(); }
        }

        public void Attach(IObserver aObserver)
        {
            this._observers.Add(aObserver);
        }

        public void Detach(IObserver aObserver)
        {
            this._observers.Remove(aObserver);
        }

        public void AddRange(IObserver[] aObservers)
        {
            this._observers.AddRange(aObservers);
        }

        protected void NotifyObservers(Subject aSubject)
        {
            foreach (IObserver o in this._observers)
            {
                o.NotifyObserver(aSubject);
            }
        }

    }
}
