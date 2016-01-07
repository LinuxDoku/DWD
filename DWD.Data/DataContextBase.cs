using System;
using LiteDB;

namespace DWD.Data {
    public abstract class DataContextBase : IDisposable {
        protected readonly LiteDatabase Database;

        public DataContextBase() {
            Database = new LiteDatabase(FileName);
        }

        protected abstract string FileName { get; }
        
        public void Dispose() {
            Database.Dispose();
        }
    }
}