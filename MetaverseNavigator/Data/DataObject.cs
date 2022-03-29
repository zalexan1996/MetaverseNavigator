using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace MetaverseNavigator.Data
{
    public class DataObject
    {
        public static List<DataObject> FromConnection(SqliteConnection connection, string cmd, Type castTo)
        {
            // Exist abruptly if the connection is invalid or if the command is empty.
            if (connection == null || String.IsNullOrEmpty(cmd))
            {
                return null;
            }


            
            using (var command = new SqliteCommand(cmd, connection))
            using(SqliteDataReader rdr = command.ExecuteReader())
            {

                List<DataObject> returnObjects = new List<DataObject>();
                while (rdr.Read())
                {
                    DataObject instance = (DataObject)Activator.CreateInstance(castTo);

                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        string fieldName = rdr.GetName(i);

                        var property = castTo.GetProperty(fieldName);

                        if (property != null)
                        {
                            property.SetValue(instance, rdr.GetValue(i));
                        }
                    }
                    returnObjects.Add(instance);
                    Console.WriteLine(instance.ToString());
                }

                return returnObjects;
            }
        }
    }
}
