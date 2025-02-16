using System.Data;
using System.Windows;
using aps_project;
using Microsoft.Data.Sqlite;

namespace aps.src
{
    public class DatabaseService
    {
        private SqliteConnection sqlite;

        public DatabaseService()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var dbPath = System.IO.Path.Combine(appDataPath, "aps", "database.db");

            var directory = System.IO.Path.GetDirectoryName(dbPath);
            if (directory == null)
            {
                throw new Exception("Caminho do diretório inválido para o banco de dados.");
            }
            System.IO.Directory.CreateDirectory(directory);
            MessageBox.Show($"Database path: {dbPath}");

            sqlite = new SqliteConnection($"Data Source={dbPath}");
            CreateTables();
        }

        private void CreateTables()
        {
            try
            {
                sqlite.Open();
                string sql = @"
                CREATE TABLE IF NOT EXISTS company (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT NOT NULL,
                    role TEXT NOT NULL,
                    phone_number TEXT NOT NULL,
                    email TEXT NOT NULL,
                    address TEXT NOT NULL,
                    cnpj INTEGER NOT NULL
                );

                CREATE TABLE IF NOT EXISTS employee (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT NOT NULL,
                    role_company TEXT NOT NULL,
                    phone_number TEXT NOT NULL,
                    email TEXT NOT NULL,
                    address TEXT NOT NULL,
                    cpf INTEGER NOT NULL,
                    wage INTEGER NOT NULL,
                    company_id INTEGER NOT NULL,
                    FOREIGN KEY (company_id) REFERENCES company(id)
                );

                CREATE TABLE IF NOT EXISTS transactions (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    description TEXT NOT NULL,
                    value INTEGER NOT NULL,
                    date DATE NOT NULL,
                    status TEXT NOT NULL,
                    type TEXT NOT NULL,
                    company_id INTEGER NOT NULL,
                    FOREIGN KEY (company_id) REFERENCES company(id)
                );

                CREATE TABLE IF NOT EXISTS users (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    username TEXT NOT NULL,
                    hashed_password TEXT NOT NULL,
                    id_employee INTEGER NOT NULL,
                    FOREIGN KEY (id_employee) REFERENCES employee(id)
                );";

                using (SqliteCommand command = new SqliteCommand(sql, sqlite))
                {
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Tables created");
            }
            catch (SqliteException e)
            {
                Console.WriteLine($"sqlite expection: {e.Message}");
            }
            finally
            {
                sqlite.Close();
            }
        }
        public int AddCompany(Company company)
        {
            try
            {
                // Abre a conexão com o banco de dados
                sqlite.Open();

                // SQL para inserir os dados da empresa
                string sql = @"
                INSERT INTO company (name, role, phone_number, email, address, cnpj)
                VALUES (@name, @role, @phone_number, @email, @address, @cnpj);
                SELECT last_insert_rowid();";

                // Cria o comando e adiciona os parâmetros
                using (SqliteCommand command = new SqliteCommand(sql, sqlite))
                {
                    command.Parameters.AddWithValue("@name", company.Name);
                    command.Parameters.AddWithValue("@role", company.Role);
                    command.Parameters.AddWithValue("@phone_number", company.Phone);
                    command.Parameters.AddWithValue("@email", company.Email);
                    command.Parameters.AddWithValue("@address", company.Address);
                    command.Parameters.AddWithValue("@cnpj", company.Cnpj);

                    object? result = command.ExecuteScalar();
                    if (result == null)
                    {
                        throw new Exception("Valor nulo retornado na inserção da empresa.");
                    }
                    long newId = Convert.ToInt64(result);
                    company.Id = (int)newId; // Atribui o id gerado ao objeto
                    return company.Id;
                }
            }
            catch (SqliteException ex)
            {
                Console.WriteLine($"Erro ao inserir empresa: {ex.Message}");
                return -1;
            }
            finally
            {
                sqlite.Close();
            }
        }
        public int AddEmployee(Employee employee)
        {
            try
            {
                sqlite.Open();
                // SQL command that inserts a new employee and returns the generated id.
                string sql = @"
                INSERT INTO employee (name, role_company, phone_number, email, address, cpf, wage, company_id)
                VALUES (@name, @role_company, @phone_number, @email, @address, @cpf, @wage, @company_id);
                SELECT last_insert_rowid();";

                using (SqliteCommand command = new SqliteCommand(sql, sqlite))
                {
                    command.Parameters.AddWithValue("@name", employee.Name);
                    command.Parameters.AddWithValue("@role_company", employee.Role);
                    command.Parameters.AddWithValue("@phone_number", employee.Phone);
                    command.Parameters.AddWithValue("@email", employee.Email);
                    command.Parameters.AddWithValue("@address", employee.Address);
                    command.Parameters.AddWithValue("@cpf", employee.Cpf);
                    command.Parameters.AddWithValue("@wage", employee.Wage);
                    command.Parameters.AddWithValue("@company_id", employee.CompanyId);

                    // Execute the command and retrieve the last inserted row id.
                    object? result = command.ExecuteScalar();
                    if (result == null)
                    {
                        throw new Exception("Valor nulo retornado na inserção da empresa.");
                    }
                    long newId = Convert.ToInt64(result);
                    employee.Id = (int)newId; // Assign the generated id to the employee object.
                    return employee.Id;
                }
            }
            catch (SqliteException ex)
            {
                Console.WriteLine($"Erro ao inserir funcionário: {ex.Message}");
                return -1;
            }
            finally
            {
                sqlite.Close();
            }
        }
        public void addUser(string username, string hashedPassword, int employeeId)
        {
            // Modified to use parameters
            using (var cmd = new SqliteCommand(
                "INSERT INTO users (username, hashed_password, id_employee) VALUES (@username, @password, @id_employee)",
                sqlite))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@id_employee", employeeId);
                ExecuteNonQuery(cmd);
            }
        }

