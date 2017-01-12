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
            string oradb = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            OracleConnection conn = new OracleConnection(oradb);

            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select distinct * from collection";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            GetCollectionsResponse response = new GetCollectionsResponse();
            List<Collection> collections = new List<Collection>();
            while (dr.HasRows && dr.Read())
            {
                int id = 0;
                bool isPrivate;
                Int32.TryParse(dr[0].ToString(), out id);
                if (dr[3].ToString() == "0")
                    isPrivate = false;
                else
                    isPrivate = true;
              
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
                    IsPrivate = isPrivate,
                    Items = new List<Item>()                             //  Items 
                };

                collections.Add(collection);
            }
            conn.Close();
            OracleConnection conn2 = new OracleConnection(oradb);

            conn2.Open();
            cmd.Connection = conn2;

            cmd.CommandText = "select * from metadata";
            List<Metadata> metaList = new List<Metadata>();
            OracleDataReader drMetadata = cmd.ExecuteReader();
            while (drMetadata.HasRows && drMetadata.Read())
            {
                //(id, itemid, documenttypeid, author,abstract, publisher, language,url, rights,datepublished,extra)
                int id, itemId, documentTypeId;
                Int32.TryParse(drMetadata[0].ToString(), out id);
                Int32.TryParse(drMetadata[1].ToString(), out itemId);
                Int32.TryParse(drMetadata[2].ToString(), out documentTypeId);
                Metadata metaData = new Metadata()
                {
                    ID = id,
                    ItemId = itemId,
                    DocumentTypeId = documentTypeId,
                    Author = drMetadata[3].ToString(),
                    Abstract = drMetadata[4].ToString(),
                    Publisher = drMetadata[5].ToString(),
                    Language = drMetadata[6].ToString(),
                    Url = drMetadata[7].ToString(),
                    Rights = drMetadata[8].ToString(),
                    Date = Convert.ToDateTime(drMetadata[9]),
                    Extra = drMetadata[10].ToString()
                };
                metaList.Add(metaData);
            }

            cmd.CommandText = "select distinct * from item";

            OracleDataReader drItems = cmd.ExecuteReader();
            List<Item> items = new List<Item>();
            while (drItems.HasRows && drItems.Read())
            {
                int id, collectionId, documentTypeId;
                bool isPrivate;
                Int32.TryParse(drItems[0].ToString(), out id);
                Int32.TryParse(drItems[1].ToString(), out collectionId);
                Int32.TryParse(drItems[2].ToString(), out documentTypeId);
                bool.TryParse(drItems[3].ToString(), out isPrivate);
                Item item = new Item
                {
                    ID = id,
                    CollectionId = collectionId,
                    DocumentTypeId = documentTypeId,
                    IsPrivate = isPrivate,
                    Title = drItems[4].ToString(),
                    Metadata = metaList.FirstOrDefault(x => x.ItemId == id)
                };
                items.Add(item);
            }

            foreach (var collection in collections)
            {

                var itemsList = items.Where(x => x.CollectionId == collection.ID).ToList();
                if (itemsList.Count > 0)
                    collection.Items.AddRange(itemsList);
            }
            response.collections = collections;

            conn2.Dispose();
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

        public AddCollectionResponse UpdateCollection(AddCollectionRequest request)
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
            cmd.CommandText = "update collection set title = '" + request.Collection.Title + "', description = '" + request.Collection.Description + "', isprivate = '" + Convert.ToInt32(request.Collection.IsPrivate).ToString() + "' where id = " + request.Collection.ID ;
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

        public AddItemResponse AddItem(AddItemRequest request)
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
            var rd = cmd.ExecuteScalar();

            string query2 = "insert into item (id, collectionid, documenttypeid, isprivate, title, createdby, datecreated, modifiedby, datemodified, isdeleted) values('" + rd + "','" + request.Item.CollectionId + "','"
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

        public AddItemResponse UpdateItem(AddItemRequest request)
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
            
            string query = "update item set collectionid = '" + request.Item.CollectionId.ToString() + "',documenttypeid = " + request.Item.DocumentTypeId + ", isprivate='" +  Convert.ToInt32(request.Item.IsPrivate).ToString()
                        + "', title = '" + request.Item.Title + "', modifiedby ='1', datemodified = sysdate where id = " + request.Item.ID; 

            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            var id = cmd.ExecuteScalar();
            conn.Close();
            OracleConnection conn2 = new OracleConnection(oradb);
            conn2.Open();
            cmd.Connection = conn2;
            string query2 = "update metadata set  author = '" + request.Item.Metadata.Author + "', abstract = '"
                + request.Item.Metadata.Abstract + "', publisher = '" + request.Item.Metadata.Publisher + "', language = '" + request.Item.Metadata.Language + "', url = '" + request.Item.Metadata.Url
                + "', rights= '" + request.Item.Metadata.Rights + "',  extra= '" + request.Item.Metadata.Extra + "' where id = " + request.Item.Metadata.ID;
            
            cmd.CommandText = query2;

            OracleDataReader dr2 = cmd.ExecuteReader();
            conn2.Close();
            return new AddItemResponse
            {
                ResponseType = ResponseType.Succeeded
            };

        }

        public GetItemsResponse GetItems()
        {
            string oradb = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            OracleConnection conn = new OracleConnection(oradb);

            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from item";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            GetItemsResponse response = new GetItemsResponse();
            List<Item> items  = new List<Item>();

            //insert into item(id, collectionid, documenttypeid, isprivate,title,createdby,datecreated,modifiedby,datemodified,isdeleted)
            while (dr.HasRows && dr.Read())
            {
                int id = 0, collectionId, documentTypeId;
                bool isPrivate;
                Int32.TryParse(dr[0].ToString(), out id);
                Int32.TryParse(dr[1].ToString(), out collectionId);
                Int32.TryParse(dr[2].ToString(), out documentTypeId);
                bool.TryParse(dr[3].ToString(), out isPrivate);

                if (id == 0)
                {
                    response.ResponseType = ResponseType.Failed;
                    response.Message = "Could not get Items or the list is empty";
                    return response;
                }

                Item item = new Item
                {
                    ID = id,
                    CollectionId = collectionId,
                    DocumentTypeId = documentTypeId,
                    IsPrivate = isPrivate,
                    Title = dr[4].ToString(),
                };

                items.Add(item);
            }
            response.Items = items;
            conn.Dispose();
            return response;
        }

        public GetDocumentTypeResponse GetDocTypes()
        {
            string oradb = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            OracleConnection conn = new OracleConnection(oradb);

            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from documenttype";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            GetDocumentTypeResponse response = new GetDocumentTypeResponse();
            response.DocumentTypes = new List<DocumentType>();
            while(dr.HasRows && dr.Read())
            {
                int id;
                Int32.TryParse(dr[0].ToString(), out id);
                DocumentType docType = new DocumentType
                {
                    ID = id,
                    DocumentTypeTitle = dr[1].ToString()
                };

                response.DocumentTypes.Add(docType);
            }
            conn.Dispose();
            return response;
        }
    }
}
