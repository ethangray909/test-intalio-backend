using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models;


public class Department
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; set; }

    [BsonElement("name")]
    public string DepartmentName { get; set; } = null!;

    public int department_id { get; set; } = 0!;

    public int parent { get; set; } = 0;
}