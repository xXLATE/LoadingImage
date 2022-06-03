using System;
using System.Collections.Generic;
using System.Text;

namespace Photo.DB
{
    public interface ISqlite
    {
        string GetDatabasePath(string filename);
    }
}
