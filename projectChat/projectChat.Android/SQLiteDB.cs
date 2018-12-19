using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using projectChat.Models;
using SQLite;
using Xamarin.Forms;

//IMPORTAR xamarin forms y projectchat nombre del namespace
[assembly: Dependency(typeof(projectChat.Droid.SQLiteDB))]

namespace projectChat.Droid
{
    class SQLiteDB : ISQLiteDB
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            //importar IO
            var path = Path.Combine(documentPath, "Mysqlite.db");
            return new SQLiteAsyncConnection(path);
        }
    }
}