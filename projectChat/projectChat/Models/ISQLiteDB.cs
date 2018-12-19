using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace projectChat.Models
{
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
