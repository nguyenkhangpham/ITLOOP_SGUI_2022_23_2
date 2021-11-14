using System;

namespace ITLOOP_HFT_2021221.Repository
{
    internal class demoCRUDEntities : IDisposable
    {
        public object Student { get; internal set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}