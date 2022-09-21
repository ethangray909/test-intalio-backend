using System;
using Backend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Backend.Services
{
    public class DepartmentService
    {
        private readonly IMongoCollection<Department> _departmentsCollection;

        public DepartmentService(IOptions<DepartmentDBSettings> departmentDBSettings)
        {
            var mongoClient = new MongoClient(
            departmentDBSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                departmentDBSettings.Value.DatabaseName);

            _departmentsCollection = mongoDatabase.GetCollection<Department>(
                departmentDBSettings.Value.DepartmentsCollectionName);
        }

        public async Task<List<Department>> GetAsync() =>
            await _departmentsCollection.Find(_ => true).ToListAsync();

        public async Task<List<Department>> SearchDepartmentAsync(string departmentName)
        {
            return await _departmentsCollection.Find(x => x.DepartmentName.Contains(departmentName)).ToListAsync();
        }

        public async Task<List<Department>> GetRootDepartmentsAsync( )
        {
            return await _departmentsCollection.Find(x => x.parent==0).ToListAsync();
        }


        public async Task<List<Department>> GetChildDepartmentsAsync(int parentId)
        {
            return await _departmentsCollection.Find(x => x.parent == parentId).ToListAsync();
        }




    }
}

