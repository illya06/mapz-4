using System;

namespace Proxy
{
    public interface IResource
    {
        void Request();
    }

    class RealResource : IResource
    {
        string _content;

        public RealResource(string content = "Empty")
        {
            this._content = content;
        }

        public void Request()
        {
            Console.WriteLine($"\n\nData : {_content}\n");
        }
    }

    class Proxy : IResource
    {
        private RealResource _realResource;
        private int _accessLevel;

        public Proxy(RealResource realResource, int accessLevel)
        {
            this._realResource = realResource;
            this._accessLevel = accessLevel;
        }

        public void Request()
        {
            if (this.CheckAccess())
            {
                this._realResource.Request();
            }
            else
            {
                System.Console.WriteLine("[Access denied]");
            }
        }

        public bool CheckAccess()
        {
            if (_accessLevel > 0)
                return true;

            return false;
        }
    }

    public class UserRequest
    {
        public void ClientCode(IResource Resource)
        {
            Resource.Request();
        }
    }
}