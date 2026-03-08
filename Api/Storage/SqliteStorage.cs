using System.Text;
using Microsoft.Data.Sqlite;

public class SqliteStorage : IStorage
{
    string connectionString = "Data Source = contacts.db";

    public bool Add(Contact contact)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var commmand = connection.CreateCommand();
        string sql = new StringBuilder()
        .Append("INSERT INTO contacts(name, email) VALUES")
        .Append($"('{contact.Name}','{contact.Email}');").ToString();

        commmand.CommandText = sql;
        Console.WriteLine("sql >> " + sql);
        return commmand.ExecuteNonQuery() > 0;
    }

    public Contact GetContactById(int id)
    {
        throw new NotImplementedException();
    }

    public int GetContactMaxId()
    {
        throw new NotImplementedException();
    }

    public List<Contact> GetContacts()
    {
        var contact = new List<Contact>();

        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = "SELECT * FROM contacts";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            contact.Add(new Contact()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Email = reader.GetString(2)
            });
        }
        return contact;
    }

    public bool Remove(int id)
    {
        throw new NotImplementedException();
    }

    public bool UpdateContact(ContactDto contactDto, int id)
    {
        throw new NotImplementedException();
    }
}