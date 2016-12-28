using EchoService.DataContracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EchoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class EchoCollection : IEchoCollection
    {
        public GetCollectionsResponse GetCollections()
        {
            string oradb = "Data Source=(DESCRIPTION="
                      + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL = TCP)(HOST=80.65.65.66)(PORT=1521)))"
                      + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME= etflab.db.lab.etf.unsa.ba)));"
                      + "User Id=nsi09;Password=wWx09!";
            OracleConnection conn = new OracleConnection(oradb);

            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from collection";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            GetCollectionsResponse response = new GetCollectionsResponse();
            List<Collection> collections = new List<Collection>();
            while (dr.HasRows && dr.Read())
            {
                int id = 0;
                bool isPrivate;
                Int32.TryParse(dr[0].ToString(), out id);
                bool.TryParse(dr[3].ToString(), out isPrivate);
                if (id == 0)
                {
                    response.ResponseType = ResponseType.Failed;
                    response.Message = "Could not get Collections or the list is empty";
                    return response;
                }
                
                Collection collection = new Collection
                {
                    ID = id,
                    Title = dr[1].ToString(),
                    Description = dr[2].ToString(),
                    IsPrivate = isPrivate//,
                  //  Items 
                };

                collections.Add(collection);
            }
            response.collections = collections;
            
            conn.Dispose();
            return response;
        }

        public AddCollectionResponse SaveCollection(AddCollectionRequest request)
        {
            if (request == null || request.Collection == null) {
                return new AddCollectionResponse
                {
                    Message = "Could not add collection",
                    ResponseType = ResponseType.Succeeded
                };
            }

             
           string oradb = "Data Source=(DESCRIPTION="
                          + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL = TCP)(HOST=80.65.65.66)(PORT=1521)))"
                          + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME= etflab.db.lab.etf.unsa.ba)));"
                          + "User Id=nsi09;Password=wWx09!";
                OracleConnection conn = new OracleConnection(oradb);

                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into collection (id, title, description, isprivate, createdby, datecreated, modifiedby, datemodified, isdeleted) values(collection_seq.NEXTVAL,'" + request.Collection.Title + "', '" + request.Collection.Description + "', '" + Convert.ToInt32(request.Collection.IsPrivate).ToString() + "', '1', sysdate, '1', sysdate, '0')";
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                GetCollectionsResponse response = new GetCollectionsResponse();
              
                while (dr.HasRows && dr.Read())
                {

                Console.WriteLine(dr[0]);
                   
                }

                conn.Dispose();
                conn.Close();
                return new AddCollectionResponse();
        }

           
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
