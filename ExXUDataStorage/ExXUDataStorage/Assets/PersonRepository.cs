using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExXUDataStorage.Models;
using SQLite;

namespace ExXUDataStorage
{
	public class PersonRepository
	{
		public string StatusMessage { get; set; }
        SQLiteAsyncConnection conn;

        public PersonRepository(string dbPath)
		{
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Person>().Wait();
		}

		public async Task AddNewPerson(string name)
		{
			try
			{
				//basic validation to ensure a name was entered
				if (string.IsNullOrEmpty(name))
					throw new Exception("Valid name required");

                var result = await conn.InsertAsync(new Person { Name = name });

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
            }
			catch (Exception ex)
			{
                StatusMessage = string.Format("{0} record(s) added [Name: {1})", name, ex.Message);
            }

		}

		public async  Task<List<Person>> GetAllPeople()
		{
            return await conn.Table<Person>().ToListAsync();
		}
	}
}