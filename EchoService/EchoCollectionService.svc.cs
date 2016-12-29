using EchoService.DataContracts;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            if (request == null || request.Collection == null)
            {
                return new AddCollectionResponse
                {
                    Message = "Could not add collection",
                    ResponseType = ResponseType.Succeeded
                };
            }

            string oradb = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into collection (id, title, description, isprivate, createdby, datecreated, modifiedby, datemodified, isdeleted) values(collection_seq.NEXTVAL,'" + request.Collection.Title + "', '" + request.Collection.Description + "', '" + Convert.ToInt32(request.Collection.IsPrivate).ToString() + "', '1', sysdate, '1', sysdate, '0')";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            GetCollectionsResponse response = new GetCollectionsResponse();
            conn.Dispose();
            conn.Close();
            return new AddCollectionResponse
            {
                ResponseType = ResponseType.Succeeded
            };
        }

        public AddItemResponse SaveItem(AddItemRequest request)
        {
            if (request == null || request.Item == null)
            {
                return new AddItemResponse
                {
                    Message = "Could not add item",
                    ResponseType = ResponseType.Succeeded
                };
            }

            string oradb = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            string query1 = "select item_seq.nextval from dual";
            cmd.CommandText = query1;
            var  rd = cmd.ExecuteScalar();
            
            
            string query2 = "insert into item (id, collectionid, documenttypeid, isprivate, title, createdby, datecreated, modifiedby, datemodified, isdeleted) values('"+ rd + "','19','"
                + request.Item.DocumentTypeId.ToString() + "','" + Convert.ToInt32(request.Item.IsPrivate).ToString()
                + "','" + request.Item.Title + "','1', sysdate, '1', sysdate, '0')";
            cmd.CommandText = query2;
            cmd.CommandType = CommandType.Text;
            var id = cmd.ExecuteScalar();
            conn.Close();
            OracleConnection conn2 = new OracleConnection(oradb);
            conn2.Open();
            cmd.Connection = conn2;
            string query3 = "insert into metadata (id, itemid, documenttypeid, author,abstract, publisher, language,url, rights,datepublished,extra) values(metadata_seq.NEXTVAL, '" + rd + "','" 
               + request.Item.DocumentTypeId.ToString() + "','" + request.Item.Metadata.Author + "','" + request.Item.Metadata.Abstract + "','" + request.Item.Metadata.Publisher + "','"
               + request.Item.Metadata.Language + "','" + request.Item.Metadata.Url + "','" + request.Item.Metadata.Rights + "', sysdate,'" + request.Item.Metadata.Extra + "')";
            cmd.CommandText = query3;
          
            OracleDataReader dr2 = cmd.ExecuteReader();
            conn2.Close();
            return new AddItemResponse
            {
                ResponseType = ResponseType.Succeeded
            };
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