        public int CheckUser(string username, string password)
        {
            try
            {
                sqlite.Open();
                // This query joins the 'users' and 'employee' tables
                // and selects the company_id for a matching username and password.
                string sql = @"
                SELECT e.company_id 
                FROM users u 
                INNER JOIN employee e ON u.id_employee = e.id
                WHERE u.username = @username AND u.hashed_password = @password;";

                using (SqliteCommand command = new SqliteCommand(sql, sqlite))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    object? result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        // User not found or invalid credentials
                        return -1;
                    }
                }
            }
            catch (SqliteException ex)
            {
                Console.WriteLine("Erro ao verificar usuário: " + ex.Message);
                return -1;
            }
            finally
            {
                sqlite.Close();
            }
        }

        public Company? GetCompany(int companyId)
        {
            Company? company = null;
            try
            {
                sqlite.Open();
                string sql = "SELECT id, name, role, phone_number, email, address, cnpj FROM company WHERE id = @id;";
                using (SqliteCommand command = new SqliteCommand(sql, sqlite))
                {
                    command.Parameters.AddWithValue("@id", companyId);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve values from the database.
                            int id = Convert.ToInt32(reader["id"]);
                            string name = reader["name"].ToString()!;
                            string role = reader["role"].ToString()!;
                            string phone = reader["phone_number"].ToString()!;
                            string email = reader["email"].ToString()!;
                            string address = reader["address"].ToString()!;
                            string cnpj = reader["cnpj"].ToString()!;

                            // Create a new Company instance.
                            company = new Company(name, email, phone, address, role, cnpj);
                            company.Id = id; // Set the auto-generated id.
                        }
                    }
                }
            }
            catch (SqliteException ex)
            {
                Console.WriteLine("Erro ao buscar empresa: " + ex.Message);
            }
            finally
            {
                sqlite.Close();
            }
            return company;
        }

        public DataTable GetUsers()
        {
            DataTable dt = new DataTable(); // Initialize DataTable

            try
            {
                sqlite.Open();
                string sql = "SELECT * FROM users"; // Match table name case (users vs Users)

                using (SqliteCommand command = new SqliteCommand(sql, sqlite))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader); // Load data directly into DataTable
                    }
                }
                return dt;
            }
            catch (SqliteException ex)
            {
                Console.WriteLine("Error selecting users: " + ex.Message);
                return dt; // Return empty DataTable on error
            }
            finally
            {
                sqlite.Close();
            }
        }

        private void ExecuteNonQuery(SqliteCommand command)
        {
            try
            {
                sqlite.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                sqlite.Close();
            }
        }
    }
}
