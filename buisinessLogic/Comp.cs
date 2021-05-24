using System;
using System.Collections.Generic;

namespace Composite_
{
    abstract class Component
    {
        public Component() { }
        public abstract string Operation();
        public virtual void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(Component component)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsComposite()
        {
            return true;
        }
    }

    class Leaf : Component
    {
        string _content;
        public Leaf(string content = "Empty")
        {
            this._content = content;
        }

        public override string Operation()
        {
            return _content;
        }

        public override bool IsComposite()
        {
            return false;
        }
    }

    class Composite : Component
    {
        protected List<Component> _children = new List<Component>();

        public override void Add(Component component)
        {
            this._children.Add(component);
        }

        public void Add(List<Component> component)
        {
            this._children.AddRange(component);
        }

        public override void Remove(Component component)
        {
            this._children.Remove(component);
        }

        public override string Operation()
        {
            int i = 0;
            string result = string.Empty;

            foreach (Component component in this._children)
            {
                result += component.Operation();
                if (i != this._children.Count - 1)
                {
                    result += "\n";
                }
                i++;
            }
            return result + "\n";
        }
    }

    class Client
    {
        public void GetContent(Component leaf)
        {
            Console.WriteLine($"RESULT:\n{leaf.Operation()}\n");
        }

        public void AddNewComponent(Component component1, Component component2)
        {
            if (component1.IsComposite())
            {
                component1.Add(component2);
            }

            //Console.WriteLine($"ADDED: {component2.Operation()}");
        }
    }
}