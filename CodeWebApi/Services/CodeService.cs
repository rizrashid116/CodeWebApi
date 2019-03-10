using CodeWebApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWebApi.Services
{
    public class CodeService
    {
        private readonly IMongoCollection<Code> _spies;

        public CodeService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MessageCodeDB"));
            var database = client.GetDatabase("MessageCodeDB");
            _spies = database.GetCollection<Code>("Spies");
        }

        public List<Code> Get()
        {
            return _spies.Find(codeSpy => true).ToList();
        }

        public Code Get(string id)
        {
            return _spies.Find<Code>(codeSpy => codeSpy.Id == id).FirstOrDefault();
        }

        public Code Create(Code codeSpy)
        {
            _spies.InsertOne(codeSpy);
            return codeSpy;
        }

        public void Update(string id, Code codySpyIn)
        {
            _spies.ReplaceOne(codeSpy => codeSpy.Id == id, codySpyIn);
        }

        public void Remove(Code codySpyIn)
        {
            _spies.DeleteOne(codeSpy => codeSpy.Id == codySpyIn.Id);
        }

        public void Remove(string id)
        {
            _spies.DeleteOne(codeSpy => codeSpy.Id == id);
        }

        public Code FindCodeName(string spy)
        {
            Code Book = _spies.Find<Code>(codeSpy => codeSpy.Spy == spy).FirstOrDefault();
            return Book;
        }
    }
}