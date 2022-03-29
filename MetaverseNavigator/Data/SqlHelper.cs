using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.Sqlite;

namespace MetaverseNavigator.Data
{
    public static class SqlHelper
    {


        public static List<Confidant>GetConfidants(string Arcana = "", string Character = "")
        {

            string filter = "";

            if (!String.IsNullOrWhiteSpace(Arcana))
            {
                filter = $" WHERE Arcana = '{Arcana}'";
            }
            else if (!String.IsNullOrWhiteSpace(Character))
            {
                filter = $" WHERE Character = '{Character}'";
            }

            return DataObject.FromConnection(connection, $"Select * FROM Confidants{filter}", typeof(Confidant)).ConvertAll(x=>(Confidant)x).OrderBy(x => x.Arcana).ToList();
        }


        public static List<ConfidantBenefit> GetConfidantBenefits(string Confidant)
        {
            return DataObject.FromConnection(connection, $"Select * FROM ConfidantBenefits WHERE Confidant = '{Confidant}'", typeof(ConfidantBenefit)).ConvertAll(x => (ConfidantBenefit)x);
        }

        public static List<ConfidantRankResponse> GetConfidantRankResponses(string Confidant)
        {
            List<ConfidantRankResponse> responses = DataObject.FromConnection(connection, $"Select * FROM ConfidantRankResponses WHERE Confidant = '{Confidant}'", typeof(ConfidantRankResponse)).ConvertAll(x => (ConfidantRankResponse)x);

            for (int i = 0; i < responses.Count; i++)
            {
                responses[i].ResponseNumber = i + 1;
            }

            return responses;

        }



        public static SqliteConnection connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqliteConnection("Data Source=hello.db");
                    _connection.Open();
                }
                return _connection;
            }
        }
        private static SqliteConnection _connection = null;

    }
}
