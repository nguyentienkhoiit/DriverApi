using AutoMapper;
using DriversApi.Configurations;
using DriversApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DriversApi.Services
{
    public class DriverService
    {
        private readonly IMongoCollection<Driver> _driverCollection;
        private readonly IMapper _mapper;

        public DriverService(IMapper mapper)
        {
            //Console.WriteLine("aaa: "+ Newtonsoft.Json.JsonConvert.SerializeObject(databaseSettings));
            var mongoClient = new MongoClient("mongodb://mongodb:aA%4012345678@localhost:27017");
            var mongoDb = mongoClient.GetDatabase("DriversApp");
            _driverCollection = mongoDb.GetCollection<Driver>("Drivers");
            _mapper = mapper;
        }

        public async Task<List<DriverDtoResponse>> GetAsync()
        {
            var drivers = await _driverCollection.Find(_ => true).ToListAsync();
            return _mapper.Map<List<DriverDtoResponse>>(drivers);
        }

        public async Task<DriverDtoResponse> GetAsync(string id)
        {
            var driver = await _driverCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<DriverDtoResponse>(driver);
        }

        public async Task<DriverDtoResponse> CreateAsync(DriverDtoRequest dtoRequest)
        {
            var driver = _mapper.Map<Driver>(dtoRequest);
            await _driverCollection.InsertOneAsync(driver);
            return _mapper.Map<DriverDtoResponse>(driver);
        }

        public async Task<DriverDtoResponse> UpdateAsync(string id, DriverDtoRequest dtoRequest)
        {
            var driver = _mapper.Map<Driver>(dtoRequest);
            await _driverCollection.ReplaceOneAsync(x => x.Id == driver.Id, driver);
            return _mapper.Map<DriverDtoResponse>(driver);
        }

        public async Task RemoveAsync(string id) => await _driverCollection.DeleteOneAsync(x => x.Id == id);
    }
}   
